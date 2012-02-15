// Derived from template~protected~nonlanding.aspx.cs~template

using AjaxControlToolkit;
using Class_biz_coned_offering_rosters;
using Class_biz_coned_offerings;
using Class_biz_counties;
using Class_biz_practitioners;
using Class_msg_protected;
using ConEdLink.WebReference_emsrs;
using kix;
using System;
using System.Collections;
using System.Configuration;
using System.Drawing;
using System.Web.UI.WebControls;

namespace ready_roster_detail
  {
  public struct p_type
    {
    public bool be_sort_order_ascending;
    public TClass_biz_coned_offering_rosters biz_coned_offering_rosters;
    public TClass_biz_coned_offerings biz_coned_offerings;
    public TClass_biz_counties biz_counties;
    public TClass_biz_practitioners biz_practitioners;
    public string coned_offering_id;
    public TClass_msg_protected.ready_roster_detail incoming;
    public string lcds_content_xml;
    public k.int_nonnegative num_attendees;
    public string sort_order;
    public k.decimal_nonnegative total_class_hours;
    }

  public partial class TWebForm_ready_roster_detail: ki_web_ui.page_class
    {
    private class ready_roster_detail_Static
      {
      public const int TCI_LAST_NAME = 0;
      public const int TCI_FIRST_NAME = 1;
      public const int TCI_MIDDLE_INITIAL = 2;
      public const int TCI_LEVEL = 3;
      public const int TCI_CERT_NUM = 4;
      public const int TCI_DOB = 5;
      public const int TCI_COUNTY = 6;
      public const int TCI_INSTRUCTOR_HOURS = 7;
      //
      internal const int TCI_LCDS_ID = 0;
      internal const int TCI_LCDS_HEADER = 1;
      internal const int TCI_LCDS_DOB = 2;
      internal const int TCI_LCDS_VALID = 3;
      internal const int TCI_LCDS_OLDCERT = 4;
      internal const int TCI_LCDS_LEVEL1 = 5;
      internal const int TCI_LCDS_REGION = 6;
      internal const int TCI_LCDS_COURSE = 7;
      internal const int TCI_LCDS_OUTOFSTATE = 8;
      internal const int TCI_LCDS_CLASS = 9;
      internal const int TCI_LCDS_HOURS = 10;
      internal const int TCI_LCDS_DATEFINAL = 11;
      internal const int TCI_LCDS_SSN = 12;
      internal const int TCI_LCDS_REMED = 13;
      internal const int TCI_LCDS_COUNTY = 14;
      internal const int TCI_LCDS_SEND = 15;
      internal const int TCI_LCDS_SPONSORID = 16;
      internal const int TCI_LCDS_DATETIMESTAMP = 17;
      internal const int TCI_LCDS_FORM_TYPE_ID = 18;
      }

    private p_type p;

    private void Bind()
      {
      p.num_attendees.val = 0;
      p.biz_coned_offering_rosters.BindBaseDataListByClassId(p.sort_order,p.be_sort_order_ascending,DataGrid_control,p.coned_offering_id);
      TableRow_none.Visible = (p.num_attendees.val == 0);
      DataGrid_control.Visible = (p.num_attendees.val > 0);
      p.biz_coned_offering_rosters.BindBaseDataListByClassId(p.sort_order,p.be_sort_order_ascending,DataGrid_lcds,p.coned_offering_id);
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      this.PreRender += this.TWebForm_ready_roster_detail_PreRender;
      }

    private void InjectPersistentClientSideScript()
      {
      //EstablishClientSideFunction(k.client_side_function_enumeral_type.EL);
      }

    private void TWebForm_ready_roster_detail_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    //==
    //
    // protected
    //
    //==

    protected void Button_go_back_Click(object sender, EventArgs e)
      {
      BackTrack();
      }

    protected void Button_mark_done_Click(object sender, EventArgs e)
      {
      p.biz_coned_offerings.Archive(p.incoming.summary);
      BackTrack();
      }

    protected void Button_submit_to_emsrs_Click(object sender, EventArgs e)
      {
      var response = new EMSREGWebServices().ProcessConed("<CONEDRAW>" + p.lcds_content_xml + "<Constraint><SecurityString>" + ConfigurationManager.AppSettings["strxml_security_string"] + "</SecurityString></Constraint></CONEDRAW>");
      if (response.Contains("Errors Found: 0"))
        {
        Alert
          (
          cause:k.alert_cause_type.NETWORK,
          state:k.alert_state_type.SUCCESS,
          key:"okfromemsrs",
          value:"EMSRS responded:" + k.NEW_LINE + k.NEW_LINE + response,
          be_using_scriptmanager:true
          );
        p.biz_coned_offerings.Archive(p.incoming.summary);
        Button_mark_done.Enabled = false;
        Button_submit_to_emsrs.Enabled = false;
        Button_go_back.Enabled = true;
        }
      else
        {
        k.SmtpMailSend
          (
          from:ConfigurationManager.AppSettings["sender_email_address"],
          to:ConfigurationManager.AppSettings["failsafe_recipient_email_address"],
          subject:"EMSRS coned cards submission response",
          message_string:"[response]" + k.NEW_LINE + response + k.NEW_LINE + k.NEW_LINE + "[p.lcds_content_xml]" + k.NEW_LINE + p.lcds_content_xml.Replace("</Table><Table>","</Table>" + k.NEW_LINE + "<Table>")
          );
        Alert
          (
          cause:k.alert_cause_type.NETWORK,
          state:k.alert_state_type.WARNING,
          key:"emsrsnotok",
          value:"EMSRS responded:" + k.NEW_LINE + k.NEW_LINE + response,
          be_using_scriptmanager:true);
        }
      }

    protected void DataGrid_control_ItemDataBound(object sender, DataGridItemEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem,ListItemType.Item,ListItemType.EditItem,ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        var instructor_hours_cell = e.Item.Cells[ready_roster_detail_Static.TCI_INSTRUCTOR_HOURS];
        if (instructor_hours_cell.Text == "none")
          {
          LabelizeAndSetTextForeColor(instructor_hours_cell,Color.LightGray);
          }
        //
        // This datagrid's viewstate is entirely disabled.
        //
        p.num_attendees.val++;
        }
      }

    protected void DataGrid_lcds_ItemDataBound(object sender, DataGridItemEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem,ListItemType.Item,ListItemType.EditItem,ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        e.Item.Cells[ready_roster_detail_Static.TCI_LCDS_OLDCERT].Attributes.Add("style","mso-number-format:\\@");
        e.Item.Cells[ready_roster_detail_Static.TCI_LCDS_REGION].Attributes.Add("style","mso-number-format:\\@");
        e.Item.Cells[ready_roster_detail_Static.TCI_LCDS_COURSE].Attributes.Add("style","mso-number-format:\\@");
        e.Item.Cells[ready_roster_detail_Static.TCI_LCDS_HOURS].Attributes.Add("style","mso-number-format:\\@");
        e.Item.Cells[ready_roster_detail_Static.TCI_LCDS_COUNTY].Attributes.Add("style","mso-number-format:\\@");
        //
        p.lcds_content_xml +=
          "<Table>"
        +   "<HEADER>" + e.Item.Cells[ready_roster_detail_Static.TCI_LCDS_HEADER].Text + "</HEADER>"
        +   "<DOB>" + e.Item.Cells[ready_roster_detail_Static.TCI_LCDS_DOB].Text + "</DOB>"
        +   "<VALID>" + e.Item.Cells[ready_roster_detail_Static.TCI_LCDS_VALID].Text + "</VALID>"
        +   "<OLDCERT>" + k.Safe(e.Item.Cells[ready_roster_detail_Static.TCI_LCDS_OLDCERT].Text,k.safe_hint_type.NUM) + "</OLDCERT>"
        +   "<LEVEL1>" + e.Item.Cells[ready_roster_detail_Static.TCI_LCDS_LEVEL1].Text + "</LEVEL1>"
        +   "<REGION>" + k.Safe(e.Item.Cells[ready_roster_detail_Static.TCI_LCDS_REGION].Text,k.safe_hint_type.NUM) + "</REGION>"
        +   "<COURSE>" + k.Safe(e.Item.Cells[ready_roster_detail_Static.TCI_LCDS_COURSE].Text,k.safe_hint_type.NUM) + "</COURSE>"
        +   "<CLASS>" + e.Item.Cells[ready_roster_detail_Static.TCI_LCDS_CLASS].Text + "</CLASS>"
        +   "<HOURS>" + k.Safe(e.Item.Cells[ready_roster_detail_Static.TCI_LCDS_HOURS].Text,k.safe_hint_type.NUM) + "</HOURS>"
        +   "<DATEFINAL>" + k.Safe(e.Item.Cells[ready_roster_detail_Static.TCI_LCDS_DATEFINAL].Text,k.safe_hint_type.DATE_TIME) + "</DATEFINAL>"
        +   "<SSN />"
        +   "<REMED>" + e.Item.Cells[ready_roster_detail_Static.TCI_LCDS_REMED].Text + "</REMED>"
        +   "<COUNTY>" + k.Safe(e.Item.Cells[ready_roster_detail_Static.TCI_LCDS_COUNTY].Text,k.safe_hint_type.NUM) + "</COUNTY>"
        +   "<SEND>" + e.Item.Cells[ready_roster_detail_Static.TCI_LCDS_SEND].Text + "</SEND>"
        + "</Table>";
        }
      }

    protected void DataGrid_control_SortCommand(object source, DataGridSortCommandEventArgs e)
      {
      if (e.SortExpression == p.sort_order)
        {
        p.be_sort_order_ascending = !p.be_sort_order_ascending;
        }
      else
        {
        p.sort_order = k.Safe(e.SortExpression, k.safe_hint_type.KI_SORT_EXPRESSION);
        p.be_sort_order_ascending = true;
        }
      Bind();
      }

    protected void LinkButton_gen_lcds_Click(object sender, EventArgs e)
      {
      ExportToExcel(Page,p.biz_coned_offerings.ClassNumberOf(p.incoming.summary).Insert(8,k.HYPHEN).Insert(2,k.HYPHEN),StringOfControl(DataGrid_lcds));
      }

    protected override void OnInit(EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      var nature_of_visit = NatureOfVisit(InstanceId() + ".p");
      if (nature_of_visit == nature_of_visit_type.VISIT_INITIAL)
        {
        //
        // Initialize p.~ objects here.
        //
        p.biz_coned_offering_rosters = new TClass_biz_coned_offering_rosters();
        p.biz_coned_offerings = new TClass_biz_coned_offerings();
        p.biz_counties = new TClass_biz_counties();
        p.biz_practitioners = new TClass_biz_practitioners();
        //
        p.be_sort_order_ascending = true;
        p.incoming = Message<TClass_msg_protected.ready_roster_detail>(folder_name:"protected",aspx_name:"ready_roster_detail");
        p.lcds_content_xml = k.EMPTY;
        p.num_attendees = new k.int_nonnegative();
        p.sort_order = "last_name%,first_name,middle_initial,certification_number,birth_date";
        //
        p.coned_offering_id = p.biz_coned_offerings.IdOf(p.incoming.summary);
        p.total_class_hours = p.biz_coned_offerings.TotalClassHoursOf(p.incoming.summary);
        }
      else if (nature_of_visit == nature_of_visit_type.VISIT_POSTBACK_STANDARD)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        }
//
//ToolkitScriptManager.GetCurrent(Page).EnablePartialRendering = false;
//
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!IsPostBack)
        {
        Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - ready_roster_detail";
        var max_spec_length = p.biz_practitioners.MaxSpecLength(Session["region_code"].ToString(),k.EMPTY);
        Literal_course_title.Text = p.biz_coned_offerings.CourseTitleOf(p.incoming.summary);
        var raw_class_number = p.biz_coned_offerings.ClassNumberOf(p.incoming.summary);
        Literal_class_number.Text = raw_class_number.Substring(0,2) + k.SPACE + raw_class_number.Substring(2,6) + k.SPACE + raw_class_number.Substring(8,6);
        Literal_location.Text = p.biz_coned_offerings.LocationOf(p.incoming.summary);
        Literal_start.Text = p.biz_coned_offerings.StartOf(p.incoming.summary);
        Literal_end.Text = p.biz_coned_offerings.EndOf(p.incoming.summary);
        Literal_total_class_hours.Text = p.total_class_hours.val.ToString();
        Literal_be_approved.Text = k.YesNoOf(p.biz_coned_offerings.BeApprovedOf(p.incoming.summary));
        Bind();
        }
      InjectPersistentClientSideScript();
      }

    } // end TWebForm_ready_roster_detail

  }
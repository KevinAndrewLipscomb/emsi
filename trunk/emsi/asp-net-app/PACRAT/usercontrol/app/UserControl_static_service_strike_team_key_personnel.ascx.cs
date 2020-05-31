using Class_biz_role_member_map;
using Class_biz_services;
using kix;
using System.Collections;
using System.Drawing;
using System.Web.UI.WebControls;

namespace UserControl_static_service_strike_team_key_personnel
  {

  public partial class TWebUserControl_static_service_strike_team_key_personnel: ki_web_ui.usercontrol_class
    {

    private class Static
      {
      public const int TCI_BE_CREDENTIALED = 0;
      public const int TCI_UNCREDENTIALED = 1;
      public const int TCI_LAST_NAME = 2;
      public const int TCI_FIRST_NAME = 3;
      public const int TCI_MIDDLE_INITIAL = 4;
      public const int TCI_LEVEL = 5;
      public const int TCI_CERT_NUM = 6;
      public const int TCI_DOB = 7;
      public const int TCI_ROLE_NAME = 8;
      public const int TCI_EMAIL_ADDRESS = 9;
      public const int TCI_STATUS_DESCRIPTION = 10;
      }

    private struct p_type
      {
      public bool be_for_email_transmission;
      public bool be_loaded;
      public bool be_noncurrent_practitioners_on_roster;
      public TClass_biz_role_member_map biz_role_member_map;
      public TClass_biz_services biz_services;
      public k.int_nonnegative num_assignees;
      public string service_id;
      public object service_summary;
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        Literal_service_name.Text = p.biz_services.NameOfSummary(p.service_summary);
        Literal_affiliate_num.Text = p.biz_services.AffiliateNumOf(p.service_summary);
        Literal_short_name.Text = p.biz_services.ShortNameOf(p.service_id);
        Bind();
        p.be_loaded = true;
        }
      }

    protected override void OnInit(System.EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      var instance_id = InstanceId();
      if (Session[instance_id + ".p"] != null)
        {
        p = (p_type)(Session[instance_id + ".p"]);
        p.be_loaded = IsPostBack;  // This test is sufficient if this control is being used statically on its page.
//        //
//        // If this control is being used dynamically under one or more parent binder(s), it must ascertain which instance it is, and whether or not that instance's parent binder
//        // had it loaded already.
//        //
//#warning Revise the binder-related instance_id to this control appropriately.
//        if (instance_id == "ASP.protected_overview_aspx.UserControl_member_binder_static_service_strike_team_roster")
//          {
//#warning Revise the ClientID path to this control appropriately.
//          p.be_loaded &= ((Session["UserControl_member_binder_PlaceHolder_content"] as string) == "UserControl_static_service_strike_team_key_personnel");
//          }
//      else if (instance_id == "ASP.~_aspx.UserControl_~_binder_static_service_strike_team_roster")
//        {
//        p.be_loaded &= ((Session["UserControl_~_binder_PlaceHolder_content"] as string) == "UserControl_static_service_strike_team_key_personnel");
//        }
        }
      else
        {
        p.be_loaded = false;
        //
        p.biz_role_member_map = new TClass_biz_role_member_map();
        p.biz_services = new TClass_biz_services();
        //
        p.be_for_email_transmission = false;
        p.be_noncurrent_practitioners_on_roster = false;
        p.num_assignees = new k.int_nonnegative();
        p.service_id = k.EMPTY;
        p.service_summary = null;
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebUserControl_static_service_strike_team_key_personnel_PreRender;
      }

    private void TWebUserControl_static_service_strike_team_key_personnel_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_static_service_strike_team_key_personnel Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void Bind()
      {
      p.be_noncurrent_practitioners_on_roster = false;
      p.num_assignees.val = 0;
      DataGrid_control.Columns[Static.TCI_DOB].Visible = !p.be_for_email_transmission;
      p.biz_role_member_map.BindBaseDataListByExplicitServiceId
        (
        sort_order:"last_name,first_name,middle_initial,certification_number",
        be_sort_order_ascending:true,
        target:DataGrid_control,
        service_id:p.biz_services.IdOf(p.service_summary)
        );
      TableRow_none.Visible = (p.num_assignees.val == 0);
      DataGrid_control.Visible = (p.num_assignees.val > 0);
      Label_noncurrent_practitioner_on_roster.Visible = p.be_noncurrent_practitioners_on_roster;
      }

    protected void DataGrid_control_ItemDataBound(object sender, DataGridItemEventArgs e)
      {
      System.Web.UI.WebControls.Image image;
      if (new ArrayList {ListItemType.AlternatingItem,ListItemType.Item,ListItemType.EditItem,ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        image = ((e.Item.Cells[Static.TCI_UNCREDENTIALED].FindControl(id:"Image_uncredentialed")) as System.Web.UI.WebControls.Image);
        if (e.Item.Cells[Static.TCI_BE_CREDENTIALED].Text == "Y")
          {
          image.Visible = false;
          }
        else
          {
          image.ImageUrl = k.ExpandAsperand(image.ImageUrl);
          image.ToolTip = "UNCREDENTIALED";
          }
        //
        var label_email_address = (e.Item.Cells[Static.TCI_EMAIL_ADDRESS].FindControl("Label_email_address") as Label);
        if (label_email_address.Text == "DESIRED")
          {
          label_email_address.ForeColor = Color.DarkOrange;
          }
        //
        if (!(new ArrayList {"Active","Probation","Suspended"}).Contains(e.Item.Cells[Static.TCI_STATUS_DESCRIPTION].Text))
          {
          e.Item.BackColor = Color.Gold;
          p.be_noncurrent_practitioners_on_roster = true;
          }
        //
        // Remove all cell controls from viewstate
        //
        foreach (TableCell cell in e.Item.Cells)
          {
          cell.EnableViewState = false;
          }
        //
        p.num_assignees.val++;
        }
      }

    internal void Set
      (
      object service_summary,
      bool be_for_email_transmission = false
      )
      {
      p.service_summary = service_summary;
      p.service_id = p.biz_services.IdOf(service_summary);
      p.be_for_email_transmission = be_for_email_transmission;
      }

    }

  }

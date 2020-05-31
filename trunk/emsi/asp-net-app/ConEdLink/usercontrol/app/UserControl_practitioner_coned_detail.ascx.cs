// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~datagrid~sortable.ascx.cs

using Class_biz_accounts;
using Class_biz_coned_offerings;
using Class_biz_practitioners;
using Class_biz_user;
using Class_msg_protected;
using kix;
using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl_practitioner_coned_detail
  {
  public partial class TWebUserControl_practitioner_coned_detail: ki_web_ui.usercontrol_class
    {

    private static class Static
      {
      public const int TCI_SELECT = 0;
      public const int TCI_ID = 1;
      public const int TCI_SELECT_FOR_COMPLETION_CERTIFICATE = 2;
      public const int TCI_CLASS_NUMBER = 3;
      public const int TCI_COURSE_TITLE = 4;
      public const int TCI_LOCATION = 5;
      public const int TCI_REGION = 6;
      public const int TCI_START = 7;
      public const int TCI_END = 8;
      public const int TCI_SPONSOR = 9;
      public const int TCI_MED_TRAUMA_HOURS = 10;
      public const int TCI_OTHER_HOURS = 11;
      public const int TCI_INSTRUCTOR_HOURS = 12;
      public const int TCI_ROSTER_ID = 13;
      }

    private struct p_type
      {
      public bool be_datagrid_empty;
      public bool be_interactive;
      public bool be_loaded;
      public bool be_sort_order_ascending;
      public bool be_user_coned_sponsor;
      public TClass_biz_accounts biz_accounts;
      public TClass_biz_coned_offerings biz_coned_offerings;
      public TClass_biz_practitioners biz_practitioners;
      public TClass_biz_user biz_user;
      public TClass_msg_protected.coned_offering_detail msg_protected_coned_offering_detail;
      public uint num_coned_offerings;
      public string practitioner_id;
      public string range;
      public ArrayList roster_id_arraylist;
      public string shielded_query_string_of_hashtable;
      public string sort_order;
      public string sponsor_id_filter;
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

    private void InjectPersistentClientSideScript()
      {
      // EstablishClientSideFunction(k.client_side_function_enumeral_type.EL);
      // EstablishClientSideFunction(k.client_side_function_enumeral_type.KGS_TO_LBS);
      // EstablishClientSideFunction(k.client_side_function_enumeral_type.LBS_TO_KGS);
      // EstablishClientSideFunction
      // (
      // 'RecalculateDependentValues()',
      // k.EMPTY
      // + 'El("' + TextBox_gain_or_loss_in_lbs.clientid + '").value ='
      // +  ' El("' + TextBox_gross_landed_weight_in_pounds.clientid + '").value - El("' + TextBox_gross_invoiced_weight_in_lbs.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_gain_or_loss_in_kgs.clientid + '").value ='
      // +  ' El("' + TextBox_gross_landed_weight_in_kgs.clientid + '").value - El("' + TextBox_gross_invoiced_weight_in_kgs.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_gain_or_loss_per_bale_in_lbs.clientid + '").value ='
      // +  ' El("' + TextBox_gain_or_loss_in_lbs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_gain_or_loss_per_bale_in_kgs.clientid + '").value ='
      // +  ' El("' + TextBox_gain_or_loss_in_kgs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value ='
      // +  ' El("' + TextBox_gain_or_loss_in_lbs.clientid + '").value - El("' + TextBox_franchise_in_lbs.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_actual_gain_or_loss_in_kgs.clientid + '").value ='
      // +  ' El("' + TextBox_gain_or_loss_in_kgs.clientid + '").value - El("' + TextBox_franchise_in_kgs.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_actual_gain_or_loss_per_bale_in_lbs.clientid + '").value ='
      // +  ' El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_actual_gain_or_loss_per_bale_in_kgs.clientid + '").value ='
      // +  ' El("' + TextBox_actual_gain_or_loss_in_kgs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_percent_gain_or_loss.clientid + '").value ='
      // +  ' Math.round(El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value/El("' + TextBox_net_invoiced_in_lbs.clientid + '").value*100*100)/100;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_monetary_gain_or_loss.clientid + '").value ='
      // +  ' El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value*El("' + TextBox_unit_price_in_cents_per_pound.clientid + '").value;'
      // );
      // //
      // TextBox_bales.attributes.Add('onkeyup','RecalculateDependentValues();');
      // TextBox_gross_landed_weight_in_pounds.attributes.Add
      // (
      // 'onkeyup',
      // 'El("' + TextBox_gross_landed_weight_in_kgs.clientid + '").value = LbsToKgs(El("' + TextBox_gross_landed_weight_in_pounds.clientid + '").value);'
      // + ' RecalculateDependentValues();'
      // );
      // TextBox_gross_landed_weight_in_kgs.attributes.Add
      // (
      // 'onkeyup',
      // 'El("' + TextBox_gross_landed_weight_in_pounds.clientid + '").value = KgsToLbs(El("' + TextBox_gross_landed_weight_in_kgs.clientid + '").value);'
      // + ' RecalculateDependentValues();'
      // );
      // TextBox_landed_or_ciq_tare.attributes.Add
      // (
      // 'onkeyup',
      // 'El("' + TextBox_landed_or_ciq_tare_in_kgs.clientid + '").value = LbsToKgs(El("' + TextBox_landed_or_ciq_tare.clientid + '").value);'
      // + ' RecalculateDependentValues();'
      // );
      // TextBox_landed_or_ciq_tare_in_kgs.attributes.Add
      // (
      // 'onkeyup',
      // 'El("' + TextBox_landed_or_ciq_tare.clientid + '").value = KgsToLbs(El("' + TextBox_landed_or_ciq_tare_in_kgs.clientid + '").value);'
      // + ' RecalculateDependentValues();'
      // );
      // TextBox_net_landed_in_pounds.attributes.Add
      // (
      // 'onkeyup',
      // 'El("' + TextBox_net_landed_in_kgs.clientid + '").value = LbsToKgs(El("' + TextBox_net_landed_in_pounds.clientid + '").value);'
      // + ' RecalculateDependentValues();'
      // );
      // TextBox_net_landed_in_kgs.attributes.Add
      // (
      // 'onkeyup',
      // 'El("' + TextBox_net_landed_in_pounds.clientid + '").value = KgsToLbs(El("' + TextBox_net_landed_in_kgs.clientid + '").value);'
      // + ' RecalculateDependentValues();'
      // );
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        if (!p.be_interactive)
          {
          DataGrid_control.AllowSorting = false;
          }
        var i = new k.subtype<int>(2012,DateTime.Today.Year);
        for (i.val = i.LAST; i.val > i.FIRST; i.val--)
          {
          DropDownList_range.Items.Add(item:(i.val - 1).ToString());
          }
        DropDownList_range.SelectedValue = p.range;
        Bind();
        p.be_loaded = true;
        }
      InjectPersistentClientSideScript();
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
        //
        // If this control is being used dynamically under one or more parent binder(s), it must ascertain which instance it is, and whether or not that instance's parent binder
        // had it loaded already.
        //
        if (instance_id == "ASP.protected_regional_staffer_overview_aspx.UserControl_regional_staffer_binder_practitioner_practitioner_coned_detail_control")
          {
          p.be_loaded &= ((Session["UserControl_regional_staffer_binder_PlaceHolder_content"] as string) == "UserControl_practitioner");
          }
        else if (instance_id == "ASP.protected_coned_sponsor_overview_aspx.UserControl_coned_sponsor_binder_control_practitioner_practitioner_coned_detail_control")
          {
          p.be_loaded &= ((Session["UserControl_coned_sponsor_binder_control_PlaceHolder_content"] as string) == "UserControl_practitioner");
          }
        }
      else
        {
        p.biz_accounts = new TClass_biz_accounts();
        p.biz_coned_offerings = new TClass_biz_coned_offerings();
        p.biz_practitioners = new TClass_biz_practitioners();
        p.biz_user = new TClass_biz_user();
        p.msg_protected_coned_offering_detail = new TClass_msg_protected.coned_offering_detail();
        //
        p.be_interactive = (Session["mode:report"] == null);
        p.be_loaded = false;
        p.be_sort_order_ascending = true;
        p.be_user_coned_sponsor = false;
        p.practitioner_id = k.EMPTY;
        p.range = "LastThreeYears";
        p.roster_id_arraylist = new ArrayList();
        p.shielded_query_string_of_hashtable = k.EMPTY;
        p.sort_order = "end%";
        p.sponsor_id_filter = "0";
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      DataGrid_control.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(DataGrid_control_ItemDataBound);
      DataGrid_control.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(DataGrid_control_SortCommand);
      DataGrid_control.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(DataGrid_control_ItemCommand);
      PreRender += TWebUserControl_practitioner_coned_detail_PreRender;
      }

    private void TWebUserControl_practitioner_coned_detail_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_practitioner_coned_detail Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void DataGrid_control_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        p.msg_protected_coned_offering_detail.summary = p.biz_coned_offerings.Summary(k.Safe(e.Item.Cells[Static.TCI_ID].Text,k.safe_hint_type.NUM));
        MessageDropCrumbAndTransferTo(p.msg_protected_coned_offering_detail,"protected","coned_offering_detail");
        }
      }

    private void DataGrid_control_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
      {
      LinkButton link_button;
      if (p.be_interactive)
        {
        if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
          {
          link_button = ((e.Item.Cells[Static.TCI_SELECT].Controls[0]) as LinkButton);
          link_button.Text = k.ExpandTildePath(link_button.Text);
          ScriptManager.GetCurrent(Page).RegisterPostBackControl(link_button);
          //
          e.Item.Cells[Static.TCI_CLASS_NUMBER].Text = p.biz_coned_offerings.StandardSafeRenditionOf(e.Item.Cells[Static.TCI_CLASS_NUMBER].Text);
          //
          // Remove all cell controls from viewstate except for the one at TCI_ID.
          //
          //foreach (TableCell cell in e.Item.Cells)
          //  {
          //  cell.EnableViewState = false;
          //  }
          //e.Item.Cells[UserControl_practitioner_coned_detail_Static.TCI_ID].EnableViewState = true;
          //
          p.num_coned_offerings++;
          }
        }
      else
        {
        e.Item.Cells[Static.TCI_SELECT].Visible = false;
        }
      }

    private void DataGrid_control_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
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
      DataGrid_control.EditItemIndex =  -1;
      Bind();
      }

    private void Bind()
      {
      DataGrid_control.Columns[Static.TCI_SELECT].Visible = !p.be_user_coned_sponsor;
      DataGrid_control.Columns[Static.TCI_SPONSOR].Visible = !p.be_user_coned_sponsor;
      p.biz_coned_offerings.BindBaseDataListPractitionerConedDetail
        (
        practitioner_id:p.practitioner_id,
        sort_order:p.sort_order,
        be_sort_order_ascending:p.be_sort_order_ascending,
        target:DataGrid_control,
        sponsor_id_filter:p.sponsor_id_filter,
        range:p.range
        );
      p.be_datagrid_empty = (p.num_coned_offerings == 0);
      TableRow_none.Visible = p.be_datagrid_empty;
      DataGrid_control.Visible = !p.be_datagrid_empty;
      TableRow_email_view_print.Visible = !p.be_datagrid_empty;
      Literal_num_classes.Text = p.num_coned_offerings.ToString();
      p.num_coned_offerings = 0;
      }

    internal void SetTarget
      (
      string practitioner_id,
      string user_sponsor_id_filter
      )
      {
      p.practitioner_id = practitioner_id;
      p.sponsor_id_filter = user_sponsor_id_filter;
      p.be_user_coned_sponsor = (user_sponsor_id_filter.Length > 0);
      Bind();
      }

    private void SetHyperlinkPrintCompletionDocumentation()
      {
      HyperLink_print_completion_documentation.NavigateUrl = k.EMPTY;
      p.roster_id_arraylist.Clear();
      for (var i = new k.subtype<int>(0,DataGrid_control.Items.Count); i.val < i.LAST; i.val++)
        {
        if ((DataGrid_control.Items[i.val].Cells[Static.TCI_SELECT].FindControl("CheckBox_selected") as CheckBox).Checked)
          {
          p.roster_id_arraylist.Add(k.Safe(DataGrid_control.Items[i.val].Cells[Static.TCI_ROSTER_ID].Text,k.safe_hint_type.NUM));
          }
        }
      if (p.roster_id_arraylist.Count > 0)
        {
        var hash_table = new Hashtable {["coned_offering_roster_ids"] = p.roster_id_arraylist};
        p.shielded_query_string_of_hashtable = ShieldedQueryStringOfHashtable(hash_table);
        HyperLink_print_completion_documentation.NavigateUrl = "~/protected/training_certificate_legacy.aspx?" + p.shielded_query_string_of_hashtable;
        }
      }

    protected void CheckBox_force_all_CheckedChanged(object sender, EventArgs e)
      {
      for (var i = new k.subtype<int>(0,DataGrid_control.Items.Count); i.val < i.LAST; i.val++)
        {
        (DataGrid_control.Items[i.val].Cells[Static.TCI_SELECT].FindControl("CheckBox_selected") as CheckBox).Checked = (sender as CheckBox).Checked;
        }
      SetHyperlinkPrintCompletionDocumentation();
      }

    protected void CheckBox_selected_CheckedChanged(object sender, EventArgs e)
      {
      SetHyperlinkPrintCompletionDocumentation();
      }

    protected void LinkButton_email_completion_documentation_Click(object sender, EventArgs e)
      {
      var practitioner_email_address = p.biz_practitioners.EmailAddressOfId(p.practitioner_id);
      if (practitioner_email_address.Length > 0)
        {
        if (p.roster_id_arraylist.Count > 0)
          {
          p.biz_practitioners.SendClassCompletionCertificateLegacy
            (
            working_directory:Server.MapPath("scratch"),
            shielded_query_string_of_hashtable:p.shielded_query_string_of_hashtable,
            sender_email_address:p.biz_accounts.EmailAddressByKindId(p.biz_user.Kind(),p.biz_user.IdNum()),
            target_email_address:practitioner_email_address
            );
          Alert(k.alert_cause_type.USER, k.alert_state_type.SUCCESS, "lcertssent", "Certificate(s) sent", true);
          }
        else
          {
          Alert(k.alert_cause_type.USER,k.alert_state_type.FAILURE,"nolcslctd","Certificate(s) *NOT* sent.  No classes are selected.",be_using_scriptmanager:true);
          }
        }
      else
        {
        Alert(k.alert_cause_type.APPDATA,k.alert_state_type.FAILURE,"notarget","Certificate(s) *NOT* sent.  No email address is known for this practitioner.",be_using_scriptmanager:true);
        }
      }

    protected void DropDownList_range_SelectedIndexChanged(object sender, EventArgs e)
      {
      p.range = k.Safe(DropDownList_range.SelectedValue,k.safe_hint_type.ALPHANUM);
      Bind();
      }

    } // end TWebUserControl_practitioner_coned_detail

  }
// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~datagrid~sortable.ascx.cs

using Class_biz_coned_offerings;
using Class_msg_protected;
using kix;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl_discarded_rosters
  {
  public partial class TWebUserControl_discarded_rosters: ki_web_ui.usercontrol_class
    {
    private static class Static
      {
      public const string DEFAULT_SORT_ORDER = "datetime_discarded desc, end desc";
      public const int TCI_SELECT = 0;
      public const int TCI_ID = 1;
      public const int TCI_CLASS_NUM = 2;
      public const int TCI_SPONSOR = 3;
      public const int TCI_COURSE_TITLE = 4;
      public const int TCI_LOCATION = 5;
      public const int TCI_START = 6;
      public const int TCI_END = 7;
      public const int TCI_STATUS = 8;
      public const int TCI_UNDISCARD = 9;
      }

    private struct p_type
      {
      public bool be_datagrid_empty;
      public bool be_interactive;
      public bool be_loaded;
      public bool be_sort_order_ascending;
      public TClass_biz_coned_offerings biz_coned_offerings;
      public string filter;
      public TClass_msg_protected.coned_offering_detail msg_protected_coned_offering_detail;
      //public TClass_msg_protected.discarded_roster_detail msg_protected_discarded_roster_detail;
      public uint num_coned_offerings;
      public string sort_order;
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
      if (Session[InstanceId() + ".p"] != null)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        p.be_loaded = IsPostBack && ((Session["UserControl_regional_staffer_binder_UserControl_roster_binder_PlaceHolder_content"] as string) == "UserControl_discarded_rosters");
        }
      else
        {
        p.biz_coned_offerings = new TClass_biz_coned_offerings();
        p.msg_protected_coned_offering_detail = new TClass_msg_protected.coned_offering_detail();
        //p.msg_protected_discarded_roster_detail = new TClass_msg_protected.discarded_roster_detail();
        //
        p.be_interactive = (Session["mode:report"] == null);
        p.be_loaded = false;
        p.be_sort_order_ascending = true;
        p.filter = "CurrentYear";
        p.sort_order = Static.DEFAULT_SORT_ORDER;
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
      PreRender += TWebUserControl_discarded_rosters_PreRender;
      }

    private void TWebUserControl_discarded_rosters_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_discarded_rosters Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void DataGrid_control_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem,ListItemType.Item,ListItemType.EditItem,ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        var summary = p.biz_coned_offerings.Summary(k.Safe(e.Item.Cells[Static.TCI_ID].Text,k.safe_hint_type.NUM));
        if (e.CommandName == "Select")
          {
          p.msg_protected_coned_offering_detail.summary = summary;
          MessageDropCrumbAndTransferTo(p.msg_protected_coned_offering_detail,"protected","coned_offering_detail");
          }
        else if (e.CommandName == "Undiscard")
          {
          p.biz_coned_offerings.ReturnToSponsor
            (
            summary:summary,
            num_attendees:new k.int_nonnegative(0),
            actor:Session["username"].ToString(),
            disapproval_reason:"You had discarded the class as 'CANCELED', 'RAN but NO CE was requested', or 'ALREADY SUBMITTED', but the regional staffer UNdiscarded it."
            );
          Bind();
          }
        }
      }

    private void DataGrid_control_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
      {
      LinkButton link_button;
      if (p.be_interactive)
        {
        if (new ArrayList {ListItemType.AlternatingItem,ListItemType.Item,ListItemType.EditItem,ListItemType.SelectedItem}.Contains(e.Item.ItemType))
          {
          link_button = ((e.Item.Cells[Static.TCI_SELECT].Controls[0]) as LinkButton);
          link_button.Text = k.ExpandTildePath(link_button.Text);
          ScriptManager.GetCurrent(Page).RegisterPostBackControl(link_button);
          //
          e.Item.Cells[Static.TCI_CLASS_NUM].Text = p.biz_coned_offerings.StandardSafeRenditionOf(e.Item.Cells[Static.TCI_CLASS_NUM].Text);
          //
          link_button = ((e.Item.Cells[Static.TCI_UNDISCARD].Controls[0]) as LinkButton);
          link_button.Text = k.ExpandTildePath(link_button.Text);
          ScriptManager.GetCurrent(Page).RegisterPostBackControl(link_button);
          RequireConfirmation
            (
            c:link_button,
            prompt:"Are you sure you want to UNdiscard class # " + e.Item.Cells[Static.TCI_CLASS_NUM].Text + ", '" + e.Item.Cells[Static.TCI_COURSE_TITLE].Text + "', marked " + e.Item.Cells[Static.TCI_STATUS].Text
            + " by sponsor " + e.Item.Cells[Static.TCI_SPONSOR].Text + ", held at " + e.Item.Cells[Static.TCI_LOCATION].Text + " from " + e.Item.Cells[Static.TCI_START].Text + " to " + e.Item.Cells[Static.TCI_END].Text + "?"
            );
          //
          // Remove all cell controls from viewstate except for the one at TCI_ID.
          //
          foreach (TableCell cell in e.Item.Cells)
            {
            cell.EnableViewState = false;
            }
          e.Item.Cells[Static.TCI_ID].EnableViewState = true;
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
      p.biz_coned_offerings.BindDiscardedRosters(Session["region_code"].ToString(),p.sort_order,p.be_sort_order_ascending,DataGrid_control,p.filter);
      p.be_datagrid_empty = (p.num_coned_offerings == 0);
      TableRow_none.Visible = p.be_datagrid_empty;
      DataGrid_control.Visible = !p.be_datagrid_empty;
      Literal_num_coned_offerings.Text = p.num_coned_offerings.ToString();
      p.num_coned_offerings = 0;
      }

    protected void Button_default_sort_Click(object sender, System.EventArgs e)
      {
      p.sort_order = Static.DEFAULT_SORT_ORDER;
      Bind();
      }

    protected void DropDownList_filter_SelectedIndexChanged(object sender, System.EventArgs e)
      {
      p.filter = k.Safe(DropDownList_filter.SelectedValue,k.safe_hint_type.ALPHA);
      Bind();
      }

    } // end TWebUserControl_discarded_rosters

  }
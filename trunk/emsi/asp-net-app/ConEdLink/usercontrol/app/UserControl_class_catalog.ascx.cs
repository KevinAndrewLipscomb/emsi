// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~datagrid~sortable.ascx.cs

using Class_biz_coned_offerings;
using Class_msg_protected;
using kix;
using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl_class_catalog
  {
  public static class UserControl_class_catalog_Static
    {
    public const int TCI_SELECT = 0;
    public const int TCI_ID = 1;
    public const int TCI_CLASS_NUM = 2;
    public const int TCI_COURSE_TITLE = 3;
    public const int TCI_LOCATION = 4;
    public const int TCI_START = 5;
    public const int TCI_END = 6;
    public const int TCI_ROSTER = 7;
    public const int TCI_SIZE = 8;
    public const int TCI_IN_PROCESS = 9;
    }

  public partial class TWebUserControl_class_catalog: ki_web_ui.usercontrol_class
    {
    private struct p_type
      {
      public bool be_datagrid_empty;
      public bool be_interactive;
      public bool be_loaded;
      public bool be_sort_order_ascending;
      public TClass_biz_coned_offerings biz_coned_offerings;
      public TClass_msg_protected.coned_offering_detail msg_protected_coned_offering_detail;
      public TClass_msg_protected.coned_offering_roster msg_protected_coned_offering_roster;
      public uint num_coned_offerings;
      public string range;
      public string sort_order;
      }

    private p_type p;

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
        for (var i = new k.subtype<int>(2012,DateTime.Today.Year + 1); i.val < i.LAST; i.val++)
          {
          DropDownList_range.Items.Insert(1,i.val.ToString());
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
      if (Session[InstanceId() + ".p"] != null)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        p.be_loaded = IsPostBack && ((Session["UserControl_coned_sponsor_binder_control_PlaceHolder_content"] as string) == "UserControl_class_catalog");
        }
      else
        {
        p.biz_coned_offerings = new TClass_biz_coned_offerings();
        p.msg_protected_coned_offering_detail = new TClass_msg_protected.coned_offering_detail();
        p.msg_protected_coned_offering_roster = new TClass_msg_protected.coned_offering_roster();
        //
        p.be_interactive = (Session["mode:report"] == null);
        p.be_loaded = false;
        p.be_sort_order_ascending = true;
        p.range = "InProcess";
        p.sort_order = "start%";
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      this.DataGrid_control.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid_control_ItemDataBound);
      this.DataGrid_control.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DataGrid_control_SortCommand);
      this.DataGrid_control.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid_control_ItemCommand);
      this.PreRender += this.TWebUserControl_class_catalog_PreRender;
      //this.Load += this.Page_Load;
      }

    private void TWebUserControl_class_catalog_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_class_catalog Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void DataGrid_control_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem,ListItemType.Item,ListItemType.EditItem,ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        var summary = p.biz_coned_offerings.Summary(k.Safe(e.Item.Cells[UserControl_class_catalog_Static.TCI_ID].Text,k.safe_hint_type.NUM));
        if (e.CommandName == "Select")
          {
          p.msg_protected_coned_offering_detail.summary = summary;
          MessageDropCrumbAndTransferTo(p.msg_protected_coned_offering_detail,"protected","coned_offering_detail");
          }
        else if (e.CommandName == "ManageRoster")
          {
          p.msg_protected_coned_offering_roster.summary = summary;
          MessageDropCrumbAndTransferTo(p.msg_protected_coned_offering_roster,"protected","coned_offering_roster");
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
          link_button = ((e.Item.Cells[UserControl_class_catalog_Static.TCI_SELECT].Controls[0]) as LinkButton);
          link_button.Text = k.ExpandTildePath(link_button.Text);
          ScriptManager.GetCurrent(Page).RegisterPostBackControl(link_button);
          //
          e.Item.Cells[UserControl_class_catalog_Static.TCI_CLASS_NUM].Text = p.biz_coned_offerings.StandardSafeRenditionOf(e.Item.Cells[UserControl_class_catalog_Static.TCI_CLASS_NUM].Text);
          //
          link_button = ((e.Item.Cells[UserControl_class_catalog_Static.TCI_ROSTER].Controls[0]) as LinkButton);
          link_button.Text = k.ExpandTildePath(link_button.Text);
          ScriptManager.GetCurrent(Page).RegisterPostBackControl(link_button);
          //
          // Remove all cell controls from viewstate except for the one at TCI_ID.
          //
          foreach (TableCell cell in e.Item.Cells)
            {
            cell.EnableViewState = false;
            }
          e.Item.Cells[UserControl_class_catalog_Static.TCI_ID].EnableViewState = true;
          //
          p.num_coned_offerings++;
          }
        }
      else
        {
        e.Item.Cells[UserControl_class_catalog_Static.TCI_SELECT].Visible = false;
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
      DataGrid_control.Columns[UserControl_class_catalog_Static.TCI_IN_PROCESS].Visible = (p.range != "InProcess");
      p.biz_coned_offerings.BindClassCatalog
        (
        region_code:Session["region_code"].ToString(),
        coned_sponsor_user_id:Session["coned_sponsor_user_id"].ToString(),
        be_limited_to_needing_coned_sponsor_finalization:(p.range == "InProcess"),
        start_year:(new ArrayList {"InProcess","All"}.Contains(p.range) ? k.EMPTY : p.range),
        sort_order:p.sort_order,
        be_sort_order_ascending:p.be_sort_order_ascending,
        target:DataGrid_control
        );
      p.be_datagrid_empty = (p.num_coned_offerings == 0);
      TableRow_none.Visible = p.be_datagrid_empty;
      DataGrid_control.Visible = !p.be_datagrid_empty;
      Literal_num_coned_offerings.Text = p.num_coned_offerings.ToString();
      p.num_coned_offerings = 0;
      }

    protected void DropDownList_range_SelectedIndexChanged(object sender, EventArgs e)
      {
      p.range = k.Safe(DropDownList_range.SelectedValue,k.safe_hint_type.ALPHANUM);
      Bind();
      }

    } // end TWebUserControl_class_catalog

  }
// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~datagrid~sortable.ascx.cs

using AjaxControlToolkit;
using Class_biz_regions;
using Class_msg_protected;
using kix;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections;
using UserControl_static_region_strike_team_key_personnel;

namespace UserControl_region_strike_team_officers_in_state
  {
  public partial class TWebUserControl_region_strike_team_officers_in_state: ki_web_ui.usercontrol_class
    {
    private static class Static
      {
      public const int TCI_CODE = 0;
      public const int TCI_CONTENT = 1;
      }

    private struct p_type
      {
      public bool be_datagrid_empty;
      public bool be_loaded;
      public TClass_biz_regions biz_regions;
      public uint num_regions;
      }

    private p_type p;

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
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
        //
        // If this control is being used dynamically under one or more parent binder(s), it must ascertain which instance it is, and whether or not that instance's parent binder
        // had it loaded already.
        //
//#warning Revise the binder-related instance_id to this control appropriately.
//        if (instance_id == "ASP.protected_overview_aspx.UserControl_member_binder_region_strike_team_officers_in_state")
//          {
//#warning Revise the ClientID path to this control appropriately.
//          p.be_loaded &= ((Session["UserControl_member_binder_PlaceHolder_content"] as string) == "UserControl_region_strike_team_officers_in_state");
//          }
//      else if (instance_id == "ASP.~_aspx.UserControl_~_binder_region_strike_team_officers_in_state")
//        {
//        p.be_loaded &= ((Session["UserControl_~_binder_PlaceHolder_content"] as string) == "UserControl_region_strike_team_officers_in_state");
//        }
        }
      else
        {
        p.biz_regions = new TClass_biz_regions();
        //
        p.be_loaded = false;
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      DataGrid_control.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(DataGrid_control_ItemDataBound);
      PreRender += TWebUserControl_region_strike_team_officers_in_state_PreRender;
      }

    private void TWebUserControl_region_strike_team_officers_in_state_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_region_strike_team_officers_in_state Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void DataGrid_control_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        p.num_regions++;
        }
      }

    private void Bind()
      {
      p.biz_regions.BindPacratManagementBaseDataList
        (
        sort_order:"name",
        be_sort_order_ascending:true,
        target:DataGrid_control,
        do_include_all_regions:false
        );
      for (var i = 0; i < p.num_regions; i++)
        {
        (DataGrid_control.Items[i].Cells[Static.TCI_CONTENT].FindControl("UserControl_static_region_strike_team_key_personnel_control") as TWebUserControl_static_region_strike_team_key_personnel).Set
          (region_summary:p.biz_regions.Summary(code:DataGrid_control.Items[i].Cells[Static.TCI_CODE].Text));
        }
      p.be_datagrid_empty = (p.num_regions == 0);
      TableRow_none.Visible = p.be_datagrid_empty;
      DataGrid_control.Visible = !p.be_datagrid_empty;
      Literal_num_regions.Text = p.num_regions.ToString();
      p.num_regions = 0;
      }

    } // end TWebUserControl_region_strike_team_officers_in_state

  }
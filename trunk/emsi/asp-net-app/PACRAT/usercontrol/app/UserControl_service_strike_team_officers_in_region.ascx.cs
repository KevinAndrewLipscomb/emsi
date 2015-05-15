// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~datagrid~sortable.ascx.cs

using AjaxControlToolkit;
using Class_biz_regions;
using Class_biz_services;
using Class_msg_protected;
using kix;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections;
using UserControl_static_service_strike_team_key_personnel;

namespace UserControl_service_strike_team_officers_in_region
  {
  public partial class TWebUserControl_service_strike_team_officers_in_region: ki_web_ui.usercontrol_class
    {
    private static class Static
      {
      public const int TCI_ID = 0;
      public const int TCI_CONTENT = 1;
      }

    private struct p_type
      {
      public bool be_datagrid_empty;
      public bool be_loaded;
      public TClass_biz_regions biz_regions;
      public TClass_biz_services biz_services;
      public uint num_services;
      public string region_code;
      }

    private p_type p;

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        Literal_region_name.Text = p.biz_regions.NameOf(p.biz_regions.Summary(code:p.region_code));
        //
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
//        if (instance_id == "ASP.protected_overview_aspx.UserControl_member_binder_service_strike_team_officers_in_region")
//          {
//#warning Revise the ClientID path to this control appropriately.
//          p.be_loaded &= ((Session["UserControl_member_binder_PlaceHolder_content"] as string) == "UserControl_service_strike_team_officers_in_region");
//          }
//      else if (instance_id == "ASP.~_aspx.UserControl_~_binder_service_strike_team_officers_in_region")
//        {
//        p.be_loaded &= ((Session["UserControl_~_binder_PlaceHolder_content"] as string) == "UserControl_service_strike_team_officers_in_region");
//        }
        }
      else
        {
        p.biz_regions = new TClass_biz_regions();
        p.biz_services = new TClass_biz_services();
        //
        p.be_loaded = false;
        p.region_code = k.EMPTY;
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      DataGrid_control.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(DataGrid_control_ItemDataBound);
      PreRender += TWebUserControl_service_strike_team_officers_in_region_PreRender;
      }

    private void TWebUserControl_service_strike_team_officers_in_region_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_service_strike_team_officers_in_region Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void DataGrid_control_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        //
        // Remove all cell controls from viewstate except for the one at TCI_ID.
        //
        foreach (TableCell cell in e.Item.Cells)
          {
          cell.EnableViewState = false;
          }
        //
        p.num_services++;
        }
      }

    private void Bind()
      {
      p.biz_services.BindPacratManagementBaseDataList
        (
        sort_order:"short_name",
        be_sort_order_ascending:true,
        target:DataGrid_control,
        region_code:p.region_code,
        do_include_all_services:false
        );
      for (var i = 0; i < p.num_services; i++)
        {
        (DataGrid_control.Items[i].Cells[Static.TCI_CONTENT].FindControl("UserControl_static_service_strike_team_key_personnel_control") as TWebUserControl_static_service_strike_team_key_personnel).Set
          (service_summary:p.biz_services.Summary(id:DataGrid_control.Items[i].Cells[Static.TCI_ID].Text));
        }
      p.be_datagrid_empty = (p.num_services == 0);
      TableRow_none.Visible = p.be_datagrid_empty;
      DataGrid_control.Visible = !p.be_datagrid_empty;
      Literal_num_services.Text = p.num_services.ToString();
      p.num_services = 0;
      }

    internal void Set(string region_emsrs_code)
      {
      p.region_code = p.biz_regions.CodeOfEmsrsCode(region_emsrs_code);
      Bind();
      }

    } // end TWebUserControl_service_strike_team_officers_in_region

  }
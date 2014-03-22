// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~datagrid~sortable.ascx.cs

using Class_biz_members;
using Class_biz_practitioners;
using Class_biz_strike_team_deployment_vehicles;
using Class_biz_strike_team_deployments;
using Class_biz_user;
using kix;
using System;
using System.Collections;
using System.Configuration;
using System.Web.UI.WebControls;

namespace UserControl_per_deployment_iap_vehicles
  {
  public partial class TWebUserControl_per_deployment_iap_vehicles: ki_web_ui.usercontrol_class
    {
    public static class UserControl_per_deployment_iap_vehicles_Static
      {
      public const int TCI_TACTICAL_NAME = 0;
      public const int TCI_TRANSPONDER_NAME = 1;
      public const int TCI_SERVICE = 2;
      public const int TCI_NAME = 3;
      public const int TCI_LVL = 4;
      public const int TCI_KIND = 5;
      public const int TCI_DECAL_NUM = 6;
      public const int TCI_TOW_CAP = 7;
      public const int TCI_FUEL = 8;
      public const int TCI_AWD = 9;
      }

    private struct p_type
      {
      public bool be_datagrid_empty;
      public TClass_biz_members biz_members;
      public TClass_biz_practitioners biz_practitioners;
      public TClass_biz_strike_team_deployment_vehicles biz_strike_team_deployment_vehicles;
      public TClass_biz_strike_team_deployments biz_strike_team_deployments;
      public TClass_biz_user biz_user;
      public string deployment_id;
      public string deployment_name;
      public uint num_vehicles;
      }

    private p_type p;

    protected void Page_Load(object sender, System.EventArgs e)
      {
      var mark = DateTime.Now;
      Literal_application_name.Text = ConfigurationManager.AppSettings["application_name"];
      Literal_ref_num.Text = mark.ToString("yyyy-MM-dd-HH-mm-ss-ff");
      var practitioner_summary = p.biz_practitioners.Summary(p.biz_members.IdOfUserId(p.biz_user.IdNum()));
      Literal_prepared_name.Text = k.EMPTY
      + p.biz_practitioners.LevelOf(practitioner_summary)
      + k.SPACE
      + p.biz_practitioners.FirstNameOf(practitioner_summary)
      + k.SPACE
      + p.biz_practitioners.LastNameOf(practitioner_summary)
      + k.SPACE
      + "(" + p.biz_practitioners.CertificationNumberOf(practitioner_summary) + ")";
      Literal_prepared_timestamp.Text = mark.ToString("yyyy-MM-dd HH:mm:ss.ff");
      }

    protected override void OnInit(System.EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      //
      p.biz_members = new TClass_biz_members();
      p.biz_practitioners = new TClass_biz_practitioners();
      p.biz_strike_team_deployment_vehicles = new TClass_biz_strike_team_deployment_vehicles();
      p.biz_strike_team_deployments = new TClass_biz_strike_team_deployments();
      p.biz_user = new TClass_biz_user();
      //
      p.deployment_id = k.EMPTY;
      p.deployment_name = k.EMPTY;
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      this.DataGrid_control.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid_control_ItemDataBound);
      this.PreRender += this.TWebUserControl_per_deployment_iap_vehicles_PreRender;
      //this.Load += this.Page_Load;
      }

    private void TWebUserControl_per_deployment_iap_vehicles_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_per_deployment_iap_vehicles Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void DataGrid_control_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        p.num_vehicles++;
        }
      }

    private void Bind()
      {
      p.biz_strike_team_deployment_vehicles.BindBaseDataList
        (
        sort_order:"tactical_name%,service,name",
        be_sort_order_ascending:true,
        target:DataGrid_control,
        deployment_id:p.deployment_id,
        do_include_all_eligible_vehicles:false,
        service_strike_team_management_footprint:k.EMPTY
        );
      p.be_datagrid_empty = (p.num_vehicles == 0);
      TableRow_none.Visible = p.be_datagrid_empty;
      DataGrid_control.Visible = !p.be_datagrid_empty;
      p.num_vehicles = 0;
      }

    internal void Set(string deployment_id)
      {
      p.deployment_id = deployment_id;
      p.deployment_name = p.biz_strike_team_deployments.NameOfId(p.deployment_id);
      Literal_deployment_name.Text = p.biz_strike_team_deployments.NameOfId(deployment_id);
      Bind();
      }

    } // end TWebUserControl_per_deployment_iap_vehicles

  }
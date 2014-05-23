// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~datagrid~sortable.ascx.cs

using Class_biz_members;
using Class_biz_patient_care_levels;
using Class_biz_practitioners;
using Class_biz_strike_team_deployment_assignments;
using Class_biz_strike_team_deployment_operational_periods;
using Class_biz_strike_team_deployments;
using Class_biz_user;
using kix;
using System;
using System.Collections;
using System.Configuration;
using System.Web.UI.WebControls;

namespace UserControl_per_op_period_iap
  {
  public partial class TWebUserControl_per_op_period_iap: ki_web_ui.usercontrol_class
    {
    public static class UserControl_per_op_period_iap_Static
      {
      public const int CI_VEHICLE = 0;
      public const int CI_VEHICLE_PATIENT_CARE_LEVEL_ID = 1;
      public const int CI_MAX_PRACTITIONER_LEVEL_PECKING_ORDER = 2;
      public const int CI_EFFECTIVE_PATIENT_CARE_LEVEL = 3;
      public const int CI_KIND = 4;
      public const int CI_LEADER = 5;
      public const int CI_PAR = 6;
      public const int CI_LEADER_PHONE_NUM= 7;
      }

    private struct p_type
      {
      public bool be_datagrid_empty;
      public TClass_biz_members biz_members;
      public TClass_biz_practitioners biz_practitioners;
      public TClass_biz_patient_care_levels biz_patient_care_levels;
      public TClass_biz_strike_team_deployment_assignments biz_strike_team_deployment_assignments;
      public TClass_biz_strike_team_deployment_operational_periods biz_strike_team_deployment_operational_periods;
      public TClass_biz_strike_team_deployments biz_strike_team_deployments;
      public TClass_biz_user biz_user;
      public k.int_nonnegative num_items;
      public string operational_period_id;
      }

    private p_type p;

    protected void Page_Load(object sender, System.EventArgs e)
      {
      }

    protected override void OnInit(System.EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      //
      p.biz_members = new TClass_biz_members();
      p.biz_patient_care_levels = new TClass_biz_patient_care_levels();
      p.biz_practitioners = new TClass_biz_practitioners();
      p.biz_strike_team_deployment_assignments = new TClass_biz_strike_team_deployment_assignments();
      p.biz_strike_team_deployment_operational_periods = new TClass_biz_strike_team_deployment_operational_periods();
      p.biz_strike_team_deployments = new TClass_biz_strike_team_deployments();
      p.biz_user = new TClass_biz_user();
      //
      p.num_items = new k.int_nonnegative();
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      this.DataGrid_control.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid_control_ItemDataBound);
      this.PreRender += this.TWebUserControl_per_op_period_iap_PreRender;
      //this.Load += this.Page_Load;
      }

    private void TWebUserControl_per_op_period_iap_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_per_op_period_iap Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void DataGrid_control_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        e.Item.Cells[UserControl_per_op_period_iap_Static.CI_EFFECTIVE_PATIENT_CARE_LEVEL].Text = p.biz_patient_care_levels.EffectiveOf
          (
          vehicle_patient_care_level_description:k.Safe(e.Item.Cells[UserControl_per_op_period_iap_Static.CI_VEHICLE_PATIENT_CARE_LEVEL_ID].Text,k.safe_hint_type.HYPHENATED_ALPHA),
          practitioner_level_short_description:k.Safe(e.Item.Cells[UserControl_per_op_period_iap_Static.CI_MAX_PRACTITIONER_LEVEL_PECKING_ORDER].Text,k.safe_hint_type.HYPHENATED_ALPHA)
          );
        //
        e.Item.Cells[UserControl_per_op_period_iap_Static.CI_LEADER_PHONE_NUM].Text = k.FormatAsNanpPhoneNum(e.Item.Cells[UserControl_per_op_period_iap_Static.CI_LEADER_PHONE_NUM].Text);
        //
        p.num_items.val++;
        }
      }

    private void Bind()
      {
      p.biz_strike_team_deployment_assignments.BindDigestByOperationalPeriod
        (
        sort_order:"vehicle_designator%",
        be_sort_order_ascending:true,
        target:DataGrid_control,
        operational_period_id:p.operational_period_id
        );
      p.be_datagrid_empty = (p.num_items.val == 0);
      TableRow_none.Visible = p.be_datagrid_empty;
      TableRow_control.Visible = !p.be_datagrid_empty;
      p.num_items.val = 0;
      }

    internal void Set(string operational_period_id)
      {
      p.operational_period_id = operational_period_id;
      //
      var be_convoy = false;
      var deployment_id = k.EMPTY;
      DateTime start;
      DateTime end;
      var prelim_shift_name = k.EMPTY;
      var kind = kind_enum.STANDARD;
      p.biz_strike_team_deployment_operational_periods.Get
        (
        id:operational_period_id,
        deployment_id:out deployment_id,
        start:out start,
        end:out end,
        be_convoy:out be_convoy,
        prelim_shift_name:out prelim_shift_name,
        kind:out kind
        );
      var mark = DateTime.Now;
      if (kind == kind_enum.PRELIM)
        {
        TableRow_prelim_1.Visible = true;
        TableRow_prelim_2.Visible = true;
        Literal_application_name.Text = ConfigurationManager.AppSettings["application_name"];
        Literal_nature.Text = "PRELIMINARY";
        Table_prelim.Visible = true;
        Literal_prelim_shift_name.Text = prelim_shift_name;
        }
      else
        {
        TableRow_nonprelim_1.Visible = true;
        TableRow_nonprelim_2.Visible = true;
        TableRow_nonprelim_3.Visible = true;
        Literal_application_name_2.Text = Literal_application_name.Text;
        Literal_ref_num.Text = mark.ToString("yyyy-MM-dd-HH-mm-ss-ff");
        Literal_nature.Text = (kind == kind_enum.CONVOY ? "CONVOY" : "OPERATIONAL PERIOD");
        Table_nonprelim.Visible = true;
        Literal_start.Text = start.ToString("MM/dd/yyyy HH:mm");
        Literal_end.Text = end.ToString("MM/dd/yyyy HH:mm");
        }
      Literal_deployment_name.Text = p.biz_strike_team_deployments.NameOfId(deployment_id);
      Bind();
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

    } // end TWebUserControl_per_op_period_iap

  }
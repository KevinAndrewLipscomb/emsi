// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~kicrudhelped~item.ascx.cs~template

using AjaxControlToolkit;
using Class_biz_members;
using Class_biz_privileges;
using Class_biz_role_member_map;
using Class_biz_strike_team_deployment_logs;
using Class_biz_strike_team_deployment_operational_periods;
using Class_biz_user;
using kix;
using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl_strike_team_deployment_operational_period
  {
  public partial class TWebUserControl_strike_team_deployment_operational_period: ki_web_ui.usercontrol_class
    {
    private struct p_type
      {
      public bool be_loaded;
      public bool be_ok_to_config_strike_team_deployment_operational_periods;
      public TClass_biz_strike_team_deployment_logs biz_strike_team_deployment_logs;
      public TClass_biz_strike_team_deployment_operational_periods biz_strike_team_deployment_operational_periods;
      public TClass_biz_members biz_members;
      public TClass_biz_privileges biz_privileges;
      public TClass_biz_role_member_map biz_role_member_map;
      public TClass_biz_user biz_user;
      public string deployment_id;
      public string operational_period_id;
      public presentation_mode_enum presentation_mode;
      public object summary;
      } // end p_type

    private p_type p;

    private void Clear()
      {
      TextBox_id.Text = k.EMPTY;
      DropDownList_id.Visible = false;
      TextBox_deployment_id.Text = k.EMPTY;
      DropDownList_kind.ClearSelection();
      ManageFormAccordingToKind();
      UserControl_drop_down_datetime_start.Clear();
      UserControl_drop_down_datetime_end.Clear();
      TextBox_prelim_shift_name.Text = k.EMPTY;
      TableRow_start.Visible = false;
      TableRow_end.Visible = false;
      TableRow_prelim_shift_name.Visible = false;
      Literal_match_index.Text = k.EMPTY;
      Literal_num_matches.Text = k.EMPTY;
      Panel_match_numbers.Visible = false;
      LinkButton_go_to_match_prior.Visible = false;
      LinkButton_go_to_match_next.Visible = false;
      LinkButton_go_to_match_last.Visible = false;
      LinkButton_go_to_match_first.Visible = false;
      SetDependentFieldAblements(false);
      Button_submit.Enabled = false;
      Button_delete.Enabled = false;
      }

    private void InjectPersistentClientSideScript()
      {
      // EstablishClientSideFunction(k.client_side_function_enumeral_type.EL);
      // EstablishClientSideFunction(k.client_side_function_enumeral_type.KGS_TO_LBS);
      // EstablishClientSideFunction(k.client_side_function_enumeral_type.LBS_TO_KGS);
      // EstablishClientSideFunction
      //   (
      //   'RecalculateDependentValues()',
      //   k.EMPTY
      //   + 'El("' + TextBox_gain_or_loss_in_lbs.clientid + '").value ='
      //   +  ' El("' + TextBox_gross_landed_weight_in_pounds.clientid + '").value - El("' + TextBox_gross_invoiced_weight_in_lbs.clientid + '").value;'
      //   + k.NEW_LINE
      //   + 'El("' + TextBox_gain_or_loss_in_kgs.clientid + '").value ='
      //   +  ' El("' + TextBox_gross_landed_weight_in_kgs.clientid + '").value - El("' + TextBox_gross_invoiced_weight_in_kgs.clientid + '").value;'
      //   + k.NEW_LINE
      //   + 'El("' + TextBox_gain_or_loss_per_bale_in_lbs.clientid + '").value ='
      //   +  ' El("' + TextBox_gain_or_loss_in_lbs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      //   + k.NEW_LINE
      //   + 'El("' + TextBox_gain_or_loss_per_bale_in_kgs.clientid + '").value ='
      //   +  ' El("' + TextBox_gain_or_loss_in_kgs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      //   + k.NEW_LINE
      //   + 'El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value ='
      //   +  ' El("' + TextBox_gain_or_loss_in_lbs.clientid + '").value - El("' + TextBox_franchise_in_lbs.clientid + '").value;'
      //   + k.NEW_LINE
      //   + 'El("' + TextBox_actual_gain_or_loss_in_kgs.clientid + '").value ='
      //   +  ' El("' + TextBox_gain_or_loss_in_kgs.clientid + '").value - El("' + TextBox_franchise_in_kgs.clientid + '").value;'
      //   + k.NEW_LINE
      //   + 'El("' + TextBox_actual_gain_or_loss_per_bale_in_lbs.clientid + '").value ='
      //   +  ' El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      //   + k.NEW_LINE
      //   + 'El("' + TextBox_actual_gain_or_loss_per_bale_in_kgs.clientid + '").value ='
      //   +  ' El("' + TextBox_actual_gain_or_loss_in_kgs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      //   + k.NEW_LINE
      //   + 'El("' + TextBox_percent_gain_or_loss.clientid + '").value ='
      //   +  ' Math.round(El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value/El("' + TextBox_net_invoiced_in_lbs.clientid + '").value*100*100)/100;'
      //   + k.NEW_LINE
      //   + 'El("' + TextBox_monetary_gain_or_loss.clientid + '").value ='
      //   +  ' El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value*El("' + TextBox_unit_price_in_cents_per_pound.clientid + '").value;'
      //   );
      // //
      // TextBox_bales.attributes.Add('onkeyup','RecalculateDependentValues();');
      // TextBox_gross_landed_weight_in_pounds.attributes.Add
      //   (
      //   'onkeyup',
      //   'El("' + TextBox_gross_landed_weight_in_kgs.clientid + '").value = LbsToKgs(El("' + TextBox_gross_landed_weight_in_pounds.clientid + '").value);'
      //   + ' RecalculateDependentValues();'
      //   );
      // TextBox_gross_landed_weight_in_kgs.attributes.Add
      //   (
      //   'onkeyup',
      //   'El("' + TextBox_gross_landed_weight_in_pounds.clientid + '").value = KgsToLbs(El("' + TextBox_gross_landed_weight_in_kgs.clientid + '").value);'
      //   + ' RecalculateDependentValues();'
      //   );
      // TextBox_landed_or_ciq_tare.attributes.Add
      //   (
      //   'onkeyup',
      //   'El("' + TextBox_landed_or_ciq_tare_in_kgs.clientid + '").value = LbsToKgs(El("' + TextBox_landed_or_ciq_tare.clientid + '").value);'
      //   + ' RecalculateDependentValues();'
      //   );
      // TextBox_landed_or_ciq_tare_in_kgs.attributes.Add
      //   (
      //   'onkeyup',
      //   'El("' + TextBox_landed_or_ciq_tare.clientid + '").value = KgsToLbs(El("' + TextBox_landed_or_ciq_tare_in_kgs.clientid + '").value);'
      //   + ' RecalculateDependentValues();'
      //   );
      // TextBox_net_landed_in_pounds.attributes.Add
      //   (
      //   'onkeyup',
      //   'El("' + TextBox_net_landed_in_kgs.clientid + '").value = LbsToKgs(El("' + TextBox_net_landed_in_pounds.clientid + '").value);'
      //   + ' RecalculateDependentValues();'
      //   );
      // TextBox_net_landed_in_kgs.attributes.Add
      //   (
      //   'onkeyup',
      //   'El("' + TextBox_net_landed_in_pounds.clientid + '").value = KgsToLbs(El("' + TextBox_net_landed_in_kgs.clientid + '").value);'
      //   + ' RecalculateDependentValues();'
      //   );
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        LinkButton_new_record.Visible = p.be_ok_to_config_strike_team_deployment_operational_periods;
        LinkButton_go_to_match_first.Text = k.ExpandTildePath(LinkButton_go_to_match_first.Text);
        LinkButton_go_to_match_prior.Text = k.ExpandTildePath(LinkButton_go_to_match_prior.Text);
        LinkButton_go_to_match_next.Text = k.ExpandTildePath(LinkButton_go_to_match_next.Text);
        LinkButton_go_to_match_last.Text = k.ExpandTildePath(LinkButton_go_to_match_last.Text);
        //
        UserControl_drop_down_datetime_start.minyear = DateTime.Now.AddYears(-1).ToString("yyyy");
        UserControl_drop_down_datetime_start.maxyear = DateTime.Now.AddYears(1).ToString("yyyy");
        UserControl_drop_down_datetime_start.minute_intervals = 15;
        UserControl_drop_down_datetime_end.minyear = DateTime.Now.AddYears(-1).ToString("yyyy");
        UserControl_drop_down_datetime_end.maxyear = DateTime.Now.AddYears(1).ToString("yyyy");
        UserControl_drop_down_datetime_end.minute_intervals = 15;
        //
        RequireConfirmation(Button_delete, "Are you sure you want to delete this record?");
        if (p.presentation_mode == presentation_mode_enum.NEW)
          {
          SetDataEntryMode();
          TextBox_deployment_id.Text = p.deployment_id;
          UserControl_drop_down_datetime_start.selectedvalue = DateTime.Now;
          UserControl_drop_down_datetime_end.selectedvalue = DateTime.Now;
          DropDownList_kind.Focus();
          }
        else
          {
          PresentRecord(p.operational_period_id);
          Panel_active_operational_period_detail.Visible = true;
          UserControl_operational_period_detail_control.Set
            (
            deployment_id:p.deployment_id,
            operational_period_id:p.operational_period_id
            );
          }

        p.be_loaded = true;
        }
      InjectPersistentClientSideScript();
      ToolkitScriptManager.GetCurrent(Page).RegisterPostBackControl(Button_submit);
      ToolkitScriptManager.GetCurrent(Page).RegisterPostBackControl(Button_delete);
      }

    private bool PresentRecord(string id)
      {
      Literal_match_index.Text = DropDownList_id.SelectedIndex.ToString();
      bool result;
      string deployment_id;
      kind_enum kind;
      DateTime start;
      DateTime end;
      bool be_convoy;
      string prelim_shift_name;
      result = false;
      if
        (
        p.biz_strike_team_deployment_operational_periods.Get
          (
          id,
          out deployment_id,
          out start,
          out end,
          out be_convoy,
          out prelim_shift_name,
          out kind
          )
        )
        {
        TextBox_id.Text = id;
        TextBox_id.Enabled = false;
        TextBox_deployment_id.Text = deployment_id;
        DropDownList_kind.SelectedValue = kind.ToString();
        ManageFormAccordingToKind();
        UserControl_drop_down_datetime_start.selectedvalue = start;
        UserControl_drop_down_datetime_end.selectedvalue = end;
        TextBox_prelim_shift_name.Text = prelim_shift_name;
        Button_lookup.Enabled = false;
        Label_lookup_arrow.Enabled = false;
        Label_lookup_hint.Enabled = false;
        LinkButton_reset.Enabled = true;
        SetDependentFieldAblements(p.be_ok_to_config_strike_team_deployment_operational_periods);
        Button_submit.Enabled = p.be_ok_to_config_strike_team_deployment_operational_periods;
        Button_delete.Enabled = p.be_ok_to_config_strike_team_deployment_operational_periods;
        result = true;
        }
      return result;
      }

    internal void Set
      (
      string deployment_id,
      string operational_period_id
      )
      {
      p.deployment_id = deployment_id;
      if (operational_period_id.Length > 0)
        {
        p.operational_period_id = operational_period_id;
        p.summary = p.biz_strike_team_deployment_operational_periods.Summary(operational_period_id);
        p.presentation_mode = (p.be_ok_to_config_strike_team_deployment_operational_periods ? presentation_mode_enum.FULL_FUNCTION : p.presentation_mode = presentation_mode_enum.REVIEW_ONLY);
        }
      else
        {
        p.operational_period_id = k.EMPTY;
        p.summary = null;
        p.presentation_mode = presentation_mode_enum.NEW;
        }
      }
    private void SetDataEntryMode()
      {
      Clear();
      TextBox_id.Text = "*";
      TextBox_id.Enabled = false;
      Button_lookup.Enabled = false;
      Label_lookup_arrow.Enabled = false;
      Label_lookup_hint.Enabled = false;
      LinkButton_reset.Enabled = true;
      LinkButton_new_record.Enabled = false;
      SetDependentFieldAblements(p.be_ok_to_config_strike_team_deployment_operational_periods);
      Button_submit.Enabled = p.be_ok_to_config_strike_team_deployment_operational_periods;
      Button_delete.Enabled = false;
      TextBox_id.Focus();
      }

    private void SetLookupMode()
      {
      Clear();
      TextBox_id.Enabled = true;
      Button_lookup.Enabled = true;
      Label_lookup_arrow.Enabled = true;
      Label_lookup_hint.Enabled = true;
      LinkButton_reset.Enabled = false;
      LinkButton_new_record.Enabled = true;
      TextBox_id.Focus();
      }

    protected override void OnInit(System.EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      if (Session[InstanceId() + ".p"] != null)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        p.be_loaded = IsPostBack;
        }
      else
        {
        p.be_loaded = false;
        p.biz_members = new TClass_biz_members();
        p.biz_privileges = new TClass_biz_privileges();
        p.biz_strike_team_deployment_logs = new TClass_biz_strike_team_deployment_logs();
        p.biz_strike_team_deployment_operational_periods = new TClass_biz_strike_team_deployment_operational_periods();
        p.biz_role_member_map = new TClass_biz_role_member_map();
        p.biz_user = new TClass_biz_user();
        p.be_ok_to_config_strike_team_deployment_operational_periods = true;
        p.deployment_id = k.EMPTY;
        p.operational_period_id = k.EMPTY;
        p.presentation_mode = presentation_mode_enum.NONE;
        p.summary = null;
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      //this.Load += this.Page_Load;
      this.PreRender += this.TWebUserControl_strike_team_deployment_operational_periods_PreRender;
      }

    private void TWebUserControl_strike_team_deployment_operational_periods_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_strike_team_deployment_operational_period Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    protected void Button_submit_Click(object sender, System.EventArgs e)
      {
      if (Page.IsValid)
        {
        var start = new DateTime();
        var end = new DateTime();
        //
        var kind = k.Safe(DropDownList_kind.SelectedValue,k.safe_hint_type.ALPHA);
        var be_convoy = (kind == "CONVOY");
        //
        if (UserControl_drop_down_datetime_start.selectedvalue != DateTime.MinValue)
          {
          start = UserControl_drop_down_datetime_start.selectedvalue;
          }
        if (UserControl_drop_down_datetime_end.selectedvalue != DateTime.MinValue)
          {
          end = UserControl_drop_down_datetime_end.selectedvalue;
          }
        p.biz_strike_team_deployment_operational_periods.Set
          (
          id:k.Safe(TextBox_id.Text,k.safe_hint_type.NUM),
          deployment_id:k.Safe(TextBox_deployment_id.Text,k.safe_hint_type.NUM),
          start:start,
          end:end,
          be_convoy:be_convoy,
          prelim_shift_name:k.Safe(TextBox_prelim_shift_name.Text,k.safe_hint_type.HYPHENATED_ALPHANUM_WORDS),
          kind:kind
          );
        if (kind != "PRELIM")
          {
          p.biz_strike_team_deployment_logs.Enter
            (
            deployment_id:p.deployment_id,
            action:"designated " + start.ToString("yyyy-MM-dd HH:mm")
            + " to " + end.ToString("yyyy-MM-dd HH:mm")
            + " as a" + (be_convoy ? " convoy" : "n operational period")
            );
          }
        Alert(k.alert_cause_type.USER, k.alert_state_type.SUCCESS, "recsaved", "Record saved.", true);
        if (p.presentation_mode == presentation_mode_enum.NEW)
          {
          BackTrack();
          }
        }
      else
        {
        ValidationAlert(true);
        }
      }

    protected void DropDownList_id_SelectedIndexChanged(object sender, System.EventArgs e)
      {
      PresentRecord(k.Safe(DropDownList_id.SelectedValue, k.safe_hint_type.NUM));
      }

    protected void LinkButton_go_to_match_first_Click(object sender, System.EventArgs e)
      {
      DropDownList_id.SelectedIndex = 1;
      PresentRecord(k.Safe(DropDownList_id.SelectedValue, k.safe_hint_type.NUM));
      }

    protected void LinkButton_go_to_match_prior_Click(object sender, System.EventArgs e)
      {
      DropDownList_id.SelectedIndex = Math.Max(1, (DropDownList_id.SelectedIndex - 1));
      PresentRecord(k.Safe(DropDownList_id.SelectedValue, k.safe_hint_type.NUM));
      }

    protected void LinkButton_go_to_match_next_Click(object sender, System.EventArgs e)
      {
      DropDownList_id.SelectedIndex = Math.Min((DropDownList_id.SelectedIndex + 1), (DropDownList_id.Items.Count - 1));
      PresentRecord(k.Safe(DropDownList_id.SelectedValue, k.safe_hint_type.NUM));
      }

    protected void LinkButton_go_to_match_last_Click(object sender, System.EventArgs e)
      {
      DropDownList_id.SelectedIndex = DropDownList_id.Items.Count - 1;
      PresentRecord(k.Safe(DropDownList_id.SelectedValue, k.safe_hint_type.NUM));
      }

    protected void Button_delete_Click(object sender, System.EventArgs e)
      {
      var operational_period_id = k.Safe(TextBox_id.Text, k.safe_hint_type.NUM);
      var summary = p.biz_strike_team_deployment_operational_periods.Summary(id:operational_period_id);
      if (p.biz_strike_team_deployment_operational_periods.Delete(operational_period_id))
        {
        if (p.biz_strike_team_deployment_operational_periods.KindOf(summary) != kind_enum.PRELIM)
          {
          p.biz_strike_team_deployment_logs.Enter
            (
            deployment_id:p.deployment_id,
            action:"deleted "
            + (p.biz_strike_team_deployment_operational_periods.BeConvoyOf(summary) ? "convoy" : "operational period")
            + " from " + p.biz_strike_team_deployment_operational_periods.StartOf(summary).ToString("yyyy-MM-dd HH:mm")
            + " to " + p.biz_strike_team_deployment_operational_periods.EndOf(summary).ToString("yyyy-MM-dd HH:mm")
            );
          }
        BackTrack();
        }
      else
        {
        Alert(k.alert_cause_type.APPDATA,k.alert_state_type.FAILURE, "dependency", " Cannot delete this record because another record depends on it.", true);
        }
      }

    protected void LinkButton_new_record_Click(object sender, System.EventArgs e)
      {
      SetDataEntryMode();
      }

    protected void LinkButton_reset_Click(object sender, System.EventArgs e)
      {
      SetLookupMode();
      }

    private void SetDependentFieldAblements(bool ablement)
      {
      TextBox_deployment_id.Enabled = ablement;
      DropDownList_kind.Enabled = ablement;
      UserControl_drop_down_datetime_start.enabled = ablement;
      UserControl_drop_down_datetime_end.enabled = ablement;
      TextBox_prelim_shift_name.Enabled = ablement;
      }

    protected void Button_lookup_Click(object sender, System.EventArgs e)
      {
      uint num_matches;
      string saved_id;
      saved_id = k.Safe(TextBox_id.Text,k.safe_hint_type.PUNCTUATED);
      Clear();
      if (!PresentRecord(saved_id))
        {
        TextBox_id.Text = saved_id;
        p.biz_strike_team_deployment_operational_periods.Bind(saved_id, DropDownList_id);
        num_matches = (uint)(DropDownList_id.Items.Count);
        if (num_matches > 0)
          {
          DropDownList_id.Visible = true;
          if (num_matches == 1)
            {
            PresentRecord(k.Safe(DropDownList_id.SelectedValue, k.safe_hint_type.NUM));
            }
          else
            {
            Literal_match_index.Text = "0";
            Literal_num_matches.Text = num_matches.ToString();
            Panel_match_numbers.Visible = true;
            LinkButton_go_to_match_prior.Visible = true;
            LinkButton_go_to_match_next.Visible = true;
            LinkButton_go_to_match_last.Visible = true;
            LinkButton_go_to_match_first.Visible = true;
            DropDownList_id.Items.Insert(0, new ListItem("-- Select --", k.EMPTY));
            }
          }
        }
      }

    protected void CustomValidator_chronological_order_ServerValidate(object source, ServerValidateEventArgs args)
      {
      args.IsValid = UserControl_drop_down_datetime_start.selectedvalue < UserControl_drop_down_datetime_end.selectedvalue;
      }

    protected void CustomValidator_uniqueness_ServerValidate(object source, ServerValidateEventArgs args)
      {
      var id_with_competing_times = p.biz_strike_team_deployment_operational_periods.IdInSameDeploymentWithCompetingTimes
        (
        id:k.Safe(TextBox_id.Text, k.safe_hint_type.NUM),
        deployment_id:p.deployment_id,
        start:UserControl_drop_down_datetime_start.selectedvalue,
        end:UserControl_drop_down_datetime_end.selectedvalue
        );
      args.IsValid = (id_with_competing_times == k.EMPTY);
      }

    protected void DropDownList_kind_SelectedIndexChanged(object sender, EventArgs e)
      {
      ManageFormAccordingToKind();
      }

    private void ManageFormAccordingToKind()
      {
      var kind = DropDownList_kind.SelectedValue;
      var be_kind_using_start_and_end = new ArrayList() { "CONVOY", "ACTUAL" }.Contains(kind);
      var be_prelim = (!be_kind_using_start_and_end && (kind.Length > 0));
      TableRow_start.Visible = be_kind_using_start_and_end;
      TableRow_end.Visible = be_kind_using_start_and_end;
      TableRow_prelim_shift_name.Visible = be_prelim;
      RequiredFieldValidator_prelim_shift_name.Enabled = be_prelim;
      CustomValidator_chronological_order.Enabled = be_kind_using_start_and_end;
      CustomValidator_uniqueness.Enabled = be_kind_using_start_and_end;
      }

    } // end TWebUserControl_strike_team_deployment_operational_periods

  }

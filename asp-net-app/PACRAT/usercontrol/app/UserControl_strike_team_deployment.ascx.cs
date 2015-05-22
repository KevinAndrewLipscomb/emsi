// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~kicrudhelped~item.ascx.cs~template

using AjaxControlToolkit;
using Class_biz_members;
using Class_biz_privileges;
using Class_biz_role_member_map;
using Class_biz_strike_team_deployment_logs;
using Class_biz_strike_team_deployment_member_policies;
using Class_biz_strike_team_deployments;
using Class_biz_user;
using Class_msg_protected;
using kix;
using System;
using System.Collections;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl_strike_team_deployment
  {
  public partial class TWebUserControl_strike_team_deployment: ki_web_ui.usercontrol_class
    {
    private struct p_type
      {
      public bool be_loaded;
      public bool be_ok_to_config_strike_team_deployments;
      public TClass_biz_members biz_members;
      public TClass_biz_privileges biz_privileges;
      public TClass_biz_role_member_map biz_role_member_map;
      public TClass_biz_strike_team_deployment_logs biz_strike_team_deployment_logs;
      public TClass_biz_strike_team_deployment_member_policies biz_strike_team_deployment_member_policies;
      public TClass_biz_strike_team_deployments biz_strike_team_deployments;
      public TClass_biz_user biz_user;
      public string id;
      public TClass_msg_protected.mobilization_announcement msg_protected_mobilization_announcement;
      public presentation_mode_enum presentation_mode;
      public object summary;
      }

    private p_type p;

    private void Clear()
      {
      TextBox_id.Text = k.EMPTY;
      DropDownList_id.Visible = false;
      UserControl_drop_down_date_creation_date.Clear();
      TextBox_name.Text = k.EMPTY;
      RadioButtonList_member_policy.ClearSelection();
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
        LinkButton_new_record.Visible = p.be_ok_to_config_strike_team_deployments;
        LinkButton_go_to_match_first.Text = k.ExpandTildePath(LinkButton_go_to_match_first.Text);
        LinkButton_go_to_match_prior.Text = k.ExpandTildePath(LinkButton_go_to_match_prior.Text);
        LinkButton_go_to_match_next.Text = k.ExpandTildePath(LinkButton_go_to_match_next.Text);
        LinkButton_go_to_match_last.Text = k.ExpandTildePath(LinkButton_go_to_match_last.Text);
        TableRow_submit_delete_announce.Visible = p.be_ok_to_config_strike_team_deployments;
        Button_submit.Visible = p.be_ok_to_config_strike_team_deployments;
        //
        RequireConfirmation(Button_delete, "Are you sure you want to delete this record?");
        if (p.presentation_mode == presentation_mode_enum.NEW)
          {
          SetDataEntryMode();
          }
        else
          {
          PresentRecord(p.id);
          SetNonNewPresentationMode();
          }
        p.be_loaded = true;
        }
      ToolkitScriptManager.GetCurrent(Page).RegisterPostBackControl(Button_submit);
      ToolkitScriptManager.GetCurrent(Page).RegisterPostBackControl(LinkButton_announce);
      InjectPersistentClientSideScript();
      }

    private void SetNonNewPresentationMode()
      {
      Button_submit.Text = "Alter this deployment";
      var be_mobilizing = p.be_ok_to_config_strike_team_deployments && !p.biz_strike_team_deployments.BeDemobilizationReasonRequired
          (
          deployment_id: p.id,
          service_strike_team_management_footprint: k.EMPTY
          );
      LinkButton_announce.Visible = be_mobilizing;
      Panel_active_deployment_detail.Visible = true;
      Table_initial_actions.Visible = be_mobilizing;
      if (be_mobilizing)
        {
        UserControl_strike_team_deployment_binder_control.SetTarget("/operational-periods/");
        }
      }

    private bool PresentRecord(string id)
      {
      Literal_match_index.Text = DropDownList_id.SelectedIndex.ToString();
      bool result;
      DateTime creation_date;
      string name;
      string member_policy_id;
      result = false;
      if
        (
        p.biz_strike_team_deployments.Get
          (
          id,
          out creation_date,
          out name,
          out member_policy_id
          )
        )
        {
        TextBox_id.Text = id;
        TextBox_id.Enabled = false;
        UserControl_drop_down_date_creation_date.selectedvalue = creation_date;
        TextBox_name.Text = name;
        RadioButtonList_member_policy.SelectedValue = member_policy_id;
        Button_lookup.Enabled = false;
        Label_lookup_arrow.Enabled = false;
        Label_lookup_hint.Enabled = false;
        LinkButton_reset.Enabled = true;
        SetDependentFieldAblements(p.be_ok_to_config_strike_team_deployments);
        Button_submit.Enabled = p.be_ok_to_config_strike_team_deployments;
        Button_delete.Enabled = p.be_ok_to_config_strike_team_deployments;
        result = true;
        }
      return result;
      }

    internal void Set(string id)
      {
      p.be_ok_to_config_strike_team_deployments = p.biz_privileges.HasForPennsylvania
        (
        member_id:p.biz_members.IdOfUserId(p.biz_user.IdNum()),
        privilege_name:"config-strike-team-deployments"
        );
      if (id.Length > 0)
        {
        p.id = id;
        p.summary = p.biz_strike_team_deployments.Summary(id);
        p.presentation_mode = (p.be_ok_to_config_strike_team_deployments ? presentation_mode_enum.FULL_FUNCTION : p.presentation_mode = presentation_mode_enum.REVIEW_ONLY);
        UserControl_strike_team_deployment_binder_control.Set
          (
          deployment_id:id,
          be_ok_to_config_strike_team_deployments:p.be_ok_to_config_strike_team_deployments
          );
        }
      else
        {
        p.id = k.EMPTY;
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
      SetDependentFieldAblements(p.be_ok_to_config_strike_team_deployments);
      Button_submit.Enabled = p.be_ok_to_config_strike_team_deployments;
      Button_delete.Enabled = false;
      if (p.presentation_mode == presentation_mode_enum.NEW)
        {
        TextBox_name.Focus();
        }
      else
        {
        TextBox_id.Focus();
        }
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
        p.biz_members = new TClass_biz_members();
        p.biz_privileges = new TClass_biz_privileges();
        p.biz_role_member_map = new TClass_biz_role_member_map();
        p.biz_strike_team_deployment_logs = new TClass_biz_strike_team_deployment_logs();
        p.biz_strike_team_deployment_member_policies = new TClass_biz_strike_team_deployment_member_policies();
        p.biz_strike_team_deployments = new TClass_biz_strike_team_deployments();
        p.biz_user = new TClass_biz_user();
        p.msg_protected_mobilization_announcement = new TClass_msg_protected.mobilization_announcement();
        //
        p.be_loaded = false;
        p.be_ok_to_config_strike_team_deployments = false;
        p.id = k.EMPTY;
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
      this.PreRender += this.TWebUserControl_strike_team_deployment_PreRender;
      }

    private void TWebUserControl_strike_team_deployment_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_strike_team_deployment Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      UserControl_drop_down_date_creation_date.Fresh();
      return this;
      }

    protected void Button_submit_Click(object sender, System.EventArgs e)
      {
      if (Page.IsValid)
        {
        var id = k.Safe(TextBox_id.Text,k.safe_hint_type.NUM);
        var creation_date = (p.presentation_mode == presentation_mode_enum.NEW ? DateTime.Today : UserControl_drop_down_date_creation_date.selectedvalue);
        var name = k.Safe(TextBox_name.Text,k.safe_hint_type.MAKE_MODEL).Trim();
        var member_policy_id = k.Safe(RadioButtonList_member_policy.SelectedValue,k.safe_hint_type.NUM);
        p.biz_strike_team_deployments.Set
          (
          id:id,
          creation_date:creation_date,
          name:name,
          member_policy_id:member_policy_id
          );
        if (p.presentation_mode != presentation_mode_enum.NEW)
          {
          //
          // Log event
          //
          p.biz_strike_team_deployment_logs.Enter
            (
            deployment_id:id,
            action:"named deployment `" + name + "` and set its personnel participation policy to `" + p.biz_strike_team_deployment_member_policies.DescriptionOf(member_policy_id).ToUpper() + "`"
            );
          //
          Alert(k.alert_cause_type.USER, k.alert_state_type.SUCCESS, "recsaved", "Record saved.", true);
          //
          UserControl_strike_team_deployment_binder_control.Set
            (
            deployment_id:id,
            be_ok_to_config_strike_team_deployments:p.be_ok_to_config_strike_team_deployments
            );
          }
        else
          {
          Set
            (
            id:p.biz_strike_team_deployments.IdOfPractical
              (
              creation_date:creation_date,
              name:name
              )
            );
          SetNonNewPresentationMode();
          Alert
            (
            cause:k.alert_cause_type.USER,
            state:k.alert_state_type.SUCCESS,
            key:"depcrtdseehints",
            value:k.EMPTY
            + "Deployment created." + k.NEW_LINE
            + k.NEW_LINE
            + "Please direct your attention to the khaki panels that " + ConfigurationManager.AppSettings["application_name"] + " will now display.  They contain important guidance that you should read and follow carefully.",
            be_using_scriptmanager:true
            );
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
      var id = k.Safe(TextBox_id.Text,k.safe_hint_type.NUM);
      if (p.biz_strike_team_deployments.Delete(id))
        {
        //
        // Log event
        //
        p.biz_strike_team_deployment_logs.Enter
          (
          deployment_id:id,
          action:"deleted deployment"
          );
        //
        SetLookupMode();
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
      UserControl_drop_down_date_creation_date.enabled = ablement;
      TextBox_name.Enabled = ablement;
      RadioButtonList_member_policy.Enabled = ablement;
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
        p.biz_strike_team_deployments.Bind(saved_id, DropDownList_id);
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

    protected void LinkButton_announce_Click(object sender, EventArgs e)
      {
      p.msg_protected_mobilization_announcement.deployment_summary = p.summary;
      MessageDropCrumbAndTransferTo
        (
        msg:p.msg_protected_mobilization_announcement,
        folder_name:"protected",
        aspx_name:"mobilization_announcement"
        );
      }

    protected void CustomValidator_name_ServerValidate(object source, ServerValidateEventArgs args)
      {
      var simplified_name = k.Safe(TextBox_name.Text,k.safe_hint_type.MAKE_MODEL).ToUpper();
      args.IsValid = !(simplified_name.Contains("DRILL") || simplified_name.Contains("EXERCISE"));
      }

    } // end TWebUserControl_strike_team_deployment

  }

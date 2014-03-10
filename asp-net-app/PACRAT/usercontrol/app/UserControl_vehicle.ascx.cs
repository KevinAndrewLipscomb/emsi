// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~kicrudhelped~item.ascx.cs~template

using AjaxControlToolkit;
using Class_biz_fuels;
using Class_biz_members;
using Class_biz_patient_care_levels;
using Class_biz_privileges;
using Class_biz_role_member_map;
using Class_biz_services;
using Class_biz_tow_capacities;
using Class_biz_user;
using Class_biz_vehicle_kinds;
using Class_biz_vehicles;
using kix;
using System;
using System.Collections;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl_vehicle
  {
  public partial class TWebUserControl_vehicle: ki_web_ui.usercontrol_class
    {
    private struct p_type
      {
      public bool be_loaded;
      public TClass_biz_fuels biz_fuels;
      public TClass_biz_members biz_members;
      public TClass_biz_patient_care_levels biz_patient_care_levels;
      public TClass_biz_privileges biz_privileges;
      public TClass_biz_role_member_map biz_role_member_map;
      public TClass_biz_services biz_services;
      public TClass_biz_tow_capacities biz_tow_capacities;
      public TClass_biz_user biz_user;
      public TClass_biz_vehicle_kinds biz_vehicle_kinds;
      public TClass_biz_vehicles biz_vehicles;
      public bool be_ok_to_config_vehicles;
      public string id;
      public presentation_mode_enum presentation_mode;
      public string service_id;
      public string service_short_name;
      public object summary;
      } // end p_type

    private p_type p;

    private void Clear()
      {
      TextBox_id.Text = k.EMPTY;
      DropDownList_id.Visible = false;
      TextBox_service_id.Text = k.EMPTY;
      TextBox_name.Text = k.EMPTY;
      DropDownList_kind.ClearSelection();
      DropDownList_tow_capacity.ClearSelection();
      DropDownList_fuel.ClearSelection();
      TextBox_license_plate.Text = k.EMPTY;
      TextBox_pa_doh_decal_num.Text = k.EMPTY;
      CheckBox_be_four_or_all_wheel_drive.Checked = false;
      DropDownList_patient_care_level.ClearSelection();
      TextBox_elaboration.Text = k.EMPTY;
      UpdateStagingDesignator();
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
        LinkButton_new_record.Visible = p.be_ok_to_config_vehicles;
        LinkButton_go_to_match_first.Text = k.ExpandTildePath(LinkButton_go_to_match_first.Text);
        LinkButton_go_to_match_prior.Text = k.ExpandTildePath(LinkButton_go_to_match_prior.Text);
        LinkButton_go_to_match_next.Text = k.ExpandTildePath(LinkButton_go_to_match_next.Text);
        LinkButton_go_to_match_last.Text = k.ExpandTildePath(LinkButton_go_to_match_last.Text);
        //
        p.biz_vehicle_kinds.BindDirectToListControl(target:DropDownList_kind);
        p.biz_tow_capacities.BindLongDescriptionDirectToListControl(target:DropDownList_tow_capacity);
        p.biz_fuels.BindDirectToListControl(target:DropDownList_fuel);
        p.biz_patient_care_levels.BindDirectToListControl(target:DropDownList_patient_care_level);
        //
        Literal_service_short_name.Text = p.service_short_name;
        Literal_application_name.Text = ConfigurationManager.AppSettings["application_name"];
        UpdateStagingDesignator();
        //
        RequireConfirmation(Button_delete, "Are you sure you want to delete this record?");
        if (p.presentation_mode == presentation_mode_enum.NEW)
          {
          SetDataEntryMode();
          TextBox_service_id.Text = p.service_id;
          DropDownList_kind.Items.Insert(0,(new ListItem("-- kind --",k.EMPTY)));
          DropDownList_tow_capacity.Items.Insert(0,(new ListItem("-- tow capacity -- ",k.EMPTY)));
          DropDownList_fuel.Items.Insert(0,(new ListItem("-- fuel --",k.EMPTY)));
          DropDownList_patient_care_level.Items.Insert(0,(new ListItem("-- patient care level --",k.EMPTY)));
          TextBox_name.Focus();
          }
        else
          {
          PresentRecord(p.id);
          }
        p.be_loaded = true;
        }
      ToolkitScriptManager.GetCurrent(Page).RegisterPostBackControl(Button_submit);
      ToolkitScriptManager.GetCurrent(Page).RegisterPostBackControl(Button_delete);
      InjectPersistentClientSideScript();
      }

    private bool PresentRecord(string id)
      {
      Literal_match_index.Text = DropDownList_id.SelectedIndex.ToString();
      bool result;
      string service_id;
      string name;
      string kind_id;
      string fuel_id;
      string license_plate;
      bool be_four_or_all_wheel_drive;
      string tow_capacity_id;
      string pa_doh_decal_num;
      string patient_care_level;
      string elaboration;
      result = false;
      if
        (
        p.biz_vehicles.Get
          (
          id,
          out service_id,
          out name,
          out kind_id,
          out fuel_id,
          out license_plate,
          out be_four_or_all_wheel_drive,
          out tow_capacity_id,
          out pa_doh_decal_num,
          out patient_care_level,
          out elaboration
          )
        )
        {
        TextBox_id.Text = id;
        TextBox_id.Enabled = false;
        TextBox_service_id.Text = service_id;
        TextBox_name.Text = name;
        DropDownList_kind.SelectedValue = kind_id;
        DropDownList_tow_capacity.SelectedValue = tow_capacity_id;
        DropDownList_fuel.SelectedValue = fuel_id;
        TextBox_license_plate.Text = license_plate;
        TextBox_pa_doh_decal_num.Text = pa_doh_decal_num;
        CheckBox_be_four_or_all_wheel_drive.Checked = be_four_or_all_wheel_drive;
        DropDownList_patient_care_level.SelectedValue = patient_care_level;
        TextBox_elaboration.Text = elaboration;
        UpdateStagingDesignator();
        Button_lookup.Enabled = false;
        Label_lookup_arrow.Enabled = false;
        Label_lookup_hint.Enabled = false;
        LinkButton_reset.Enabled = true;
        SetDependentFieldAblements(p.be_ok_to_config_vehicles);
        Button_submit.Enabled = p.be_ok_to_config_vehicles;
        Button_delete.Enabled = p.be_ok_to_config_vehicles;
        result = true;
        }
      return result;
      }

    internal void Set
      (
      string id,
      string service_id
      )
      {
      p.service_id = service_id;
      p.service_short_name = p.biz_services.ShortNameOf(service_id);
      if (id.Length > 0)
        {
        p.id = id;
        p.summary = p.biz_vehicles.Summary(id);
        p.be_ok_to_config_vehicles = p.biz_privileges.HasForService
          (
          member_id:p.biz_members.IdOfUserId(p.biz_user.IdNum()),
          privilege_name:"config-vehicles",
          service_id:p.biz_vehicles.ServiceIdOf(p.summary)
          );
        p.presentation_mode = (p.be_ok_to_config_vehicles ? presentation_mode_enum.FULL_FUNCTION : p.presentation_mode = presentation_mode_enum.REVIEW_ONLY);
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
      SetDependentFieldAblements(p.be_ok_to_config_vehicles);
      Button_submit.Enabled = p.be_ok_to_config_vehicles;
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
        p.biz_fuels = new TClass_biz_fuels();
        p.biz_members = new TClass_biz_members();
        p.biz_patient_care_levels = new TClass_biz_patient_care_levels();
        p.biz_privileges = new TClass_biz_privileges();
        p.biz_role_member_map = new TClass_biz_role_member_map();
        p.biz_services = new TClass_biz_services();
        p.biz_tow_capacities = new TClass_biz_tow_capacities();
        p.biz_user = new TClass_biz_user();
        p.biz_vehicle_kinds = new TClass_biz_vehicle_kinds();
        p.biz_vehicles = new TClass_biz_vehicles();
        //
        p.be_loaded = false;
        p.be_ok_to_config_vehicles = k.Has((string[])(Session["privilege_array"]), "config-vehicles");
        p.id = k.EMPTY;
        p.presentation_mode = presentation_mode_enum.NONE;
        p.service_id = k.EMPTY;
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
      this.PreRender += this.TWebUserControl_vehicle_PreRender;
      }

    private void TWebUserControl_vehicle_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_vehicle Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    protected void Button_submit_Click(object sender, System.EventArgs e)
      {
      if (Page.IsValid)
        {
        p.biz_vehicles.Set
          (
          k.Safe(TextBox_id.Text,k.safe_hint_type.NUM),
          k.Safe(TextBox_service_id.Text,k.safe_hint_type.NUM),
          k.Safe(TextBox_name.Text,k.safe_hint_type.MAKE_MODEL).Trim(),
          k.Safe(DropDownList_kind.Text,k.safe_hint_type.NUM),
          k.Safe(DropDownList_fuel.Text,k.safe_hint_type.NUM),
          k.Safe(TextBox_license_plate.Text,k.safe_hint_type.ALPHANUM),
          CheckBox_be_four_or_all_wheel_drive.Checked,
          k.Safe(DropDownList_tow_capacity.Text,k.safe_hint_type.NUM),
          k.Safe(TextBox_pa_doh_decal_num.Text,k.safe_hint_type.NUM),
          k.Safe(DropDownList_patient_care_level.Text,k.safe_hint_type.NUM),
          k.Safe(TextBox_elaboration.Text,k.safe_hint_type.MEMO).Trim()
          );
        Alert(k.alert_cause_type.USER, k.alert_state_type.SUCCESS, "recsaved", "Record saved.", true);
        BackTrack();
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
      if (p.biz_vehicles.Delete(k.Safe(TextBox_id.Text, k.safe_hint_type.ALPHANUM)))
        {
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
      TextBox_service_id.Enabled = ablement;
      TextBox_name.Enabled = ablement;
      DropDownList_kind.Enabled = ablement;
      DropDownList_tow_capacity.Enabled = ablement;
      DropDownList_fuel.Enabled = ablement;
      TextBox_license_plate.Enabled = ablement;
      CheckBox_be_four_or_all_wheel_drive.Enabled = ablement;
      TextBox_pa_doh_decal_num.Enabled = ablement;
      DropDownList_patient_care_level.Enabled = ablement;
      TextBox_elaboration.Enabled = ablement;
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
        p.biz_vehicles.Bind(saved_id, DropDownList_id);
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

    protected void CustomValidator_uniqueness_ServerValidate(object source, ServerValidateEventArgs args)
      {
      args.IsValid = (new ArrayList {k.EMPTY,p.id}).Contains(p.biz_vehicles.IdByServiceIdAndName
        (
        service_id:p.service_id,
        name:k.Safe(TextBox_name.Text,k.safe_hint_type.MAKE_MODEL).Trim())
        );
      }

    protected void CustomValidator_license_plate_ServerValidate(object source, ServerValidateEventArgs args)
      {
      var designator_with_competing_license_plate = p.biz_vehicles.DesignatorWithCompetingLicensePlate
        (
        id:k.Safe(TextBox_id.Text, k.safe_hint_type.NUM),
        license_plate:k.Safe(TextBox_license_plate.Text, k.safe_hint_type.ALPHANUM)
        );
      CustomValidator_license_plate.ErrorMessage += designator_with_competing_license_plate;
      args.IsValid = (designator_with_competing_license_plate == k.EMPTY);
      }

    protected void CustomValidator_pa_doh_decal_num_ServerValidate(object source, ServerValidateEventArgs args)
      {
      var designator_with_competing_pa_doh_decal_num = p.biz_vehicles.DesignatorWithCompetingPaDohDecalNum
        (
        id:k.Safe(TextBox_id.Text, k.safe_hint_type.NUM),
        pa_doh_decal_num:k.Safe(TextBox_pa_doh_decal_num.Text, k.safe_hint_type.NUM)
        );
      CustomValidator_pa_doh_decal_num.ErrorMessage += designator_with_competing_pa_doh_decal_num;
      args.IsValid = (designator_with_competing_pa_doh_decal_num == k.EMPTY);
      }

    protected void DropDownList_kind_SelectedIndexChanged(object sender, EventArgs e)
      {
      UpdateStagingDesignator();
      }

    protected void TextBox_name_TextChanged(object sender, EventArgs e)
      {
      UpdateStagingDesignator(be_for_name_change:true);
      }

    private void UpdateStagingDesignator(bool be_for_name_change)
      {
      Label_designator.Text =
        p.service_short_name + k.SPACE + k.Safe(TextBox_name.Text,k.safe_hint_type.MAKE_MODEL).Trim() + k.SPACE + "(" + p.biz_vehicle_kinds.DescriptionOf(k.Safe(DropDownList_kind.SelectedValue,k.safe_hint_type.NUM)) + ")";
      if (be_for_name_change)
        {
        Alert
          (
          cause:k.alert_cause_type.USER,
          state:k.alert_state_type.NORMAL,
          key:"stagdesupd",
          value:"Your change has had an effect on the Staging Designator.  Please review it.  Don't forget to SUBMIT your changes if you are satisfied.",
          be_using_scriptmanager:true
          );
        }
      }
    private void UpdateStagingDesignator()
      {
      UpdateStagingDesignator(be_for_name_change:false);
      }

    } // end TWebUserControl_vehicle

  }

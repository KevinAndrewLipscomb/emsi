unit request_item_detail;

interface

uses
  System.Collections, System.ComponentModel,
  System.Data, System.Drawing, System.Web, System.Web.SessionState,
  system.web.ui, ki_web_ui, System.Web.UI.WebControls, System.Web.UI.HtmlControls, kix, system.configuration, mysql.data.mysqlclient,
  system.web.mail, system.web.security,
  Class_db,
  Class_db_trail,
  Class_biz_equipment;

type
  TWebForm_request_item_detail = class(ki_web_ui.page_class)
  {$REGION 'Designer Managed Code'}
  strict private
    procedure InitializeComponent;
    procedure Button_cancel_Click(sender: System.Object; e: System.EventArgs);
    procedure DropDownList_equipment_category_SelectedIndexChanged(sender: System.Object;
      e: System.EventArgs);
    procedure Button_submit_and_repeat_Click(sender: System.Object; e: System.EventArgs);
    procedure Button_submit_and_stop_Click(sender: System.Object; e: System.EventArgs);
    procedure LinkButton_recalculate_1_Click(sender: System.Object; e: System.EventArgs);
    procedure LinkButton_recalculate_2_Click(sender: System.Object; e: System.EventArgs);
    procedure LinkButton_recalculate_3_Click(sender: System.Object; e: System.EventArgs);
    procedure Button_delete_Click(sender: System.Object; e: System.EventArgs);
    procedure Button_update_Click(sender: System.Object; e: System.EventArgs);
    procedure Button_withdraw_Click(sender: System.Object; e: System.EventArgs);
    procedure TWebForm_request_item_detail_PreRender(sender: System.Object;
      e: System.EventArgs);
    procedure CustomValidator_special_conditions_ServerValidate(source: System.Object;
      args: System.Web.UI.WebControls.ServerValidateEventArgs);
  {$ENDREGION}
  strict private
    type
      p_type =
        RECORD
        additional_service_ante: decimal;
        allowable_cost: decimal;
        biz_equipment: TClass_biz_equipment;
        dri_equipment_category_allowable_cost: cardinal;
        dri_equipment_category_funding_level: cardinal;
        cmdText_get_equipment_category_monetary_details: string;
        db: TClass_db;
        db_trail: TClass_db_trail;
        funding_level: decimal;
        match_level: decimal;
        saved_emsof_ante: decimal;
        saved_additional_service_ante: decimal;
        END;
  strict private
    p: p_type;
    procedure AddItem;
    procedure Page_Load(sender: System.Object; e: System.EventArgs);
    procedure Recalculate;
    procedure ShowDependentData;
  strict protected
    Title: System.Web.UI.HtmlControls.HtmlGenericControl;
    PlaceHolder_precontent: System.Web.UI.WebControls.PlaceHolder;
    PlaceHolder_postcontent: System.Web.UI.WebControls.PlaceHolder;
    DropDownList_equipment_category: System.Web.UI.WebControls.DropDownList;
    Button_cancel: System.Web.UI.WebControls.Button;
    Label_life_expectancy: System.Web.UI.WebControls.Label;
    TextBox_make_model: System.Web.UI.WebControls.TextBox;
    RequiredFieldValidator_make_model: System.Web.UI.WebControls.RequiredFieldValidator;
    TextBox_place_kept: System.Web.UI.WebControls.TextBox;
    RequiredFieldValidator_place_kept: System.Web.UI.WebControls.RequiredFieldValidator;
    RequiredFieldValidator_condition: System.Web.UI.WebControls.RequiredFieldValidator;
    RadioButtonList_condition: System.Web.UI.WebControls.RadioButtonList;
    RegularExpressionValidator_make_model: System.Web.UI.WebControls.RegularExpressionValidator;
    RegularExpressionValidator_place_kept: System.Web.UI.WebControls.RegularExpressionValidator;
    RequiredFieldValidator_unit_cost: System.Web.UI.WebControls.RequiredFieldValidator;
    RegularExpressionValidator_unit_cost: System.Web.UI.WebControls.RegularExpressionValidator;
    TextBox_quantity: System.Web.UI.WebControls.TextBox;
    RequiredFieldValidator_quantity: System.Web.UI.WebControls.RequiredFieldValidator;
    RegularExpressionValidator_quantity: System.Web.UI.WebControls.RegularExpressionValidator;
    Label_total_cost: System.Web.UI.WebControls.Label;
    Label_min_service_ante: System.Web.UI.WebControls.Label;
    TextBox_additional_service_ante: System.Web.UI.WebControls.TextBox;
    Label_emsof_ante: System.Web.UI.WebControls.Label;
    Label_allowable_cost: System.Web.UI.WebControls.Label;
    RequiredFieldValidator_equipment_category: System.Web.UI.WebControls.RequiredFieldValidator;
    RangeValidator_equipment_category: System.Web.UI.WebControls.RangeValidator;
    Button_submit_and_repeat: System.Web.UI.WebControls.Button;
    Button_submit_and_stop: System.Web.UI.WebControls.Button;
    TextBox_unit_cost: System.Web.UI.WebControls.TextBox;
    RegularExpressionValidator_additional_service_ante: System.Web.UI.WebControls.RegularExpressionValidator;
    LinkButton_recalculate_1: System.Web.UI.WebControls.LinkButton;
    LinkButton_recalculate_2: System.Web.UI.WebControls.LinkButton;
    LinkButton_recalculate_3: System.Web.UI.WebControls.LinkButton;
    CheckBox_delete: System.Web.UI.WebControls.CheckBox;
    Button_delete: System.Web.UI.WebControls.Button;
    TableRow_delete: System.Web.UI.HtmlControls.HtmlTableRow;
    Button_update: System.Web.UI.WebControls.Button;
    Button_withdraw: System.Web.UI.WebControls.LinkButton;
    TableRow_post_finalization_actions: System.Web.UI.HtmlControls.HtmlTableRow;
    CustomValidator_special_conditions: System.Web.UI.WebControls.CustomValidator;
  protected
    procedure OnInit(e: EventArgs); override;
  end;

implementation

uses
  Class_biz_fiscal_years;

{$REGION 'Designer Managed Code'}
/// <summary>
/// Required method for Designer support -- do not modify
/// the contents of this method with the code editor.
/// </summary>
procedure TWebForm_request_item_detail.InitializeComponent;
begin
  Include(Self.DropDownList_equipment_category.SelectedIndexChanged, Self.DropDownList_equipment_category_SelectedIndexChanged);
  Include(Self.LinkButton_recalculate_1.Click, Self.LinkButton_recalculate_1_Click);
  Include(Self.LinkButton_recalculate_2.Click, Self.LinkButton_recalculate_2_Click);
  Include(Self.LinkButton_recalculate_3.Click, Self.LinkButton_recalculate_3_Click);
  Include(Self.Button_submit_and_repeat.Click, Self.Button_submit_and_repeat_Click);
  Include(Self.Button_submit_and_stop.Click, Self.Button_submit_and_stop_Click);
  Include(Self.Button_update.Click, Self.Button_update_Click);
  Include(Self.Button_cancel.Click, Self.Button_cancel_Click);
  Include(Self.CustomValidator_special_conditions.ServerValidate, Self.CustomValidator_special_conditions_ServerValidate);
  Include(Self.Button_delete.Click, Self.Button_delete_Click);
  Include(Self.Button_withdraw.Click, Self.Button_withdraw_Click);
  Include(Self.PreRender, Self.TWebForm_request_item_detail_PreRender);
  Include(Self.Load, Self.Page_Load);
end;
{$ENDREGION}

procedure TWebForm_request_item_detail.Page_Load(sender: System.Object; e: System.EventArgs);
var
  dr_factors: mysqldatareader;
  dr_services: mysqldatareader;
  dr_user_details: mysqldatareader;
  be_before_deadline: boolean;
  be_finalized: boolean;
  be_locked: boolean;
  be_new: boolean;
  biz_fiscal_years: TClass_biz_fiscal_years;
  cmdText: string;
begin
  if IsPostback then begin
    if assigned(session['request_item_detail.p']) then begin
      p := p_type(session['request_item_detail.p']);
    end else begin
      server.Transfer('~/timeout.aspx');
    end;
  end else begin
    if request.servervariables['URL'] = request.currentexecutionfilepath then begin
      session.Clear;
      server.Transfer('~/login.aspx');
    end;
    Title.InnerText := server.HtmlEncode(configurationmanager.AppSettings['application_name']) + ' - request_item_detail';
    //
    biz_fiscal_years := TClass_biz_fiscal_years.Create;
    p.biz_equipment := TClass_biz_equipment.Create;
    p.db := TClass_db.Create;
    p.db_trail := TClass_db_trail.Create;
    //
    p.db.Open;
    //
    // Set default match_level.
    //
    p.match_level := decimal.Parse
      (
      mysqlcommand.Create
        (
        'select factor'
        + ' from match_level join county_dictated_appropriation on (county_dictated_appropriation.match_level_id=match_level.id)'
        + ' where county_dictated_appropriation.id = ' + session['county_dictated_appropriation_id'].tostring,
        p.db.connection
        )
        .ExecuteScalar.tostring
      );
    //
    // Build cmdText_get_equipment_category_monetary_details
    //
    p.cmdText_get_equipment_category_monetary_details := 'select life_expectancy_years,'
    + ' allowable_cost,';
    if p.match_level = 0.60 then begin
      p.cmdText_get_equipment_category_monetary_details := p.cmdText_get_equipment_category_monetary_details
      + 'funding_level_rural as funding_level';
    end else if p.match_level = 1.00 then begin
      p.cmdText_get_equipment_category_monetary_details := p.cmdText_get_equipment_category_monetary_details
      + 'allowable_cost as funding_level';
    end else begin
      p.cmdText_get_equipment_category_monetary_details := p.cmdText_get_equipment_category_monetary_details
      + 'funding_level_nonrural as funding_level';
    end;
    p.cmdText_get_equipment_category_monetary_details := p.cmdText_get_equipment_category_monetary_details
    + ' from eligible_provider_equipment_list'
    + ' where fiscal_year_id = ' + biz_fiscal_years.IdOfDesignator(session['fiscal_year_designator'].tostring)
    +   ' and code = ';
    //    Mind these indices if the query changes.
    p.dri_equipment_category_allowable_cost := 1;
    p.dri_equipment_category_funding_level := 2;
    //
    be_before_deadline := session['be_before_service_to_county_submission_deadline'].tostring = 'True'; // Case matters.
    be_finalized := session['be_finalized'].tostring = 'True'; // Case matters.
    be_locked := (not be_before_deadline) or be_finalized;
    be_new := session['emsof_request_item_priority'].tostring = EMPTY;
    //
    // Manage whether or not the instruction ("-- Select --") appears at the top of DropDownList_equipment_category.
    //
    if be_new then begin
      DropDownList_equipment_category.Items.Add(listitem.Create('-- Select (then wait for form to refresh) --','0'));
    end;
    //
    // Manage the loading of nominal elements into DropDownList_equipment_category.
    //
    if be_new or (not be_locked) then begin
      //
      // Determine this service's eligibility factors.
      //
      dr_factors := mysqlcommand.Create
        (
        'select (be_als_amb or be_air_amb) as be_als_amb,'
        + ' (be_als_amb or be_als_squad) as be_als_squad,'
        + ' (be_bls_amb or be_als_amb) as be_bls_amb,'
        + ' (be_qrs or be_bls_amb or be_als_amb or be_als_squad) as be_qrs'
        + ' FROM service'
        + ' WHERE id = ' + session['service_user_id'].tostring,
        p.db.connection
        )
        .ExecuteReader;
      dr_factors.Read;
      cmdText := 'SELECT code,description FROM eligible_provider_equipment_list'
      + ' WHERE fiscal_year_id = ' + biz_fiscal_years.IdOfDesignator(session['fiscal_year_designator'].tostring)
      +   ' and (FALSE '; // Default to empty set
      if dr_factors['be_als_amb'].tostring = '1' then begin
        cmdText := cmdText + 'or be_eligible_als_amb = 1 ';
      end;
      if dr_factors['be_als_squad'].tostring = '1' then begin
        cmdText := cmdText + 'or be_eligible_als_squad = 1 ';
      end;
      if dr_factors['be_bls_amb'].tostring = '1' then begin
        cmdText := cmdText + 'or be_eligible_bls_amb = 1 ';
      end;
      if dr_factors['be_qrs'].tostring = '1' then begin
        cmdText := cmdText + 'or be_eligible_qrs = 1 ';
      end;
      cmdText := cmdText + ') ORDER BY description';
      dr_factors.Close;
      //
      dr_services := mysqlcommand.Create(cmdText,p.db.connection).ExecuteReader;
      while dr_services.Read do begin
        DropDownList_equipment_category.Items.Add(listitem.Create(dr_services['description'].tostring,dr_services['code'].ToString));
      end;
      dr_services.Close;
    end else begin
      DropDownList_equipment_category.Items.Add
        (
        listitem.Create
          (
          session['emsof_request_item_equipment_category'].tostring,
          session['emsof_request_item_code'].tostring
          )
        );
      //
    end;
    //
    // Manage the initially selected value in DropDownList_equipment_category and the availability of the submit/update/delete
    // options.
    //
    if not (be_new or be_locked) then begin
      DropDownList_equipment_category.selectedvalue := session['emsof_request_item_code'].tostring;
      Button_submit_and_repeat.visible := FALSE;
      Button_submit_and_stop.visible := FALSE;
      Button_update.visible := TRUE;
    end else begin
      TableRow_delete.visible := FALSE;
    end;
    //
    // Manage the filling of the other data elements.
    //
    if not be_new then begin
      //
      p.db.Close;
      ShowDependentData;
      p.db.Open;
      //
      dr_user_details := mysqlcommand.Create
        (
        'select make_model,place_kept,be_refurbished,unit_cost,quantity,additional_service_ante,emsof_ante'
        + ' from emsof_request_detail'
        + ' where master_id = ' + session['emsof_request_master_id'].tostring
        +   ' and priority = ' + session['emsof_request_item_priority'].tostring,
        p.db.connection
        )
        .ExecuteReader;
      dr_user_details.Read;
      TextBox_make_model.text := dr_user_details['make_model'].tostring;
      TextBox_place_kept.text := dr_user_details['place_kept'].tostring;
      if dr_user_details['be_refurbished'].tostring = '0' then begin
         RadioButtonList_condition.selectedindex := 0;
      end else begin
         RadioButtonList_condition.selectedindex := 1;
      end;
      TextBox_unit_cost.text := decimal.Parse(dr_user_details['unit_cost'].tostring).tostring('N2');
      TextBox_quantity.text := dr_user_details['quantity'].tostring;
      TextBox_additional_service_ante.text := decimal.Parse(dr_user_details['additional_service_ante'].tostring).tostring('N2');
      p.saved_emsof_ante := decimal.Parse(dr_user_details['emsof_ante'].tostring);
      p.saved_additional_service_ante := decimal.Parse(dr_user_details['additional_service_ante'].tostring);
      Label_emsof_ante.text := p.saved_emsof_ante.tostring('N2');
      dr_user_details.Close;
      //
      Recalculate;
      //
    end;
    //
    // Manage the availability of the remaining item-detail-related controls.
    //
    if be_locked then begin
      //
      DropDownList_equipment_category.enabled := FALSE;
      RequiredFieldValidator_equipment_category.enabled := FALSE;
      RangeValidator_equipment_category.enabled := FALSE;
      TextBox_make_model.enabled := FALSE;
      RequiredFieldValidator_make_model.enabled := FALSE;
      RegularExpressionValidator_make_model.enabled := FALSE;
      TextBox_place_kept.enabled := FALSE;
      RequiredFieldValidator_place_kept.enabled := FALSE;
      RegularExpressionValidator_place_kept.enabled := FALSE;
      RadioButtonList_condition.enabled := FALSE;
      RequiredFieldValidator_condition.enabled := FALSE;
      TextBox_unit_cost.enabled := FALSE;
      RequiredFieldValidator_unit_cost.enabled := FALSE;
      RegularExpressionValidator_unit_cost.enabled := FALSE;
      TextBox_quantity.enabled := FALSE;
      RequiredFieldValidator_quantity.enabled := FALSE;
      RegularExpressionValidator_quantity.enabled := FALSE;
      TextBox_additional_service_ante.enabled := FALSE;
      RegularExpressionValidator_additional_service_ante.enabled := FALSE;
      LinkButton_recalculate_1.visible := FALSE;
      LinkButton_recalculate_2.visible := FALSE;
      LinkButton_recalculate_3.visible := FALSE;
      Button_submit_and_repeat.visible := FALSE;
      Button_submit_and_stop.visible := FALSE;
      Button_update.visible := FALSE;
      Button_cancel.visible := FALSE;
      TableRow_post_finalization_actions.visible := TRUE;
      //
    end else begin
      TableRow_post_finalization_actions.visible := FALSE;
    end;
    //
    Button_withdraw.enabled := (uint32.Parse(session['status_code'].tostring) < 11);
    //
    p.db.Close;
    //
  end;
end;

procedure TWebForm_request_item_detail.OnInit(e: EventArgs);
begin
  //
  // Required for Designer support
  //
  InitializeComponent;
  inherited OnInit(e);
end;

procedure TWebForm_request_item_detail.CustomValidator_special_conditions_ServerValidate(source: System.Object;
  args: System.Web.UI.WebControls.ServerValidateEventArgs);
var
  special_rules_violation: string;
begin
  args.isvalid := TRUE;
  special_rules_violation := p.biz_equipment.SpecialRulesViolation
    (
    session['service_user_id'].tostring,
    session['emsof_request_master_id'].tostring,
    session['emsof_request_item_priority'].tostring,
    Safe(DropDownList_equipment_category.selectedvalue,NUM),
    Safe(TextBox_quantity.text,NUM)
    );
  if special_rules_violation <> EMPTY then begin
    args.isvalid := FALSE;
    CustomValidator_special_conditions.errormessage := special_rules_violation;
  end;
end;

procedure TWebForm_request_item_detail.TWebForm_request_item_detail_PreRender(sender: System.Object;
  e: System.EventArgs);
begin
  SessionSet('request_item_detail.p',p);
end;

procedure TWebForm_request_item_detail.Button_withdraw_Click(sender: System.Object;
  e: System.EventArgs);
begin
  SessionSet('emsof_request_item_make_model',Safe(TextBox_make_model.text,MAKE_MODEL));
  SessionSet('emsof_request_item_emsof_ante',Safe(Label_emsof_ante.text,REAL_NUM));
  SessionSet('emsof_request_item_additional_service_ante',p.saved_additional_service_ante.tostring);
  DropCrumbAndTransferTo('withdraw_request_item.aspx');
end;

procedure TWebForm_request_item_detail.Button_update_Click(sender: System.Object;
  e: System.EventArgs);
begin
  //
  Recalculate;  // Forces setting of additional_service_ante
  //
  if page.IsValid then begin
    p.db.Open;
    //
    // Update the detail record.
    // Update the master record.
    //
    mysqlcommand.Create
      (
      p.db_trail.Saved
        (
        'START TRANSACTION'
        + ';'
        + 'update emsof_request_detail'
        + ' set equipment_code = ' + Safe(DropDownList_equipment_category.selectedvalue,NUM) + COMMA
        +   ' make_model = "' + Safe(TextBox_make_model.text,MAKE_MODEL) + '",'
        +   ' place_kept = "' + Safe(TextBox_place_kept.text,PUNCTUATED) + '",'
        +   ' be_refurbished = ' + Safe(RadioButtonList_condition.selectedvalue,NUM) + COMMA
        +   ' quantity = ' + Safe(TextBox_quantity.text,NUM) + COMMA
        +   ' unit_cost = ' + Safe(TextBox_unit_cost.text,REAL_NUM) + COMMA
        +   ' additional_service_ante = ' + p.additional_service_ante.tostring + COMMA
        +   ' emsof_ante = ' + Safe(Label_emsof_ante.text,REAL_NUM)
        + ' where master_id = ' + session['emsof_request_master_id'].tostring
        +   ' and priority = ' + session['emsof_request_item_priority'].tostring
        + ';'
        + 'update emsof_request_master'
        + ' set value = value - ' + p.saved_emsof_ante.tostring + ' + ' + Safe(Label_emsof_ante.text,REAL_NUM)
        +   ' , shortage = shortage - ' + p.saved_additional_service_ante.tostring + ' + ' + p.additional_service_ante.tostring
        + ' where id = ' + session['emsof_request_master_id'].tostring
        + ';'
        + 'COMMIT;'
        ),
      p.db.connection
      )
      .ExecuteNonQuery;
    //
    p.db.Close;
    BackTrack;
  end;
end;

procedure TWebForm_request_item_detail.Button_delete_Click(sender: System.Object;
  e: System.EventArgs);
begin
  if CheckBox_delete.checked then begin
    p.db.Open;
    //
    // Delete the detail record.
    // Eliminate the resulting gap in the priority sequence.
    // Update the master record.
    //
    mysqlcommand.Create
      (
      p.db_trail.Saved
        (
        'START TRANSACTION'
        + ';'
        + 'delete from emsof_request_detail'
        + ' where master_id = ' + session['emsof_request_master_id'].tostring
        +   ' and priority = ' + session['emsof_request_item_priority'].tostring
        + ';'
        + 'update emsof_request_detail set priority = priority - 1'
        + ' where master_id = ' + session['emsof_request_master_id'].tostring
        +   ' and priority > ' + session['emsof_request_item_priority'].tostring
        + ';'
        + 'update emsof_request_master'
        + ' set value = value - ' + p.saved_emsof_ante.tostring
        +   ' , shortage = shortage - ' + p.saved_additional_service_ante.tostring
        +   ' , num_items = num_items - 1'
        + ' where id = ' + session['emsof_request_master_id'].tostring
        + ';'
        + 'COMMIT;'
        ),
      p.db.connection
      )
      .ExecuteNonQuery;
    p.db.Close;
    BackTrack;
  end;
end;

procedure TWebForm_request_item_detail.LinkButton_recalculate_3_Click(sender: System.Object;
  e: System.EventArgs);
begin
  Recalculate;
end;

procedure TWebForm_request_item_detail.LinkButton_recalculate_2_Click(sender: System.Object;
  e: System.EventArgs);
begin
  Recalculate;
end;

procedure TWebForm_request_item_detail.LinkButton_recalculate_1_Click(sender: System.Object;
  e: System.EventArgs);
begin
  Recalculate;
end;

procedure TWebForm_request_item_detail.Button_submit_and_stop_Click(sender: System.Object;
  e: System.EventArgs);
begin
  if page.isvalid then begin
    AddItem;
    BackTrack;
  end;
end;

procedure TWebForm_request_item_detail.Button_submit_and_repeat_Click(sender: System.Object;
  e: System.EventArgs);
begin
  if page.isvalid then begin
    AddItem;
    DropDownList_equipment_category.SelectedIndex := -1;
    Label_life_expectancy.text := '';
    TextBox_make_model.text := '';
    TextBox_place_kept.text := '';
    RadioButtonList_condition.selectedindex := -1;
    Label_allowable_cost.text := '';
    TextBox_unit_cost.text := '';
    TextBox_quantity.text := '';
    Label_total_cost.text := '';
    Label_min_service_ante.text := '';
    TextBox_additional_service_ante.text := '';
    Label_emsof_ante.text := '';
  end;
end;

procedure TWebForm_request_item_detail.DropDownList_equipment_category_SelectedIndexChanged(sender: System.Object;
  e: System.EventArgs);
begin
  ShowDependentData;
end;

procedure TWebForm_request_item_detail.Button_cancel_Click(sender: System.Object;
  e: System.EventArgs);
begin
  BackTrack;
end;

procedure TWebForm_request_item_detail.Recalculate;
var
  effective_emsof_ante: decimal;
  max_emsof_ante: decimal;
  quantity: decimal;
  total_cost: decimal;
  unit_cost: decimal;
begin
  if (Safe(TextBox_unit_cost.text,REAL_NUM) <> EMPTY) and (Safe(TextBox_quantity.text,NUM) <> EMPTY)
  then begin
    //
    unit_cost := decimal.Parse(Safe(TextBox_unit_cost.text,REAL_NUM));
    quantity := decimal.Parse(Safe(TextBox_quantity.text,NUM));
    if TextBox_additional_service_ante.text <> EMPTY then begin
      p.additional_service_ante := decimal.Parse(Safe(TextBox_additional_service_ante.text,REAL_NUM));
    end else begin
      p.additional_service_ante := 0;
    end;
    //
    total_cost := unit_cost*quantity;
    Label_total_cost.text := total_cost.tostring('N2');
    //
    if ((p.match_level = 1.00) and (p.allowable_cost = decimal.maxvalue))
        //
        // This is the zebra case where a distressed service wants an item with no specified allowable cost (initially an ambulance
        // or squad/response vehicle).  Basically, they can have whatever they want, up to the limit of the remainder of their
        // appropriation.  Consideration of their appropriation is not within the scope of this form, so we can indicate that the
        // request can be fully funded.
        //
      or ((unit_cost <= p.allowable_cost) and (p.funding_level = p.allowable_cost) and (p.allowable_cost < decimal.maxvalue))
        //
        // This is the case where items in an "equipment category" are always fully funded (up to the limit of a service's
        // appropriation, which is not within the scope of this form).  This initially describes only Data Collection Software and
        // the EMT-P Written Test.  The "Other - with external documentation" category is specifically excluded from this case.
        //
    then begin
      //
      max_emsof_ante := total_cost;
      //
    end else begin
      //
      if unit_cost > p.allowable_cost then begin
        max_emsof_ante := math.Max(p.allowable_cost*p.match_level,p.funding_level)*quantity;
      end else begin
        max_emsof_ante := total_cost*p.match_level;
      end;
      //
    end;
    //
    // A service may elect not to use the max_emsof_ante.  An example would be when they know that doing so, in the context of all
    // their other request items, would draw more EMSOF funds than they were appropriated.  So account for if they want to ante up
    // more of the cost themselves.
    //
    effective_emsof_ante := max_emsof_ante - p.additional_service_ante;
    //
    Label_emsof_ante.text := effective_emsof_ante.tostring('N2');
    Label_min_service_ante.text := (total_cost - max_emsof_ante).tostring('N2');
  end;
end;

procedure TWebForm_request_item_detail.AddItem;
var
  priority_string: string;
begin
  //
  Recalculate;  // Forces setting of additional_service_ante
  //
  p.db.Open;
  //
  //
  // Get the number of items entered against this request previously, and initialize this item to have a priority just lower than
  // all previous items.
  //
  priority_string := mysqlcommand.Create
    (
    'select (num_items + 1) from emsof_request_master where id = ' + session['emsof_request_master_id'].tostring,
    p.db.connection
    )
    .ExecuteScalar.tostring;
  //
  // Record the new request item.
  // Update the master record.
  //
  mysqlcommand.Create
    (
    p.db_trail.Saved
      (
      'START TRANSACTION'
      + ';'
      + 'insert into emsof_request_detail'
      + ' set master_id = ' + session['emsof_request_master_id'].tostring + COMMA
      +   ' equipment_code = ' + Safe(DropDownList_equipment_category.selectedvalue,NUM) + COMMA
      +   ' make_model = "' + Safe(TextBox_make_model.text,MAKE_MODEL) + '",'
      +   ' place_kept = "' + Safe(TextBox_place_kept.text,PUNCTUATED) + '",'
      +   ' be_refurbished = ' + Safe(RadioButtonList_condition.selectedvalue,NUM) + COMMA
      +   ' quantity = ' + Safe(TextBox_quantity.text,NUM) + COMMA
      +   ' unit_cost = ' + Safe(TextBox_unit_cost.text,REAL_NUM) + COMMA
      +   ' additional_service_ante = ' + p.additional_service_ante.tostring + COMMA
      +   ' emsof_ante = ' + Safe(Label_emsof_ante.text,REAL_NUM) + COMMA
      +   ' priority = ' + priority_string
      + ';'
      + 'update emsof_request_master'
      + ' set status_code = 2,'
      +   ' value = value + ' + Safe(Label_emsof_ante.text,REAL_NUM) + COMMA
      +   ' shortage = shortage + ' + p.additional_service_ante.tostring + COMMA
      +   ' num_items = num_items + 1'
      + ' where id = ' + session['emsof_request_master_id'].tostring
      + ';'
      + 'COMMIT;'
      ),
    p.db.connection
    )
    .ExecuteNonQuery;
  //
  p.db.Close;
end;

procedure TWebForm_request_item_detail.ShowDependentData;
var
  dr_state_details: mysqldatareader;
  life_expectancy_string: string;
begin
  p.db.Open;
  dr_state_details := mysqlcommand.Create
    (
    p.cmdText_get_equipment_category_monetary_details + Safe(DropDownList_equipment_category.SelectedValue,NUM),
    p.db.connection
    )
    .ExecuteReader;
  if dr_state_details.Read then begin
    //
    life_expectancy_string := dr_state_details['life_expectancy_years'].tostring;
    //
    if life_expectancy_string <> EMPTY then begin
      Label_life_expectancy.text := 'PA DOH EMSO expects this equipment to last ' + life_expectancy_string + ' years.';
      Label_life_expectancy.font.bold := TRUE;
    end else begin
      Label_life_expectancy.text := 'PA DOH EMSO has not specified a life expectancy for this category of equipment.';
      Label_life_expectancy.font.bold := FALSE;
    end;
    //
    if not dr_state_details.IsDbNull(p.dri_equipment_category_allowable_cost) then begin
      Label_allowable_cost.text := decimal.Parse(dr_state_details['allowable_cost'].tostring).tostring('N2');
      p.allowable_cost := decimal.Parse(Label_allowable_cost.text);
    end else begin
      Label_allowable_cost.text := '(none specified)';
      p.allowable_cost := decimal.maxvalue;
    end;
    //
    if not dr_state_details.IsDbNull(p.dri_equipment_category_funding_level) then begin
      p.funding_level := decimal.Parse(dr_state_details['funding_level'].tostring);
    end else begin
      p.funding_level := decimal.maxvalue;
    end;
    //
  end;
  dr_state_details.Close;
  p.db.Close;
  //
  Recalculate;
end;

end.


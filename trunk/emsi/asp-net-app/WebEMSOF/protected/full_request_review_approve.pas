
unit full_request_review_approve;

interface

uses
  System.Collections, System.ComponentModel,
  System.Data, System.Drawing, System.Web, System.Web.SessionState,
  System.Web.UI, System.Web.UI.WebControls, System.Web.UI.HtmlControls, ki.common, system.configuration, system.web.security,
  borland.data.provider,
  Class_biz_emsof_requests;

const ID = '$Id$';

type
  p_type =
    RECORD
    biz_emsof_requests: Class_biz_emsof_requests.TClass_biz_emsof_requests;
    be_before_improvement_deadline: boolean;
    num_items: cardinal;
    parent_appropriation_amount: decimal;
    total_emsof_ante: decimal;
    END;
  TWebForm_full_request_review_approve = class(System.Web.UI.Page)
  {$REGION 'Designer Managed Code'}
  strict private
    procedure InitializeComponent;
    procedure LinkButton_logout_Click(sender: System.Object; e: System.EventArgs);
    procedure DataGrid_items_ItemDataBound(sender: System.Object; e: System.Web.UI.WebControls.DataGridItemEventArgs);
    procedure Button_approve_Click(sender: System.Object; e: System.EventArgs);
    procedure Button_disapprove_Click(sender: System.Object; e: System.EventArgs);
    procedure TWebForm_full_request_review_approve_PreRender(sender: System.Object;
      e: System.EventArgs);
    procedure LinkButton_back_Click(sender: System.Object; e: System.EventArgs);
    procedure Button_mark_done_Click(sender: System.Object; e: System.EventArgs);
  {$ENDREGION}
  strict private
    p: p_type;
    procedure Page_Load(sender: System.Object; e: System.EventArgs);
  strict protected
    Title: System.Web.UI.HtmlControls.HtmlGenericControl;
    PlaceHolder_precontent: System.Web.UI.WebControls.PlaceHolder;
    PlaceHolder_postcontent: System.Web.UI.WebControls.PlaceHolder;
    LinkButton_logout: System.Web.UI.WebControls.LinkButton;
    HyperLink_change_password: System.Web.UI.WebControls.HyperLink;
    HyperLink_change_email_address: System.Web.UI.WebControls.HyperLink;
    Label_account_descriptor: System.Web.UI.WebControls.Label;
    Label_parent_appropriation_amount: System.Web.UI.WebControls.Label;
    Label_sponsor_county: System.Web.UI.WebControls.Label;
    Label_fiscal_year_designator: System.Web.UI.WebControls.Label;
    Label_sum_of_emsof_antes: System.Web.UI.WebControls.Label;
    Label_unused_amount: System.Web.UI.WebControls.Label;
    DataGrid_items: System.Web.UI.WebControls.DataGrid;
    Label_service_name: System.Web.UI.WebControls.Label;
    Label_affiliate_num: System.Web.UI.WebControls.Label;
    TableRow_sum_of_emsof_antes: System.Web.UI.HtmlControls.HtmlTableRow;
    TableRow_unrequested_amount: System.Web.UI.HtmlControls.HtmlTableRow;
    Label_num_items: System.Web.UI.WebControls.Label;
    CheckBox_approve: System.Web.UI.WebControls.CheckBox;
    Button_approve: System.Web.UI.WebControls.Button;
    Button_disapprove: System.Web.UI.WebControls.Button;
    Table_disposition: System.Web.UI.HtmlControls.HtmlTable;
    TableRow_return: System.Web.UI.HtmlControls.HtmlTableRow;
    TableRow_reject: System.Web.UI.HtmlControls.HtmlTableRow;
    Table_action_required: System.Web.UI.HtmlControls.HtmlTable;
    TextArea_disapproval_reason: System.Web.UI.HtmlControls.HtmlTextArea;
    Label_next_reviewer: System.Web.UI.WebControls.Label;
    LinkButton_back: System.Web.UI.WebControls.LinkButton;
    LinkButton_back_2: System.Web.UI.WebControls.LinkButton;
    CheckBox_mark_done: System.Web.UI.WebControls.CheckBox;
    Button_mark_done: System.Web.UI.WebControls.Button;
    Table_action_pending: System.Web.UI.HtmlControls.HtmlTable;
    Table_mark_done: System.Web.UI.HtmlControls.HtmlTable;
    Label_current_status: System.Web.UI.WebControls.Label;
    Label_sponsor_county_2: System.Web.UI.WebControls.Label;
    Label_county_approval_timestamp: System.Web.UI.WebControls.Label;
    Label_regional_planner_approval_timestamp: System.Web.UI.WebControls.Label;
    Label_regional_exec_dir_approval_timestamp: System.Web.UI.WebControls.Label;
    Table_prior_approvals: System.Web.UI.HtmlControls.HtmlTable;
    TableRow_regional_planner_approval_timestamp: System.Web.UI.HtmlControls.HtmlTableRow;
    TableRow_regional_exec_dir_approval_timestamp: System.Web.UI.HtmlControls.HtmlTableRow;
    Label_region_name_1: System.Web.UI.WebControls.Label;
    Label_region_name_2: System.Web.UI.WebControls.Label;
    procedure OnInit(e: EventArgs); override;
  private
    { Private Declarations }
  public
    { Public Declarations }
  end;

implementation

uses
  Class_biz_appropriations;

{$REGION 'Designer Managed Code'}
/// <summary>
/// Required method for Designer support -- do not modify
/// the contents of this method with the code editor.
/// </summary>
procedure TWebForm_full_request_review_approve.InitializeComponent;
begin
  Include(Self.LinkButton_logout.Click, Self.LinkButton_logout_Click);
  Include(Self.LinkButton_back.Click, Self.LinkButton_back_Click);
  Include(Self.DataGrid_items.ItemDataBound, Self.DataGrid_items_ItemDataBound);
  Include(Self.LinkButton_back_2.Click, Self.LinkButton_back_Click);
  Include(Self.Button_approve.Click, Self.Button_approve_Click);
  Include(Self.Button_disapprove.Click, Self.Button_disapprove_Click);
  Include(Self.Button_mark_done.Click, Self.Button_mark_done_Click);
  Include(Self.Load, Self.Page_Load);
  Include(Self.PreRender, Self.TWebForm_full_request_review_approve_PreRender);
end;
{$ENDREGION}

procedure TWebForm_full_request_review_approve.Page_Load
  (
  sender: System.Object;
  e: System.EventArgs
  );
var
  request_id: string;
  status: Class_biz_emsof_requests.status_type;
  timestamp: datetime;
begin
  ki.common.PopulatePlaceHolders(PlaceHolder_precontent,PlaceHolder_postcontent);
  if IsPostback and (session['p'].GetType.namespace = p.GetType.namespace) then begin
    p := p_type(session['p']);
  end else begin
    //
    Title.InnerText := server.HtmlEncode(ConfigurationSettings.AppSettings['application_name']) + ' - full_request_review_approve';
    Label_account_descriptor.text := session['account_descriptor'].tostring;
    //
    // Initialize class private data members.
    //
    p.biz_emsof_requests := Class_biz_emsof_requests.TClass_biz_emsof_requests.Create;
    p.num_items := 0;
    p.total_emsof_ante := 0;
    //
    // Initialize local vars.
    //
    request_id := p.biz_emsof_requests.IdOf(session['e_item']);
    status := p.biz_emsof_requests.StatusOf(session['e_item']);
    //
    Label_fiscal_year_designator.text := p.biz_emsof_requests.FyDesignatorOf(session['e_item']);
    Label_service_name.text := p.biz_emsof_requests.ServiceNameOf(session['e_item']);
    Label_affiliate_num.text := p.biz_emsof_requests.AffiliateNumOf(session['e_item']);
    p.parent_appropriation_amount :=
      TClass_biz_appropriations.Create.ParentAppropriationOfEmsofRequest(p.biz_emsof_requests.IdOf(session['e_item']));
    Label_parent_appropriation_amount.text := p.parent_appropriation_amount.tostring('C');
    Label_sponsor_county.text := p.biz_emsof_requests.SponsorCountyNameOf(session['e_item']);
    //
    Table_prior_approvals.visible := FALSE;
    TableRow_regional_planner_approval_timestamp.visible := FALSE;
    TableRow_regional_exec_dir_approval_timestamp.visible := FALSE;
    //
    if status > NEEDS_COUNTY_APPROVAL then begin
      Table_prior_approvals.visible := TRUE;
      Label_sponsor_county_2.text := Label_sponsor_county.text;
      Label_county_approval_timestamp.text :=
        p.biz_emsof_requests.CountyApprovalTimestampOf(request_id).tostring('HH:mm:ss dddd, MMMM d, yyyy');
      if status > NEEDS_REGIONAL_COMPLIANCE_CHECK then begin
        if p.biz_emsof_requests.BeValidRegionalPlannerApprovalTimestampOf(request_id,timestamp) then begin
          TableRow_regional_planner_approval_timestamp.visible := TRUE;
          Label_region_name_1.text := p.biz_emsof_requests.SponsorRegionNameOf(p.biz_emsof_requests.IdOf(session['e_item']));
          Label_regional_planner_approval_timestamp.text := timestamp.tostring('HH:mm:ss dddd, MMMM d, yyyy');
        end;
        if status > NEEDS_REGIONAL_EXEC_DIR_APPROVAL then begin
          if p.biz_emsof_requests.BeValidRegionalExecDirApprovalTimestampOf(request_id,timestamp) then begin
            TableRow_regional_exec_dir_approval_timestamp.visible := TRUE;
            Label_region_name_2.text := Label_region_name_1.text;
            Label_regional_exec_dir_approval_timestamp.text := timestamp.tostring('HH:mm:ss dddd, MMMM d, yyyy');
          end;
        end;
      end;
    end;
    //
    p.biz_emsof_requests.BindDetail(request_id,DataGrid_items);
    //
    Label_sum_of_emsof_antes.text := p.total_emsof_ante.tostring('C');
    Label_unused_amount.text := (p.parent_appropriation_amount - p.total_emsof_ante).tostring('C');
    Label_num_items.text := p.num_items.tostring;
    //
    if p.biz_emsof_requests.BeOkToApproveEmsofRequest(status) then begin
      Label_next_reviewer.text :=
        p.biz_emsof_requests.NextReviewer(status);
      if datetime.Now <= p.biz_emsof_requests.ReworkDeadline(session['e_item']) then begin
        TableRow_reject.visible := FALSE;
        Button_disapprove.text := 'Return';
      end else begin
        TableRow_return.visible := FALSE;
        Button_disapprove.text := 'REJECT';
      end;
    end else begin
      Table_action_required.visible := FALSE;
      Table_disposition.visible := FALSE;
    end;
    //
    if p.biz_emsof_requests.BeOkToMarkDone(status) then begin
      Label_current_status.text := system.object(status).tostring;
    end else begin
      Table_action_pending.visible := FALSE;
      Table_mark_done.visible := FALSE;
    end;
    //
  end;
end;

procedure TWebForm_full_request_review_approve.OnInit(e: EventArgs);
begin
  //
  // Required for Designer support
  //
  InitializeComponent;
  inherited OnInit(e);
end;

procedure TWebForm_full_request_review_approve.Button_mark_done_Click(sender: System.Object;
  e: System.EventArgs);
begin
  if CheckBox_mark_done.checked then begin
    p.biz_emsof_requests.MarkDone(session['e_item'],session['account_descriptor'].tostring);
    server.Transfer(stack(session['waypoint_stack']).Pop.tostring);
  end;
end;

procedure TWebForm_full_request_review_approve.LinkButton_back_Click(sender: System.Object;
  e: System.EventArgs);
begin
  server.Transfer(stack(session['waypoint_stack']).Pop.tostring);
end;

procedure TWebForm_full_request_review_approve.TWebForm_full_request_review_approve_PreRender(sender: System.Object;
  e: System.EventArgs);
begin
  session.Remove('p');
  session.Add('p',p);
end;

procedure TWebForm_full_request_review_approve.Button_disapprove_Click
  (
  sender: System.Object;
  e: System.EventArgs
  );
begin
  if TextArea_disapproval_reason.Value <> system.string.EMPTY then begin
    p.biz_emsof_requests.Demote
      (
      session['e_item'],
      session['account_descriptor'].tostring,
      Safe(TextArea_disapproval_reason.value,NARRATIVE),
      Safe(Label_sum_of_emsof_antes.text,CURRENCY_USA)
      );
    server.Transfer(stack(session['waypoint_stack']).Pop.tostring);
  end;
end;

procedure TWebForm_full_request_review_approve.Button_approve_Click
  (
  sender: System.Object;
  e: System.EventArgs
  );
begin
  if CheckBox_approve.checked then begin
    p.biz_emsof_requests.Approve(session['e_item'],session['account_descriptor'].tostring);
    server.Transfer(stack(session['waypoint_stack']).Pop.tostring);
  end;
end;

procedure TWebForm_full_request_review_approve.DataGrid_items_ItemDataBound(sender: System.Object;
  e: System.Web.UI.WebControls.DataGridItemEventArgs);
begin
  if (e.item.itemtype = listitemtype.alternatingitem)
    or (e.item.itemtype = listitemtype.edititem)
    or (e.item.itemtype = listitemtype.item)
    or (e.item.itemtype = listitemtype.selecteditem)
  then begin
    //
    // We are dealing with a data row, not a header or footer row.
    //
    p.num_items := p.num_items + 1;
    p.total_emsof_ante := p.total_emsof_ante
      + decimal.Parse(databinder.Eval(e.item.dataitem,p.biz_emsof_requests.PropertyNameOfEmsofAnte).tostring);
  end;
end;

procedure TWebForm_full_request_review_approve.LinkButton_logout_Click(sender: System.Object;
  e: System.EventArgs);
begin
  formsauthentication.SignOut;
  session.Clear;
  server.Transfer('../Default.aspx');
end;

end.


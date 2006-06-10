
unit full_request_review_approve;

interface

uses
  System.Collections, System.ComponentModel,
  System.Data, System.Drawing, System.Web, System.Web.SessionState,
  System.Web.UI, System.Web.UI.WebControls, System.Web.UI.HtmlControls, AppCommon, system.configuration, system.web.security,
  borland.data.provider,
  Class_bc_appropriations,
  Class_bc_emsof_request;

const ID = '$Id$';

type
  p_type =
    RECORD
    bc_emsof_requests: Class_bc_emsof_request.TClass_bc_emsof_request;
    be_before_improvement_deadline: boolean;
    num_items: cardinal;
    parent_appropriation_amount: decimal;
    total_emsof_ante: decimal;
    END;

type
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
  {$ENDREGION}
  //
  // Expected session objects:
  //
  //   calling_form: string;
  //   account_descriptor: string;
  //   e_item: System.Web.UI.WebControls.DataGridItem;
  //   status_of_interest: Class_bc_emsof_request.status_type;
  //
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
    HyperLink_back: System.Web.UI.WebControls.HyperLink;
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
    HyperLink_back_2: System.Web.UI.WebControls.HyperLink;
    CheckBox_approve: System.Web.UI.WebControls.CheckBox;
    Button_approve: System.Web.UI.WebControls.Button;
    Button_disapprove: System.Web.UI.WebControls.Button;
    Table_disposition: System.Web.UI.HtmlControls.HtmlTable;
    TableRow_return: System.Web.UI.HtmlControls.HtmlTableRow;
    TableRow_reject: System.Web.UI.HtmlControls.HtmlTableRow;
    Table_action_required: System.Web.UI.HtmlControls.HtmlTable;
    TextArea_disapproval_reason: System.Web.UI.HtmlControls.HtmlTextArea;
    Label_next_approver: System.Web.UI.WebControls.Label;
    procedure OnInit(e: EventArgs); override;
  private
    { Private Declarations }
  public
    { Public Declarations }
  end;

implementation

{$REGION 'Designer Managed Code'}
/// <summary>
/// Required method for Designer support -- do not modify
/// the contents of this method with the code editor.
/// </summary>
procedure TWebForm_full_request_review_approve.InitializeComponent;
begin
  Include(Self.LinkButton_logout.Click, Self.LinkButton_logout_Click);
  Include(Self.DataGrid_items.ItemDataBound, Self.DataGrid_items_ItemDataBound);
  Include(Self.Button_approve.Click, Self.Button_approve_Click);
  Include(Self.Button_disapprove.Click, Self.Button_disapprove_Click);
  Include(Self.Load, Self.Page_Load);
  Include(Self.PreRender, Self.TWebForm_full_request_review_approve_PreRender);
end;
{$ENDREGION}

procedure TWebForm_full_request_review_approve.Page_Load
  (
  sender: System.Object;
  e: System.EventArgs
  );
begin
  AppCommon.PopulatePlaceHolders(PlaceHolder_precontent,PlaceHolder_postcontent);
  if IsPostback then begin
    p := p_type(session['p']);
  end else begin
    //
    Title.InnerText := server.HtmlEncode(ConfigurationSettings.AppSettings['application_name']) + ' - full_request_review_approve';
    HyperLink_back.navigateurl := session['calling_form'].tostring;
    Label_account_descriptor.text := session['account_descriptor'].tostring;
    //
    // Initialize class private data members.
    //
    p.bc_emsof_requests := Class_bc_emsof_request.TClass_bc_emsof_request.Create;
    p.num_items := 0;
    p.total_emsof_ante := 0;
    //
    Label_fiscal_year_designator.text := p.bc_emsof_requests.FyDesignatorOf(session['e_item']);
    Label_service_name.text := p.bc_emsof_requests.ServiceNameOf(session['e_item']);
    Label_affiliate_num.text := p.bc_emsof_requests.AffiliateNumOf(session['e_item']);
    Label_parent_appropriation_amount.text := TClass_bc_appropriations.Create.AppropriationFromSpecificParent
      (
      p.bc_emsof_requests.SponsorCountyCodeOf(session['e_item']),
      'service',
      p.bc_emsof_requests.IdOf(session['e_item'])
      )
      .tostring('C');
    Label_sponsor_county.text := p.bc_emsof_requests.SponsorCountyNameOf(session['e_item']);
    //
    p.bc_emsof_requests.BindDetail(p.bc_emsof_requests.IdOf(session['e_item']),DataGrid_items);
    //
    Label_sum_of_emsof_antes.text := p.total_emsof_ante.tostring('C');
    Label_unused_amount.text := (p.parent_appropriation_amount - p.total_emsof_ante).tostring('C');
    Label_num_items.text := p.num_items.tostring;
    //
    if p.bc_emsof_requests.BeOkToApproveEmsofRequest(status_type(session['status_of_interest'])) then begin
      HyperLink_back_2.navigateurl := session['calling_form'].tostring;
      Label_next_approver.text :=
        p.bc_emsof_requests.NextApprover(status_type(session['status_of_interest']));
      if datetime.Now <= p.bc_emsof_requests.ReworkDeadline(session['e_item']) then begin
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
    p.bc_emsof_requests.Demote
      (
      session['e_item'],
      status_type(session['status_of_interest']),
      session['account_descriptor'].tostring,
      Safe(TextArea_disapproval_reason.value,NARRATIVE),
      Safe(Label_sum_of_emsof_antes.text,CURRENCY_USA)
      );
    server.Transfer(session['calling_form'].tostring);
  end;
end;

procedure TWebForm_full_request_review_approve.Button_approve_Click
  (
  sender: System.Object;
  e: System.EventArgs
  );
var
  cmdText: string;
  new_status_description: string;
  next_approver_email_address: string;
  reviewer_descriptor: string;
  service_email_address: string;
begin
  if CheckBox_approve.checked then begin
    p.bc_emsof_requests.Promote
      (session['e_item'],status_type(session['status_of_interest']),session['account_descriptor'].tostring);
    server.Transfer(session['calling_form'].tostring);
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
    p.total_emsof_ante := p.total_emsof_ante + decimal.Parse(databinder.Eval(e.item.dataitem,'emsof_ante').tostring);
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


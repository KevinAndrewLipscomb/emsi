
unit add_proof_of_payment;

interface

uses
  System.Collections, System.ComponentModel,
  System.Data, System.Drawing, System.Web, System.Web.SessionState,
  System.Web.UI, System.Web.UI.WebControls, System.Web.UI.HtmlControls, system.configuration, system.web.security,
  appcommon,
  Class_biz_emsof_requests,
  Class_biz_payment_proof_methods,
  ki_web_ui;

const ID = '$Id$';

type
  p_type =
    RECORD
    amount: decimal;
    biz_emsof_requests: TClass_biz_emsof_requests;
    biz_payment_proof_methods: TClass_biz_payment_proof_methods;
    END;
  TWebForm_add_proof_of_payment = class(ki_web_ui.page_class)
  {$REGION 'Designer Managed Code'}
  strict private
    procedure InitializeComponent;
    procedure LinkButton_logout_Click(sender: System.Object; e: System.EventArgs);
    procedure TWebForm_add_proof_of_payment_PreRender(sender: System.Object;
      e: System.EventArgs);
    procedure LinkButton_change_password_Click(sender: System.Object;
      e: System.EventArgs);
    procedure LinkButton_change_email_address_Click(sender: System.Object;
      e: System.EventArgs);
    procedure LinkButton_back_Click(sender: System.Object; e: System.EventArgs);
    procedure Button_cancel_Click(sender: System.Object; e: System.EventArgs);
    procedure Button_submit_Click(sender: System.Object; e: System.EventArgs);
    procedure CustomValidator_amount_ServerValidate(source: System.Object; args: System.Web.UI.WebControls.ServerValidateEventArgs);
  {$ENDREGION}
  //
  // Expected session objects:
  //
  //   waypoint_stack: system.collections.stack;
  //
  //
  strict private
    p: p_type;
    procedure Page_Load(sender: System.Object; e: System.EventArgs);
  strict protected
    Title: System.Web.UI.HtmlControls.HtmlGenericControl;
    PlaceHolder_precontent: System.Web.UI.WebControls.PlaceHolder;
    PlaceHolder_postcontent: System.Web.UI.WebControls.PlaceHolder;
    LinkButton_logout: System.Web.UI.WebControls.LinkButton;
    LinkButton_change_password: System.Web.UI.WebControls.LinkButton;
    LinkButton_change_email_address: System.Web.UI.WebControls.LinkButton;
    Label_account_descriptor: System.Web.UI.WebControls.Label;
    LinkButton_back: System.Web.UI.WebControls.LinkButton;
    Button_submit: System.Web.UI.WebControls.Button;
    Button_cancel: System.Web.UI.WebControls.Button;
    RequiredFieldValidator_method: System.Web.UI.WebControls.RequiredFieldValidator;
    TextBox_amount: System.Web.UI.WebControls.TextBox;
    TextBox_note: System.Web.UI.WebControls.TextBox;
    RequiredFieldValidator_amount: System.Web.UI.WebControls.RequiredFieldValidator;
    RegularExpressionValidator_amount: System.Web.UI.WebControls.RegularExpressionValidator;
    Label_service_name: System.Web.UI.WebControls.Label;
    Calendar_date_of_payment: System.Web.UI.WebControls.Calendar;
    DropDownList_methods: System.Web.UI.WebControls.DropDownList;
    CustomValidator_amount: System.Web.UI.WebControls.CustomValidator;
    procedure OnInit(e: EventArgs); override;
  private
    { Private Declarations }
  public
    { Public Declarations }
  end;

implementation

uses
  ki;

{$REGION 'Designer Managed Code'}
/// <summary>
/// Required method for Designer support -- do not modify
/// the contents of this method with the code editor.
/// </summary>
procedure TWebForm_add_proof_of_payment.InitializeComponent;
begin
  Include(Self.LinkButton_logout.Click, Self.LinkButton_logout_Click);
  Include(Self.LinkButton_back.Click, Self.LinkButton_back_Click);
  Include(Self.LinkButton_change_password.Click, Self.LinkButton_change_password_Click);
  Include(Self.LinkButton_change_email_address.Click, Self.LinkButton_change_email_address_Click);
  Include(Self.CustomValidator_amount.ServerValidate, Self.CustomValidator_amount_ServerValidate);
  Include(Self.Button_submit.Click, Self.Button_submit_Click);
  Include(Self.Button_cancel.Click, Self.Button_cancel_Click);
  Include(Self.Load, Self.Page_Load);
  Include(Self.PreRender, Self.TWebForm_add_proof_of_payment_PreRender);
end;
{$ENDREGION}

procedure TWebForm_add_proof_of_payment.Page_Load(sender: System.Object; e: System.EventArgs);
begin
  appcommon.PopulatePlaceHolders(PlaceHolder_precontent,PlaceHolder_postcontent);
  if IsPostback and (session['p'].GetType.namespace = p.GetType.namespace) then begin
    p := p_type(session['p']);
  end else begin
    if request.servervariables['URL'] = request.currentexecutionfilepath then begin
      //
      // The request for this page could not have been the result of a server.Transfer call, and the session state is therefore unknown.  This is rarely allowed.
      //
      session.Clear;
      server.Transfer('~/login.aspx');
    end else begin
      //
      Title.InnerText := server.HtmlEncode(ConfigurationSettings.AppSettings['application_name']) + ' - add_proof_of_payment';
      Label_account_descriptor.text := session.item['account_descriptor'].tostring;
      //
      p.biz_emsof_requests := TClass_biz_emsof_requests.Create;
      p.biz_payment_proof_methods := TClass_biz_payment_proof_methods.Create;
      //
      Label_service_name.text := p.biz_emsof_requests.ServiceNameOf(session['e_item']);
      Calendar_date_of_payment.selecteddate := datetime.today;
      p.biz_payment_proof_methods.BindDropDownList(DropDownList_methods);
      //
    end;
  end;
end;

procedure TWebForm_add_proof_of_payment.OnInit(e: EventArgs);
begin
  //
  // Required for Designer support
  //
  InitializeComponent;
  inherited OnInit(e);
end;

procedure TWebForm_add_proof_of_payment.CustomValidator_amount_ServerValidate(source: System.Object;
  args: System.Web.UI.WebControls.ServerValidateEventArgs);
var
  amount_string: string;
begin
  amount_string := Safe(args.value,REAL_NUM);
  if amount_string = system.string.EMPTY then begin
    args.isvalid := FALSE;
  end else begin
    p.amount := decimal.Parse(amount_string);
    args.isvalid := (p.amount > 0);
  end;
end;

procedure TWebForm_add_proof_of_payment.Button_submit_Click(sender: System.Object;
  e: System.EventArgs);
var
  timestamp: datetime;
begin
  if p.biz_emsof_requests.BeValidStateApprovalTimestampOf(p.biz_emsof_requests.IdOf(session['e_item']),timestamp)
    and (Calendar_date_of_payment.selecteddate >= timestamp.Date)
    and (Calendar_date_of_payment.selecteddate < datetime.Now)
  then begin
    p.biz_emsof_requests.AddProofOfPayment
      (
      p.biz_emsof_requests.IdOf(session['e_item']),
      Calendar_date_of_payment.selecteddate,
      Safe(DropDownList_methods.selectedvalue,NUM),
      p.amount,
      Safe(TextBox_note.text,NARRATIVE)
      );
  end;
  server.Transfer(stack(session['waypoint_stack']).Pop.tostring);
end;

procedure TWebForm_add_proof_of_payment.Button_cancel_Click(sender: System.Object;
  e: System.EventArgs);
begin
  server.Transfer(stack(session['waypoint_stack']).Pop.tostring);
end;

procedure TWebForm_add_proof_of_payment.LinkButton_change_email_address_Click(sender: System.Object;
  e: System.EventArgs);
begin
  server.Transfer('change_email_address.aspx');
end;

procedure TWebForm_add_proof_of_payment.LinkButton_change_password_Click(sender: System.Object;
  e: System.EventArgs);
begin
  server.Transfer('change_password.aspx');
end;

procedure TWebForm_add_proof_of_payment.LinkButton_back_Click(sender: System.Object;
  e: System.EventArgs);
begin
  server.Transfer(stack(session['waypoint_stack']).Pop.tostring);
end;

procedure TWebForm_add_proof_of_payment.TWebForm_add_proof_of_payment_PreRender(sender: System.Object;
  e: System.EventArgs);
begin
  session.Remove('p');
  session.Add('p',p);
end;

procedure TWebForm_add_proof_of_payment.LinkButton_logout_Click(sender: System.Object;
  e: System.EventArgs);
begin
  formsauthentication.SignOut;
  session.Clear;
  server.Transfer('../Default.aspx');
end;

end.


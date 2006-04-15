
unit create_new_service_appropriation;

interface

uses
  System.Collections, System.ComponentModel,
  System.Data, System.Drawing, System.Web, System.Web.SessionState,
  System.Web.UI, System.Web.UI.WebControls, System.Web.UI.HtmlControls, AppCommon, system.configuration, borland.data.provider,
  system.web.mail;

type
  TWebForm_create_new_service_appropriation = class(System.Web.UI.Page)
  {$REGION 'Designer Managed Code'}
  strict private
    procedure InitializeComponent;
    procedure Button_add_appropriation_and_repeat_Click(sender: System.Object;
      e: System.EventArgs);
    procedure Button_cancel_Click(sender: System.Object; e: System.EventArgs);
    procedure Button_add_appropriation_and_stop_Click(sender: System.Object;
      e: System.EventArgs);
  {$ENDREGION}
  strict private
    procedure Page_Load(sender: System.Object; e: System.EventArgs);
    procedure AddAppropriation(amount_string: string; service_id_string: string);
  strict protected
    Title: System.Web.UI.HtmlControls.HtmlGenericControl;
    PlaceHolder_precontent: System.Web.UI.WebControls.PlaceHolder;
    PlaceHolder_postcontent: System.Web.UI.WebControls.PlaceHolder;
    DropDownList_services: System.Web.UI.WebControls.DropDownList;
    RangeValidator_service: System.Web.UI.WebControls.RangeValidator;
    TextBox_new_amount: System.Web.UI.WebControls.TextBox;
    RequiredFieldValidator_new_amount: System.Web.UI.WebControls.RequiredFieldValidator;
    RegularExpressionValidator_new_amount: System.Web.UI.WebControls.RegularExpressionValidator;
    Button_add_appropriation_and_repeat: System.Web.UI.WebControls.Button;
    RequiredFieldValidator_service: System.Web.UI.WebControls.RequiredFieldValidator;
    Button_add_appropriation_and_stop: System.Web.UI.WebControls.Button;
    Button_cancel: System.Web.UI.WebControls.Button;
    procedure OnInit(e: EventArgs); override;
  private
  public
    { Public Declarations }
  end;

implementation

{$REGION 'Designer Managed Code'}
/// <summary>
/// Required method for Designer support -- do not modify
/// the contents of this method with the code editor.
/// </summary>
procedure TWebForm_create_new_service_appropriation.InitializeComponent;
begin
  Include(Self.Button_add_appropriation_and_repeat.Click, Self.Button_add_appropriation_and_repeat_Click);
  Include(Self.Button_add_appropriation_and_stop.Click, Self.Button_add_appropriation_and_stop_Click);
  Include(Self.Button_cancel.Click, Self.Button_cancel_Click);
  Include(Self.Load, Self.Page_Load);
end;
{$ENDREGION}

const ID = '$Id$';

procedure TWebForm_create_new_service_appropriation.Page_Load(sender: System.Object; e: System.EventArgs);
var
  bc_get_services: borland.data.provider.BdpCommand;
  bdr_services: borland.data.provider.BdpDataReader;
begin
  AppCommon.PopulatePlaceHolders(PlaceHolder_precontent,PlaceHolder_postcontent);
  if not IsPostback then
    begin
    Title.InnerText := server.HtmlEncode(ConfigurationSettings.AppSettings['application_name']) + ' - create_new_service_appropriation';
    //
    // Fill DropDownList_services.
    //
    DropDownList_services.Items.Add(listitem.Create('-- Select --','0'));
    bc_get_services := Borland.Data.Provider.BdpCommand.Create
      (
      'SELECT id,name FROM service_user JOIN service using (id) ORDER BY name',
      AppCommon.BdpConnection
      );
    appcommon.bdpconnection.Open;
    bdr_services := bc_get_services.ExecuteReader;
    while bdr_services.Read do
      DropDownList_services.Items.Add(listitem.Create(bdr_services['name'].tostring,bdr_services['id'].ToString));
    end;
    appcommon.bdpconnection.Close;
end;

procedure TWebForm_create_new_service_appropriation.OnInit(e: EventArgs);
begin
  //
  // Required for Designer support
  //
  InitializeComponent;
  inherited OnInit(e);
end;

procedure TWebForm_create_new_service_appropriation.Button_add_appropriation_and_stop_Click(sender: System.Object;
  e: System.EventArgs);
begin
  AddAppropriation(Safe(TextBox_new_amount.Text.Trim,REAL_NUM),Safe(DropDownList_services.SelectedValue,NUM));
  server.Transfer('county_dictated_appropriations.aspx');
end;

procedure TWebForm_create_new_service_appropriation.Button_cancel_Click(sender: System.Object;
  e: System.EventArgs);
begin
  server.Transfer('county_dictated_appropriations.aspx');
end;

procedure TWebForm_create_new_service_appropriation.Button_add_appropriation_and_repeat_Click(sender: System.Object;
  e: System.EventArgs);
begin
  AddAppropriation(Safe(TextBox_new_amount.Text.Trim,REAL_NUM),Safe(DropDownList_services.SelectedValue,NUM));
  TextBox_new_amount.Text := system.string.EMPTY;
  DropDownList_services.SelectedIndex := -1;
end;

procedure TWebForm_create_new_service_appropriation.AddAppropriation
  (
  amount_string: string;
  service_id_string: string
  );
var
  amount: decimal;
  bc_get_cc_email_address: borland.data.provider.bdpcommand;
  bc_get_fy_designator: borland.data.provider.bdpcommand;
  bc_get_service_email_address: borland.data.provider.bdpcommand;
  bc_insert_appropriation: borland.data.provider.bdpcommand;
begin
  if amount_string <> system.string.EMPTY then begin
    amount := decimal.Parse(amount_string);
    if amount > 0 then begin
      appcommon.bdpconnection.Open;
      //
      // Record the new appropriation.
      //
      bc_insert_appropriation := borland.data.provider.bdpcommand.Create
        (
        'insert into county_dictated_appropriation'
        + ' set region_dictated_appropriation_id = ' + session.Item['region_dictated_appropriation_id'].tostring + ','
        +   ' service_id = ' + service_id_string + ','
        +   ' amount = ' + amount.tostring,
        appcommon.bdpconnection
        );
      bc_insert_appropriation.ExecuteNonQuery;
      //
      // Send notice of the appropriation to the service's email address of record.
      //
      //   Set up the command to get service's email address of record.
      bc_get_service_email_address := borland.data.provider.bdpcommand.Create
        (
        'select password_reset_email_address from service_user '
        + 'where id ="' + service_id_string + '"',
        AppCommon.BdpConnection
        );
      //   Set up the command to get the appropriate fiscal year designator.
      bc_get_fy_designator := borland.data.provider.bdpcommand.Create
        (
        'select designator'
        + ' from fiscal_year'
        +   ' join state_dictated_appropriation on (state_dictated_appropriation.fiscal_year_id=fiscal_year.id)'
        +   ' join region_dictated_appropriation'
        +     ' on (region_dictated_appropriation.state_dictated_appropriation_id=state_dictated_appropriation.id)'
        + ' where region_dictated_appropriation.id = ' + session.Item['region_dictated_appropriation_id'].tostring,
        appcommon.bdpconnection
        );
      //   Set up the command to get the County Coorindator's email address.
      bc_get_cc_email_address := borland.data.provider.bdpcommand.Create
        (
        'select password_reset_email_address from county_user where id ="' + session.item['county_user_id'].tostring + '"',
        AppCommon.BdpConnection
        );
      //   Send the email message.
      smtpmail.SmtpServer := ConfigurationSettings.AppSettings['smtp_server'];
      smtpmail.Send
        (
        bc_get_cc_email_address.ExecuteScalar.tostring,
        bc_get_service_email_address.ExecuteScalar.tostring,
        'New ' + ConfigurationSettings.AppSettings['application_name'] + ' appropriation for your service',
        'The ' + session.Item['county_name'].ToString + ' County EMSOF Coordinator has made a new EMSOF appropriation of '
        + amount.tostring('C') + ' to your service for ' + bc_get_fy_designator.ExecuteScalar.tostring + '.' + NEW_LINE
        + NEW_LINE
        + 'You can work on this appropriation by visiting:' + NEW_LINE
        + NEW_LINE
        + '   http://' + ConfigurationSettings.AppSettings['host_domain_name'] + '/'
        + server.UrlEncode(ConfigurationSettings.AppSettings['application_name']) + '/main.aspx' + NEW_LINE
        + NEW_LINE
        + 'Replies to this message will be addressed to the ' + session.Item['county_name'].ToString + ' County EMSOF Coordinator.'
        + NEW_LINE
        + NEW_LINE
        + '-- ' + ConfigurationSettings.AppSettings['application_name']
        );
      //
      appcommon.bdpconnection.Close;
    end;
  end;
end;

end.


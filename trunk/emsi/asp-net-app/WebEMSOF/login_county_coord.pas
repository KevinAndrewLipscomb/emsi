
unit login_county_coord;

interface

uses
  System.Collections, System.ComponentModel,
  System.Data, System.Drawing, System.Web, System.Web.SessionState,
  System.Web.UI, System.Web.UI.WebControls, System.Web.UI.HtmlControls,
  AppCommon, Borland.Data.Provider, System.Globalization, 
  System.Data.SqlClient, System.Data.Common, system.configuration, borland.vcl.sysutils;

type
  TWebForm_login_county_coord = class(System.Web.UI.Page)
  {$REGION 'Designer Managed Code'}
  strict private
    procedure InitializeComponent;
    procedure Button_log_in_Click(sender: System.Object; e: System.EventArgs);
    procedure Button_new_password_Click(sender: System.Object; e: System.EventArgs);
    procedure DropDownList_county_SelectedIndexChanged(sender: System.Object;
      e: System.EventArgs);
  {$ENDREGION}
  strict private
    procedure Page_Load(sender: System.Object; e: System.EventArgs);
  strict protected
    Title: System.Web.UI.HtmlControls.HtmlGenericControl;
    invalid_credentials_warning: System.Web.UI.HtmlControls.HtmlGenericControl;
    TextBox_password: System.Web.UI.WebControls.TextBox;
    Button_log_in: System.Web.UI.WebControls.Button;
    CheckBox_keep_me_logged_in: System.Web.UI.WebControls.CheckBox;
    DropDownList_county: System.Web.UI.WebControls.DropDownList;
    PlaceHolder_precontent: System.Web.UI.WebControls.PlaceHolder;
    PlaceHolder_postcontent: System.Web.UI.WebControls.PlaceHolder;
    Button_new_password: System.Web.UI.WebControls.Button;
    RangeValidator_county: System.Web.UI.WebControls.RangeValidator;
    RegularExpressionValidator_password: System.Web.UI.WebControls.RegularExpressionValidator;
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
procedure TWebForm_login_county_coord.InitializeComponent;
begin
  Include(Self.DropDownList_county.SelectedIndexChanged, Self.DropDownList_county_SelectedIndexChanged);
  Include(Self.TextBox_password.TextChanged, Self.Button_log_in_Click);
  Include(Self.Button_new_password.Click, Self.Button_new_password_Click);
  Include(Self.Load, Self.Page_Load);
end;
{$ENDREGION}

procedure TWebForm_login_county_coord.Page_Load(sender: System.Object; e: System.EventArgs);
var
  bdpCommand_get_counties: Borland.Data.Provider.BdpCommand;
  bdr: borland.data.provider.BdpDataReader;
begin
  Title.InnerText := ConfigurationSettings.AppSettings['application_name'] + ' - login_county_coord';
  AppCommon.PopulatePlaceHolders(PlaceHolder_precontent,PlaceHolder_postcontent);
  if not IsPostback then
    begin
    session.Remove('target_user_table');
    session.Add('target_user_table','county');
    AppCommon.BdpConnection.Open;
    invalid_credentials_warning.Visible := FALSE;
    //
    // Load DropDownList_account
    //
    DropDownList_county.Items.Add(listitem.Create('-- Select --','0'));
    bdpCommand_get_counties := Borland.Data.Provider.BdpCommand.Create
      (
      'SELECT id,name '
      + 'FROM county_user JOIN county_code_name_map on (county_code_name_map.code = county_user.id) '
      + 'WHERE be_active = TRUE '
      + 'ORDER BY name',
      AppCommon.BdpConnection
      );
    bdr := bdpCommand_get_counties.ExecuteReader;
    while bdr.Read do
      DropDownList_county.Items.Add(listitem.Create(bdr['name'].tostring,bdr['id'].ToString));
    AppCommon.BdpConnection.Close;
    end;
end;

procedure TWebForm_login_county_coord.OnInit(e: EventArgs);
begin
  //
  // Required for Designer support
  //
  InitializeComponent;
  inherited OnInit(e);
end;

procedure TWebForm_login_county_coord.DropDownList_county_SelectedIndexChanged(sender: System.Object;
  e: System.EventArgs);
begin
  session.Remove('county_user_id');
  session.Add('county_user_id',DropDownList_county.SelectedValue);
  session.Remove('county_name');
  session.Add('county_name',DropDownList_county.SelectedItem.Text);
end;

procedure TWebForm_login_county_coord.Button_new_password_Click(sender: System.Object;
  e: System.EventArgs);
begin
  server.Transfer('new_password.aspx');
end;

procedure TWebForm_login_county_coord.Button_log_in_Click(sender: System.Object; e: System.EventArgs);
var
  bdpCommand_match_account: borland.data.provider.BdpCommand;
  BdpCommand_get_appropriation_ids: borland.data.provider.BdpCommand;
  bdpCommand_get_max_fiscal_year_id: borland.data.provider.BdpCommand;
  bdr: borland.data.provider.BdpDataReader;
  be_stale_password_obj: System.Object;
  max_fiscal_year_id_obj: System.Object;
begin
  bdpCommand_match_account := Borland.Data.Provider.BdpCommand.Create
    (
    'SELECT be_stale_password FROM county_user '
    +  'where id="' + DropDownList_county.SelectedValue + '" '
    +     'and encoded_password=sha("' + Safe(Trim(TextBox_password.Text),ALPHANUM) + '")'
    ,AppCommon.BdpConnection
    );
  AppCommon.BdpConnection.Open;
  be_stale_password_obj := bdpCommand_match_account.ExecuteScalar;
  AppCommon.BdpConnection.Close;
  if be_stale_password_obj <> nil then begin
    if be_stale_password_obj.ToString = '0' then begin
      AppCommon.BdpConnection.Open;
      //
      // Determine current fiscal year
      //
      bdpCommand_get_max_fiscal_year_id := borland.data.provider.bdpcommand.Create
        (
        'SELECT max(id) as max_id FROM fiscal_year',
        AppCommon.BdpConnection
        );
      max_fiscal_year_id_obj := bdpCommand_get_max_fiscal_year_id.ExecuteScalar;
      //
      BdpCommand_get_appropriation_ids := borland.data.provider.bdpcommand.Create
        (
        'SELECT region_dictated_appropriation.id'
        + ' FROM region_dictated_appropriation'
        +   ' JOIN state_dictated_appropriation on (state_dictated_appropriation.id=state_dictated_appropriation_id)'
        +   ' JOIN fiscal_year on (fiscal_year.id = fiscal_year_id)'
        + ' WHERE county_code = ' + session.Item['county_user_id'].ToString
        +   ' and fiscal_year_id >= (' + max_fiscal_year_id_obj.ToString + ' - 1)',
        appcommon.bdpconnection
        );
      bdr := BdpCommand_get_appropriation_ids.ExecuteReader;
      if not bdr.Read then begin
        server.Transfer('no_appropriation.aspx');
      end else begin
        //
        // This county has received at least one appropriation.  Add its id to the session in case its the only one.  If this is not
        // the only appropriation, the id will be replaced by the choose_county_appropriation form.
        //
        session.Remove('region_dictated_appropriation_id');
        session.Add('region_dictated_appropriation_id',bdr['id'].tostring);
        //
        if bdr.Read then begin
          AppCommon.BdpConnection.Close;
          server.Transfer('choose_county_appropriation.aspx');
        end else begin
          AppCommon.BdpConnection.Close;
          server.Transfer('county_dictated_appropriations.aspx');
        end;
      end;
    end else begin
      server.Transfer('change_password.aspx');
    end;
  end else begin
    // be_stale_password_obj = nil
    if DropDownList_county.SelectedIndex <> 0 then begin
      invalid_credentials_warning.Visible := TRUE;
    end;
  end;
end;

end.

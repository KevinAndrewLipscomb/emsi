UNIT AppCommon;

INTERFACE

uses
  borland.data.provider,
  system.configuration,
  system.data,
  system.security.cryptography,
  system.text,
  system.text.regularexpressions,
  system.web,
  system.web.security,
  system.Web.UI.WebControls;

const ID = '$Id$';

const
  APOSTROPHE = '''';
  DOUBLE_APOSTROPHE = '''''';
  DOUBLE_QUOTE = '""';
  NEW_LINE = #10;
  QUOTE = '"';
  SPACE = #32;
  TAB = #9;

type
  safe_hint_type =
    (
    NONE,
    ALPHA,
    ALPHANUM,
    DATE_TIME,
    ECMASCRIPT_WORD,
    EMAIL_ADDRESS,
    HOSTNAME,
    HUMAN_NAME,
    HUMAN_NAME_CSV,
    HYPHENATED_ALPHANUM,
    HYPHENATED_NUM,
    MAKE_MODEL,
    NARRATIVE,
    NUM,
    ORG_NAME,
    PHONE_NUM,
    POSTAL_CITY,
    POSTAL_STREET_ADDRESS,
    REAL_NUM
    );
  string_array = array of string;

var
  db: borland.data.provider.bdpconnection;

procedure DbClose;

procedure DbOpen;

function Digest(source_string: string): string;

procedure PopulatePlaceHolders
  (
  var precontent: System.Web.Ui.WebControls.PlaceHolder;
  var postcontent: System.Web.Ui.WebControls.PlaceHolder
  );

function Safe
  (
  source_string: string;
  hint: safe_hint_type = NONE
  )
  : string;

IMPLEMENTATION

PROCEDURE DbClose;
begin
  db.Close;
end;

PROCEDURE DbOpen;
begin
  if db.State <> connectionstate.OPEN then begin
    db.Open;
  end;
end;

FUNCTION Digest(source_string: string): string;
var
  byte_buf: array[1..20] of byte;
  i: cardinal;
  target_string: string;
begin
  target_string := system.string.EMPTY;
  byte_buf := sha1managed.Create.ComputeHash(asciiencoding.Create.GetBytes(source_string));
  for i := 1 to 20 do begin
    target_string := target_string + byte_buf[i].tostring('x2');
  end;
  Digest := target_string;
end;

PROCEDURE PopulatePrecontent(var precontent: System.Web.Ui.WebControls.PlaceHolder);
var
  literal: System.Web.Ui.WebControls.Literal;
  validation_summary_control: System.Web.Ui.WebControls.ValidationSummary;
begin
  literal := System.Web.Ui.WebControls.Literal.Create;
  literal.Text := ''
    + '<table cellpadding=5>'
    +   '<tr>'
    +     '<td valign=top width=1>'
    +       '<img src="https://' + ConfigurationSettings.AppSettings['ssl_base_path'] + '/'
    +         ConfigurationSettings.AppSettings['application_name']
    +         '/protected/image/logo_left.gif" align="center" valign="middle" width="113" height="99" />'
    +     '</td>'
    +     '<td align="left" valign="top" width=1>'
    +       '<img src="https://' + ConfigurationSettings.AppSettings['ssl_base_path'] + '/'
    +         ConfigurationSettings.AppSettings['application_name']
    +         '/protected/image/logo_right.gif" align="left" valign="top" width="135" height="100" />'
    +     '</td>'
    +     '<td nowrap valign=top>'
    +       '<p>'
    +         '<small>'
    +           '221-2500 Penn Avenue '
    +           '<a href="http://www.emsi.org/location/index.shtml">'
    +             '<b><span style="font-variant: small-caps">(map)</span></b>'
    +           '</a>'
    +           '<br>'
    +           'Pittsburgh, PA 15221-2166<br>'
    +           'tel:+1-412-242-7322<br>'
    +           'tel:+1-866-827-EMSI (3674)<br>'
    +           'fax:+1-412-242-7434<br>'
    +           '<a href="mailto:info@emsi.org">info@emsi.org</a>'
    +         '</small>'
    +       '</p>'
    +     '</td>'
    +   '</tr>'
    + '</table>'
    + '<h1>' + ConfigurationSettings.AppSettings['application_name'] + ' system</h1>';
  precontent.Controls.Add(literal);
  validation_summary_control := System.Web.Ui.WebControls.ValidationSummary.Create;
  precontent.Controls.Add(validation_summary_control);
end;

PROCEDURE PopulatePostcontent(var postcontent: System.Web.Ui.WebControls.PlaceHolder);
var
  literal: System.Web.Ui.WebControls.Literal;
begin
  literal := System.Web.Ui.WebControls.Literal.Create;
  literal.Text := '<!-- Copyright Kalips''o Infogistics LLC -->';
  postcontent.Controls.Add(literal);
end;

PROCEDURE PopulatePlaceHolders
  (
  var precontent: System.Web.Ui.WebControls.PlaceHolder;
  var postcontent: System.Web.Ui.WebControls.PlaceHolder
  );
begin
PopulatePrecontent(precontent);
PopulatePostcontent(postcontent);
end;

FUNCTION Safe
  (
  source_string: string;
  hint: safe_hint_type = NONE
  )
  : string;
var
  allow: string;
  scratch_string: string;
begin
  allow := system.string.EMPTY;
  case hint of
    //
    // Be extremely protective here:
    // -  Escape ("\") the following twelve characters: [\^$.|?*+()-
    // -  For scalars, do not allow punctuation.
    // -  When in doubt, don't allow it.
    //
    // This routine is not intended to assure that data is submitted in proper
    // format.  It is intended to protect against SQL insertion attacks.
    //
    ALPHA:
      allow := 'a-zA-Z';
    ALPHANUM:
      allow := '0-9a-zA-Z';
    DATE_TIME:
      allow := '0-9AMPamp:\/ ';
    ECMASCRIPT_WORD:
      allow := '0-9a-zA-Z_';
    EMAIL_ADDRESS:
      allow := '0-9a-zA-Z_\.@\-';
    HOSTNAME:
      allow := '0-9a-zA-Z_\-\.';
    HUMAN_NAME:
      allow := 'a-zA-Z\-\. ' + APOSTROPHE;
    HUMAN_NAME_CSV:
      allow := 'a-zA-Z\-,\. ' + APOSTROPHE;
    HYPHENATED_ALPHANUM:
      allow := 'a-zA-z0-9\-';
    HYPHENATED_NUM:
      allow := '0-9\-';
    MAKE_MODEL:
      allow := '0-9a-zA-Z#\*\(\)\-\+/\. ';
    NARRATIVE:
      allow := '0-9a-zA-Z#\(\)\-,/\. ';
    NUM:
      allow := '0-9';
    ORG_NAME:
      allow := '0-9a-zA-Z#&\-,\. ' + APOSTROPHE;
    PHONE_NUM:
      allow := '0-9-\+\(\) ';
    POSTAL_CITY:
      allow := 'a-zA-Z\-\. ' + APOSTROPHE;
    POSTAL_STREET_ADDRESS:
      allow := '0-9a-zA-Z#\-,\(\)\. ' + APOSTROPHE;
    REAL_NUM:
      allow := '0-9\.';
  end;
  //
  if allow = system.string.EMPTY then
    scratch_string := system.string.EMPTY
  else
    begin
    scratch_string := regex.Replace(source_string,'[^' + allow + ']',system.string.EMPTY);
    regex.Replace(scratch_string,APOSTROPHE,DOUBLE_APOSTROPHE);
    regex.Replace(scratch_string,QUOTE,DOUBLE_QUOTE);
    regex.Replace(scratch_string,';',':,');
    end;
  //
  Safe := scratch_string;
end;

BEGIN
db := borland.data.provider.bdpconnection.Create;
db.ConnectionOptions := 'transaction isolation=ReadCommitted';
db.ConnectionString := ConfigurationSettings.AppSettings['bdp_connection_string'];
END.

using Class_biz_accounts;
using Class_biz_regions;
using kix;
using System;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;

namespace login
{
    public struct p_type
    {
        public TClass_biz_accounts biz_accounts;
        public TClass_biz_regions biz_regions;
        public string region_code;
    } // end p_type

    public partial class TWebForm_login: ki_web_ui.page_class
    {
        private p_type p;
        protected System.Web.UI.WebControls.PlaceHolder PlaceHolder_precontent = null;
        protected System.Web.UI.WebControls.PlaceHolder PlaceHolder_postcontent = null;
        // / <summary>
        // / Required method for Designer support -- do not modify
        // / the contents of this method with the code editor.
        // / </summary>
        private void InitializeComponent()
        {
            //this.Load += this.Page_Load;
            this.PreRender += this.TWebForm_login_PreRender;
        }

    private void InjectPersistentClientSideScript()
      {
      EstablishClientSideFunction(k.client_side_function_enumeral_type.EL);
      EstablishClientSideFunction(k.client_side_function_enumeral_type.REMOVE_EL);
      EstablishClientSideFunction("SetClientTimezoneOffset()","El('" + Hidden_client_timezone_offset.ClientID + "').value = (new Date()).getTimezoneOffset();");
      Button_log_in.Attributes.Add("onclick","SetClientTimezoneOffset();");
      EstablishClientSideFunction
        (
        "SecurePassword()",
        k.EMPTY
        + "if (El('" + TextBox_password.ClientID + "').value != '')"
        +   " {"
        +   " El('" + HiddenField_hashed_password.ClientID + "').value = new jsSHA(El('" + TextBox_password.ClientID + "').value,'ASCII').getHash('HEX');"
        +   " RemoveEl('" + TextBox_password.ClientID + "');"
        +   " }"
        );
      //
      Form_control.Attributes.Add("onsubmit","SecurePassword()");
      }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (IsPostBack)
            {
                if ((Session[InstanceId() + ".p"] != null))
                {
                    p = (p_type)(Session[InstanceId() + ".p"]);
                }
                else
                {
                    Server.Transfer("~/timeout.aspx");
                }
            }
            else
            {
                Title = ConfigurationManager.AppSettings["application_name"] + " - login";
                Literal_application_name.Text = ConfigurationManager.AppSettings["application_name"];
                p.biz_accounts = new TClass_biz_accounts();
                p.biz_regions = new TClass_biz_regions();
                RequireConfirmation(Button_new_password,"Are you sure you want a new password?");
            }
            InjectPersistentClientSideScript();
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(Button_new_password);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(Button_log_in);
        }

        protected override void OnInit(EventArgs e)
        {
            // Required for Designer support
            InitializeComponent();
            base.OnInit(e);
            p.region_code = "1";
        }

        private void TWebForm_login_PreRender(object sender, System.EventArgs e)
        {
            SessionSet(InstanceId() + ".p", p);
        }

        protected void CustomValidator_account_exists_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = p.biz_accounts.Exists(k.Safe(DropDownList_user_kind.SelectedValue,k.safe_hint_type.ECMASCRIPT_WORD),k.Safe(DropDownList_user.SelectedValue,k.safe_hint_type.NUM),k.Safe(HiddenField_hashed_password.Value,k.safe_hint_type.HEX));
        }

        protected void DropDownList_user_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Session.Remove(DropDownList_user_kind.SelectedValue + "_user_id");
            Session.Add(DropDownList_user_kind.SelectedValue + "_user_id", k.Safe(DropDownList_user.SelectedValue, k.safe_hint_type.NUM));
            Session.Remove(DropDownList_user_kind.SelectedValue + "_name");
            Session.Add(DropDownList_user_kind.SelectedValue + "_name", k.Safe(DropDownList_user.SelectedItem.Text, k.safe_hint_type.ORG_NAME));
        }

        protected void DropDownList_user_kind_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SessionSet("target_user_table", k.Safe(DropDownList_user_kind.SelectedValue, k.safe_hint_type.ECMASCRIPT_WORD));
            Label_user.Enabled = true;
            if (DropDownList_user_kind.SelectedValue == "service")
            {
                Label_user.Text = "Service";
                p.biz_accounts.BindServicesInRegion(p.region_code,DropDownList_user);
            }
            else if (DropDownList_user_kind.SelectedValue == "county")
            {
                Label_user.Text = "County";
                p.biz_accounts.BindCountiesInRegion(p.region_code,DropDownList_user);
            }
            else if (DropDownList_user_kind.SelectedValue == "regional_staffer")
            {
                Label_user.Text = "Regional staffer";
                p.biz_accounts.BindRegionalStaffersInRegionForWebEMSOF(p.region_code,DropDownList_user);
            }
            else
            {
                Session.Remove("target_user_table");
                Label_user.Enabled = false;
                Label_user.Text = "User";
                DropDownList_user.Items.Clear();
            }
        }

        protected void Button_new_password_Click(object sender, System.EventArgs e)
        {
            Server.Transfer("new_password.aspx");
        }

        protected void Button_log_in_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                SessionSet("region_code",p.region_code);
                // Set username in session for the benefit of the TableRow_account_control in UserControl_precontent.
                SessionSet("username", k.Safe(DropDownList_user.SelectedItem.Text, k.safe_hint_type.ORG_NAME));
                FormsAuthentication.RedirectFromLoginPage(k.Safe(DropDownList_user.SelectedValue, k.safe_hint_type.HYPHENATED_UNDERSCORED_ALPHANUM), CheckBox_keep_me_logged_in.Checked);
            }
        }

        protected void DropDownList_region_SelectedIndexChanged(object sender, EventArgs e)
          {
          p.region_code = k.Safe(DropDownList_region.SelectedValue,k.safe_hint_type.NUM);
          }

    } // end TWebForm_login

}

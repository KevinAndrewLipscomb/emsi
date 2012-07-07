using kix;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections;

using UserControl_role;
using UserControl_role_member_mapping;
using UserControl_role_notification_mapping;
using UserControl_role_privilege_mapping;
namespace UserControl_roles_and_matrices_binder
{
    public struct p_type
    {
        public bool be_loaded;
        public string content_id;
        public uint tab_index;
    } // end p_type

    public class TWebUserControl_roles_and_matrices_binder: ki_web_ui.usercontrol_class
    {
        private p_type p;
        protected System.Web.UI.WebControls.PlaceHolder PlaceHolder_content = null;
        protected AjaxControlToolkit.TabContainer TabContainer_control = null;
        protected AjaxControlToolkit.TabPanel TabPanel_roles = null;
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!p.be_loaded)
            {
                TabContainer_control.ActiveTabIndex = (int)(p.tab_index);
                if (k.Has((string[])(Session["privilege_array"]), "config-roles-and-matrices"))
                {
                    TabPanel_roles.Enabled = true;
                }
                p.be_loaded = true;
            }

        }

        protected override void OnInit(System.EventArgs e)
        {
            // Required for Designer support
            InitializeComponent();
            base.OnInit(e);
            if (Session[InstanceId() + ".p"] != null)
            {
                p = (p_type)(Session[InstanceId() + ".p"]);
                p.be_loaded = IsPostBack && ((Session["UserControl_member_binder_UserControl_config_PlaceHolder_content"] as string) == "UserControl_roles_and_matrices_binder");
                if ((Session["UserControl_roles_and_matrices_binder_selected_tab"] != null))
                {
                    p.tab_index = (uint)(Session["UserControl_roles_and_matrices_binder_selected_tab"].GetHashCode());
                    Session.Remove("UserControl_roles_and_matrices_binder_selected_tab");
                }
                switch(p.tab_index)
                {
                    case Units.UserControl_roles_and_matrices_binder.TSSI_ROLES:
                        // Dynamic controls must be re-added on each postback.
                        p.content_id = AddIdentifiedControlToPlaceHolder(((TWebUserControl_role)(LoadControl("~/usercontrol/app/UserControl_role.ascx"))), "UserControl_role", PlaceHolder_content);
                        break;
                    case Units.UserControl_roles_and_matrices_binder.TSSI_ROLE_MEMBER_MAPPINGS:
                        p.content_id = AddIdentifiedControlToPlaceHolder(((TWebUserControl_role_member_mapping)(LoadControl("~/usercontrol/app/UserControl_role_member_mapping.ascx"))), "UserControl_role_member_mapping", PlaceHolder_content);
                        break;
                    case Units.UserControl_roles_and_matrices_binder.TSSI_ROLE_PRIVILEGE_MAPPINGS:
                        p.content_id = AddIdentifiedControlToPlaceHolder(((TWebUserControl_role_privilege_mapping)(LoadControl("~/usercontrol/app/UserControl_role_privilege_mapping.ascx"))), "UserControl_role_privilege_mapping", PlaceHolder_content);
                        break;
                    case Units.UserControl_roles_and_matrices_binder.TSSI_ROLE_NOTIFICATION_MAPPINGS:
                        p.content_id = AddIdentifiedControlToPlaceHolder(((TWebUserControl_role_notification_mapping)(LoadControl("~/usercontrol/app/UserControl_role_notification_mapping.ascx"))), "UserControl_role_notification_mapping", PlaceHolder_content);
                        break;
                }
            }
            else
            {
                p.be_loaded = false;
                p.tab_index = Units.UserControl_roles_and_matrices_binder.TSSI_ROLES;
                p.content_id = AddIdentifiedControlToPlaceHolder(((TWebUserControl_role)(LoadControl("~/usercontrol/app/UserControl_role.ascx"))),"UserControl_role",PlaceHolder_content,InstanceId());
            }

        }

        // / <summary>
        // / Required method for Designer support -- do not modify
        // / the contents of this method with the code editor.
        // / </summary>
        private void InitializeComponent()
        {
            this.TabContainer_control.ActiveTabChanged += this.TabContainer_control_ActiveTabChanged;
            this.PreRender += this.TWebUserControl_roles_and_matrices_binder_PreRender;
            //this.Load += this.Page_Load;
        }

        private void TWebUserControl_roles_and_matrices_binder_PreRender(object sender, System.EventArgs e)
        {
            // Indicate to children which content control was active on this pass, so that on subsequent passes a child can detect whether or
            // not it is already loaded in the user's browser.
            SessionSet(PlaceHolder_content.ClientID, p.content_id);
            SessionSet(InstanceId() + ".p", p);

        }

        public TWebUserControl_roles_and_matrices_binder Fresh()
        {
            TWebUserControl_roles_and_matrices_binder result;
            Session.Remove(InstanceId() + ".p");
            result = this;
            return result;
        }

        private void TabContainer_control_ActiveTabChanged(object sender, System.EventArgs e)
        {
            p.tab_index = (uint)(TabContainer_control.ActiveTabIndex);
            PlaceHolder_content.Controls.Clear();
            switch(p.tab_index)
            {
                case Units.UserControl_roles_and_matrices_binder.TSSI_ROLES:
                    p.content_id = AddIdentifiedControlToPlaceHolder(((TWebUserControl_role)(LoadControl("~/usercontrol/app/UserControl_role.ascx"))),"UserControl_role",PlaceHolder_content,InstanceId());
                    break;
                case Units.UserControl_roles_and_matrices_binder.TSSI_ROLE_MEMBER_MAPPINGS:
                    p.content_id = AddIdentifiedControlToPlaceHolder(((TWebUserControl_role_member_mapping)(LoadControl("~/usercontrol/app/UserControl_role_member_mapping.ascx"))),"UserControl_role_member_mapping",PlaceHolder_content,InstanceId());
                    break;
                case Units.UserControl_roles_and_matrices_binder.TSSI_ROLE_PRIVILEGE_MAPPINGS:
                    p.content_id = AddIdentifiedControlToPlaceHolder(((TWebUserControl_role_privilege_mapping)(LoadControl("~/usercontrol/app/UserControl_role_privilege_mapping.ascx"))),"UserControl_role_privilege_mapping",PlaceHolder_content,InstanceId());
                    break;
                case Units.UserControl_roles_and_matrices_binder.TSSI_ROLE_NOTIFICATION_MAPPINGS:
                    p.content_id = AddIdentifiedControlToPlaceHolder(((TWebUserControl_role_notification_mapping)(LoadControl("~/usercontrol/app/UserControl_role_notification_mapping.ascx"))),"UserControl_role_notification_mapping",PlaceHolder_content,InstanceId());
                    break;
            }
        }

    } // end TWebUserControl_roles_and_matrices_binder

}

namespace UserControl_roles_and_matrices_binder.Units
{
    public class UserControl_roles_and_matrices_binder
    {
        public const int TSSI_ROLES = 0;
        public const int TSSI_ROLE_MEMBER_MAPPINGS = 1;
        public const int TSSI_ROLE_PRIVILEGE_MAPPINGS = 2;
        public const int TSSI_ROLE_NOTIFICATION_MAPPINGS = 3;
    } // end UserControl_roles_and_matrices_binder

}


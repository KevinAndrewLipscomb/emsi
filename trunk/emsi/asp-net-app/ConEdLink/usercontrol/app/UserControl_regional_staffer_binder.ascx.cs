using System.Web;
using UserControl_about;
using UserControl_regional_staffer_emsrs_gateway_binder;

namespace UserControl_regional_staffer_binder
{
    public partial class TWebUserControl_regional_staffer_binder: ki_web_ui.usercontrol_class
    {
        private p_type p;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!p.be_loaded)
            {
                TabContainer_control.ActiveTabIndex = (int)(p.tab_index);
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
                p.be_loaded = IsPostBack;
                if ((Session["UserControl_regional_staffer_binder_selected_tab"] != null))
                {
                    p.tab_index = (uint)(Session["UserControl_regional_staffer_binder_selected_tab"].GetHashCode());
                    Session.Remove("UserControl_regional_staffer_binder_selected_tab");
                }
                switch(p.tab_index)
                {
                    case Units.UserControl_regional_staffer_binder.TSSI_EMSRS_GATEWAY:
                        p.content_id = AddIdentifiedControlToPlaceHolder(((TWebUserControl_regional_staffer_emsrs_gateway_binder)(LoadControl("~/usercontrol/app/UserControl_regional_staffer_emsrs_gateway_binder.ascx"))), "UserControl_regional_staffer_emsrs_gateway_binder", PlaceHolder_content);
                        break;
                    case Units.UserControl_regional_staffer_binder.TSSI_ABOUT:
                        p.content_id = AddIdentifiedControlToPlaceHolder(((TWebUserControl_about)(LoadControl("~/usercontrol/app/UserControl_about.ascx"))), "UserControl_about", PlaceHolder_content);
                        break;
                }
            }
            else
            {
                p.be_loaded = false;
                p.tab_index = Units.UserControl_regional_staffer_binder.TSSI_EMSRS_GATEWAY;
                p.content_id = AddIdentifiedControlToPlaceHolder(((TWebUserControl_regional_staffer_emsrs_gateway_binder)(LoadControl("~/usercontrol/app/UserControl_regional_staffer_emsrs_gateway_binder.ascx"))),"UserControl_regional_staffer_emsrs_gateway_binder",PlaceHolder_content,InstanceId());
            }

        }

        private void TabContainer_control_ActiveTabChanged(object sender, System.EventArgs e)
        {
            p.tab_index = (uint)(TabContainer_control.ActiveTabIndex);
            PlaceHolder_content.Controls.Clear();
            switch(p.tab_index)
            {
                case Units.UserControl_regional_staffer_binder.TSSI_EMSRS_GATEWAY:
                    p.content_id = AddIdentifiedControlToPlaceHolder(((TWebUserControl_regional_staffer_emsrs_gateway_binder)(LoadControl("~/usercontrol/app/UserControl_regional_staffer_emsrs_gateway_binder.ascx"))),"UserControl_regional_staffer_emsrs_gateway_binder",PlaceHolder_content,InstanceId());
                    break;
                case Units.UserControl_regional_staffer_binder.TSSI_ABOUT:
                    p.content_id = AddIdentifiedControlToPlaceHolder(((TWebUserControl_about)(LoadControl("~/usercontrol/app/UserControl_about.ascx"))),"UserControl_about",PlaceHolder_content,InstanceId());
                    break;
            }
        }

        // / <summary>
        // / Required method for Designer support -- do not modify
        // / the contents of this method with the code editor.
        // / </summary>
        private void InitializeComponent()
        {
            this.TabContainer_control.ActiveTabChanged += this.TabContainer_control_ActiveTabChanged;
            //this.Load += this.Page_Load;
            this.PreRender += this.TWebUserControl_regional_staffer_binder_PreRender;
        }

        private void TWebUserControl_regional_staffer_binder_PreRender(object sender, System.EventArgs e)
        {
            // Indicate to children which content control was active on this pass, so that on subsequent passes a child can detect whether or
            // not it is already loaded in the user's browser.
            SessionSet(PlaceHolder_content.ClientID, p.content_id);
            SessionSet(InstanceId() + ".p", p);

        }

        public TWebUserControl_regional_staffer_binder Fresh()
        {
            TWebUserControl_regional_staffer_binder result;
            Session.Remove(InstanceId() + ".p");
            result = this;
            return result;
        }

        private struct p_type
        {
            public bool be_loaded;
            public string content_id;
            public uint tab_index;
        } // end p_type

    } // end TWebUserControl_regional_staffer_binder

}

namespace UserControl_regional_staffer_binder.Units
{
    public class UserControl_regional_staffer_binder
    {
        public const int TSSI_EMSRS_GATEWAY = 0;
        public const int TSSI_ABOUT = 1;
    } // end UserControl_regional_staffer_binder

}
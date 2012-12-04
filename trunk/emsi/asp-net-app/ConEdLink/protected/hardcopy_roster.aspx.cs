using Class_biz_coned_offerings;
using kix;
using System;
using System.Configuration;

namespace hardcopy_roster
{
    // Derived from KiAspdotnetFramework/protected/template~protected~nonlanding.pas~template
    public partial class TWebForm_hardcopy_roster: ki_web_ui.page_class
    {
        private p_type p;
        protected new System.Web.UI.HtmlControls.HtmlTitle Title = null;
        // / <summary>
        // / Required method for Designer support -- do not modify
        // / the contents of this method with the code editor.
        // / </summary>
        private void InitializeComponent()
        {
            this.PreRender += this.TWebForm_hardcopy_roster_PreRender;
            //this.Load += this.Page_Load;
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                Title.Text = ConfigurationManager.AppSettings["application_name"] + " - hardcopy_roster";
                Literal_application_name.Text = ConfigurationManager.AppSettings["application_name"];
                Literal_timestamp.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Literal_status.Text = p.biz_coned_offerings.StatusOf(p.summary);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            // Required for Designer support
            InitializeComponent();
            base.OnInit(e);
            switch(NatureOfVisitUnlimited(InstanceId() + ".p"))
            {
                case nature_of_visit_type.VISIT_COLD_CALL:
                case nature_of_visit_type.VISIT_INITIAL:
                    p.biz_coned_offerings = new TClass_biz_coned_offerings();
                    p.summary = p.biz_coned_offerings.Summary(HashtableOfShieldedRequest()["coned_offering_id"].ToString());
                    UserControl_roster_control.SetTarget(coned_offering_summary:p.summary);
                    break;
                case nature_of_visit_type.VISIT_POSTBACK_STANDARD:
                    p = (p_type)(Session[InstanceId() + ".p"]);
                    break;
            }

        }

        private void TWebForm_hardcopy_roster_PreRender(object sender, System.EventArgs e)
        {
            SessionSet(InstanceId() + ".p", p);
        }

        private struct p_type
        {
        public TClass_biz_coned_offerings biz_coned_offerings;
        public object summary;
        } // end p_type

    } // end TWebForm_hardcopy_roster

}

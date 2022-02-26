using Class_biz_accounts;
using System;
using System.Configuration;

namespace coned_sponsor_overview
{
    public partial class TWebForm_coned_sponsor_overview: ki_web_ui.page_class
    {

      private void InitializeComponent()
        {
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - coned_sponsor_overview";
            if (!IsPostBack)
            {
                BeginBreadCrumbTrail();
                if (new TClass_biz_accounts().BeStalePassword(user_kind:"coned_sponsor",user_id:Session["coned_sponsor_user_id"].ToString()))
                  {
                  DropCrumbAndTransferTo("change_password.aspx");
                  }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            // Required for Designer support
            InitializeComponent();
            base.OnInit(e);
            //
            // When NullReferenceException happens during a Page_Load and the Session is empty, it's because this kind of logic is being checked too late, in the Page_Load, rather than in the OnInit.
            //
            if ((Session["coned_sponsor_name"] == null) || (Session["coned_sponsor_user_id"] == null))
              {
              Session.Clear();
              DropCrumbAndTransferTo("~/login.aspx");
              }
            UserControl_coned_sponsor_binder_control.Set(user_sponsor_id:Session["coned_sponsor_user_id"].ToString());
        }

    } // end TWebForm_coned_sponsor_overview

}

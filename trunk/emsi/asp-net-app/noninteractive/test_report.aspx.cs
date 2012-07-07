using System.Configuration;

using kix;

using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;



using System.Text;
using System.IO;
namespace test_report
{
    public partial class TWebForm_test_report: System.Web.UI.Page
    {
        // / <summary>
        // / Required method for Designer support -- do not modify
        // / the contents of this method with the code editor.
        // / </summary>
        private void InitializeComponent()
        {
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // TODO: Put user code to initialize the page here

        }

        protected override void OnInit(EventArgs e)
        {
            // Required for Designer support
            InitializeComponent();
            base.OnInit(e);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb;
            // Write the HTML stream into a StringBuilder.
            sb = new StringBuilder();
            base.Render(new HtmlTextWriter(new StringWriter(sb)));
            // Send output stream as an email message.
            // from
            // to
            // subject
            // body
            // be_html
           k.SmtpMailSend(ConfigurationManager.AppSettings["sender_email_address"], "recipient@frompaper2web.com", "Test Report", sb.ToString(), true);

        }

    } // end TWebForm_test_report

}

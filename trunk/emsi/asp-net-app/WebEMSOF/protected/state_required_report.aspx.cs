using Class_biz_appropriations;
using Class_biz_emsof_requests;
using kix;
using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace state_required_report
{
    public partial class TWebForm_state_required_report: ki_web_ui.page_class
    {
    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

        protected System.Web.UI.WebControls.PlaceHolder PlaceHolder_precontent = null;
        protected System.Web.UI.WebControls.PlaceHolder PlaceHolder_postcontent = null;
        protected System.Web.UI.WebControls.Label Label_amount_available = null;
        protected System.Web.UI.WebControls.LinkButton LinkButton_back = null;

        // / <summary>
        // / Required method for Designer support -- do not modify
        // / the contents of this method with the code editor.
        // / </summary>
        private void InitializeComponent()
        {
            DataGrid_state_export_batch.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(DataGrid_state_export_batch_ItemDataBound);
            PreRender += TWebForm_state_required_report_PreRender;
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            uint i;
            uint num_active_amendments;
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
                if (Request.ServerVariables["URL"] == Request.CurrentExecutionFilePath)
                {
                    Session.Clear();
                    Server.Transfer("~/login.aspx");
                }
                Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - state_required_report";
                // Initialize implementation-wide vars.
                p.amendment_num_string = "0";
                p.be_replacement_rows_present = false;
                p.biz_appropriations = new TClass_biz_appropriations();
                p.biz_emsof_requests = new TClass_biz_emsof_requests();
                p.grand_total_cost = 0;
                p.num_datagrid_rows = 0;
                p.total_emsof_ante = 0;
                p.total_provider_match = 0;
                RequireConfirmation
                  (
                  c:LinkButton_export_scratch_copy,
                  prompt:"We will send you HTML-formatted data masquerading as an XLS file so that it will open up in your spreadsheet program.  The discrepancy is intentional.  The file is not corrupt or untrustworthy." + k.NEW_LINE
                  + k.NEW_LINE
                  + "If your spreadsheet program mentions these things and asks if you want to open the file, click 'Yes'."
                  );
                Label_total_num_requests.Text = p.biz_emsof_requests.TallyOfStatus(Class_biz_emsof_requests.status_type.NEEDS_SENT_TO_PA_DOH_EMSO);
                num_active_amendments = p.biz_appropriations.NumActiveAmendments(Session["regional_staffer_user_id"].ToString());
                if (num_active_amendments == 0)
                {
                    TableRow_this_is_everything.Visible = true;
                    Label_total_num_requests_2.Text = Label_total_num_requests.Text;
                }
                else
                {
                    TableRow_this_is_just_some.Visible = true;
                    DropDownList_amendment.Items.Add(new ListItem("the original contract", "0"));
                    for (i = 1; i <= num_active_amendments; i ++ )
                    {
                        DropDownList_amendment.Items.Add(new ListItem("contract amendment #" + i.ToString(), i.ToString()));
                    }
                    Label_num_filtered_requests.Text = p.biz_emsof_requests.NumRequestsInStateExportBatch(((status_type)(Session["status_of_interest"])), p.amendment_num_string, Session["regional_staffer_user_id"].ToString()).ToString();
                }
                Label_funding_round_everything.Text = ((uint)p.biz_appropriations.FundingRoundsGenerated(Session["regional_staffer_user_id"].ToString()) + 1).ToString();
                Label_funding_round_some.Text = Label_funding_round_everything.Text;
                Bind();
            }
        }

        protected override void OnInit(EventArgs e)
        {
            // Required for Designer support
            InitializeComponent();
            base.OnInit(e);
        }

        protected void LinkButton_export_scratch_copy_Click(object sender, System.EventArgs e)
        {
            ExportToExcel(Page, "WebEmsof-UNOFFICIAL-" + DateTime.Now.ToString("yyyyMMddHHmmssf"), StringOfControl(DataGrid_state_export_batch));
        }

        protected void DropDownList_amendment_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            p.amendment_num_string = k.Safe(DropDownList_amendment.SelectedValue, k.safe_hint_type.NUM);
            Label_num_filtered_requests.Text = p.biz_emsof_requests.NumRequestsInStateExportBatch(((status_type)(Session["status_of_interest"])), p.amendment_num_string, Session["regional_staffer_user_id"].ToString()).ToString();
            Label_funding_round_everything.Text = ((uint)1 + p.biz_appropriations.FundingRoundsGenerated(Session["regional_staffer_user_id"].ToString(), p.amendment_num_string)).ToString();
            Label_funding_round_some.Text = Label_funding_round_everything.Text;
            Bind();
        }

        protected void LinkButton_transmit_to_state_Click(object sender, System.EventArgs e)
        {
            p.biz_emsof_requests.SubmitToState(DataGrid_state_export_batch, Request.PhysicalPath, ((status_type)(Session["status_of_interest"])), Session["regional_staffer_user_id"].ToString(), p.amendment_num_string);
            BackTrack();  //DropCrumbAndTransferTo("state_transmittal_complete.aspx");            
        }

        private void DataGrid_state_export_batch_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            // Manage column visibility
            if ((e.Item.ItemType == ListItemType.AlternatingItem) || (e.Item.ItemType == ListItemType.EditItem) || (e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.SelectedItem))
            {
                // We are dealing with a data row, not a header or footer row.
                p.num_datagrid_rows = p.num_datagrid_rows + 1;
                p.be_replacement_rows_present = p.be_replacement_rows_present || (e.Item.Cells[(int)(p.biz_emsof_requests.TcciOfSrrReplacementRowIndicator())].Text.EndsWith("*"));
                p.grand_total_cost = p.grand_total_cost + Convert.ToDecimal(DataBinder.Eval(e.Item.DataItem, "total_cost"));
                p.total_emsof_ante = p.total_emsof_ante + Convert.ToDecimal(DataBinder.Eval(e.Item.DataItem, "emsof_ante"));
                p.total_provider_match = p.total_provider_match + Convert.ToDecimal(DataBinder.Eval(e.Item.DataItem, "provider_match"));
            }
            else if ((e.Item.ItemType == ListItemType.Footer))
            {
                e.Item.Cells[0].Text = "Total This Request:";
                e.Item.Cells[6].Text = p.grand_total_cost.ToString();
                e.Item.Cells[9].Text = p.total_provider_match.ToString();
                e.Item.Cells[10].Text = p.total_emsof_ante.ToString();
            }
        }

        private void TWebForm_state_required_report_PreRender(object sender, System.EventArgs e)
        {
            SessionSet(InstanceId() + ".p", p);
        }

        private void Bind()
        {
            p.biz_emsof_requests.BindStateExportBatch(DataGrid_state_export_batch, ((status_type)(Session["status_of_interest"])), p.amendment_num_string, Session["regional_staffer_user_id"].ToString());
            // Manage control visibilities.
            p.be_datagrid_empty = (p.num_datagrid_rows == 0);
            TableRow_none.Visible = p.be_datagrid_empty;
            DataGrid_state_export_batch.Visible = !p.be_datagrid_empty;
            LinkButton_transmit_to_state.Enabled = !p.be_datagrid_empty;
            LinkButton_export_scratch_copy.Enabled = !p.be_datagrid_empty;
            TableRow_replacement_note.Visible = p.be_replacement_rows_present;
            // Clear aggregation vars for next bind, if any.
            p.num_datagrid_rows = 0;

        }

        private struct p_type
        {
            public string amendment_num_string;
            public bool be_datagrid_empty;
            public bool be_replacement_rows_present;
            public TClass_biz_appropriations biz_appropriations;
            public TClass_biz_emsof_requests biz_emsof_requests;
            public decimal grand_total_cost;
            public uint num_datagrid_rows;
            public decimal total_emsof_ante;
            public decimal total_provider_match;
        } // end p_type

    } // end TWebForm_state_required_report

}

using Class_biz_old_analysis_of_region_by_years;
using System;

namespace special_task
  {
  public partial class TWebForm_special_task: System.Web.UI.Page
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
        new TClass_biz_old_analysis_of_region_by_years().PopulatePast();
        }

        protected override void OnInit(EventArgs e)
        {
            // Required for Designer support
            InitializeComponent();
            base.OnInit(e);
        }

    } // end TWebForm_special_task

}

using Class_biz_coned_offerings;
using Class_biz_coned_offering_rosters;
using kix;
using System;

namespace UserControl_training_certificate
  {

  public struct p_type
    {
    public bool be_loaded;
    public TClass_biz_coned_offerings biz_coned_offerings;
    public TClass_biz_coned_offering_rosters biz_coned_offering_rosters;
    }

  public partial class TWebUserControl_training_certificate: ki_web_ui.usercontrol_class
    {

    private p_type p;

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebUserControl_training_certificate_PreRender;
      }

    private void TWebUserControl_training_certificate_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        Image_banner.ImageUrl = k.ExpandAsperand(Image_banner.ImageUrl);
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
        }
      else
        {
        p.biz_coned_offerings = new TClass_biz_coned_offerings();
        p.biz_coned_offering_rosters = new TClass_biz_coned_offering_rosters();
        //
        p.be_loaded = false;
        }
      }

    internal void Set
      (
      string sponsor_name,
      string sponsor_number,
      string first_name,
      string middle_initial,
      string last_name,
      string certification_number,
      string level_emsrs_code,
      string level_short_description,
      string dob,
      string class_number,
      string course_title,
      string total_ceus,
      string med_trauma_ceus,
      string date_final,
      string instructor_hours
      )
      {
      Literal_sponsor_name.Text = sponsor_name;
      Literal_sponsor_number.Text = (sponsor_number.Contains(k.HYPHEN) ? sponsor_number : sponsor_number.Substring(0,2) + k.HYPHEN + sponsor_number.Substring(2));
      Literal_practitioner_name.Text = (first_name + k.SPACE + middle_initial.Replace("nbsp",k.EMPTY) + k.SPACE + last_name).Replace(k.SPACE + k.SPACE,k.SPACE);
      Literal_certification_number.Text = certification_number;
      Literal_practitioner_level_emsrs_code.Text = level_emsrs_code;
      Literal_practitioner_level_short_description.Text = level_short_description;
      Literal_dob.Text = dob;
      if (instructor_hours.Length == 0)
        {
        Literal_completed.Visible = true;
        Literal_total_ce_hours.Text = total_ceus;
        Literal_num_med_trauma_hours.Text = med_trauma_ceus;
        TableRow_ceus.Visible = true;
        }
      else
        {
        Literal_taught.Visible = true;
        Literal_instructor_hours.Text = instructor_hours;
        TableRow_instructor_hours.Visible = true;
        }
      Literal_class_number.Text = class_number;
      Literal_course_title.Text = course_title;
      Literal_date_final.Text = DateTime.Parse(date_final.Substring(0,date_final.IndexOf(k.SPACE))).ToString("dddd d MMMM yyyy");
      }

    internal TWebUserControl_training_certificate Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    }

  }

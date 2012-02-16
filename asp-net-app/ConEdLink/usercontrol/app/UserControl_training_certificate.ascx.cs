using kix;

namespace UserControl_training_certificate
  {

  public struct p_type
    {
    public bool be_loaded;
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
        p.be_loaded = false;
        }
      }

    internal void Set
      (
      string sponsor_name,
      string first_name,
      string middle_initial,
      string last_name,
      string certification_number,
      string level_emsrs_code,
      string level_short_description,
      string dob,
      string course_number,
      string course_title,
      string total_ceus,
      string med_trauma_ceus,
      string date_final
      )
      {
      Literal_sponsor_name.Text = sponsor_name;
      Literal_practitioner_name.Text = (first_name + k.SPACE + middle_initial + k.SPACE + last_name).Replace(k.SPACE + k.SPACE,k.SPACE);
      Literal_certification_number.Text = certification_number;
      Literal_practitioner_level_emsrs_code.Text = level_emsrs_code;
      Literal_practitioner_level_short_description.Text = level_short_description;
      Literal_dob.Text = dob;
      Literal_course_number.Text = course_number;
      Literal_course_title.Text = course_title;
      Literal_total_ce_hours.Text = total_ceus;
      Literal_num_med_trauma_hours.Text = med_trauma_ceus;
      Literal_date_final.Text = date_final;
      }

    internal TWebUserControl_training_certificate Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    }

  }

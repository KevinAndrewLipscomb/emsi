using Class_biz_practitioners;
using kix;
using System.Configuration;

namespace UserControl_change_practitioner_email_address
  {

  public partial class TWebUserControl_change_practitioner_email_address: ki_web_ui.usercontrol_class
    {

    private struct p_type
      {
      public bool be_loaded;
      public TClass_biz_practitioners biz_practitioners;
      public object practitioner_summary;
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        Literal_application_name.Text = ConfigurationManager.AppSettings["application_name"];
        Literal_name.Text = (p.biz_practitioners.FirstNameOf(p.practitioner_summary) + k.SPACE + p.biz_practitioners.MiddleInitialOf(p.practitioner_summary) + k.SPACE + p.biz_practitioners.LastNameOf(p.practitioner_summary))
          .Replace(k.SPACE + k.SPACE,k.SPACE);
        Literal_level.Text = p.biz_practitioners.LevelOf(p.practitioner_summary);
        Literal_certification_number.Text = p.biz_practitioners.CertificationNumberOf(p.practitioner_summary);
        Literal_birth_date.Text = p.biz_practitioners.BirthDateOf(p.practitioner_summary);
        TextBox_email_address.Text = p.biz_practitioners.EmailAddressOf(p.practitioner_summary);
        TextBox_email_address.Focus();
        //
        p.be_loaded = true;
        }
      }

    protected override void OnInit(System.EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      var instance_id = InstanceId();
      if (Session[instance_id + ".p"] != null)
        {
        p = (p_type)(Session[instance_id + ".p"]);
        p.be_loaded = IsPostBack;  // This test is sufficient if this control is being used statically on its page.
        //
        // If this control is being used dynamically under one or more parent binder(s), it must ascertain which instance it is, and whether or not that instance's parent binder
        // had it loaded already.
        //
//#warning Revise the binder-related instance_id to this control appropriately.
//        if (instance_id == "ASP.protected_overview_aspx.UserControl_member_binder_change_practitioner_email_address")
//          {
//#warning Revise the ClientID path to this control appropriately.
//          p.be_loaded &= ((Session["UserControl_member_binder_PlaceHolder_content"] as string) == "UserControl_change_practitioner_email_address");
//          }
////      else if (instance_id == "ASP.~_aspx.UserControl_~_binder_change_practitioner_email_address")
////        {
////        p.be_loaded &= ((Session["UserControl_~_binder_PlaceHolder_content"] as string) == "UserControl_change_practitioner_email_address");
////        }
        }
      else
        {
        p.be_loaded = false;
        //
        p.biz_practitioners = new TClass_biz_practitioners();
        //
        p.practitioner_summary = null;
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebUserControl_change_practitioner_email_address_PreRender;
      }

    private void TWebUserControl_change_practitioner_email_address_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_change_practitioner_email_address Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    internal void Set(object practitioner_summary)
      {
      p.practitioner_summary = practitioner_summary;
      }

    protected void Button_submit_Click(object sender, System.EventArgs e)
      {
      p.biz_practitioners.SetEmailAddress(p.biz_practitioners.IdOf(p.practitioner_summary),k.Safe(TextBox_email_address.Text,k.safe_hint_type.EMAIL_ADDRESS));
      BackTrack();
      }

    protected void Button_cancel_Click(object sender, System.EventArgs e)
      {
      BackTrack();
      }

    protected void CustomValidator_email_address_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
      {
      args.IsValid = (args.Value.Length == 0) || k.BeValidDomainPartOfEmailAddress(args.Value);
      }

    }

  }

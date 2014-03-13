using Class_biz_associates;
using Class_biz_members;
using kix;
using System;
using System.Configuration;

namespace UserControl_associate_registration
  {

  public partial class TWebUserControl_associate_registration: ki_web_ui.usercontrol_class
    {

    private struct p_type
      {
      public TClass_biz_associates biz_associates;
      public TClass_biz_members biz_members;
      public bool be_loaded;
      }

    private p_type p;

    private void Clear()
      {
      TextBox_last_name.Text = k.EMPTY;
      TextBox_first_name.Text = k.EMPTY;
      TextBox_middle_initial.Text = k.EMPTY;
      UserControl_drop_down_date_birth_date.Clear();
      TextBox_email_address.Text = k.EMPTY;
      TextBox_street_address_1.Text = k.EMPTY;
      TextBox_street_address_2.Text = k.EMPTY;
      TextBox_city_state_zip.Text = k.EMPTY;
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        Literal_application_name.Text = ConfigurationManager.AppSettings["application_name"];
        Literal_application_name_2.Text = Literal_application_name.Text;
        UserControl_drop_down_date_birth_date.minyear = DateTime.Today.AddYears(-130).Year.ToString();
        UserControl_drop_down_date_birth_date.maxyear = DateTime.Today.AddYears(-16).Year.ToString();
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
//        //
//        // If this control is being used dynamically under one or more parent binder(s), it must ascertain which instance it is, and whether or not that instance's parent binder
//        // had it loaded already.
//        //
//#warning Revise the binder-related instance_id to this control appropriately.
//        if (instance_id == "ASP.protected_associate_registration_aspx.UserControl_associate_registration")
//          {
//#warning Revise the ClientID path to this control appropriately.
//          p.be_loaded &= ((Session["UserControl_member_binder_PlaceHolder_content"] as string) == "UserControl_associate_registration");
//          }
//      else if (instance_id == "ASP.~_aspx.UserControl_~_binder_associate_registration")
//        {
//        p.be_loaded &= ((Session["UserControl_~_binder_PlaceHolder_content"] as string) == "UserControl_associate_registration");
//        }
        }
      else
        {
        p.be_loaded = false;
        //
        p.biz_associates = new TClass_biz_associates();
        p.biz_members = new TClass_biz_members();
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebUserControl_associate_registration_PreRender;
      }

    private void TWebUserControl_associate_registration_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_associate_registration Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    protected void CustomValidator_email_address_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
      {
      args.IsValid = k.BeValidDomainPartOfEmailAddress(k.Safe(TextBox_email_address.Text, k.safe_hint_type.EMAIL_ADDRESS));
      }

    protected void Button_cancel_Click(object sender, System.EventArgs e)
      {
      BackTrack();
      }

    private bool Add()
      {
      var add = false;
      if (UserControl_drop_down_date_birth_date.isvalid)
        {
        if (Page.IsValid)
          {
          if(
            p.biz_associates.Add
              (
              last_name:k.Safe(TextBox_last_name.Text.Trim(), k.safe_hint_type.HUMAN_NAME),
              first_name:k.Safe(TextBox_first_name.Text.Trim(), k.safe_hint_type.HUMAN_NAME),
              middle_initial:k.Safe(TextBox_middle_initial.Text.Trim(), k.safe_hint_type.ALPHA),
              birth_date:UserControl_drop_down_date_birth_date.selectedvalue,
              email_address:k.Safe(TextBox_email_address.Text.Trim(), k.safe_hint_type.EMAIL_ADDRESS),
              street_address_1:k.Safe(TextBox_street_address_1.Text, k.safe_hint_type.POSTAL_STREET_ADDRESS),
              street_address_2:k.Safe(TextBox_street_address_2.Text, k.safe_hint_type.POSTAL_STREET_ADDRESS),
              city_state_zip:k.Safe(TextBox_city_state_zip.Text, k.safe_hint_type.POSTAL_STREET_ADDRESS)
              )
            )
            {
            add = true;
            }
          else
            {
            Alert(k.alert_cause_type.USER, k.alert_state_type.FAILURE, "alreadinsys", "NOT ADDED:  The specified name is already in the system for this region.", true);
            }
          }
        else
          {
          ValidationAlert(true);
          }
        }
      else
        {
        Label_invalid_birth_date.Visible = true;
        ValidationAlert(true);
        }
      return add;
      }

    protected void Button_add_and_stop_Click(object sender, System.EventArgs e)
      {
      if (Add())
        {
        BackTrack();
        }
      }

    protected void Button_add_and_repeat_Click(object sender, System.EventArgs e)
      {
      if (Add())
        {
        Clear();
        Button_add_and_repeat.Enabled = false;
        Button_add_and_stop.Enabled = false;
        }
      }

    }

  }

using Class_biz_coned_sponsor_users;
using kix;
using System.Web.UI;

namespace UserControl_coned_sponsor_user
  {
  public partial class TWebUserControl_coned_sponsor_user: ki_web_ui.usercontrol_class
    {

    private struct p_type
      {
      public bool be_loaded;
      public bool be_ok_to_config_users;
      public TClass_biz_coned_sponsor_users biz_coned_sponsor_users;
      public string id;
      }

    private p_type p;

    private void Clear()
      {
      CheckBox_be_stale_password.Checked = false;
      CheckBox_be_active.Checked = false;
      CheckBox_be_ok_to_input_roster_by_batch.Checked = false;
      CheckBox_be_ok_to_input_roster_by_copy.Checked = false;
      SetDependentFieldAblements(false);
      Button_submit.Enabled = false;
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        SetDataEntryMode();
        PresentRecord(p.id);
        p.be_loaded = true;
        }
      }

    private bool PresentRecord(string id)
      {
      bool be_stale_password;
      bool be_active;
      bool be_ok_to_input_roster_by_batch;
      bool be_ok_to_input_roster_by_copy;
      var result = false;
      if (p.biz_coned_sponsor_users.Get(id, out be_stale_password, out be_active, out be_ok_to_input_roster_by_batch, out be_ok_to_input_roster_by_copy))
        {
        CheckBox_be_stale_password.Checked = be_stale_password;
        CheckBox_be_active.Checked = be_active;
        CheckBox_be_ok_to_input_roster_by_batch.Checked = be_ok_to_input_roster_by_batch;
        CheckBox_be_ok_to_input_roster_by_copy.Checked = be_ok_to_input_roster_by_copy;
        SetDependentFieldAblements(p.be_ok_to_config_users);
        Button_submit.Enabled = p.be_ok_to_config_users;
        result = true;
        }
      return result;
      }

    private void SetDataEntryMode()
      {
      Clear();
      SetDependentFieldAblements(p.be_ok_to_config_users);
      Button_submit.Enabled = p.be_ok_to_config_users;
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
        p.biz_coned_sponsor_users = new TClass_biz_coned_sponsor_users();
        p.be_ok_to_config_users = true; //k.Has((string[])(Session["privilege_array"]), "config-users");
        p.id = k.EMPTY;
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebUserControl_coned_sponsor_user_PreRender;
      }

    private void TWebUserControl_coned_sponsor_user_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_coned_sponsor_user Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    protected void Button_submit_Click(object sender, System.EventArgs e)
      {
      if (Page.IsValid)
        {
        p.biz_coned_sponsor_users.Set(p.id,CheckBox_be_stale_password.Checked,CheckBox_be_active.Checked,CheckBox_be_ok_to_input_roster_by_batch.Checked,CheckBox_be_ok_to_input_roster_by_copy.Checked);
        Alert(k.alert_cause_type.USER, k.alert_state_type.SUCCESS, "recsaved", "Record saved.", true);
        //SetLookupMode();
        }
      else
        {
        ValidationAlert(true);
        }
      }

    private void SetDependentFieldAblements(bool ablement)
      {
      CheckBox_be_stale_password.Enabled = ablement;
      CheckBox_be_active.Enabled = ablement;
      CheckBox_be_ok_to_input_roster_by_batch.Enabled = ablement;
      CheckBox_be_ok_to_input_roster_by_copy.Enabled = ablement;
      }

    internal void SetTarget(string id)
      {
      p.id = id;
      }

    } // end TWebUserControl_coned_sponsor_user

  }

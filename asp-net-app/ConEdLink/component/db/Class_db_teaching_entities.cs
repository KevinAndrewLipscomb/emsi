// Derived from KiAspdotnetFramework/component/db/Class~db~template~kicrudhelped~items.cs~template

using Class_db;
using Class_db_trail;
using external_data_binding.emsams.ConEdSponsorInfo;
using kix;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Class_db_teaching_entities
  {
  public class TClass_db_teaching_entities: TClass_db
    {
    private readonly TClass_db_trail db_trail = null;

    public TClass_db_teaching_entities() : base()
      {
      db_trail = new TClass_db_trail();
      }

    public bool Bind(string partial_spec, object target)
      {
      var concat_clause = "concat(IFNULL(emsrs_id,'-'),'|',IFNULL(sponsor_number,'-'),'|',IFNULL(training_ins_accred_num,'-'),'|',IFNULL(name,'-'),'|',IFNULL(short_name,'-'),'|',IFNULL(address_1,'-'),'|',IFNULL(address_2,'-'),'|',IFNULL(city,'-'),'|',IFNULL(state,'-'),'|',IFNULL(zip,'-'),'|',IFNULL(county_code,'-'),'|',IFNULL(region,'-'),'|',IFNULL(email,'-'),'|',IFNULL(website,'-'),'|',IFNULL(daytime_phone,'-'),'|',IFNULL(evening_phone,'-'),'|',IFNULL(fax,'-'),'|',IFNULL(contact_first_name,'-'),'|',IFNULL(contact_last_name,'-'),'|',IFNULL(public_contact_name,'-'))";
      Open();
      ((target) as ListControl).Items.Clear();
      using var my_sql_command = new MySqlCommand
        (
        "select id"
        + " , CONVERT(" + concat_clause + " USING utf8) as spec"
        + " from teaching_entity"
        + " where " + concat_clause + " like '%" + partial_spec.ToUpper() + "%'"
        + " order by spec",
        connection
        );
      var dr = my_sql_command.ExecuteReader();
      while (dr.Read())
        {
        ((target) as ListControl).Items.Add(new ListItem(dr["spec"].ToString(), dr["id"].ToString()));
        }
      dr.Close();
      Close();
      return ((target) as ListControl).Items.Count > 0;
      }

    public void BindConedSponsorsBaseDataList
      (
      string region_code,
      string sort_order,
      bool be_order_ascending,
      object target
      )
      {
      Open();
      using var my_sql_command = new MySqlCommand
        (
        "select id"
        + " , sponsor_number"
        + " , IFNULL(teaching_entity.name,IFNULL(teaching_entity.short_name,'')) as name"
        + " , IFNULL(email,IFNULL(contact_email,public_contact_email)) as email_address"
        + " from teaching_entity"
        +   " join region_code_name_map on (region_code_name_map.emsrs_code=teaching_entity.region)"
        + " where sponsor_number is not null"
        +   " and IFNULL(email,IFNULL(contact_email,public_contact_email)) is not null"
        +   " and code = '" + region_code + "'"
        + " order by " + sort_order.Replace("%",(be_order_ascending ? " asc" : " desc")),
        connection
        );
      ((target) as BaseDataList).DataSource = my_sql_command.ExecuteReader();
      ((target) as BaseDataList).DataBind();
      Close();
      }

    public void BindDirectToListControl(object target)
      {
      Open();
      ((target) as ListControl).Items.Clear();
      using var my_sql_command = new MySqlCommand
        (
        "SELECT id"
        + " , CONVERT(concat(IFNULL(emsrs_id,'-'),'|',IFNULL(sponsor_number,'-'),'|',IFNULL(training_ins_accred_num,'-'),'|',IFNULL(name,'-'),'|',IFNULL(short_name,'-'),'|',IFNULL(address_1,'-'),'|',IFNULL(address_2,'-'),'|',IFNULL(city,'-'),'|',IFNULL(state,'-'),'|',IFNULL(zip,'-'),'|',IFNULL(county_code,'-'),'|',IFNULL(region,'-'),'|',IFNULL(email,'-'),'|',IFNULL(website,'-'),'|',IFNULL(daytime_phone,'-'),'|',IFNULL(evening_phone,'-'),'|',IFNULL(fax,'-'),'|',IFNULL(contact_first_name,'-'),'|',IFNULL(contact_last_name,'-'),'|',IFNULL(public_contact_name,'-')) USING utf8) as spec"
        + " FROM teaching_entity"
        + " order by spec",
        connection
        );
      var dr = my_sql_command.ExecuteReader();
      while (dr.Read())
        {
        ((target) as ListControl).Items.Add(new ListItem(dr["spec"].ToString(), dr["id"].ToString()));
        }
      dr.Close();
      Close();
      }

    public bool Delete(string id)
      {
      var result = true;
      Open();
      try
        {
        using var my_sql_command = new MySqlCommand(db_trail.Saved("delete from teaching_entity where id = \"" + id + "\""), connection);
        my_sql_command.ExecuteNonQuery();
        }
      catch(System.Exception e)
        {
        if (e.Message.StartsWith("Cannot delete or update a parent row: a foreign key constraint fails", true, null))
          {
          result = false;
          }
        else
          {
          throw;
          }
        }
      Close();
      return result;
      }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1806:Do not ignore method results")]
    public bool Get
      (
      string id,
      out string emsrs_id,
      out DateTime date_created,
      out DateTime date_last_edited,
      out string sponsor_number,
      out string training_ins_accred_num,
      out string name,
      out string short_name,
      out string address_1,
      out string address_2,
      out string city,
      out string state,
      out string zip,
      out string county_code,
      out string region,
      out string email,
      out string website,
      out string daytime_phone,
      out string evening_phone,
      out string fax,
      out string business_type_id,
      out string con_ed_level_id,
      out string certification_level,
      out string contact_first_name,
      out string contact_last_name,
      out string contact_title,
      out string contact_address_1,
      out string contact_address_2,
      out string contact_city,
      out string contact_state,
      out string contact_zip,
      out string contact_daytime_phone,
      out string contact_evening_phone,
      out string contact_fax,
      out string contact_email,
      out string public_contact_name,
      out string public_contact_phone,
      out string public_contact_email,
      out string public_contact_website,
      out string public_contact_notes,
      out DateTime application_date,
      out DateTime application_received,
      out string coned_sponsor_status_id,
      out string training_inst_status_id,
      out DateTime issue_date,
      out DateTime prev_expiration_date,
      out DateTime expiration_date_sponsor,
      out DateTime expiration_date_training_inst,
      out DateTime process_date,
      out string corrective_action,
      out DateTime compliance_by_date,
      out DateTime initial_accred_date,
      out DateTime accepted_provisional_date,
      out DateTime completed_provisional_date,
      out DateTime withdrawal_challenge_due_date,
      out bool letter_for_expiration,
      out bool letter_f_for_ppwk_non_compliance,
      out bool other_letter,
      out string history
      )
      {
      emsrs_id = k.EMPTY;
      date_created = DateTime.MinValue;
      date_last_edited = DateTime.MinValue;
      sponsor_number = k.EMPTY;
      training_ins_accred_num = k.EMPTY;
      name = k.EMPTY;
      short_name = k.EMPTY;
      address_1 = k.EMPTY;
      address_2 = k.EMPTY;
      city = k.EMPTY;
      state = k.EMPTY;
      zip = k.EMPTY;
      county_code = k.EMPTY;
      region = k.EMPTY;
      email = k.EMPTY;
      website = k.EMPTY;
      daytime_phone = k.EMPTY;
      evening_phone = k.EMPTY;
      fax = k.EMPTY;
      business_type_id = k.EMPTY;
      con_ed_level_id = k.EMPTY;
      certification_level = k.EMPTY;
      contact_first_name = k.EMPTY;
      contact_last_name = k.EMPTY;
      contact_title = k.EMPTY;
      contact_address_1 = k.EMPTY;
      contact_address_2 = k.EMPTY;
      contact_city = k.EMPTY;
      contact_state = k.EMPTY;
      contact_zip = k.EMPTY;
      contact_daytime_phone = k.EMPTY;
      contact_evening_phone = k.EMPTY;
      contact_fax = k.EMPTY;
      contact_email = k.EMPTY;
      public_contact_name = k.EMPTY;
      public_contact_phone = k.EMPTY;
      public_contact_email = k.EMPTY;
      public_contact_website = k.EMPTY;
      public_contact_notes = k.EMPTY;
      application_date = DateTime.MinValue;
      application_received = DateTime.MinValue;
      coned_sponsor_status_id = k.EMPTY;
      training_inst_status_id = k.EMPTY;
      issue_date = DateTime.MinValue;
      prev_expiration_date = DateTime.MinValue;
      expiration_date_sponsor = DateTime.MinValue;
      expiration_date_training_inst = DateTime.MinValue;
      process_date = DateTime.MinValue;
      corrective_action = k.EMPTY;
      compliance_by_date = DateTime.MinValue;
      initial_accred_date = DateTime.MinValue;
      accepted_provisional_date = DateTime.MinValue;
      completed_provisional_date = DateTime.MinValue;
      withdrawal_challenge_due_date = DateTime.MinValue;
      letter_for_expiration = false;
      letter_f_for_ppwk_non_compliance = false;
      other_letter = false;
      history = k.EMPTY;
      var result = false;
      //
      Open();
      using var my_sql_command = new MySqlCommand("select * from teaching_entity where CAST(id AS CHAR) = \"" + id + "\"", connection);
      var dr = my_sql_command.ExecuteReader();
      if (dr.Read())
        {
        emsrs_id = dr["emsrs_id"].ToString();
        DateTime.TryParse(dr["date_created"].ToString(),out date_created);
        DateTime.TryParse(dr["date_last_edited"].ToString(),out date_last_edited);
        sponsor_number = dr["sponsor_number"].ToString();
        training_ins_accred_num = dr["training_ins_accred_num"].ToString();
        name = dr["name"].ToString();
        short_name = dr["short_name"].ToString();
        address_1 = dr["address_1"].ToString();
        address_2 = dr["address_2"].ToString();
        city = dr["city"].ToString();
        state = dr["state"].ToString();
        zip = dr["zip"].ToString();
        county_code = dr["county_code"].ToString();
        region = dr["region"].ToString();
        email = dr["email"].ToString();
        website = dr["website"].ToString();
        daytime_phone = dr["daytime_phone"].ToString();
        evening_phone = dr["evening_phone"].ToString();
        fax = dr["fax"].ToString();
        business_type_id = dr["business_type_id"].ToString();
        con_ed_level_id = dr["con_ed_level_id"].ToString();
        certification_level = dr["certification_level"].ToString();
        contact_first_name = dr["contact_first_name"].ToString();
        contact_last_name = dr["contact_last_name"].ToString();
        contact_title = dr["contact_title"].ToString();
        contact_address_1 = dr["contact_address_1"].ToString();
        contact_address_2 = dr["contact_address_2"].ToString();
        contact_city = dr["contact_city"].ToString();
        contact_state = dr["contact_state"].ToString();
        contact_zip = dr["contact_zip"].ToString();
        contact_daytime_phone = dr["contact_daytime_phone"].ToString();
        contact_evening_phone = dr["contact_evening_phone"].ToString();
        contact_fax = dr["contact_fax"].ToString();
        contact_email = dr["contact_email"].ToString();
        public_contact_name = dr["public_contact_name"].ToString();
        public_contact_phone = dr["public_contact_phone"].ToString();
        public_contact_email = dr["public_contact_email"].ToString();
        public_contact_website = dr["public_contact_website"].ToString();
        public_contact_notes = dr["public_contact_notes"].ToString();
        DateTime.TryParse(dr["application_date"].ToString(),out application_date);
        DateTime.TryParse(dr["application_received"].ToString(),out application_received);
        coned_sponsor_status_id = dr["coned_sponsor_status_id"].ToString();
        training_inst_status_id = dr["training_inst_status_id"].ToString();
        DateTime.TryParse(dr["issue_date"].ToString(),out issue_date);
        DateTime.TryParse(dr["prev_expiration_date"].ToString(),out prev_expiration_date);
        DateTime.TryParse(dr["expiration_date_sponsor"].ToString(),out expiration_date_sponsor);
        DateTime.TryParse(dr["expiration_date_training_inst"].ToString(),out expiration_date_training_inst);
        DateTime.TryParse(dr["process_date"].ToString(),out process_date);
        corrective_action = dr["corrective_action"].ToString();
        DateTime.TryParse(dr["compliance_by_date"].ToString(),out compliance_by_date);
        DateTime.TryParse(dr["initial_accred_date"].ToString(),out initial_accred_date);
        DateTime.TryParse(dr["accepted_provisional_date"].ToString(),out accepted_provisional_date);
        DateTime.TryParse(dr["completed_provisional_date"].ToString(),out completed_provisional_date);
        DateTime.TryParse(dr["withdrawal_challenge_due_date"].ToString(),out withdrawal_challenge_due_date);
        letter_for_expiration = (dr["letter_for_expiration"].ToString() == "1");
        letter_f_for_ppwk_non_compliance = (dr["letter_f_for_ppwk_non_compliance"].ToString() == "1");
        other_letter = (dr["other_letter"].ToString() == "1");
        history = dr["history"].ToString();
        result = true;
        }
      dr.Close();
      Close();
      return result;
      }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types")]
    internal void ImportLatestFromEmsrs(ArrayList recs)
      {
      if (recs.Count > 0)
        {
        var application_name = ConfigurationManager.AppSettings["application_name"];
        var be_production_instance = !(application_name.ToLower().EndsWith("_d") || application_name.ToLower().EndsWith("_x"));
        //
        MySqlTransaction transaction;
        var emsrs_id = k.EMPTY;
        var email = k.EMPTY;
        var childless_field_assignments_clause = k.EMPTY;
        Open();
        foreach (var rec in recs)
          {
          if ((rec as SponsorsSponsor).Name != null)
            {
            emsrs_id = (rec as SponsorsSponsor).SponsorID.ToString();
            //
            email = k.EMPTY;
            if (be_production_instance)
              {
              if ((rec as SponsorsSponsor).Email != null)
                {
                var safe_email = k.Safe((rec as SponsorsSponsor).Email,k.safe_hint_type.EMAIL_ADDRESS);
                if (k.BeValidFormatEmailAddress(safe_email))
                  {
                  email = safe_email;
                  }
                }
              }
            else
              {
              email = "TeachingEnt" + emsrs_id + "E@frompaper2web.com";
              }
            //
            childless_field_assignments_clause = k.EMPTY
            + " sponsor_number = NULLIF('" + k.Safe((rec as SponsorsSponsor).SponsorNumber,k.safe_hint_type.HYPHENATED_NUM) + "','')"
            + " , name = NULLIF('" + k.Safe((rec as SponsorsSponsor).Name,k.safe_hint_type.ORG_NAME).Trim() + "','')"
            + " , region = NULLIF('" + (rec as SponsorsSponsor).Region.ToString() + "','')"
            + " , email = NULLIF('" + email + "','')"
            + " , coned_sponsor_status_id = NULLIF(IFNULL((select id from coned_sponsor_status where description = '" + k.Safe((rec as SponsorsSponsor).SponsorStatusDescription,k.safe_hint_type.ALPHA_WORDS) + "'),''),'')"
            + k.EMPTY;
            transaction = connection.BeginTransaction();
            try
              {
              using var my_sql_command_1 = new MySqlCommand("select 1 from teaching_entity where emsrs_id = '" + emsrs_id + "'",connection,transaction);
              if (my_sql_command_1.ExecuteScalar() == null)
                {
                using var my_sql_command_2 = new MySqlCommand("insert teaching_entity set emsrs_id = NULLIF('" + emsrs_id + "',''), " + childless_field_assignments_clause,connection,transaction);
                my_sql_command_2.ExecuteNonQuery();
                }
              else
                {
                using var my_sql_command_3 = new MySqlCommand("update teaching_entity set " + childless_field_assignments_clause + " where emsrs_id = '" + emsrs_id + "'",connection,transaction);
                my_sql_command_3.ExecuteNonQuery();
                }
              transaction.Commit();
              }
            catch (Exception e)
              {
              transaction.Rollback();
              k.EscalatedException(e,"#noninteractive#" + k.NEW_LINE + "emsrs_id = [" + emsrs_id + "]" + k.NEW_LINE + "childless_field_assignments_clause = [" + childless_field_assignments_clause + "]");
              }
            }
          }
        Close();
        }
      }

    public void Set
      (
      string id,
      string emsrs_id,
      DateTime date_created,
      DateTime date_last_edited,
      string sponsor_number,
      string training_ins_accred_num,
      string name,
      string short_name,
      string address_1,
      string address_2,
      string city,
      string state,
      string zip,
      string county_code,
      string region,
      string email,
      string website,
      string daytime_phone,
      string evening_phone,
      string fax,
      string business_type_id,
      string con_ed_level_id,
      string certification_level,
      string contact_first_name,
      string contact_last_name,
      string contact_title,
      string contact_address_1,
      string contact_address_2,
      string contact_city,
      string contact_state,
      string contact_zip,
      string contact_daytime_phone,
      string contact_evening_phone,
      string contact_fax,
      string contact_email,
      string public_contact_name,
      string public_contact_phone,
      string public_contact_email,
      string public_contact_website,
      string public_contact_notes,
      DateTime application_date,
      DateTime application_received,
      string coned_sponsor_status_id,
      string training_inst_status_id,
      DateTime issue_date,
      DateTime prev_expiration_date,
      DateTime expiration_date_sponsor,
      DateTime expiration_date_training_inst,
      DateTime process_date,
      string corrective_action,
      DateTime compliance_by_date,
      DateTime initial_accred_date,
      DateTime accepted_provisional_date,
      DateTime completed_provisional_date,
      DateTime withdrawal_challenge_due_date,
      bool letter_for_expiration,
      bool letter_f_for_ppwk_non_compliance,
      bool other_letter,
      string history
      )
      {
      var childless_field_assignments_clause = k.EMPTY
      + "emsrs_id = NULLIF('" + emsrs_id + "','')"
      + " , date_created = '" + date_created.ToString("yyyy-MM-dd") + "'"
      + " , date_last_edited = '" + date_last_edited.ToString("yyyy-MM-dd") + "'"
      + " , sponsor_number = NULLIF('" + sponsor_number + "','')"
      + " , training_ins_accred_num = NULLIF('" + training_ins_accred_num + "','')"
      + " , name = NULLIF('" + name + "','')"
      + " , short_name = NULLIF('" + short_name + "','')"
      + " , address_1 = NULLIF('" + address_1 + "','')"
      + " , address_2 = NULLIF('" + address_2 + "','')"
      + " , city = NULLIF('" + city + "','')"
      + " , state = NULLIF('" + state + "','')"
      + " , zip = NULLIF('" + zip + "','')"
      + " , county_code = NULLIF('" + county_code + "','')"
      + " , region = NULLIF('" + region + "','')"
      + " , email = NULLIF('" + email + "','')"
      + " , website = NULLIF('" + website + "','')"
      + " , daytime_phone = NULLIF('" + daytime_phone + "','')"
      + " , evening_phone = NULLIF('" + evening_phone + "','')"
      + " , fax = NULLIF('" + fax + "','')"
      + " , business_type_id = NULLIF('" + business_type_id + "','')"
      + " , con_ed_level_id = NULLIF('" + con_ed_level_id + "','')"
      + " , certification_level = NULLIF('" + certification_level + "','')"
      + " , contact_first_name = NULLIF('" + contact_first_name + "','')"
      + " , contact_last_name = NULLIF('" + contact_last_name + "','')"
      + " , contact_title = NULLIF('" + contact_title + "','')"
      + " , contact_address_1 = NULLIF('" + contact_address_1 + "','')"
      + " , contact_address_2 = NULLIF('" + contact_address_2 + "','')"
      + " , contact_city = NULLIF('" + contact_city + "','')"
      + " , contact_state = NULLIF('" + contact_state + "','')"
      + " , contact_zip = NULLIF('" + contact_zip + "','')"
      + " , contact_daytime_phone = NULLIF('" + contact_daytime_phone + "','')"
      + " , contact_evening_phone = NULLIF('" + contact_evening_phone + "','')"
      + " , contact_fax = NULLIF('" + contact_fax + "','')"
      + " , contact_email = NULLIF('" + contact_email + "','')"
      + " , public_contact_name = NULLIF('" + public_contact_name + "','')"
      + " , public_contact_phone = NULLIF('" + public_contact_phone + "','')"
      + " , public_contact_email = NULLIF('" + public_contact_email + "','')"
      + " , public_contact_website = NULLIF('" + public_contact_website + "','')"
      + " , public_contact_notes = NULLIF('" + public_contact_notes + "','')"
      + " , application_date = '" + application_date.ToString("yyyy-MM-dd") + "'"
      + " , application_received = '" + application_received.ToString("yyyy-MM-dd") + "'"
      + " , coned_sponsor_status_id = NULLIF('" + coned_sponsor_status_id + "','')"
      + " , training_inst_status_id = NULLIF('" + training_inst_status_id + "','')"
      + " , issue_date = '" + issue_date.ToString("yyyy-MM-dd") + "'"
      + " , prev_expiration_date = '" + prev_expiration_date.ToString("yyyy-MM-dd") + "'"
      + " , expiration_date_sponsor = '" + expiration_date_sponsor.ToString("yyyy-MM-dd") + "'"
      + " , expiration_date_training_inst = '" + expiration_date_training_inst.ToString("yyyy-MM-dd") + "'"
      + " , process_date = '" + process_date.ToString("yyyy-MM-dd") + "'"
      + " , corrective_action = NULLIF('" + corrective_action + "','')"
      + " , compliance_by_date = '" + compliance_by_date.ToString("yyyy-MM-dd") + "'"
      + " , initial_accred_date = '" + initial_accred_date.ToString("yyyy-MM-dd") + "'"
      + " , accepted_provisional_date = '" + accepted_provisional_date.ToString("yyyy-MM-dd") + "'"
      + " , completed_provisional_date = '" + completed_provisional_date.ToString("yyyy-MM-dd") + "'"
      + " , withdrawal_challenge_due_date = '" + withdrawal_challenge_due_date.ToString("yyyy-MM-dd") + "'"
      + " , letter_for_expiration = NULLIF('" + letter_for_expiration.ToString() + "','')"
      + " , letter_f_for_ppwk_non_compliance = NULLIF('" + letter_f_for_ppwk_non_compliance.ToString() + "','')"
      + " , other_letter = NULLIF('" + other_letter.ToString() + "','')"
      + " , history = NULLIF('" + history + "','')"
      + k.EMPTY;
      Open();
      using var my_sql_command = new MySqlCommand
        (
        db_trail.Saved
          (
          "insert teaching_entity"
          + " set id = NULLIF('" + id + "','')"
          + " , " + childless_field_assignments_clause
          + " on duplicate key update "
          + childless_field_assignments_clause
          ),
          connection
        );
      my_sql_command.ExecuteNonQuery();
      Close();
      }

    internal string SponsorNumberOf(string id)
      {
      Open();
      using var my_sql_command = new MySqlCommand("select sponsor_number from teaching_entity where id = '" + id + "'",connection);
      var sponsor_number_of = my_sql_command.ExecuteScalar().ToString();
      Close();
      return sponsor_number_of;
      }

    internal void SyncConedSponsorAccounts()
      {
      Open();
      using var my_sql_command = new MySqlCommand
        (
        "update coned_sponsor_user"
        + " join teaching_entity using (id)"
        + " set password_reset_email_address = IFNULL(email,IFNULL(contact_email,public_contact_email))"
        + " where IFNULL(email,IFNULL(contact_email,public_contact_email)) is not null"
        + ";"
        + " insert coned_sponsor_user (id,password_reset_email_address)"
        + " select id"
        + " , IFNULL(email,IFNULL(contact_email,public_contact_email)) as password_reset_email_address"
        + " from teaching_entity left outer join coned_sponsor_user using (id)"
        + " where coned_sponsor_user.id is null"
        +   " and sponsor_number is not null"
        +   " and IFNULL(email,IFNULL(contact_email,public_contact_email)) is not null",
        connection
        );
      my_sql_command.ExecuteNonQuery();
      Close();
      }

    } // end TClass_db_teaching_entitys

  }

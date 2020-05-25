using Class_db;
using Class_db_trail;
using MySql.Data.MySqlClient;
using kix;
using System;
using System.Web.UI.WebControls;

namespace Class_db_strike_team_deployment_member_policies
  {

  internal enum strike_team_deployment_member_policy_enumeration
    {
    DESCRIPTION_1 = 1,
    DESCRIPTION_2 = 2
    }

  public class TClass_db_strike_team_deployment_member_policies: TClass_db
    {

    private readonly TClass_db_trail db_trail = null;

    public TClass_db_strike_team_deployment_member_policies() : base()
      {
      db_trail = new TClass_db_trail();
      }

    public bool Bind
      (
      string partial_spec,
      object target
      )
      {
      Open();
      ((target) as ListControl).Items.Clear();
      using var my_sql_command = new MySqlCommand
        (
        "SELECT lpad(id,4,'0') as id"
        + " , description"
        + " FROM strike_team_deployment_member_policy"
        + " WHERE concat(lpad(id,4,'0'),' -- ',description) like '%" + partial_spec + "%'"
        + " order by description",
        connection
        );
      var dr = my_sql_command.ExecuteReader();
      while (dr.Read())
        {
        ((target) as ListControl).Items.Add(new ListItem(dr["id"].ToString() + k.SPACE_HYPHENS_SPACE + dr["description"].ToString(), dr["id"].ToString()));
        }
      dr.Close();
      Close();
      return ((target) as ListControl).Items.Count > 0;
      }

    public void BindDirectToListControl
      (
      object target,
      string unselected_literal,
      string selected_value
      )
      {
      ((target) as ListControl).Items.Clear();
      if (unselected_literal.Length > 0)
        {
        ((target) as ListControl).Items.Add(new ListItem(unselected_literal, k.EMPTY));
        }
      Open();
      using var my_sql_command = new MySqlCommand("SELECT id,description FROM strike_team_deployment_member_policy where description <> '(none specified)' order by id", connection);
      var dr = my_sql_command.ExecuteReader();
      while (dr.Read())
        {
        ((target) as ListControl).Items.Add(new ListItem(dr["description"].ToString(), dr["id"].ToString()));
        }
      dr.Close();
      Close();
      if (selected_value.Length > 0)
        {
        ((target) as ListControl).SelectedValue = selected_value;
        }
      }
    public void BindDirectToListControl(object target,string unselected_literal)
      {
      BindDirectToListControl(target, unselected_literal, k.EMPTY);
      }
    public void BindDirectToListControl(object target)
      {
      BindDirectToListControl(target, "-- strike_team_deployment_member_policy --");
      }

    public bool Delete(string id)
      {
      var result = true;
      Open();
      try
        {
        using var my_sql_command = new MySqlCommand(db_trail.Saved("delete from strike_team_deployment_member_policy where id = '" + id + "'"), connection);
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

    internal string DescriptionOf(string id)
      {
      Open();
      using var my_sql_command = new MySqlCommand("select description from strike_team_deployment_member_policy where id = '" + id + "'",connection);
      var description_of = my_sql_command.ExecuteScalar().ToString();
      Close();
      return description_of;
      }

    public bool Get
      (
      string id,
      out string description
      )
      {
      description = k.EMPTY;
      var result = false;
      Open();
      using var my_sql_command = new MySqlCommand("select description from strike_team_deployment_member_policy where id = '" + id + "'", connection);
      var dr = my_sql_command.ExecuteReader();
      if (dr.Read())
        {
        description = dr["description"].ToString();
        result = true;
        }
      dr.Close();
      Close();
      return result;
      }

    public void Set
      (
      string id,
      string description
      )
      {
      var childless_field_assignments_clause = "description = '" + description + "'";
      db_trail.MimicTraditionalInsertOnDuplicateKeyUpdate
        (
        target_table_name:"strike_team_deployment_member_policy",
        key_field_name:"id",
        key_field_value:id,
        childless_field_assignments_clause:childless_field_assignments_clause
        );
      }

    } // end TClass_db_strike_team_deployment_member_policies

  }

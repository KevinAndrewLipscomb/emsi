using Class_db;
using Class_db_trail;
using MySql.Data.MySqlClient;
using kix;
using System;
using System.Web.UI.WebControls;

namespace Class_db_eval_summary_modes
  {

  internal enum eval_summary_mode_enumeration
    {
    DESCRIPTION_1 = 1,
    DESCRIPTION_2 = 2
    }

  public class TClass_db_eval_summary_modes: TClass_db
    {

    private readonly TClass_db_trail db_trail = null;

    public TClass_db_eval_summary_modes() : base()
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
        + " FROM eval_summary_mode"
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
      using var my_sql_command = new MySqlCommand("SELECT id,description FROM eval_summary_mode where description <> '(none specified)' order by id", connection);
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
      BindDirectToListControl(target, "-- eval_summary_mode --");
      }

    public void BindRadioButtonList(object target)
      {
      var display_html = k.EMPTY;
      Open();
      ((target) as RadioButtonList).Items.Clear();
      using var my_sql_command = new MySqlCommand
        (
        "SELECT id"
        + " , description"
        + " , elaboration"
        + " FROM eval_summary_mode",
        connection
        );
      var dr = my_sql_command.ExecuteReader();
      while (dr.Read())
        {
        display_html = "<b>" + dr["description"].ToString() + "</b>";
        if (dr["elaboration"].ToString().Length > 0)
          {
          display_html = display_html
          + "<table>"
          +   "<tr>"
          +     "<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>"
          +     "<td><small><i>" + dr["elaboration"].ToString() + "</i></small></td>"
          +   "</tr>"
          + "</table>";
          }
        ((target) as RadioButtonList).Items.Add(new ListItem(display_html, dr["id"].ToString()));
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
        using var my_sql_command = new MySqlCommand(db_trail.Saved("delete from eval_summary_mode where id = '" + id + "'"), connection);
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

    public bool Get
      (
      string id,
      out string description
      )
      {
      description = k.EMPTY;
      var result = false;
      Open();
      using var my_sql_command = new MySqlCommand("select description from eval_summary_mode where id = '" + id + "'", connection);
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
        target_table_name:"eval_summary_mode",
        key_field_name:"id",
        key_field_value:id,
        childless_field_assignments_clause:childless_field_assignments_clause
        );
      }

    } // end TClass_db_eval_summary_modes

  }

// Derived from KiAspdotnetFramework/component/db/Class~db~template~kicrudhelped~items.cs~template

using Class_db;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Web.UI.WebControls;
using UserControl_drop_down_date;

namespace Class_db_eval_summary_tallies
  {
  public class TClass_db_eval_summary_tallies: TClass_db
    {
    private class eval_summary_tally_summary
      {
      public string id;
      }

    private TClass_db_trail db_trail = null;

    public TClass_db_eval_summary_tallies() : base()
      {
      db_trail = new TClass_db_trail();
      }

    public bool Bind(string partial_spec, object target)
      {
      var concat_clause = "concat(id)";
      Open();
      ((target) as ListControl).Items.Clear();
      var dr = new MySqlCommand
        (
        "select id"
        + " , CONVERT(" + concat_clause + " USING utf8) as spec"
        + " from eval_summary_tally"
        + " where " + concat_clause + " like '%" + partial_spec.ToUpper() + "%'"
        + " order by spec",
        connection
        )
        .ExecuteReader();
      while (dr.Read())
        {
        ((target) as ListControl).Items.Add(new ListItem(dr["spec"].ToString(), dr["id"].ToString()));
        }
      dr.Close();
      Close();
      return ((target) as ListControl).Items.Count > 0;
      }

    internal void BindBaseDataList
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target
      )
      {
      Open();
      ((target) as BaseDataList).DataSource = new MySqlCommand
        (
        "select eval_summary_tally.id as id"
        + " from eval_summary_tally",
        connection
        )
        .ExecuteReader();
      ((target) as BaseDataList).DataBind();
      Close();
      }

    public void BindDirectToListControl(object target)
      {
      Open();
      ((target) as ListControl).Items.Clear();
      var dr = new MySqlCommand
        (
        "SELECT id"
        + " , CONVERT(concat(id) USING utf8) as spec"
        + " FROM eval_summary_tally"
        + " order by spec",
        connection
        )
        .ExecuteReader();
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
        new MySqlCommand(db_trail.Saved("delete from eval_summary_tally where id = \"" + id + "\""), connection).ExecuteNonQuery();
        }
      catch(System.Exception e)
        {
        if (e.Message.StartsWith("Cannot delete or update a parent row: a foreign key constraint fails", true, null))
          {
          result = false;
          }
        else
          {
          throw e;
          }
        }
      Close();
      return result;
      }

    public bool Get
      (
      string id,
      out string coned_offering_id,
      out string rating,
      out string question,
      out string value
      )
      {
      coned_offering_id = k.EMPTY;
      rating = k.EMPTY;
      question = k.EMPTY;
      value = k.EMPTY;
      var result = false;
      //
      Open();
      var dr = new MySqlCommand("select * from eval_summary_tally where CAST(id AS CHAR) = \"" + id + "\"", connection).ExecuteReader();
      if (dr.Read())
        {
        coned_offering_id = dr["coned_offering_id"].ToString();
        rating = dr["rating"].ToString();
        question = dr["question"].ToString();
        value = dr["value"].ToString();
        result = true;
        }
      dr.Close();
      Close();
      return result;
      }

    internal string GetPractical
      (
      string coned_offering_id,
      string rating,
      string question
      )
      {
      Open();
      var value_obj = new MySqlCommand("select value from eval_summary_tally where coned_offering_id = '" + coned_offering_id + "' and rating = '" + rating + "' and question = '" + question + "'",connection).ExecuteScalar();
      Close();
      return (value_obj == null ? k.EMPTY : value_obj.ToString());
      }

    public void Set
      (
      string id,
      string coned_offering_id,
      string rating,
      string question,
      string value
      )
      {
      var childless_field_assignments_clause = k.EMPTY
      + "coned_offering_id = NULLIF('" + coned_offering_id + "','')"
      + " , rating = NULLIF('" + rating + "','')"
      + " , question = NULLIF('" + question + "','')"
      + " , value = NULLIF('" + value + "','')"
      + k.EMPTY;
      db_trail.MimicTraditionalInsertOnDuplicateKeyUpdate
        (
        target_table_name:"eval_summary_tally",
        key_field_name:"id",
        key_field_value:id,
        childless_field_assignments_clause:childless_field_assignments_clause
        );
      }

    internal object Summary(string id)
      {
      Open();
      var dr =
        (
        new MySqlCommand
          (
          "SELECT *"
          + " FROM eval_summary_tally"
          + " where id = '" + id + "'",
          connection
          )
          .ExecuteReader()
        );
      dr.Read();
      var the_summary = new eval_summary_tally_summary()
        {
        id = id
        };
      Close();
      return the_summary;
      }

    } // end TClass_db_eval_summary_tallies

  }

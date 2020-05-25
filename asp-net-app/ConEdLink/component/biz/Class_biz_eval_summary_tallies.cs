// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_db_eval_summary_tallies;
using kix;
using System;
using System.Collections;

namespace Class_biz_eval_summary_tallies
  {
  public class TClass_biz_eval_summary_tallies
    {
    private readonly TClass_db_eval_summary_tallies db_eval_summary_tallies = null;

    public TClass_biz_eval_summary_tallies() : base()
      {
      db_eval_summary_tallies = new TClass_db_eval_summary_tallies();
      }

    public bool Bind(string partial_spec, object target)
      {
      return db_eval_summary_tallies.Bind(partial_spec, target);
      }

    public void BindBaseDataList
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target
      )
      {
      db_eval_summary_tallies.BindBaseDataList(sort_order,be_sort_order_ascending,target);
      }

    public void BindDirectToListControl(object target)
      {
      db_eval_summary_tallies.BindDirectToListControl(target);
      }

    public bool Delete(string id)
      {
      return db_eval_summary_tallies.Delete(id);
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
      return db_eval_summary_tallies.Get
        (
        id,
        out coned_offering_id,
        out rating,
        out question,
        out value
        );
      }

    internal void Load
      (
      string coned_offering_id,
      out string question_1_rating_1,
      out string question_1_rating_2,
      out string question_1_rating_3,
      out string question_1_rating_4,
      out string question_1_rating_5,
      out string question_2_rating_1,
      out string question_2_rating_2,
      out string question_2_rating_3,
      out string question_2_rating_4,
      out string question_2_rating_5,
      out string question_3_rating_1,
      out string question_3_rating_2,
      out string question_3_rating_3,
      out string question_3_rating_4,
      out string question_3_rating_5,
      out string question_4_rating_1,
      out string question_4_rating_2,
      out string question_4_rating_3,
      out string question_4_rating_4,
      out string question_4_rating_5,
      out string question_5_rating_1,
      out string question_5_rating_2,
      out string question_5_rating_3,
      out string question_5_rating_4,
      out string question_5_rating_5,
      out string question_6_rating_1,
      out string question_6_rating_2,
      out string question_6_rating_3,
      out string question_6_rating_4,
      out string question_6_rating_5
      )
      {
      question_1_rating_1 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"1",question:"1");
      question_1_rating_2 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"2",question:"1");
      question_1_rating_3 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"3",question:"1");
      question_1_rating_4 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"4",question:"1");
      question_1_rating_5 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"5",question:"1");
      question_2_rating_1 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"1",question:"2");
      question_2_rating_2 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"2",question:"2");
      question_2_rating_3 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"3",question:"2");
      question_2_rating_4 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"4",question:"2");
      question_2_rating_5 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"5",question:"2");
      question_3_rating_1 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"1",question:"3");
      question_3_rating_2 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"2",question:"3");
      question_3_rating_3 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"3",question:"3");
      question_3_rating_4 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"4",question:"3");
      question_3_rating_5 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"5",question:"3");
      question_4_rating_1 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"1",question:"4");
      question_4_rating_2 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"2",question:"4");
      question_4_rating_3 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"3",question:"4");
      question_4_rating_4 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"4",question:"4");
      question_4_rating_5 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"5",question:"4");
      question_5_rating_1 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"1",question:"5");
      question_5_rating_2 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"2",question:"5");
      question_5_rating_3 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"3",question:"5");
      question_5_rating_4 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"4",question:"5");
      question_5_rating_5 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"5",question:"5");
      question_6_rating_1 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"1",question:"6");
      question_6_rating_2 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"2",question:"6");
      question_6_rating_3 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"3",question:"6");
      question_6_rating_4 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"4",question:"6");
      question_6_rating_5 = db_eval_summary_tallies.GetPractical(coned_offering_id:coned_offering_id,rating:"5",question:"6");
      }

    internal void Save
      (
      string coned_offering_id,
      string question_1_rating_1,
      string question_1_rating_2,
      string question_1_rating_3,
      string question_1_rating_4,
      string question_1_rating_5,
      string question_2_rating_1,
      string question_2_rating_2,
      string question_2_rating_3,
      string question_2_rating_4,
      string question_2_rating_5,
      string question_3_rating_1,
      string question_3_rating_2,
      string question_3_rating_3,
      string question_3_rating_4,
      string question_3_rating_5,
      string question_4_rating_1,
      string question_4_rating_2,
      string question_4_rating_3,
      string question_4_rating_4,
      string question_4_rating_5,
      string question_5_rating_1,
      string question_5_rating_2,
      string question_5_rating_3,
      string question_5_rating_4,
      string question_5_rating_5,
      string question_6_rating_1,
      string question_6_rating_2,
      string question_6_rating_3,
      string question_6_rating_4,
      string question_6_rating_5
      )
      {
      if (question_1_rating_1.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"1",question:"1",value:question_1_rating_1); }
      if (question_1_rating_2.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"2",question:"1",value:question_1_rating_2); }
      if (question_1_rating_3.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"3",question:"1",value:question_1_rating_3); }
      if (question_1_rating_4.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"4",question:"1",value:question_1_rating_4); }
      if (question_1_rating_5.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"5",question:"1",value:question_1_rating_5); }
      if (question_2_rating_1.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"1",question:"2",value:question_2_rating_1); }
      if (question_2_rating_2.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"2",question:"2",value:question_2_rating_2); }
      if (question_2_rating_3.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"3",question:"2",value:question_2_rating_3); }
      if (question_2_rating_4.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"4",question:"2",value:question_2_rating_4); }
      if (question_2_rating_5.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"5",question:"2",value:question_2_rating_5); }
      if (question_3_rating_1.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"1",question:"3",value:question_3_rating_1); }
      if (question_3_rating_2.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"2",question:"3",value:question_3_rating_2); }
      if (question_3_rating_3.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"3",question:"3",value:question_3_rating_3); }
      if (question_3_rating_4.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"4",question:"3",value:question_3_rating_4); }
      if (question_3_rating_5.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"5",question:"3",value:question_3_rating_5); }
      if (question_4_rating_1.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"1",question:"4",value:question_4_rating_1); }
      if (question_4_rating_2.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"2",question:"4",value:question_4_rating_2); }
      if (question_4_rating_3.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"3",question:"4",value:question_4_rating_3); }
      if (question_4_rating_4.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"4",question:"4",value:question_4_rating_4); }
      if (question_4_rating_5.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"5",question:"4",value:question_4_rating_5); }
      if (question_5_rating_1.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"1",question:"5",value:question_5_rating_1); }
      if (question_5_rating_2.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"2",question:"5",value:question_5_rating_2); }
      if (question_5_rating_3.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"3",question:"5",value:question_5_rating_3); }
      if (question_5_rating_4.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"4",question:"5",value:question_5_rating_4); }
      if (question_5_rating_5.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"5",question:"5",value:question_5_rating_5); }
      if (question_6_rating_1.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"1",question:"6",value:question_6_rating_1); }
      if (question_6_rating_2.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"2",question:"6",value:question_6_rating_2); }
      if (question_6_rating_3.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"3",question:"6",value:question_6_rating_3); }
      if (question_6_rating_4.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"4",question:"6",value:question_6_rating_4); }
      if (question_6_rating_5.Length > 0) { db_eval_summary_tallies.Set(id:k.EMPTY,coned_offering_id:coned_offering_id,rating:"5",question:"6",value:question_6_rating_5); }
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
      db_eval_summary_tallies.Set
        (
        id,
        coned_offering_id,
        rating,
        question,
        value
        );
      }

    internal object Summary(string id)
      {
      return db_eval_summary_tallies.Summary(id);
      }

    } // end TClass_biz_eval_summary_tallies

  }

select fiscal_year.designator as fiscal_year_designator
, state_dictated_appropriation.amendment_num as state_dictated_appropriation_amendment_num
, state_dictated_appropriation.amount as state_dictated_appropriation_amount
, state_dictated_appropriation.funding_rounds_generated as state_dictated_appropriation_funding_rounds_generated
, county_code_name_map.name as county_name
, county_default_match_level.name as county_default_match_level_name
, county_default_match_level.factor as county_default_match_level_factor
, county_code_name_map.emsrs_code as county_emsrs_code
, region_dictated_appropriation.amount as region_dictated_appropriation_amount
, region_dictated_appropriation.service_to_county_submission_deadline as region_dictated_appropriation_service_to_county_submission_deadline
, region_dictated_appropriation_match_level.name as region_dictated_appropriation_match_level_name
, region_dictated_appropriation_match_level.factor as region_dictated_appropriation_match_level_factor
, service.*
, charter_kind.description as charter_kind
, county_dictated_appropriation.amount as county_dictated_appropriation_amount
, county_dictated_appropriation_match_level.name as county_dictated_appropriation_match_level_name
, county_dictated_appropriation_match_level.factor as county_dictated_appropriation_match_level_factor
, request_status_code_description_map.description as emsof_request_master_status
, emsof_request_master.value as emsof_request_master_value
, emsof_request_master.num_items as emsof_request_master_num_items
, emsof_request_master.shortage as emsof_request_master_shortage
, emsof_request_master.has_wish_list as emsof_request_master_has_wish_list
, emsof_request_master.county_approval_timestamp as emsof_request_master_county_approval_timestamp
, emsof_request_master.regional_planner_approval_timestamp as emsof_request_master_regional_planner_approval_timestamp
, emsof_request_master.regional_director_approval_timestamp as emsof_request_master_regional_director_approval_timestamp
, emsof_request_master.state_approval_timestamp as emsof_request_master_state_approval_timestamp
, emsof_request_master.actual_value as emsof_request_master_actual_value
, emsof_request_master.be_deadline_exempt as emsof_request_master_be_deadline_exempt
, emsof_request_master.be_reopened_after_going_to_state as emsof_request_master_be_reopened_after_going_to_state
, emsof_request_detail.make_model as emsof_request_detail_make_model
, emsof_request_detail.place_kept as emsof_request_detail_place_kept
, emsof_request_detail.be_refurbished as emsof_request_detail_be_refurbished
, emsof_request_detail.quantity as emsof_request_detail_quantity
, emsof_request_detail.unit_cost as emsof_request_detail_unit_cost
, emsof_request_detail.additional_service_ante as emsof_request_detail_additional_service_ante
, emsof_request_detail.emsof_ante as emsof_request_detail_emsof_ante
, IF(item_status_code_description_map.description = "WITHDRAWN",1,0) as item_request_withdrawn
, emsof_request_detail.priority as emsof_request_detail_priority
, emsof_request_detail.invoice_designator as emsof_request_detail_invoice_designator
, emsof_request_detail.actual_quantity as emsof_request_detail_actual_quantity
, emsof_request_detail.actual_subtotal_cost as emsof_request_detail_actual_subtotal_cost
, emsof_request_detail.actual_emsof_ante as emsof_request_detail_actual_emsof_ante
, emsof_request_detail.attachment_key as emsof_request_detail_attachment_key
, eligible_provider_equipment_list.description as eligible_provider_equipment_list_description
, eligible_provider_equipment_list.life_expectancy_years as eligible_provider_equipment_list_life_expectancy_years
, eligible_provider_equipment_list.be_eligible_als_amb as eligible_provider_equipment_list_be_eligible_als_amb
, eligible_provider_equipment_list.be_eligible_als_squad as eligible_provider_equipment_list_be_eligible_als_squad
, eligible_provider_equipment_list.be_eligible_bls_amb as eligible_provider_equipment_list_be_eligible_bls_amb
, eligible_provider_equipment_list.be_eligible_qrs as eligible_provider_equipment_list_be_eligible_qrs
, eligible_provider_equipment_list.allowable_cost as eligible_provider_equipment_list_allowable_cost
, eligible_provider_equipment_list.funding_level_nonrural as eligible_provider_equipment_list_funding_level_nonrural
, eligible_provider_equipment_list.funding_level_rural as eligible_provider_equipment_list_funding_level_rural
, GROUP_CONCAT(emsof_purchase_payment.date_of," ",payment_proof_method_code_description_map.description," ",emsof_purchase_payment.note," $",emsof_purchase_payment.amount SEPARATOR "; ") as payment_on_master
from emsof_request_detail
  join eligible_provider_equipment_list on
    (eligible_provider_equipment_list.code=emsof_request_detail.equipment_code)
  join item_status_code_description_map on
    (item_status_code_description_map.code=emsof_request_detail.status_code)
  join emsof_request_master on
    (emsof_request_master.id=emsof_request_detail.master_id)
  join request_status_code_description_map on
    (request_status_code_description_map.code=emsof_request_master.status_code)
  join county_dictated_appropriation on
    (county_dictated_appropriation.id=emsof_request_master.county_dictated_appropriation_id)
  join service on (service.id=county_dictated_appropriation.service_id)
  join charter_kind on (charter_kind.id=service.charter_kind)
  join region_dictated_appropriation on
    (region_dictated_appropriation.id=county_dictated_appropriation.region_dictated_appropriation_id)
  join county_code_name_map on
    (county_code_name_map.code=region_dictated_appropriation.county_code)
  join match_level county_default_match_level on (county_default_match_level.id=county_code_name_map.default_match_level_id)
  join match_level region_dictated_appropriation_match_level on (region_dictated_appropriation_match_level.id=region_dictated_appropriation.match_level_id)
  join match_level county_dictated_appropriation_match_level on (county_dictated_appropriation_match_level.id=region_dictated_appropriation.match_level_id)
  join state_dictated_appropriation on
    (state_dictated_appropriation.id=region_dictated_appropriation.state_dictated_appropriation_id)
  join region_code_name_map on
    (region_code_name_map.code=state_dictated_appropriation.region_code)
  join fiscal_year on (fiscal_year.id=state_dictated_appropriation.fiscal_year_id)
  join emsof_purchase_payment on (emsof_purchase_payment.master_id=emsof_request_master.id)
  join payment_proof_method_code_description_map on
    (payment_proof_method_code_description_map.code=emsof_purchase_payment.method_code)
where fiscal_year.designator in ("FY0910","FY1011")
group by emsof_request_master.id,emsof_request_detail.priority
order by fiscal_year.id
, state_dictated_appropriation.id
, region_dictated_appropriation.id
, county_dictated_appropriation.id
, emsof_request_master.id
, emsof_request_detail.priority
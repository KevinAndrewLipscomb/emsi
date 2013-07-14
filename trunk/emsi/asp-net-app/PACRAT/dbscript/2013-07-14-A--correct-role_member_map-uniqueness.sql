START TRANSACTION
;
ALTER TABLE `role_member_map` 
  DROP INDEX `practical`
,
  ADD UNIQUE INDEX `practical_by_region` (`member_id` ASC, `role_id` ASC, `region_code` ASC) 
,
  ADD UNIQUE INDEX `practical_by_service` (`member_id` ASC, `role_id` ASC, `service_id` ASC) 
;
COMMIT
START TRANSACTION
;
ALTER TABLE `vehicle` 
  DROP INDEX `id`
,
  DROP INDEX `name` 
,
  DROP INDEX `vehicle_service_id` 
,
  ADD UNIQUE INDEX `practical` (`service_id` ASC, `name` ASC)
;
COMMIT
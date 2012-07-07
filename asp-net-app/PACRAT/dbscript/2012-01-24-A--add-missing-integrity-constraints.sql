START TRANSACTION
;
ALTER TABLE `role_privilege_map`
  ADD CONSTRAINT `role_privilege_map_role_id` FOREIGN KEY (`role_id` ) REFERENCES `role` (`id` )
,
  ADD CONSTRAINT `role_privilege_map_privilege_id` FOREIGN KEY (`privilege_id` ) REFERENCES `privilege` (`id` )
;
ALTER TABLE `role_notification_map`
  DROP INDEX `privilege_id`
,
  ADD INDEX `notification_id` (`notification_id` ASC)
,
  ADD CONSTRAINT `role_notification_map_role_id` FOREIGN KEY (`role_id` ) REFERENCES `role` (`id` )
,
  ADD CONSTRAINT `role_notification_map_notification_id` FOREIGN KEY (`notification_id` ) REFERENCES `notification` (`id` )
;
COMMIT
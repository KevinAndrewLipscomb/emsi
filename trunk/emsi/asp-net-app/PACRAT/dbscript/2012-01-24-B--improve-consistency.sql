START TRANSACTION
;
ALTER TABLE `role_notification_map`
  DROP INDEX `notification_id`
,
  ADD INDEX `notification_id` (`notification_id` ASC, `role_id` ASC)
;
ALTER TABLE `role_member_map`
  DROP FOREIGN KEY `role_member_map_ibfk_1`
,
  DROP FOREIGN KEY `role_member_map_ibfk_2`
;
ALTER TABLE `role_member_map`
  DROP INDEX `role_id`
,
  ADD INDEX `role_id` (`role_id` ASC, `member_id` ASC)
,
  ADD CONSTRAINT `role_member_map_member_id` FOREIGN KEY (`member_id` ) REFERENCES `member` (`id` )
,
  ADD CONSTRAINT `role_member_map_role_id` FOREIGN KEY (`role_id` ) REFERENCES `role` (`id` )
;
ALTER TABLE `role_privilege_map`
  DROP INDEX `privilege_id`
,
  ADD INDEX `privilege_id` (`privilege_id` ASC, `role_id` ASC)
;
ALTER TABLE `user_member_map`
  DROP FOREIGN KEY `user_member_map_ibfk_1`
,
  DROP FOREIGN KEY `user_member_map_ibfk_2`
;
ALTER TABLE `user_member_map`
  ADD CONSTRAINT `user_member_map_user_id` FOREIGN KEY (`user_id` ) REFERENCES `user` (`id` )
,
  ADD CONSTRAINT `user_member_map_member_id` FOREIGN KEY (`member_id` ) REFERENCES `member` (`id` )
;
COMMIT
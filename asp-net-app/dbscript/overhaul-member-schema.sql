-- PACRAT

START TRANSACTION;

ALTER TABLE `member`
 DROP INDEX `user_id`,
 DROP COLUMN `user_id`,
 DROP COLUMN `be_valid`,
 ADD COLUMN `last_name` VARCHAR(31) NOT NULL,
 ADD COLUMN `first_name` VARCHAR(31) NOT NULL,
 ADD COLUMN `email_address` VARCHAR(255),
 ADD COLUMN `registration_code` VARCHAR(15),
 ADD INDEX `last_name`(`last_name`),
 ADD INDEX `first_name`(`first_name`);

insert member (last_name,first_name,email_address,registration_code) values
("Administrator","Application","pacrat@frompaper2web.com","1");

ALTER TABLE `user`
  MODIFY COLUMN `last_login` DATETIME;

insert privilege set name = "send-quickmessages";

COMMIT
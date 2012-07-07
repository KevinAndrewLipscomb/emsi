START TRANSACTION;

ALTER TABLE `role`
  ADD COLUMN `pecking_order` INTEGER UNSIGNED NOT NULL;

update role set pecking_order = 11000 where name = "Application Administrator";

ALTER TABLE `role`
  ADD UNIQUE `pecking_order`(`pecking_order`);

COMMIT
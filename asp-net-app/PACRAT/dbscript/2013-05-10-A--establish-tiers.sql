START TRANSACTION
;
drop table if exists tier
;
CREATE TABLE `tier` (
  `id` tinyint(3) unsigned NOT NULL auto_increment,
  `name` varchar(31) NOT NULL,
  `pecking_order` int unsigned not null,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`),
  unique key `pecking_order` (`pecking_order`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8
;
insert ignore tier (name,pecking_order) values
("State",10000),
("Region",20000),
("County",30000),
("Service",40000)
;
alter table role
  add column tier_id tinyint unsigned
,
  add index tier_id (tier_id,pecking_order)
,
  add constraint role_tier_id foreign key (tier_id) references tier (id)
;
update role set tier_id = (select id from tier where name = "State") where name like "State%" or name = "Application Administrator"
;
update role set tier_id = (select id from tier where name = "Region") where name like "Region%"
;
update role set tier_id = (select id from tier where name = "Service") where name like "Service%"
;
COMMIT
START TRANSACTION
;
CREATE TABLE `strike_team_roster` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `service_id` smallint unsigned NOT NULL,
  `practitioner_id` bigint(20) unsigned NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `practitoner_id` (`practitioner_id`,`service_id`),
  UNIQUE KEY `service_id` (`service_id`,`practitioner_id`),
  CONSTRAINT `strike_team_roster_service_id` FOREIGN KEY (`service_id`) REFERENCES `service` (`id`),
  CONSTRAINT `strike_team_roster_practitioner_id` FOREIGN KEY (`practitioner_id`) REFERENCES `practitioner` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
;
COMMIT
START TRANSACTION
;
DROP TABLE IF EXISTS `vehicle_kind`;
CREATE TABLE `vehicle_kind` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `description` varchar(31) NOT NULL,
  `be_target_pm_mileage_meaningful` tinyint(1) NOT NULL DEFAULT '0',
  `be_dmv_inspection_due_meaningful` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `description` (`description`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
--
-- Dumping data for table `vehicle_kind`
--

INSERT INTO `vehicle_kind` VALUES (1,'Ambulance',1,1);
INSERT INTO `vehicle_kind` VALUES (2,'Zone car',1,1);
INSERT INTO `vehicle_kind` VALUES (3,'Squad truck',1,1);
INSERT INTO `vehicle_kind` VALUES (4,'Support truck',1,1);
INSERT INTO `vehicle_kind` VALUES (5,'Boat',0,0);
INSERT INTO `vehicle_kind` VALUES (6,'Special cart',0,0);
INSERT INTO `vehicle_kind` VALUES (7,'Utility car',1,1);
INSERT INTO `vehicle_kind` VALUES (8,'Supervisor car',1,1);
INSERT INTO `vehicle_kind` VALUES (9,'Chief car',1,1);
INSERT INTO `vehicle_kind` VALUES (10,'ATV',0,0);
INSERT INTO `vehicle_kind` VALUES (11,'Air ambulance',0,0);
INSERT INTO `vehicle_kind` VALUES (12,'MCI truck',1,1);
INSERT INTO `vehicle_kind` VALUES (13,'Parade piece',1,1);
INSERT INTO `vehicle_kind` VALUES (14,'Light utility trailer',0,0);
INSERT INTO `vehicle_kind` VALUES (15,'Light special trailer',0,0);
INSERT INTO `vehicle_kind` VALUES (16,'Light cargo trailer',0,0);
INSERT INTO `vehicle_kind` VALUES (17,'Dive truck',1,1);
INSERT INTO `vehicle_kind` VALUES (18,'SAR truck',1,1);
INSERT INTO `vehicle_kind` VALUES (19,'Light boat trailer',0,0);
INSERT INTO `vehicle_kind` VALUES (20,'Heavy utility trailer',0,1);
INSERT INTO `vehicle_kind` VALUES (21,'Heavy special trailer',0,1);
INSERT INTO `vehicle_kind` VALUES (22,'Heavy cargo trailer',0,1);
INSERT INTO `vehicle_kind` VALUES (23,'Heavy boat trailer',0,1);
;
DROP TABLE IF EXISTS `fuel`;
CREATE TABLE `fuel` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `description` varchar(31) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `description` (`description`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `fuel`
--

INSERT INTO `fuel` VALUES (8,'(none)');
INSERT INTO `fuel` VALUES (6,'Biodiesel');
INSERT INTO `fuel` VALUES (1,'Diesel');
INSERT INTO `fuel` VALUES (2,'Gasoline');
INSERT INTO `fuel` VALUES (7,'Hydrogen');
INSERT INTO `fuel` VALUES (3,'Jet A');
INSERT INTO `fuel` VALUES (5,'Natural gas');
INSERT INTO `fuel` VALUES (4,'Propane');
;
DROP TABLE IF EXISTS vehicle;
CREATE TABLE IF NOT EXISTS vehicle (
  id SERIAL,
  service_id SMALLINT UNSIGNED NOT NULL,
  name VARCHAR(63) NOT NULL,
  kind_id BIGINT UNSIGNED NOT NULL,
  fuel_id BIGINT UNSIGNED NOT NULL,
  license_plate VARCHAR(15),
  be_four_or_all_wheel_drive BOOLEAN DEFAULT FALSE NOT NULL,
  PRIMARY KEY(id),
  UNIQUE (name),
  CONSTRAINT vehicle_service_id FOREIGN KEY (service_id) REFERENCES service (id),
  CONSTRAINT vehicle_kind_id FOREIGN KEY (kind_id) REFERENCES vehicle_kind (id),
  CONSTRAINT vehicle_fuel_id FOREIGN KEY (fuel_id) REFERENCES fuel (id)
)
ENGINE = InnoDB
;
COMMIT
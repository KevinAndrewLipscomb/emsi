SET FOREIGN_KEY_CHECKS=0;

SET AUTOCOMMIT=0;
START TRANSACTION;


-- --------------------------------------------------------

--
-- Table structure for table `notification`
--
drop table if exists notification;
create table notification
  (
  id int unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(63) NOT NULL,
  PRIMARY KEY (id),
  UNIQUE KEY (`name`)
  ) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO notification (id,`name`) VALUES
(1,'member-added');

--
-- Table structure for table `role_notification_map`
--
DROP TABLE IF EXISTS role_notification_map;
CREATE TABLE role_notification_map (
  role_id int unsigned NOT NULL,
  notification_id int unsigned NOT NULL,
  PRIMARY KEY  (role_id,notification_id),
  KEY privilege_id (notification_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE role ADD COLUMN tier_id TINYINT UNSIGNED;

--
-- Table structure for table `tier`
--
DROP TABLE IF EXISTS tier;
CREATE TABLE tier (
  id tinyint unsigned NOT NULL,
  name varchar(31) NOT NULL,
  PRIMARY KEY id (id),
  UNIQUE KEY name (name)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE role ADD CONSTRAINT tier_id FOREIGN KEY tier_id (tier_id)
    REFERENCES tier (id);


SET FOREIGN_KEY_CHECKS=1;

COMMIT;
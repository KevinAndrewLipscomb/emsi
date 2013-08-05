START TRANSACTION
;
DROP TABLE IF EXISTS `sms_gateway`
;
CREATE TABLE `sms_gateway` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `carrier_name` varchar(63) NOT NULL,
  `hostname` varchar(253) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `carrier_name` (`carrier_name`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8
;
INSERT INTO `sms_gateway` (id,carrier_name,hostname) VALUES
(1,'Verizon Wireless','vtext.com'),
(2,'AT&T','txt.att.net'),
(3,'Sprint','messaging.sprintpcs.com'),
(4,'T-Mobile','tmomail.net')
;
COMMIT
START TRANSACTION
;
UPDATE `practitioner_level` SET `emsrs_practitioner_level_description`='AEMT' WHERE `id`='12'
;
UPDATE `practitioner_level` SET `emsrs_practitioner_level_description`='PHPE' WHERE `id`='11'
;
UPDATE `practitioner_level` SET `emsrs_practitioner_level_description`='PHP' WHERE `id`='5'
;
INSERT INTO `practitioner_level` (`short_description`, `emsrs_practitioner_level_description`, `be_hereafter_valid`, `pecking_order`, `emsrs_code`) VALUES ('Admin', 'Admin Access', '1', '245', '8')
;
INSERT INTO `practitioner_level` (`short_description`, `emsrs_practitioner_level_description`, `be_hereafter_valid`, `pecking_order`, `emsrs_code`) VALUES ('EMSVO-QRS', 'EMSVO QRS', '1', '221', '8')
;
COMMIT

START TRANSACTION
;
ALTER TABLE `region_code_name_map`
  ADD COLUMN `conedlink_emsportal_username` VARCHAR(10) NULL
,
  ADD COLUMN `conedlink_emsportal_password` VARCHAR(10) NULL
,
  ADD UNIQUE INDEX `conedlink_emsportal_username` (`conedlink_emsportal_username` ASC)
;
COMMIT
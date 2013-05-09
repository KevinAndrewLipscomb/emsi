START TRANSACTION
;
DROP TABLE IF EXISTS any_region_role_member_map
;
CREATE TABLE IF NOT EXISTS any_region_role_member_map (
  id SERIAL,
  region_code TINYINT UNSIGNED NOT NULL,
  role_id INTEGER UNSIGNED NOT NULL,
  member_id BIGINT UNSIGNED NOT NULL,
  PRIMARY KEY(id),
  key region_code (region_code),
  key role_id (role_id),
  key member_id (member_id),
  constraint any_region_role_member_map_region_code foreign key (region_code) references region_code_name_map (code),
  constraint any_region_role_member_map_role_id foreign key (role_id) references role (id),
  constraint any_region_role_member_map_member_id foreign key (member_id) references practitioner (id)
)
ENGINE = InnoDB
;
COMMIT
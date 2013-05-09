START TRANSACTION
;
DROP TABLE IF EXISTS any_service_role_member_map
;
CREATE TABLE IF NOT EXISTS any_service_role_member_map (
  id SERIAL,
  service_id SMALLINT UNSIGNED NOT NULL,
  role_id INTEGER UNSIGNED NOT NULL,
  member_id BIGINT UNSIGNED NOT NULL,
  PRIMARY KEY(id),
  key service_id (service_id),
  key role_id (role_id),
  key member_id (member_id),
  constraint any_service_role_member_map_service_id foreign key (service_id) references service (id),
  constraint any_service_role_member_map_role_id foreign key (role_id) references role (id),
  constraint any_service_role_member_map_member_id foreign key (member_id) references practitioner (id)
)
ENGINE = InnoDB
;
COMMIT
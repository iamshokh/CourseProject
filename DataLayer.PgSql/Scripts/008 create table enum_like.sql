create table enum_like
(
	id						serial not null primary key,
	item_id        			int not null,
	user_id     			int not null,
	state_id				int not null,
	created_date			timestamp without time zone default now() not null,
	created_user_id			int null,
	modified_date			timestamp without time zone,
	modified_user_id		int,

	constraint fk_state_id foreign key ( state_id ) references enum_state ( id ),
	constraint fk_item_id foreign key ( item_id ) references doc_item ( id ),
	constraint fk_user_id foreign key ( user_id ) references sys_user ( id )
);
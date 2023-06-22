create table doc_collection
(
	id						serial not null primary key,
	full_name   			varchar(250) not null,
    image_url               varchar(250) not null,
	details		 			varchar(1000) NOT NULL,
	state_id				int not null,
	created_date			timestamp without time zone default now() not null,
	created_user_id			int null,
	modified_date			timestamp without time zone,
	modified_user_id		int,

	constraint fk_state_id foreign key ( state_id ) references enum_state ( id )
);

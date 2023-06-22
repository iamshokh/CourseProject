create table sys_role (
    id                  serial not null primary key,
    code                varchar(20) null,
    short_name          varchar(250) not null,
    full_name           varchar(300) not null,
    state_id            int not null,
    created_date	    timestamp without time zone default now() not null,
    
    constraint fk_state_id foreign key (state_id) references enum_state(id)
);

insert into sys_role (id, code, short_name, full_name, state_id) 
VALUES (1,'001','Admin','Admin',1),(2,'002','User','User',1);
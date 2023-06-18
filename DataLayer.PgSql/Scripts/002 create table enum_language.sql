create table enum_language (
  id         int not null primary key,
  code       varchar(10) not null,
  short_name  varchar(50) not null,
  full_name  varchar(100) not null,
  created_date timestamp without time zone default now() not null
);

insert into enum_language (id,code,short_name,full_name) VALUES
(1,N'uz-cyrl',N'Ўз',N'Ўзбекча'),
(2,N'en',N'En',N'English');
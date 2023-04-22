use GomaskoDP_Geo

drop table FinalData
drop table Profile
drop table Place
drop table Account
drop table Post
drop table Project


create table Project(
	id_project int identity,
	owner nvarchar(100),
	cost int,

	primary key (id_project)
);

create table Post(
	id_post int,
	title nvarchar(50),
	salary int,

	primary key (id_post)
);

insert into Post (id_post, title, salary) values (1, 'asd', 500)

create table Account(
	id_account int identity,
	full_name nvarchar(1000),
	login nvarchar(30),
	password nvarchar(30),
	_id_post int,

	foreign key (_id_post) references Post (id_post),
	primary key (id_account)
);

insert into Account (login, password, _id_post) values ('a', 'a', 1)

create table Place(
	id_place int identity,
	_id_project int, 
	date Date,
	_id_operator int,
	comment nvarchar(1000),
	_id_expert int,
	assessment int check (assessment >= 3 and assessment <= 5),

	foreign key (_id_project) references Project (id_project),
	foreign key (_id_operator) references Account (id_account),
	foreign key (_id_expert) references Account (id_account),
	primary key (id_place)
);

create table Profile(
	id_profile int identity,
	length int,
	_id_place int,
	raw_data_link nvarchar(500),

	foreign key (_id_place) references Place (id_place),
	primary key (id_profile)
);

create table FinalData(
	id_final_data int identity,
	_id_project int,
	_id_analytic int,
	final_data_link nvarchar(500),

	foreign key (_id_project) references Project (id_project),
	foreign key (_id_analytic) references Account (id_account),
	primary key (id_final_data)
);
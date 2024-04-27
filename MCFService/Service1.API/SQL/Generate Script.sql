Create Database MCFDB;

Create Table ms_user (
  user_id BIGINT IDENTITY(1,1) PRIMARY KEY,
  user_name VARCHAR(20) NOT NULL,
  password VARCHAR(50) NOT NULL,
  is_active bit not null,
);

Create Table ms_storage_location(
  location_id varchar(10) Primary key,
  location_name varchar(100)
)

Create Table tr_bpkb(
	agreement_number varchar(100) Primary Key,
	bpkb_no varchar(100) null,
    branch_id varchar(10) null,
	bpkb_date datetime null,
	faktur_no varchar(100) null,
	faktur_date datetime null,
	location_id varchar(10) Foreign Key References ms_storage_location(location_id) not null,
	police_no varchar(20) null,
	bpkb_date_in datetime,
	created_by varchar(20) null,
	created_on datetime null,
	last_updated_by varchar(20) null,
	last_updated_on datetime null
)

insert into ms_user values('user_tes_1','P@ssw0rd',1);
insert into ms_user values('user_tes_2','P@ssw0rd',1);
insert into ms_storage_location values('Loc1','Location 1');
insert into ms_storage_location values('Loc2','Location 2');
insert into ms_storage_location values('Loc3','Location 3');
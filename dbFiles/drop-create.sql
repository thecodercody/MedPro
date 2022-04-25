drop table appointments;
drop table availability;
drop table doctorservices;
drop table doctors;
drop table patients;
drop table times;
drop table services;
drop table users;

CREATE TABLE users (
 userId INT IDENTITY NOT NULL,
 firstName VARCHAR (100) NOT NULL,
 lastName VARCHAR (100) NOT NULL,
 email VARCHAR (100) NOT NULL,
 password VARCHAR (100) NOT NULL,
 role int not null,
 CONSTRAINT pk_userId
 PRIMARY KEY ( userId ) ) ;

 CREATE TABLE services (
 sId INT IDENTITY NOT NULL,
 sName VARCHAR (50),
 timeNeeded int not null,
 CONSTRAINT pk_sId
 PRIMARY KEY ( sId ) ) ;

 CREATE TABLE patients (
 pId int identity not null,
 userId int not null,
 CONSTRAINT pk_pId
 PRIMARY KEY ( pId ) ) ;

 ALTER TABLE patients ADD CONSTRAINT fk_pUserId
 FOREIGN KEY (userId)
 REFERENCES users (userId) ;

 CREATE TABLE doctors (
 docId INT IDENTITY NOT NULL,
 userId INT NOT NULL,
 CONSTRAINT pk_docId
 PRIMARY KEY ( docId ) ) ;

 ALTER TABLE doctors ADD CONSTRAINT fk_docUserId
 FOREIGN KEY (userId)
 REFERENCES users (userId) ;

 create table doctorservices (
 dsId int identity not null,
 docId int not null,
 sId int not null,
 constraint pk_dsId
 primary key ( dsId ) );

 alter table doctorservices add constraint fk_dsDocId
 foreign key (docId)
 references doctors (docId) ;

 alter table doctorservices add constraint fk_dsSId
 foreign key (sId)
 references services (sId) ;

 create table times (
 timeId int identity not null,
 timeStart datetime not null,
 timeEnd datetime not null,
 constraint pk_timeId
 primary key ( timeId ) );

create table availability (
availId int identity not null,
docId int not null,
timeId int not null,
constraint pk_availId
primary key ( availId ) );

alter table availability add constraint fk_availDocId
foreign key (docId)
references doctors (docId);

alter table availability add constraint fk_availTimeId
foreign key (timeId)
references times (timeId);

create table appointments (
apptId int identity not null,
pId int not null,
docId int not null,
timeId int not null,
constraint pk_apptId
primary key ( apptId ) );

alter table appointments add constraint fk_apptDocId
foreign key (docId)
references doctors (docId);

alter table appointments add constraint fk_apptTimeId
foreign key (timeId)
references times (timeId);

alter table appointments add constraint fk_apptPId
foreign key (pId)
references patients (pId);

-- insert statements
insert into users values ('khrystyna', 'khryzanivska', 'kk@gmail.com', 'abCD1234', 1), ('kaelan', 'lynch', 'kl@gmail.com', 'abCD1234', 1), ('cody', 'scholberg', 'cs@gmail.com', 'abCD1234', 2);


insert into services values ('physical', 2), ('x-ray', 1), ('mri', 1), ('ct scan', 1);

insert into times values ('2022-05-01 08:00:00', '2022-05-01 09:00:00'),
('2022-05-02 09:00:00', '2022-05-02 10:00:00'),
('2022-05-02 10:00:00', '2022-05-02 11:00:00'),
('2022-05-02 11:00:00', '2022-05-02 12:00:00'),
('2022-05-02 12:00:00', '2022-05-02 13:00:00'),
('2022-05-02 13:00:00', '2022-05-02 14:00:00'),
('2022-05-02 14:00:00', '2022-05-02 15:00:00'),
('2022-05-02 15:00:00', '2022-05-02 16:00:00'),
('2022-05-02 16:00:00', '2022-05-02 17:00:00'),
('2022-05-03 09:00:00', '2022-05-03 10:00:00'),
('2022-05-03 10:00:00', '2022-05-03 11:00:00'),
('2022-05-03 11:00:00', '2022-05-03 12:00:00'),
('2022-05-03 12:00:00', '2022-05-03 13:00:00'),
('2022-05-03 13:00:00', '2022-05-03 14:00:00'),
('2022-05-03 14:00:00', '2022-05-03 15:00:00'),
('2022-05-03 15:00:00', '2022-05-03 16:00:00'),
('2022-05-03 16:00:00', '2022-05-03 17:00:00'),
('2022-05-04 09:00:00', '2022-05-04 10:00:00'),
('2022-05-04 10:00:00', '2022-05-04 11:00:00'),
('2022-05-04 11:00:00', '2022-05-04 12:00:00'),
('2022-05-04 12:00:00', '2022-05-04 13:00:00'),
('2022-05-04 13:00:00', '2022-05-04 14:00:00'),
('2022-05-04 14:00:00', '2022-05-04 15:00:00'),
('2022-05-04 15:00:00', '2022-05-04 16:00:00'),
('2022-05-04 16:00:00', '2022-05-04 17:00:00'),
('2022-05-05 09:00:00', '2022-05-05 10:00:00'),
('2022-05-05 10:00:00', '2022-05-05 11:00:00'),
('2022-05-05 11:00:00', '2022-05-05 12:00:00'),
('2022-05-05 12:00:00', '2022-05-05 13:00:00'),
('2022-05-05 13:00:00', '2022-05-05 14:00:00'),
('2022-05-05 14:00:00', '2022-05-05 15:00:00'),
('2022-05-05 15:00:00', '2022-05-05 16:00:00'),
('2022-05-05 16:00:00', '2022-05-05 17:00:00'),
('2022-05-06 09:00:00', '2022-05-06 10:00:00'),
('2022-05-06 10:00:00', '2022-05-06 11:00:00'),
('2022-05-06 11:00:00', '2022-05-06 12:00:00'),
('2022-05-06 12:00:00', '2022-05-06 13:00:00'),
('2022-05-06 13:00:00', '2022-05-06 14:00:00'),
('2022-05-06 14:00:00', '2022-05-06 15:00:00'),
('2022-05-06 15:00:00', '2022-05-06 16:00:00'),
('2022-05-06 16:00:00', '2022-05-06 17:00:00');

insert into patients values (1), (2);

insert into doctors values (3);

insert into availability values (1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (1, 6), (1, 7), (1, 8);

insert into appointments values (1, 1, 1), (2, 1, 4);

insert into doctorservices values (1, 2), (1, 3);

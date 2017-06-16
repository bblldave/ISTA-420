--Name: David Harris
--File: teamroster.sql
--Date: 6/01/2017

.echo on
.headers on

drop table if exists Players;

CREATE TABLE Players(
	playerID int,
	FirstName text NOT NULL,
	LastName text NOT NULL,
	teamID integer,
	Position text);

INSERT INTO Players values (1, "David", "Harris", 1, "FirstBase");
INSERT INTO Players values (1, "David", "Ruiz", 1, "SecondBase");
INSERT INTO Players values (1, "David", "Nielso", 2, "FirstBase");
INSERT INTO Players values (1, "David", "Johnson",2,"SecondBase");


drop table if exists Teams;

CREATE TABLE Teams(
	teamID int,
	TeamName text NOT NULL,
	City text NOT NULL,
	coachID int);

INSERT INTO Teams values (1, "Tigers", "Columbus", 1);
INSERT INTO Teams values (2, "Dolphins", "Canada", 2);

drop table if exists Stats;

CREATE TABLE Stats(
	playerID,
	G double,
	AB double,
	R double,
	H double,
	2b double,
	3b double,
	HR double,
	RBI double,
	BB double,
	K double,
	SB double,
	CS double,
	AVG double,
	SLG double,
	OBP double,
	OPS double);

CREATE TABLE Users(
	userName text,
	firstName text,
	lastName text,
	email text,
	role text,
	phoneNumber text,
	password text);





	
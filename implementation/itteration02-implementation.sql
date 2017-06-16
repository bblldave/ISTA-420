--Name: David Harris
--File: teamroster.sql
--Date: 6/01/2017

.echo on
.headers on

drop table if exists Players;

CREATE TABLE Players(
	playerID int,
	LastName text NOT NULL,
	FirstName text NOT NULL,
	Position text,
	Team text);
	
.mode csv
.import Players.csv Players

drop table if exists Teams;

CREATE TABLE Teams(
	Team text,
	TeamName text NOT NULL,
	City text NOT NULL,
	coachID int);

.mode csv
.import Teams.csv Teams




INSERT INTO Teams values (1, "Tigers", "Columbus", 1);
INSERT INTO Teams values (2, "Dolphins", "Canada", 2);

drop table if exists Stats;

CREATE TABLE Stats(
	playerID,
	G double,
	AB double,
	R double,
	H double,
	Second double,
	Third double,
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

.mode csv
.import stats.csv stats


drop table if exists Users;

CREATE TABLE Users(
	userName text,
	firstName text,
	lastName text,
	email text,
	role text,
	phoneNumber text,
	password text);



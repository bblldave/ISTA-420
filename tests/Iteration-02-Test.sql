--Name:David Harris
--File: test1.sql
--Date: 6/16/2017

-- Guests can view teams and info
select * from Teams;

--Guests can view team rosters for atlanta
select p.firstname, p.lastname, p.position
from dbo.players as p
where team = 'ATL'

--Guests can view Player stats
select p.firstname, p.lastname, s.*
from dbo.stats as s, dbo.players as p
where s.playerid = p.playerid and p.playerid = 4;

--Coaches can create teams
insert into dbo.teams values('ABC', 'TestTeam', 'FortBenning', 1)
select * from dbo.teams;

--Users can Register
insert into dbo.users values('testUser', 'Test', 'User', 'testuser@gmail.com', 'Coach', '1232342323', 'Pa$$w0rd')
select * from dbo.users;
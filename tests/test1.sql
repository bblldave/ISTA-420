--Name:David Harris
--File: test1.sql
--Date: 6/9/2017

.echo on
.headers on

SELECT p.firstname, p.lastname, t.teamname, t.city
from players as p, teams as t
where t.teamid = p.teamid
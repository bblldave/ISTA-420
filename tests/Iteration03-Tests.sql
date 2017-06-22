--Guests can view schedules
select * from dbo.schedule

--Coaches can Alter the schedules and calendar events
update dbo.schedule
set time = '9:00 AM'
where gameId = 1

select * from dbo.schedule

--View the games for a certain team
select * from dbo.schedule
where team1 = 'MIL'
or team2 = 'MIL'

--view games played at a certain location
select * from dbo.schedule
where location ='New York'
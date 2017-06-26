# ISTA 420 Project User Doc
## David Harris and David Lawburgh
### June 26, 2017

## Description of Tables
Our database consists of five different tables. These tables are labeled Players, Teams, Stats,
Schedule, and Users.
### Players Table
The Players table consists of all the information for each individual player. The playerID column is 
an auto incremented column and it is the primary key for the table. Each column represents a different
attribute of that player.

### Teams table
The Teams table consists of all the information for each team in the league. The Team column is the 
abrivation of the team and it is the Primary key for the table. The CoachId column is an integer and
will represent a coach from the coach table. The coaches table has not been implemented yet.

### Stats Table
The stats table consists of all the stats for each individual player. The playerID column represents
the player that it is connected to. The columns represent various baseball stats with the corresponding
abbreviation.

### Schedule Table
The schedule table holds all of the information for each game that is played. The team 1 column corresponds
to the Home team and the team 2 column corresponds to the away team. Location represents the city that the
game will be played in. GameId is an auto incrementing key that is the primary key for the table.

## Relationship Explanations
### Team Relationship 
The Teams table has multiple relationships. The first relationship is the relationship with the players. 
Each team can have multiple players. This is a one to many relationship. The foreign key for this is the
PlayerId column in the players table. The other Relationship is with the schedules. The foriegn key is is
Team 1 and Team 2 columns. It is a one to many relationship because each team plays multiple games.

### Player Relationship
The Players table has two relationships. Besides the relationship with the teams table, it also has a 
relationship with the stats table. It is a one to one relationship and the foreign key is the playerid
column.
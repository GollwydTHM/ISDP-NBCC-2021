DROP database IF EXISTS gamesdb;
CREATE DATABASE IF NOT EXISTS gamesdb;
USE gamesdb;

create table GamesTheme
(
	gameThemeID varchar(3) not null,
	gameTheme varchar(20) not null,
	primary key (gameThemeID)
);

create table Games
(
	gameID int not null,
	gameThemeID varchar(3) not null,
	name varchar(80) not null,
	year varchar(4) not null,
	hours int not null,
	score int not null,
	bought boolean not null,
	primary key (gameID),
	foreign key (gameThemeID) references GamesTheme(gameThemeID) on delete cascade
);

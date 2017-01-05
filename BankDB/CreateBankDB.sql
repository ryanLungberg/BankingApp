USE master

IF DB_ID('Bank') IS NOT NULL
	DROP DATABASE Bank
GO

CREATE DATABASE Bank
GO

USE Bank

CREATE TABLE Customer 
(
	CustomerID int PRIMARY KEY IDENTITY
	,Name varchar(70) NOT NULL
)
GO

INSERT INTO Customer(Name)
	VALUES ('Joe Programmer')
		,('Ryan Lungberg')
		,('Peter Griffin')
		,('Bob Smith')
		,('John Doe')
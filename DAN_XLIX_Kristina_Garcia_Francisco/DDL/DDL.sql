-- Dropping the tables before recreating the database in the order depending how the foreign keys are placed.
IF OBJECT_ID('tblEmployee', 'U') IS NOT NULL DROP TABLE tblEmployee;
IF OBJECT_ID('tblManager', 'U') IS NOT NULL DROP TABLE tblManager;
IF OBJECT_ID('tblUser', 'U') IS NOT NULL DROP TABLE tblUser;
if OBJECT_ID('vwEmployee','v') IS NOT NULL DROP VIEW vwEmployee;
if OBJECT_ID('vwManager','v') IS NOT NULL DROP VIEW vwManager;

-- Checks if the database already exists.
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'HotelDB')
CREATE DATABASE HotelDB;
GO

USE HotelDB
CREATE TABLE tblUser(
	UserID INT IDENTITY(1,1) PRIMARY KEY 	NOT NULL,
	FirstName VARCHAR (40)					NOT NULL,
	LastName VARCHAR (40)					NOT NULL,
	DateOfBirth DATE						NOT NULL,
	Email VARCHAR (40)						NOT NULL,
	Username VARCHAR (40) UNIQUE			NOT NULL,
	UserPassword VARCHAR (40)				NOT NULL,
);

USE HotelDB
CREATE TABLE tblEmployee (
	WorkerID INT IDENTITY(1,1) PRIMARY KEY		NOT NULL,
	FloorNumber INT  							NOT NULL,
	Gender CHAR									NOT NULL,
	Citizenship VARCHAR (40)					NOT NULL,
	Responsibility VARCHAR (40)					NOT NULL,
	Salary VARCHAR (40),
	UserID INT FOREIGN KEY REFERENCES tblUser(UserID) NOT NULL,
);

USE HotelDB
CREATE TABLE tblManager (
	ManagerID INT IDENTITY(1,1) PRIMARY KEY		NOT NULL,
	FloorNumber INT  							NOT NULL,
	YearsOfExperience INT						NOT NULL,
	EducationDegree VARCHAR (3)					NOT NULL,
	UserID INT FOREIGN KEY REFERENCES tblUser(UserID) NOT NULL,
);

GO
CREATE VIEW vwEmployee AS
	SELECT	tblUser.*, 
			tblEmployee.FloorNumber, tblEmployee.Gender, tblEmployee.Citizenship, 
			tblEmployee.Responsibility, tblEmployee.Salary
	FROM	tblUser, tblEmployee
	WHERE	tblUser.UserID = tblEmployee.UserID

GO
CREATE VIEW vwManager AS
	SELECT	tblUser.*, 
			tblManager.FloorNumber, tblManager.YearsOfExperience, tblManager.EducationDegree
	FROM	tblUser, tblManager 
	WHERE	tblUser.UserID = tblManager.UserID

--liquibase formatted sql

--changeset kavishkamk:Test_0001_1
--comment: Create system schema
--precondition-sql-check expectedResult:0 SELECT COUNT(*) FROM sys.schemas WHERE name = 'system'
CREATE SCHEMA [system]
--rollback: DROP TABLE IF EXISTS [system];


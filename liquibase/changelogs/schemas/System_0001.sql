--liquibase formatted sql

--changeset kavishkamk:System_0001_1
--comment: Create system schema

-- Using onFail:MARK_RAN because this schema may already exist in legacy environments and should not trigger a failure.

--preconditions onFail:MARK_RAN
--precondition-sql-check expectedResult:0 SELECT COUNT(*) FROM sys.schemas WHERE name = 'system'

CREATE SCHEMA [system]
--rollback IF EXISTS (SELECT * FROM sys.schemas WHERE name = 'system') DROP SCHEMA [system]
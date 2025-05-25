--liquibase formatted sql

--changeset kavishkamk:Test_0001_1
--comment: Create Test table
--precondition-sql-check expectedResult:0 SELECT COUNT(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[system].[Test]') AND type in (N'U')
CREATE TABLE system.Test (
    id BIGINT NOT NULL,
    name VARCHAR(255) NOT NULL,
    PRIMARY KEY (id)
)
--rollback: DROP TABLE IF EXISTS "system.Test";


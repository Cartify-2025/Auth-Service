--liquibase formatted sql

--changeset kavishkamk:Test_0001_1
--comment: Create Test table

CREATE TABLE system.Test (
    id BIGINT NOT NULL,
    name VARCHAR(255) NOT NULL
)
--rollback DROP TABLE IF EXISTS system.Test


--changeSet kavishkamk:Test_0001_2
--comment: Add primary key to Test table

ALTER TABLE system.Test
ADD CONSTRAINT PK_Test PRIMARY KEY (id)
--rollback IF EXISTS (SELECT * FROM sys.indexes WHERE name = 'PK_Test' AND object_id = OBJECT_ID(N'system.Test')) ALTER TABLE system.Test DROP CONSTRAINT PK_Test


@echo off
echo Running Liquibase migrations...

REM Change to Liquibase directory (where both properties and YAML exist)
cd /d ..\liquibase

REM Run Liquibase with your config
liquibase --defaultsFile=liquibase.properties update

IF %ERRORLEVEL% NEQ 0 (
    echo Liquibase migration failed!
    exit /b 1
)

echo Liquibase migration completed successfully.

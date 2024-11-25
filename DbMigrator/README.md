# DbMigrator

We use grate for migrations: https://erikbra.github.io/grate/

## The important stuff

### Script Types
Scripts in grate are considered to be one of three types:

**One-time scripts** These are scripts that are run exactly once per database, and never again. More info here.

**Anytime Scripts** These scripts are run any time they’re changed. More info here.

**Everytime Scripts** These scripts are run (you guessed it) every time grate executes :) More info here

**Directory run order**
By default, grate processes the files in a standard set of directories in a fixed order for deterministic processing.
As of grate 1.4, the folder structure is fully customisable. However, if you don’t have any special requirements (e.g. an existing set of SQL scripts in an existing, set folder structure), we would recommend you going with the defaults.

The default folders are run in the following order:

-1. dropDatabase (Anytime scripts)
If you have the need for a custom DROP DATABASE script (used with the --drop command-line flag)

0. createDatabase (Anytime scripts)
If you have the need for a custom CREATE DATABASE script, put it here, and it will be used instead of the default.

1. beforeMigration (Everytime scripts)
If you have particular tasks you want to perform prior to any database migrations (custom logging? database backups? disable replication?) you can do it here.

2. alterDatabase (Anytime scripts)
If you have scripts that need to alter the database config itself (rather than the contents of the database) this is the place to do it. For example setting recovery modes, enabling query stores, etc etc

3. runAfterCreateDatabase (Anytime scripts).
This directory is only processed if the database was created from scratch by grate. Maybe you need to add user accounts or similar?

4. runBeforeUp (Anytime scripts)
5. up (One-time scripts).
This is where the bulk of your ‘migration’ scripts end up, eg adding tables, removing columns, adding reference data etc

Note that there’s no down! If you’ve dropped a column in your up scripts, how do you possibly script an undo for that operation? grate has support for running the migration inside a transaction, and will rollback on script failure.

6. runFirstAfterUp (One-time scripts)
Scripts run prior to other anytime folders are found here. This folder exists to allow you to put sql files in when you need to run out of order, say a stored procecure prior to a function. It is not a normal occurrence to have many files in here or any for that matter.

7. functions (Anytime scripts)
If you have any functions that need to run prior to others, make sure they are alphabetically first before the dependent scripts.

8. views (Anytime scripts)
If you have views any that need to run prior to others, make sure they are alphabetically first before the dependent scripts.

9. sprocs (Anytime scripts)
Stored procedures are found in a sprocs folder. If you have any that need to run prior to others, make sure they are alphabetically first before the dependent scripts.

10. triggers (Anytime scripts)
11. indexes (Anytime scripts)
12. runAfterOtherAnyTimeScripts (Anytime scripts)
This folder exists to allow you to run scripts after you have set up your anytime scripts. It’s pretty open what you put in here, but remember that it is still an anytime folder.

13. permissions (Everytime scripts)
If you have any that need to run prior to others, make sure they are alphabetically first before the dependent scripts. Permissions may contain auto-wiring of permissions, so they are run every time regardless of changes in the files.

14. afterMigration (Everytime scripts)
If you have particular tasks you want to perform prior to any database migrations (custom logging? database backups?) you can do it here.
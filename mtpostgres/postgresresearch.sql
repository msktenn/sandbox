SELECT pg_terminate_backend(pg_stat_activity.pid)
FROM pg_stat_activity
WHERE pg_stat_activity.datname = 'pixls' -- ← change this to your DB
  AND pid <> pg_backend_pid();
DROP DATABASE pixls;

select * from pg_user
select * from pg_roles

SELECT DISTINCT usename
FROM pg_stat_activity;
select * from pg_roles
DROP ROLE tenantadmin

CREATE USER michael WITH PASSWORD 'michaelpw';
GRANT SELECT, INSERT ON questions TO michael;

/* create tenantadmin role */
CREATE ROLE tenantadmin WITH CREATEROLE;

/* create tenantuser role */
CREATE ROLE tenantuser INHERIT;
GRANT SELECT, INSERT ON questions TO tenantuser;

/* create pixlsadmin user */
DROP USER bob
CREATE USER pixlsadmin WITH PASSWORD 'pixlsadminpw';
GRANT tenantadmin TO pixlsadmin;

/* create tenant user */
CREATE USER bob WITH PASSWORD 'bobpw';
GRANT tenantuser TO bob;



REVOKE tenantadmin FROM pixlsadmin;
DROP ROLE tenantadmin
ALTER USER pixlsadmin WITH CREATEROLE;


CREATE ROLE tenantuser INHERIT;
GRANT SELECT, INSERT ON questions TO tenantuser;
REVOKE SELECT, INSERT ON questions FROM tenantuser;

DROP TABLE IF EXISTS questions;

CREATE TABLE IF NOT EXISTS t_questions (
	id uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
	question_text CITEXT NOT NULL,
	tenant VARCHAR ( 20 ) NOT NULL DEFAULT current_user
);

CREATE VIEW questions AS
    SELECT
        id,
        question_text
    FROM
        t_questions
    WHERE
        tenant = current_user;





insert into questions (question_text) Values ('Apple');
insert into questions (question_text) Values ('Banana');
insert into questions (question_text) Values ('apple');
insert into questions (question_text) Values ('banana');


select * from questions order by question_text;



CREATE OR REPLACE FUNCTION getcurrentuser()
RETURNS varchar(100) AS
$$
BEGIN
  return (SELECT current_user);
END
$$ LANGUAGE plpgsql;
SELECT getcurrentuser()

SELECT * FROM pg_collation;
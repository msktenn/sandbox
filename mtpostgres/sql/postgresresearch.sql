select * from pg_user;
select * from pg_roles;

SELECT DISTINCT usename FROM pg_stat_activity;



/* create tenant user */
CREATE USER bob WITH PASSWORD 'bobpw';
GRANT tenant_user TO bob;

insert into questions (question_text) Values ('Apple');
insert into questions (question_text) Values ('Banana');
insert into questions (question_text) Values ('apple');
insert into questions (question_text) Values ('banana');

select * from questions order by question_text;

select * from pg_catalog.pg_tables where schemaname='public';


SELECT 'CREATE DATABASE prismatest'
WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'prismatest')\gexec

CREATE DATABASE prismatest
--add extionsions
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
CREATE EXTENSION IF NOT EXISTS CITEXT;

--create role that will be allowed to create tenant users
SELECT 'CREATE ROLE tenant_admin WITH CREATEROLE INHERIT'
WHERE NOT EXISTS (SELECT FROM pg_catalog.pg_roles WHERE rolname='tenant_admin')\gexec

--create role that will define what a tenant user can do
SELECT 'CREATE ROLE tenant_user INHERIT'
WHERE NOT EXISTS (SELECT FROM pg_catalog.pg_roles WHERE rolname='tenant_user')\gexec

--create user that will be allowed to create tenants
CREATE USER pixls_admin WITH PASSWORD 'pixls_adminpw';
GRANT tenant_admin TO pixls_admin;


SELECT pg_terminate_backend(pg_stat_activity.pid)
FROM pg_stat_activity
WHERE pg_stat_activity.datname = 'pixls'
  AND pid <> pg_backend_pid();


SELECT 'DROP ROLE tenant_admin;'
WHERE EXISTS (SELECT FROM pg_user WHERE usename = 'tenant_user')\gexec

SELECT 'REVOKE SELECT, INSERT ON questions FROM tenant_user; DROP ROLE tenant_user'
WHERE EXISTS (SELECT FROM pg_roles WHERE rolname = 'tenant_user')\gexec

SELECT 'REVOKE SELECT, INSERT ON questions FROM tenant_user;'
WHERE EXISTS (SELECT FROM pg_user WHERE usename = 'pixls_admin')\gexec

SELECT 'CREATE DATABASE pixls'
WHERE EXISTS (SELECT FROM pg_database WHERE datname = 'pixls')\gexec

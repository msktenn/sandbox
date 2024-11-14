SELECT 'CREATE DATABASE pixls'
WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'pixls')\gexec



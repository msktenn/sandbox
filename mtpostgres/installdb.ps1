$env:PGPASSWORD='33787bafa98847078fb363640ea87c6f'
psql -U postgres -d postgres -a -f dropdatabase.sql
psql -U postgres -d postgres -a -f createdatabase.sql
psql -U postgres -d pixls -a -f createroles.sql
psql -U postgres -d pixls -a -f createschema.sql


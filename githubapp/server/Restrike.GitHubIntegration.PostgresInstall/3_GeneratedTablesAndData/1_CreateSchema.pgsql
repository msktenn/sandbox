--DO NOT MODIFY THIS FILE. IT IS ALWAYS OVERWRITTEN ON GENERATION.
--Data Schema

CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
--GO

--CREATE TABLE [ConfigSetting]
CREATE TABLE IF NOT EXISTS public."ConfigSetting" (
	"ID" INTEGER GENERATED ALWAYS AS IDENTITY NOT NULL ,
	"Text" TEXT NOT NULL COLLATE case_insensitive ,
	"Name" VARCHAR NOT NULL COLLATE case_insensitive ,
	"ModifiedBy" Varchar (50) COLLATE case_insensitive NULL,
	"ModifiedDate" timestamp CONSTRAINT DF__CONFIGSETTING_MODIFIEDDATE NOT NULL DEFAULT current_timestamp,
	"CreatedBy" Varchar (50) COLLATE case_insensitive NULL,
	"CreatedDate" timestamp CONSTRAINT DF__CONFIGSETTING_CREATEDDATE NOT NULL DEFAULT current_timestamp,
	"__concurrency" int NOT NULL DEFAULT 1,
	CONSTRAINT "PK_CONFIGSETTING" PRIMARY KEY 
	(
		"ID"
	)
);

--GO

--##SECTION BEGIN [AUDIT TRAIL CREATE]

--APPEND AUDIT TRAIL CREATE FOR TABLE [ConfigSetting]
ALTER TABLE public."ConfigSetting" ADD COLUMN IF NOT EXISTS "CreatedBy" Varchar (50) NULL;
ALTER TABLE public."ConfigSetting" ADD COLUMN IF NOT EXISTS "CreatedDate" timestamp CONSTRAINT "DF__CONFIGSETTING_CREATEDDATE" DEFAULT current_timestamp NULL;
--GO

--APPEND AUDIT TRAIL MODIFY FOR TABLE [ConfigSetting]
ALTER TABLE public."ConfigSetting" ADD COLUMN IF NOT EXISTS "ModifiedBy" Varchar (50) NULL;
ALTER TABLE public."ConfigSetting" ADD COLUMN IF NOT EXISTS "ModifiedDate" timestamp CONSTRAINT "DF__CONFIGSETTING_MODIFIEDDATE" DEFAULT current_timestamp NULL;
--GO

--APPEND AUDIT TRAIL CONCURRENCY FOR TABLE [ConfigSetting]
ALTER TABLE public."ConfigSetting" ADD COLUMN IF NOT EXISTS "__concurrency" int NOT NULL;
--GO

--GO

--##SECTION END [AUDIT TRAIL CREATE]

--##SECTION BEGIN [AUDIT TRAIL REMOVE]

--##SECTION END [AUDIT TRAIL REMOVE]

--##SECTION BEGIN [CREATE INDEXES]

--##SECTION END [CREATE INDEXES]

--##SECTION BEGIN [TENANT INDEXES]

--##SECTION END [TENANT INDEXES]

--##SECTION BEGIN [REMOVE DEFAULTS]

--BEGIN DEFAULTS FOR TABLE [ConfigSetting]
ALTER TABLE public."ConfigSetting" ALTER COLUMN "Name" DROP DEFAULT;
ALTER TABLE public."ConfigSetting" ALTER COLUMN "Text" DROP DEFAULT;
--END DEFAULTS FOR TABLE [ConfigSetting]
--GO

--##SECTION END [REMOVE DEFAULTS]

--##SECTION BEGIN [CREATE DEFAULTS]

--##SECTION END [CREATE DEFAULTS]

--INTERNAL MANAGEMENT TABLE
CREATE TABLE IF NOT EXISTS "__nhydrateschema" (
"dbVersion" varchar (50) NOT NULL,
"LastUpdate" timestamp NOT NULL,
"ModelKey" UUID PRIMARY KEY,
"History" text NOT NULL);

--GO

--INTERNAL MANAGEMENT TABLE
CREATE TABLE IF NOT EXISTS "__nhydrateobjects"
(rowid bigint GENERATED BY DEFAULT AS IDENTITY,
"id" UUID NULL,
"name" varchar (450) NOT NULL,
"type" varchar (10) NOT NULL,
"schema" varchar (450) NULL,
"CreatedDate" timestamp NOT NULL,
"ModifiedDate" timestamp NOT NULL,
"Hash" varchar (32) NULL,
"Status" varchar (500) NULL,
"ModelKey" UUID NOT NULL);

--GO


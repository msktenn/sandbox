--Generated Unversioned Upgrade
--Generated on 2021-03-12 09:57:01

--NEEDED FOR CASE-INSENSITIVE COLLATION
CREATE COLLATION case_insensitive(
      provider = icu,
      locale = 'und-u-ks-level2',
      deterministic = false
    );

--UNCOMMENT TO DROP ALL DEFAULTS IF NEEDED. IF THIS MODEL WAS IMPORTED FROM AN EXISTING DATABASE THE MODEL WILL RECREATE ALL DEFAULTS WITH A GENERATED NAME.
--DROP ALL DEFAULTS
--DECLARE @SqlCmd varchar(4000); SET @SqlCmd = ''
--DECLARE @Cnt int; SET @Cnt = 0
--select @Cnt = count(*) from sys.objects d
--join  sys.objects o on d.parent_object_id = o.object_id
--where d.type = 'D'
 
--WHILE @Cnt > 0
--BEGIN
--      select TOP 1 @SqlCmd = 'ALTER TABLE ' + o.name + ' DROP CONSTRAINT ' + d.name
--      from sys.objects d
--      join sys.objects o on d.parent_object_id = o.object_id
--      where d.type = 'D'
--      EXEC(@SqlCmd) --SELECT @SqlCmd --view the command only
--      select @Cnt = count(*) from sys.objects d
--      join  sys.objects o on d.parent_object_id = o.object_id
--      where d.type = 'D'
--END
--GO

--RENAME OLD INDEXES FROM THE IMPORT DATABASE IF NEEDED


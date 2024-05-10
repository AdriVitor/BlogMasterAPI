USE master;
GO;

EXEC sp_configure 'remote access', 1;
RECONFIGURE;
GO
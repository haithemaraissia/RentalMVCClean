ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [DB_33736_rental_data], FILENAME = '$(DefaultDataPath)$(DatabaseName)_data.mdf', MAXSIZE = 102400 KB, FILEGROWTH = 1024 KB) TO FILEGROUP [PRIMARY];


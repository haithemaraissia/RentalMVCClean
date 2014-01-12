ALTER DATABASE [$(DatabaseName)]
    ADD LOG FILE (NAME = [DB_33736_rental_log], FILENAME = '$(DefaultLogPath)$(DatabaseName)_log.ldf', MAXSIZE = 1024000 KB, FILEGROWTH = 10 %);


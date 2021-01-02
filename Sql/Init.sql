CREATE LOGIN [WeatherForecastUser] WITH PASSWORD=N'Pa55w0rd!', DEFAULT_DATABASE=[master]
GO

EXEC sp_addsrvrolemember 'WeatherForecastUser', 'sysadmin'
GO
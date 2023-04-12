# The MovieDB Assessment

## Getting Started
1. Run the following command `dotnet restore`
2. Open an editor and configure the connection string on `appsettings.json`

```json
  "ConnectionStrings": {
    "AbstractConnectionString": "server=DESKTOP-4T30FEI\\SQLEXPRESS;database=demoapp;Trusted_connection=true"
  },
```

3. Run the command `Update-Database` to migrate EF to your SQL server
4. Run command `dotnet run` and the API will run at http://localhost:44374/api


## Endpoints

```
[GET] https://localhost:44374/api/Movie/{userId}/{search}
```


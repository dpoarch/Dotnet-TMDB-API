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
4. Run command `dotnet run` to start the project

the API will now run at `http://localhost:44374/swagger/index.html`


## Endpoints

```
[POST] https://localhost:44374/api/Movie/Search

```

### Request Body

```json
{
    "userId": 1,
    "search": "superman"
}
```

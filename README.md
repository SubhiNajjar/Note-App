# Note App ASP.NET Core 5.0
#### Simple Project


###### Backend .Net core
* ASP.NET API Core 5.0
* MongoDb Atlas
* Swagger

###### Frontend Redux-React
* Redux-React
* Node.Js v15.3.0
* React Bootstrap

## Set-up Db Commands T.Ex

``` bash
# Space Name Db
dotnet user-secrets init -p NoteApp.API

# Set MongoDb
dotnet user-secrets set "Connectionstring" "mongodb+srv://<username>:<password>@test.wzl6u.mongodb.net/<dbname>?retryWrites=true&w=majority"-p NoteApp.API
```

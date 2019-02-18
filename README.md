# File Service
---
Simple ASP.NET Core application to upload a file to a server
## Endpoint
```
<baseAddress>:<port>/file
```
### Method

POST
    - BODY: send the file as form-data

### Configuration
In appsettings.json set the folder/directory path which you want to store the received file. You need to replace both of _DirectoryPath_ and the _AppSettings.DirectoryPath_ 
Add migrate 

```jsx
dotnet ef migrations add Initial --project CrudNet8MVC.csproj --startup-project CrudNet8MVC.csproj --context CrudNet8MVC.Datos.ApplicationDbContext --output-dir Migrations
```

update base

```jsx
dotnet ef database update --project CrudNet8MVC.csproj --startup-project CrudNet8MVC.csproj
```
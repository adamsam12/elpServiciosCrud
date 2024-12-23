# ALTERNATIVE  DOTNET FOR RIDER + zsh

## DOCKER
entrar a capeta docker - shell

```jsx
docker compose up -d
```

Instala la herramienta dotnet-ef globalmente:

```jsx
dotnet tool install --global dotnet-ef
```

Agrega la ruta de las herramientas globales de .NET a tu variable de entorno PATH.

```jsx
export PATH="$PATH:$HOME/.dotnet/tools"

```

Recarga tu archivo de perfil:

```jsx
source ~/.zshrc
```

Verifica que dotnet-ef está instalado correctamente:

```jsx
dotnet ef
```

Add migrate

```jsx
dotnet ef migrations add Initial --project CrudNet8MVC.csproj --startup-project CrudNet8MVC.csproj --context CrudNet8MVC.Datos.ApplicationDbContext --output-dir Migrations
```

update base

```jsx
dotnet ef database update --project CrudNet8MVC.csproj --startup-project CrudNet8MVC.csproj
```
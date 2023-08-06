# Check for dotnet-ef

```shell
dotnet tool list --global
```

# Install dotnet-ef

```shell
dotner tool install --global dotnet-ef
```

# Creating migration script

```shell
dotnet ef migrations add InitialCreate -p buber-dinner-infrastructure -s buber-dinner-host
```

# Apply migrations

```shell
dotnet ef database update -p buber-dinner-infrastructure -s buber-dinner-host --connection "Server=localhost,1733;Database=BuberDinner;User Id=sa;Password=S3cur3P@ssW0rd\!;Encrypt=false"
```
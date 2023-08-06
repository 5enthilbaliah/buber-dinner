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
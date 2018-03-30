# Syku.WebMarkupMin.Config
Default configuration for WebMarkupMin .NET Core MVC 2

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // ...
    services.AddDefaultWebMarkupMinConfig();
    // ...
}
```

```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    // ...
    app.UseDefaultWebMarkupMinConfig();
    // ...
}
```

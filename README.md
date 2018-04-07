# Syku.WebMarkupMin.Config
My default configuration for WebMarkupMin .NET Core MVC 2. It minifies response HTML, CSS, JS and compresses it using Brotli (or Deflate if not available).

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

# Serilog.Enrichers.EnrichedProperties

Enriches Serilog events with information from logger properties that was enriched earlier.
 
[![Build status](https://ci.appveyor.com/api/projects/status/5?svg=true)](https://ci.appveyor.com/project/serilog/serilog-enrichers-enrichedproperties) [![NuGet Version](http://img.shields.io/nuget/v/Serilog.Enrichers.EnrichedProperties.svg?style=flat)](https://www.nuget.org/packages/Serilog.Enrichers.EnrichedProperties/)

To use the enricher, first install the NuGet package:

```powershell
Install-Package Serilog.Enrichers.EnrichedProperties
```

Then, apply the enricher to you `LoggerConfiguration`:

```csharp
Log.Logger = new LoggerConfiguration()
    .Enrich.With... // ... other Enrichers here
    .Enrich.WithEnrichedProperties()
    // ...other configuration...
    .CreateLogger();
```

The `WithEnrichedProperties()` enricher will add properties from logger that was enriched earlier to produced events.

### Included enrichers

The package includes:

 * `WithEnrichedProperties()` - adds properties from logger that was enriched earlier

Copyright &copy; 2018 Unchase - Provided under the [Apache License, Version 2.0](http://apache.org/licenses/LICENSE-2.0.html).

# Serilog.Enrichers.EnrichedProperties

Enriches Serilog events with information from logger properties that was enriched earlier.
 
[![GitHub version](https://badge.fury.io/gh/unchase%2Fserilog-enrichers-enrichedproperties.svg)](https://badge.fury.io/gh/unchase%2Fserilog-enrichers-enrichedproperties) [![Github Releases](https://img.shields.io/github/downloads/unchase/serilog-enrichers-enrichedproperties/total.svg)](https://github.com/unchase/serilog-enrichers-enrichedproperties/releases/latest) [![GitHub Release Date](https://img.shields.io/github/release-date/unchase/serilog-enrichers-enrichedproperties.svg)](https://github.com/unchase/serilog-enrichers-enrichedproperties/releases/latest) 

[![Build status](https://ci.appveyor.com/api/projects/status/3wuxneqb8i40wi6t?svg=true)](https://ci.appveyor.com/project/unchase/serilog-enrichers-enrichedproperties) [![AppVeyor tests](https://img.shields.io/appveyor/tests/unchase/serilog-enrichers-enrichedproperties.svg)](https://ci.appveyor.com/project/unchase/serilog-enrichers-enrichedproperties/build/tests) [![NuGet Version](http://img.shields.io/nuget/v/Serilog.Enrichers.EnrichedProperties.svg?style=flat)](https://www.nuget.org/packages/Serilog.Enrichers.EnrichedProperties/) [![Nuget](https://img.shields.io/nuget/dt/Serilog.Enrichers.EnrichedProperties.svg)](https://www.nuget.org/packages/Serilog.Enrichers.EnrichedProperties/)

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

 * `WithEnrichedProperties()` - adds properties from logger that was enriched earlier.

Copyright &copy; 2018 Unchase - Provided under the [Apache License, Version 2.0](http://apache.org/licenses/LICENSE-2.0.html).

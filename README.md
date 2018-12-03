# Serilog.Enrichers.EnrichedProperties

[![Build status](https://ci.appveyor.com/api/projects/status/3wuxneqb8i40wi6t?svg=true)](https://ci.appveyor.com/project/unchase/serilog-enrichers-enrichedproperties) [![AppVeyor tests](https://img.shields.io/appveyor/tests/unchase/serilog-enrichers-enrichedproperties.svg)](https://ci.appveyor.com/project/unchase/serilog-enrichers-enrichedproperties/build/tests)

Enriches Serilog events with information from logger properties that was enriched earlier.
 
[![GitHub release](https://img.shields.io/github/release/unchase/serilog-enrichers-enrichedproperties.svg)](https://github.com/unchase/serilog-enrichers-enrichedproperties/releases/latest) [![GitHub Release Date](https://img.shields.io/github/release-date/unchase/serilog-enrichers-enrichedproperties.svg)](https://github.com/unchase/serilog-enrichers-enrichedproperties/releases/latest) 

Apply the enricher to your `LoggerConfiguration` with formated, for example, the [console sink](https://github.com/serilog/serilog-sinks-console), the [file sink](https://github.com/serilog/serilog-sinks-file) or the [email sink](https://github.com/serilog/serilog-sinks-email) etc. `outputTemplate` configuration parameter:

```csharp
Log.Logger = new LoggerConfiguration()
    .Enrich.WithProperty("Test property", "Added") // for example
    .Enrich.With... // ... other Enrichers here
    .Enrich.WithEnrichedProperties()
    // ...other configuration...
    .WriteTo.Console(outputTemplate:
        "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}{NewLine}Enriched properties:{NewLine}{EnrichedProperties}")
    .WriteTo.File("log.txt", outputTemplate: 
        "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}{NewLine}Enriched properties:{NewLine}{EnrichedProperties}")
    .WriteTo.Email(outputTemplate:
        "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}{NewLine}Enriched properties:{NewLine}{EnrichedProperties}",
        fromEmail: "app@example.com",
        toEmail: "support@example.com",
        mailServer: "smtp.example.com")
    .CreateLogger();
```

Where built-in the enricher property is `EnrichedProperties` in output templates.

The `WithEnrichedProperties()` enricher will add properties from logger that was enriched earlier to produced events.

#

For example, the output text in file `log.txt` will be:
```
[23:12:28 INF] Has an EnrichedProperties property with properties that was enriched earlier

Enriched properties:
Test property: "Added"
```


### Included enrichers

The package includes:

 * `WithEnrichedProperties()` - adds properties from logger that was enriched earlier.

Copyright &copy; 2018 Unchase - Provided under the [![Crates.io](https://img.shields.io/crates/l/rustc-serialize.svg)](http://apache.org/licenses/LICENSE-2.0.html)

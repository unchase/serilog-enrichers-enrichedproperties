using System.IO;
using Serilog.Events;
using Serilog.Tests.Support;
using Xunit;

namespace Serilog.Tests.Enrichers
{
    public class EnrichedPropertiesEnricherTests
    {
        [Fact, Trait("Category", "Main")]
        public void EnrichedPropertiesEnricherIsApplied()
        {
            // Arrange
            LogEvent evt = null;
            var log = new LoggerConfiguration()
                .Enrich.WithProperty("Test property", "Added")
                .Enrich.WithEnrichedProperties()
                .WriteTo.Sink(new DelegatingSink(e => evt = e))
                .CreateLogger();

            // Act
            log.Information(@"Has an EnrichedProperties property with properties that was enriched earlier");

            // Assert
            Assert.NotNull(evt);
            Assert.NotEmpty((string)evt.Properties["EnrichedProperties"].LiteralValue());
        }

        [Fact, Trait("Category", "Sinks")]
        public void EnrichedPropertiesEnricherWriteToFileIsApplied()
        {
            // Arrange
            using (var log = new LoggerConfiguration()
                .Enrich.WithProperty("Test property", "Added")
                .Enrich.WithEnrichedProperties()
                .WriteTo.File("log.txt", outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}{NewLine}Enriched properties:{NewLine}{EnrichedProperties}")
                .CreateLogger())
            {
                // Act
                log.Information(@"Has an EnrichedProperties property with properties that was enriched earlier");
            }

            // Assert
            using (var fileStream = new FileStream("log.txt", FileMode.Open))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    Assert.Contains("Test property", streamReader.ReadToEnd());
                }
            }

            // Act
            File.Delete("log.txt");

            // Assert
            Assert.False(File.Exists("log.txt"));
        }
    }
}

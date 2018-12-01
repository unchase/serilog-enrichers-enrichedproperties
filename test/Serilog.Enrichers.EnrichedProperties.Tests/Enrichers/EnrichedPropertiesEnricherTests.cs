using Serilog.Events;
using Serilog.Tests.Support;
using Xunit;

namespace Serilog.Tests.Enrichers
{
    public class EnrichedPropertiesEnricherTests
    {
        [Fact]
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
    }
}

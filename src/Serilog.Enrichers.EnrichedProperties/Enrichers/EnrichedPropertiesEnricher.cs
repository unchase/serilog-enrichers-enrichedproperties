// Copyright 2018 Unchase
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Immutable;
using System.Text;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    /// <summary>
    /// Enriches log events with an EnvironmentUserName property containing properties that was enriched earlier.
    /// </summary>
    public class EnrichedPropertiesEnricher : ILogEventEnricher
    {
        private LogEventProperty _cachedProperty;

        /// <summary>
        /// The property name added to enriched log events.
        /// </summary>
        public const string EnrichedPropertiesPropertyName = "EnrichedProperties";

        /// <summary>
        /// Enrich the log event.
        /// </summary>
        /// <param name="logEvent">The log event to enrich.</param>
        /// <param name="propertyFactory">Factory for creating new properties to add to the event.</param>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var properties = new StringBuilder();
            foreach (var enrichedProperty in logEvent.Properties.ToImmutableSortedDictionary())
            {
                properties.AppendLine($"{enrichedProperty.Key}: {enrichedProperty.Value}");
            }

            _cachedProperty = _cachedProperty ?? propertyFactory.CreateProperty(EnrichedPropertiesPropertyName, properties.ToString());
            logEvent.AddPropertyIfAbsent(_cachedProperty);
        }
    }
}

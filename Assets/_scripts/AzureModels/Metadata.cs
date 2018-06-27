using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._scripts.AzureModels
{
    /// <summary>
    /// <see cref="T:Microsoft.Azure.Devices.Shared.Metadata" /> for properties in <see cref="T:Microsoft.Azure.Devices.Shared.TwinCollection" />
    /// </summary>
    public sealed class Metadata
    {
        /// <summary>
        /// Initializes a new instance of <see cref="T:Microsoft.Azure.Devices.Shared.Metadata" />
        /// </summary>
        /// <param name="lastUpdated"></param>
        /// <param name="lastUpdatedVersion"></param>
        public Metadata(DateTime lastUpdated, long? lastUpdatedVersion)
        {
            this.LastUpdated = lastUpdated;
            this.LastUpdatedVersion = lastUpdatedVersion;
        }

        /// <summary>Time when a property was last updated</summary>
        public DateTime LastUpdated { get; set; }

        /// <remarks>
        /// This SHOULD be null for Reported properties metadata and MUST not be null for Desired properties metadata.
        /// </remarks>
        public long? LastUpdatedVersion { get; set; }
    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._scripts.AzureModels
{
    /// <summary>
    /// Represents a property value in <see cref="T:Microsoft.Azure.Devices.Shared.TwinCollection" />
    /// </summary>
    public class TwinCollectionValue : JValue
    {
        private const string metadataName = "$metadata";
        private const string lastUpdatedName = "$lastUpdated";
        private const string lastUpdatedVersionName = "$lastUpdatedVersion";
        private readonly JObject _metadata;

        internal TwinCollectionValue(JValue jValue, JObject metadata)
          : base(jValue)
        {
            this._metadata = metadata;
        }

        /// <summary>Gets the value for the given property name</summary>
        /// <param name="propertyName">Property Name to lookup</param>
        /// <returns>Value if present</returns>
        public object this[string propertyName]
        {
            get
            {
                if (propertyName == "$metadata")
                    return (object)this.GetMetadata();
                if (propertyName == "$lastUpdated")
                    return (object)this.GetLastUpdated();
                if (propertyName == "$lastUpdatedVersion")
                    return (object)this.GetLastUpdatedVersion();
                throw new Exception(string.Format("'Newtonsoft.Linq.JValue' does not contain a definition for '{0}'.", (object)propertyName));
            }
        }

        /// <summary>Gets the Metadata for this property</summary>
        /// <returns>Metadata instance representing the metadata for this property</returns>
        public Metadata GetMetadata()
        {
            return new Metadata(this.GetLastUpdated(), this.GetLastUpdatedVersion());
        }

        /// <summary>Gets the LastUpdated time for this property</summary>
        /// <returns>DateTime instance representing the LastUpdated time for this property</returns>
        public DateTime GetLastUpdated()
        {
            return (DateTime)this._metadata["$lastUpdated"];
        }

        /// <summary>Gets the LastUpdatedVersion for this property</summary>
        /// <returns>LastUpdatdVersion if present, null otherwise</returns>
        public long? GetLastUpdatedVersion()
        {
            return (long?)this._metadata["$lastUpdatedVersion"];
        }
    }
}

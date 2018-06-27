using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Assets._scripts.AzureModels
{
    public class TwinCollection : IEnumerable
    {
        /// <summary>
        /// Represents a collection of properties for <see cref="T:Microsoft.Azure.Devices.Shared.Twin" />
        /// </summary>
        private const string MetadataName = "$metadata";
        private const string LastUpdatedName = "$lastUpdated";
        private const string LastUpdatedVersionName = "$lastUpdatedVersion";
        private const string VersionName = "$version";
        private JObject _jObject;
        private JObject _metadata;

        /// <summary>
        /// Creates instance of <see cref="T:Microsoft.Azure.Devices.Shared.TwinCollection" />.
        /// </summary>
        public TwinCollection()
          : this((JObject)null)
        {
        }

        /// <summary>
        /// Creates a <see cref="T:Microsoft.Azure.Devices.Shared.TwinCollection" /> using a JSON fragment as the body.
        /// </summary>
        /// <param name="twinJson">JSON fragment containing the twin data.</param>
        public TwinCollection(string twinJson)
          : this(JObject.Parse(twinJson))
        {
        }

        /// <summary>
        /// Creates a <see cref="T:Microsoft.Azure.Devices.Shared.TwinCollection" /> using the given JSON fragments for the body and metadata.
        /// </summary>
        /// <param name="twinJson">JSON fragment containing the twin data.</param>
        /// <param name="metadataJson">JSON fragment containing the metadata.</param>
        public TwinCollection(string twinJson, string metadataJson)
          : this(JObject.Parse(twinJson), JObject.Parse(metadataJson))
        {
        }

        /// <summary>
        /// Creates a <see cref="T:Microsoft.Azure.Devices.Shared.TwinCollection" /> using a JSON fragment as the body.
        /// </summary>
        /// <param name="twinJson">JSON fragment containing the twin data.</param>
        internal TwinCollection(JObject twinJson)
        {
            this._jObject = twinJson ?? new JObject();
            JToken jtoken;
            if (!this._jObject.TryGetValue("$metadata", out jtoken))
                return;
            this._metadata = jtoken as JObject;
        }

        /// <summary>
        /// Creates a <see cref="T:Microsoft.Azure.Devices.Shared.TwinCollection" /> using the given JSON fragments for the body and metadata.
        /// </summary>
        /// <param name="twinJson">JSON fragment containing the twin data.</param>
        /// <param name="metadataJson">JSON fragment containing the metadata.</param>
        public TwinCollection(JObject twinJson, JObject metadataJson)
        {
            this._jObject = twinJson ?? new JObject();
            this._metadata = metadataJson;
        }

        /// <summary>
        /// Gets the version of the <see cref="T:Microsoft.Azure.Devices.Shared.TwinCollection" />
        /// </summary>
        public long Version
        {
            get
            {
                JToken jtoken;
                if (!this._jObject.TryGetValue("$version", out jtoken))
                    return 0;
                return (long)jtoken;
            }
        }

        /// <summary>Gets the count of properties in the Collection</summary>
        public int Count
        {
            get
            {
                int count = this._jObject.Count;
                if (count > 0)
                {
                    JToken jtoken;
                    if (this._jObject.TryGetValue("$metadata", out jtoken))
                        --count;
                    if (this._jObject.TryGetValue("$version", out jtoken))
                        --count;
                }
                return count;
            }
        }

        internal JObject JObject
        {
            get
            {
                return this._jObject;
            }
        }

        //TODO: Add all your properties here. Normally these would be dynamic.
        public object MyProperty { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return this._jObject.ToString();
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

        /// <summary>Gets the TwinProperties as a JSON string</summary>
        /// <param name="formatting">Optional. Formatting for the output JSON string.</param>
        /// <returns>JSON string</returns>
        public string ToJson(Formatting formatting = Formatting.None)
        {
            return JsonConvert.SerializeObject((object)this._jObject, formatting);
        }

        /// <summary>Determines whether the specified property is present</summary>
        /// <param name="propertyName">The property to locate</param>
        /// <returns>true if the specified property is present; otherwise, false</returns>
        public bool Contains(string propertyName)
        {
            JToken jtoken;
            return this._jObject.TryGetValue(propertyName, out jtoken);
        }

        /// <inheritdoc />
        public IEnumerator GetEnumerator()
        {
            yield return this._jObject.Values();
        }

        private bool TryGetMemberInternal(string propertyName, out object result)
        {
            JToken jtoken1;
            if (!this._jObject.TryGetValue(propertyName, out jtoken1))
            {
                result = (object)null;
                return false;
            }
            JToken jtoken2 = this._metadata != null ? this._metadata[propertyName] : null;
            result = !(jtoken2 is JObject) ? (object)jtoken1 : (!(jtoken1 is JValue) ? (object)new TwinCollection(jtoken1 as JObject, (JObject)this._metadata[propertyName]) : (object)new TwinCollectionValue((JValue)jtoken1, (JObject)this._metadata[propertyName]));
            return true;
        }

        private bool TrySetMemberInternal(string propertyName, object value)
        {
            JToken jtoken1 = value == null ? (JToken)null : JToken.FromObject(value);
            JToken jtoken2;
            if (this._jObject.TryGetValue(propertyName, out jtoken2))
                this._jObject[propertyName] = jtoken1;
            else
                this._jObject.Add(propertyName, jtoken1);
            return true;
        }

        private void TryClearMetadata(string propertyName)
        {
            JToken jtoken;
            if (!this._jObject.TryGetValue(propertyName, out jtoken))
                return;
            this._jObject.Remove(propertyName);
        }

        /// <summary>Clear metadata out of the collection</summary>
        public void ClearMetadata()
        {
            this.TryClearMetadata("$metadata");
            this.TryClearMetadata("$lastUpdated");
            this.TryClearMetadata("$lastUpdatedVersion");
            this.TryClearMetadata("$version");
        }
    }
}

// Decompiled with JetBrains decompiler
// Type: Microsoft.Azure.Devices.Shared.TwinCollection
// Assembly: Microsoft.Azure.Devices.Shared, Version=1.15.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 639EDF1B-A71A-40DB-B84F-E0B0A0C57628
// Assembly location: C:\Users\Matt\.nuget\packages\microsoft.azure.devices.shared\1.15.0\lib\net451\Microsoft.Azure.Devices.Shared.dll




using System.Collections;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

[Serializable]
public class Doc {
    [JsonProperty("_rid")]
    public string RevisionId;
    [JsonProperty("_self")]
    public string Self;
    [JsonProperty("_etag")]
    public string ETag;
    [JsonProperty("_attachments")]
    public string Attachments;
    [JsonProperty("_ts")]
    public int Timestamp;
}

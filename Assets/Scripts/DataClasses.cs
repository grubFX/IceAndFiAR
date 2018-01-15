namespace grubFX
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class Chapter
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class Episode
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("long")]
        public double Long { get; set; }
    }

    public partial class Nobility
    {
        [JsonProperty("wikiKey")]
        public string WikiKey { get; set; }

        [JsonProperty("seatKey")]
        public string SeatKey { get; set; }

        [JsonProperty("imgRatio")]
        public double? ImgRatio { get; set; }

        [JsonProperty("img")]
        public string Img { get; set; }

        [JsonProperty("anchor")]
        public List<long> Anchor { get; set; }

        [JsonProperty("isGreat")]
        public bool? IsGreat { get; set; }

        [JsonProperty("chapters")]
        public List<long> Chapters { get; set; }

        [JsonProperty("episodes")]
        public List<long> Episodes { get; set; }

        [JsonProperty("lat")]
        public double? Lat { get; set; }

        [JsonProperty("lng")]
        public double? Lng { get; set; }

        [JsonProperty("clue")]
        public string Clue { get; set; }
    }

    public partial class Paths
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("paths")]
        public List<Path> PathArray { get; set; }
    }

    public partial class Path
    {
        [JsonProperty("path")]
        public List<string> PointArray { get; set; }

        [JsonProperty("chapters")]
        public List<long> Chapters { get; set; }

        [JsonProperty("episodes")]
        public List<long> Episodes { get; set; }

        [JsonProperty("coord")]
        public Coord Coord { get; set; }
    }

    public partial class Coord
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("long")]
        public double Long { get; set; }
    }

    public partial class Chapters
    {
        public static List<Chapter> FromJson(string json) => JsonConvert.DeserializeObject<List<Chapter>>(json, Converter.Settings);
    }

    public partial class Episodes
    {
        public static List<Episode> FromJson(string json) => JsonConvert.DeserializeObject<List<Episode>>(json, Converter.Settings);
    }

    public partial class Locations
    {
        public static List<Location> FromJson(string json) => JsonConvert.DeserializeObject<List<Location>>(json, Converter.Settings);
    }
    
    public partial class Nobilities
    {
        public static List<Nobility> FromJson(string json) => JsonConvert.DeserializeObject<List<Nobility>>(json, Converter.Settings);
    }
    public partial class Paths
    {
        public static List<Paths> FromJson(string json) => JsonConvert.DeserializeObject<List<Paths>>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<Chapter> self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<Episode> self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<Location> self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<Nobility> self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<Paths> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}

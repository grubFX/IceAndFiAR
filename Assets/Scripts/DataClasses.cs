namespace grubFX
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class Location
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("coords")]
        public Coords Coords { get; set; }
    }

    public partial class Coords
    {
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
        public List<int> Anchor { get; set; }

        [JsonProperty("isGreat")]
        public bool? IsGreat { get; set; }

        [JsonProperty("chapters")]
        public List<int> Chapters { get; set; }

        [JsonProperty("episodes")]
        public List<int> Episodes { get; set; }

        [JsonProperty("lat")]
        public double? Lat { get; set; }

        [JsonProperty("lng")]
        public double? Lng { get; set; }

        [JsonProperty("clue")]
        public string Clue { get; set; }
    }

    public partial class Episode
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class PathsPerPerson
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("paths")]
        public List<Path> PathList { get; set; }
    }

    public partial class Path
    {
        [JsonProperty("chapters")]
        public List<int> Chapters { get; set; }

        [JsonProperty("episodes")]
        public List<int> Episodes { get; set; }

        [JsonProperty("singleCoords")]
        public Coords SingleCoords { get; set; }

        [JsonProperty("points")]
        public List<Coords> PointList { get; set; }
    }

    public partial class Locations
    {
        public static List<Location> FromJson(string json) => JsonConvert.DeserializeObject<List<Location>>(json, Converter.Settings);
    }

    public partial class Nobilities
    {
        public static List<Nobility> FromJson(string json) => JsonConvert.DeserializeObject<List<Nobility>>(json, Converter.Settings);
    }

    public partial class ChaptersOrEpisodes
    {
        public static List<Episode> FromJson(string json) => JsonConvert.DeserializeObject<List<Episode>>(json, Converter.Settings);
    }

    public partial class Paths
    {
        public static List<PathsPerPerson> FromJson(string json) => JsonConvert.DeserializeObject<List<PathsPerPerson>>(json, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            CheckAdditionalContent = true
        };
    }
}
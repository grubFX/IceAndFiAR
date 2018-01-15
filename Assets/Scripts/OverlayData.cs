using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace grubFX
{
    public class OverlayData: EventArgs
    {
        public OverlayData(string chapters, string episodes, string locations, string nobilities, string paths)
        {
            ChapterList = new ArrayList(Chapters.FromJson(chapters));
            EpisodeList = new ArrayList(Episodes.FromJson(episodes));
            LocationList = new ArrayList(Locations.FromJson(locations));
            NobilityList = new ArrayList(Nobilities.FromJson(nobilities));
            PathList = new ArrayList(Paths.FromJson(paths));
        }

        public ArrayList ChapterList { get; }
        public ArrayList EpisodeList { get; }
        public ArrayList LocationList { get; }
        public ArrayList NobilityList { get; }
        public ArrayList PathList { get; }
    }
}

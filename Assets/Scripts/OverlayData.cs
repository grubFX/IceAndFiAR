using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace grubFX
{
    public class OverlayData : EventArgs
    {
        public OverlayData(string episodes, string locations, string nobilities, string paths)
        {
            EpisodeList = new ArrayList(ChaptersOrEpisodes.FromJson(episodes));
            LocationList = new ArrayList(Locations.FromJson(locations));
            NobilityList = new ArrayList(Nobilities.FromJson(nobilities));
            AllPathsList = new ArrayList(Paths.FromJson(paths));
        }

        public ArrayList EpisodeList { get; }
        public ArrayList LocationList { get; }
        public ArrayList NobilityList { get; }
        public ArrayList AllPathsList { get; }
    }
}

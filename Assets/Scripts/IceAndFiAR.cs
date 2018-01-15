using UnityEngine;
using System;

namespace grubFX
{
    public class Parser
    {
        public Parser()
        {
            JSParser parser = new JSParser();
            parser.OverlayDataGenerated += HandleEvent;
            parser.startCalculating("input.txt");
        }

        public void HandleEvent(object sender, EventArgs args)
        {
            Debug.Log("Event received: " + args.GetType().ToString() + "\n");
        }
    }
}
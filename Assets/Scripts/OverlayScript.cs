using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace grubFX
{
    public class OverlayScript : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            JSParser parser = new JSParser();
            parser.OverlayDataGenerated += HandleEvent;
            parser.startCalculating("Assets/Scripts/input.txt");
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void HandleEvent(object sender, EventArgs args)
        {
            Debug.Log("Event received: " + args.GetType().ToString() + "\n");
            if (args.GetType() == typeof(OverlayData))
            {
                DrawOverlayData((OverlayData)args);
            }
        }

        private void DrawOverlayData(OverlayData data)
        {
            Debug.Log("starting drawing of overlay");
            // TODO draw overlaydata

            foreach (Location l in data.LocationList)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3((float)l.Long, 0, (float)l.Lat);
            }
        }
    }
}
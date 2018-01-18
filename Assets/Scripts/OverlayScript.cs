using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace grubFX
{
    public class OverlayScript : MonoBehaviour
    {
        private ArrayList overlayObjects;
        private Slider episodeSlider;

        // Use this for initialization
        void Start()
        {
            episodeSlider = GameObject.Find("EpisodeSlider").GetComponent<Slider>();
            episodeSlider?.onValueChanged.AddListener(delegate { reactOnSliderValueChange(); });
        }

        public void reactOnSliderValueChange()
        {
            Debug.Log("slider value changed to " + episodeSlider?.value);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void DrawOverlayData(OverlayData data)
        {
            if (episodeSlider)
            {
                episodeSlider.maxValue = data.EpisodeList.Count - 1;
            }

            Debug.Log("starting drawing of overlay");

            if (overlayObjects == null)
            {
                overlayObjects = new ArrayList();
            }
            overlayObjects.Clear();

            // locations
            foreach (Location l in data.LocationList)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3((float)l.Long, 0, (float)l.Lat);
                overlayObjects.Add(cube);
            }

            // paths
            foreach (Paths p in data.PathList)
            {

            }
        }

        public void StopDrawingOverlay()
        {
            Debug.Log("stopping drawing of overlay");

            if (overlayObjects?.Count > 0)
            {
                foreach (GameObject o in overlayObjects)
                {
                    o.SetActive(false);
                }
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace grubFX
{
    public class OverlayScript : MonoBehaviour
    {
        private static ArrayList overlayObjects;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        public static void DrawOverlayData(OverlayData data)
        {
            Debug.Log("starting drawing of overlay");

            if (overlayObjects == null)
            {
                overlayObjects = new ArrayList();
            }

            if (overlayObjects.Count == 0)
                foreach (Location l in data.LocationList)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3((float)l.Long, 0, (float)l.Lat);
                    overlayObjects.Add(cube);
                }
            else
            {
                foreach (GameObject o in overlayObjects)
                {
                    o.SetActive(true);
                }
            }

        }

        public static void StopDrawingOverlay()
        {
            Debug.Log("stopping drawing of overlay");

            if (overlayObjects != null)
            {
                foreach (GameObject o in overlayObjects)
                {
                    o.SetActive(false);
                }
            }
        }
    }
}
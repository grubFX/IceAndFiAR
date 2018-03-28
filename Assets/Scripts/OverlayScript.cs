using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace grubFX
{
    public class OverlayScript : MonoBehaviour
    {
        private OverlayData overlayData;
        private ArrayList locationObjects, pathsObjects;
        private Slider episodeSlider;
        private Text episodeLabel;

        // Use this for initialization
        void Start()
        {
            episodeSlider = GameObject.Find("EpisodeSlider").GetComponent<Slider>();
            episodeSlider?.onValueChanged.AddListener(delegate { ReactOnSliderValueChange(); });

            episodeLabel = GameObject.Find("EpisodeLabel").GetComponent<Text>();
        }

        public void ReactOnSliderValueChange()
        {
            Debug.Log("slider value changed to " + episodeSlider?.value);
            SetEpisodeLabelOfIndex((int)episodeSlider.value);
            DrawPaths();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void DrawOverlayData(OverlayData data)
        {
            overlayData = data;

            if (episodeSlider != null)
            {
                episodeSlider.maxValue = overlayData.EpisodeList.Count - 1;
            }
            if (episodeLabel != null)
            {
                SetEpisodeLabelOfIndex(0);
            }

            Debug.Log("starting drawing of overlay");


            // locations
            DrawLocations();

            // paths
            DrawPaths();
        }

        private void DrawPaths()
        {
            pathsObjects = DeepCleanListAndReturn(pathsObjects);
            foreach (PathsPerPerson pathsPerPerson in overlayData.AllPathsList)
            {
                foreach (Path path in pathsPerPerson.PathList)
                {
                    if (episodeSlider != null && path.Episodes.Contains((int)episodeSlider.value))
                    {
                        DrawSinglePath(path);
                    }
                }
            }
        }

        private void DrawLocations()
        {
            locationObjects = DeepCleanListAndReturn(locationObjects);
            foreach (Location l in overlayData.LocationList)
            {
                if (l != null && l.Coords != null && l.Coords.Lat != 0 && l.Coords.Long != 0)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.GetComponent<Renderer>().material.color = Color.gray;
                    cube.transform.position = new Vector3((float)l.Coords.Long, 0, (float)l.Coords.Lat);
                    locationObjects.Add(cube);
                }
            }
        }

        private void DrawSinglePath(Path path)
        {
            // SingleCoords
            if (path.SingleCoords.Lat != 0 && path.SingleCoords.Long != 0)
            {
                GameObject sphere0 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere0.GetComponent<Renderer>().material.color = Color.green;
                sphere0.transform.localScale = new Vector3(2, 2, 2);
                sphere0.transform.position = new Vector3((float)path.SingleCoords.Long, 1, (float)path.SingleCoords.Lat);
                pathsObjects.Add(sphere0);
            }

            // Path
            if (path.PointList.Count > 0)
            {
                // -- draw [0]
                GameObject sphere1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere1.GetComponent<Renderer>().material.color = Color.green;
                sphere1.transform.localScale = new Vector3(2, 2, 2);
                sphere1.transform.position = new Vector3((float)path.PointList[0].Long, 1, (float)path.PointList[0].Lat);
                pathsObjects.Add(sphere1);

                // -- draw [1] to end
                for (int i = 0; i < path.PointList.Count - 1; i++)
                {
                    Coords c0 = path.PointList[i], c1 = path.PointList[i + 1];

                    sphere1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere1.GetComponent<Renderer>().material.color = Color.green;
                    sphere1.transform.localScale = new Vector3(2, 2, 2);
                    sphere1.transform.position = new Vector3((float)c1.Long, 1, (float)c1.Lat);
                    pathsObjects.Add(sphere1);

                    /*
                    Gizmos.color = Color.green;
                    Gizmos.DrawLine(new Vector3((float)c0.Long, 0, (float)c0.Lat), new Vector3((float)c1.Long, 0, (float)c1.Lat));
                    */
                }
            }
        }

        public void StopDrawingOverlay()
        {
            Debug.Log("stopping drawing of overlay");

            DeepCleanListAndReturn(locationObjects);
            DeepCleanListAndReturn(pathsObjects);
        }

        private void SetEpisodeLabelOfIndex(int index)
        {
            episodeLabel.text = ((Episode)overlayData.EpisodeList[index]).Title;
        }

        private ArrayList DeepCleanListAndReturn(ArrayList list)
        {
            if (list == null)
            {
                list = new ArrayList();
            }
            else
            {
                if (list.Count > 0)
                {
                    foreach (GameObject o in list)
                    {
                        Destroy(o);
                    }
                }
                list.Clear();
            }
            return list;
        }
    }
}
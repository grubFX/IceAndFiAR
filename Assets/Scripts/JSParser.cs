using System;
using System.IO;
using System.Security.Policy;
using UnityEngine;

namespace grubFX
{
    public class JSParser
    {
        //private static Jurassic.ScriptEngine jurassic;
        private static OverlayData overlayData;
        public event EventHandler<OverlayData> OverlayDataGenerated;

        public JSParser()
        {
            //jurassic = new Jurassic.ScriptEngine();
            overlayData = null;
        }

        /*
        public void StartCalculating(String inputFile)
        { // since Jurrasic is not available on Android we will use the pre parsed JSON files as sources
            StreamReader reader = new StreamReader(inputFile);
            string script = reader.ReadToEnd();
            reader.Close();
            jurassic.Execute(script);

            String episodes = jurassic.Evaluate<string>("JSON.stringify(episodes)");
            String locations = jurassic.Evaluate<string>("var out=[];for(key in locations){out.push({key:key,coords:{lat:locations[key].lat,long:locations[key].lng}})}JSON.stringify(out);");
            String nobilities = jurassic.Evaluate<string>("JSON.stringify(nobility)");
            reader = new StreamReader("Assets/Scripts/pathScript.txt");
            string pathScript = reader.ReadToEnd();
            reader.Close();
            String paths = jurassic.Evaluate<string>(pathScript);

            //Console.WriteLine("\nchapters:\n" + chapters);
            Console.WriteLine("\nepisodes:\n" + episodes);
            Console.WriteLine("\nlocations:\n" + locations);
            Console.WriteLine("\nnobilities:\n" + nobilities);
            Console.WriteLine("\npaths:\n" + paths);

            GenerateOverlayData(episodes, locations, nobilities, paths);
        }
        */

        public void StartCalculating()
        { // since Jurrasic is not available on Android we will use the pre parsed JSON files as sources
            String episodes = (Resources.Load("episodes") as TextAsset).ToString();
            String locations = (Resources.Load("locations") as TextAsset).ToString();
            String nobilities = (Resources.Load("nobilities") as TextAsset).ToString();
            String paths = (Resources.Load("paths") as TextAsset).ToString();
            GenerateOverlayData(episodes, locations, nobilities, paths);
        }

        public JSParser(Url inputUrl)
        {
            // here could be code to import the JS file directly from the website and parse it
        }

        private void GenerateOverlayData(string episodes, string locations, string nobilities, string paths)
        {
            overlayData = new OverlayData(episodes, locations, nobilities, paths);
            OverlayDataGenerated?.Invoke(this, overlayData);
        }
    }
}
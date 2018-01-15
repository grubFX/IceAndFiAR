using System;
using System.IO;
using System.Security.Policy;

namespace grubFX
{
    public class JSParser
    {
        private static Jurassic.ScriptEngine jurassic;
        private static OverlayData overlayData;
        public event EventHandler<OverlayData> OverlayDataGenerated;

        public JSParser()
        {
            jurassic = new Jurassic.ScriptEngine();
            overlayData = null;
        }

        public void startCalculating(String inputFile)
        {
            StreamReader reader = new StreamReader(inputFile);
            string script = reader.ReadToEnd();
            reader.Close();
            jurassic.Execute(script);

            String chapters = jurassic.Evaluate<string>("JSON.stringify(chapters)");

            String episodes = jurassic.Evaluate<string>("JSON.stringify(episodes)");

            String locations = jurassic.Evaluate<string>("var out=[];for(key in locations){out.push({key:key,lat:locations[key].lat,long:locations[key].lng})}JSON.stringify(out);");

            String nobilities = jurassic.Evaluate<string>("JSON.stringify(nobility)");

            reader = new StreamReader("Assets/Scripts/pathScript.txt");
            string pathScript = reader.ReadToEnd();
            reader.Close();
            String paths = jurassic.Evaluate<string>(pathScript);

            /*
            Console.WriteLine("\nchapters:\n" + chapters);
            Console.WriteLine("\nepisodes:\n" + episodes);
            Console.WriteLine("\nlocations:\n" + locations);
            Console.WriteLine("\nnobilities:\n" + nobilities);
            Console.WriteLine("\npaths:\n" + paths);
            */
            GenerateOverlayData(chapters, episodes, locations, nobilities, paths);
        }

        public JSParser(Url inputUrl)
        {
            // TODO
        }

        private void GenerateOverlayData(string chapters, string episodes, string locations, string nobilities, string paths)
        {
            overlayData = new OverlayData(chapters, episodes, locations, nobilities, paths);
            OverlayDataGenerated?.Invoke(this, overlayData);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Galaxies.models;
using Galaxies.enums;
namespace Galaxies
{
    class Program
    {
        static Dictionary<String, Galaxy> galaxies = new Dictionary<string, Galaxy>();
        static Dictionary<String, Star> stars = new Dictionary<string, Star>();
        static Dictionary<String, Planet> planets = new Dictionary<string, Planet>();

        static Dictionary<String, Moon> moons = new Dictionary<string, Moon>();
        static string getBetweenSquareBrackets(string value)
        {
            int start = value.LastIndexOf("[")+1;
            int end = value.IndexOf("]", start);
            return value.Substring(start, end - start);
        }

        static void AddGalaxy(string name, string[] specifications)
        {
            GalaxyType type = (GalaxyType) Enum.Parse(typeof(GalaxyType), specifications[4]);
            string ageStr = specifications[5];
            AgeLiteral ageLiteral = (AgeLiteral) Enum.Parse(typeof(AgeLiteral), ageStr.Substring(ageStr.Length-1));
            double age = Double.Parse(ageStr.Remove(ageStr.Length-1));

            Galaxy galaxy = new Galaxy(name, type, age, ageLiteral);

            galaxies.Add(name, galaxy);
            
        }
        static void AddStar(string name, string specifications)
        {
            string partToRemove = "[" + name + "]";
            string galaxyName = getBetweenSquareBrackets(specifications.Replace(partToRemove, ("")));

            if(galaxies.ContainsKey(galaxyName))
            {
                string[] splitSpecifications = specifications.Split(" ");
                double mass = Double.Parse(splitSpecifications[5]);
                double size = Double.Parse(splitSpecifications[6]);
                int temperature = Int32.Parse(splitSpecifications[7]);
                double luminosity = Double.Parse(splitSpecifications[8]);

                Star star = new Star(name, mass, size, temperature, luminosity);

                galaxies[galaxyName].addStar(star);
                stars.Add(name, star);
            } else Console.WriteLine("Non existing galaxy");
            
        }
        static void AddPlanet(string name, string specifications)
        {
            string partToRemove = "[" + name + "]";
            
            string starName = getBetweenSquareBrackets(specifications.Replace(partToRemove, ("")));
            string[] splitSpecifications = specifications.Split(" ");
            if (stars.ContainsKey(starName))
            {
                PlanetType type = (PlanetType) Enum.Parse(typeof(PlanetType), splitSpecifications[4]);
                string supportsLife = splitSpecifications[5];

                Planet planet = new Planet(name, type, supportsLife == "yes" ? true : false);
                planets.Add(name, planet);
                stars[starName].addPlanet(planet);

            } else Console.WriteLine("Non existing star");
        }
        static void AddMoon(string name, string specifications)
        {
            string partToRemove = "[" + name + "]";
            
            string planetName = getBetweenSquareBrackets(specifications.Replace(partToRemove, ("")));
            string[] splitSpecifications = specifications.Split(" ");
            if (planets.ContainsKey(planetName))
            {
                Moon moon = new Moon(name);
                planets[planetName].addMoon(moon);
                moons.Add(name, moon);
            } else Console.WriteLine("Non existing planet");
        }
        static void Add (string data){
            string spaceObject = data.Split(" ")[1];
            string name = getBetweenSquareBrackets(data);

            switch(spaceObject)
            {
                case "galaxy": AddGalaxy(name, data.Split(" ")); break;
                case "star": AddStar(name, data); break;
                case "planet": AddPlanet(name, data); break;
                case "moon": AddMoon(name, data); break;
                default: break;
            }
            
        }
        static void List (string data){
            string spaceObjects = data.Split(" ")[1];
            List<string> objectsToList = new List<string>();

            switch(spaceObjects)
            {
                case "galaxies": objectsToList = galaxies.Keys.ToList(); break;
                case "stars": objectsToList = stars.Keys.ToList(); break;
                case "planets": objectsToList = planets.Keys.ToList(); break;
                case "moons": objectsToList = moons.Keys.ToList(); break;
                default: Console.WriteLine("Space objects {0} do not exist.", spaceObjects); break;
            }
            Console.WriteLine("--- List of all researched {0} ---", spaceObjects);
            objectsToList.ForEach(objectName => Console.WriteLine(objectName));
            Console.WriteLine("--- End of {0} list ---", spaceObjects);
        }
        static void GetReport (string data){
        Console.WriteLine(
            "--- Stats ---\n"+
            "Galaxies: {0}\n"+
            "Stars: {1}\n"+
            "Planets: {2}\n"+
            "Moons: {3}\n"+
            "--- End of stats ---", galaxies.Count(), stars.Count(), planets.Count(), moons.Count());
        }
        static void PrintGalaxies (string data){
            string galaxyName = getBetweenSquareBrackets(data);

            if(galaxies.ContainsKey(galaxyName))
            {
                galaxies[galaxyName].print();
            } else Console.WriteLine("Galaxy {0} does not exist.", galaxyName);
        }
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            while(input != "exit")
            {
                string command = input.Split(" ")[0];

                switch (command) {
                    case "add": Add(input); break;
                    case "list": List(input); break;
                    case "stats": GetReport(input); break;
                    case "print": PrintGalaxies(input); break;
                    default: break;
                }

                input = Console.ReadLine();
            }
        }
    }
}

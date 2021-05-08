using System;
using System.Collections.Generic;
using Galaxies.models;
namespace Galaxies
{
    class Program
    {
        Dictionary<Galaxy, Star> galaxyStarRecord;
        Dictionary<Star, Planet> starPlanetRecords;

        Dictionary<Planet, Moon> planetMoonRecords; 
        static void Add (string data){

        }
        static void List (string data){

        }
        static void GetReport (string data){

        }
        static void PrintGalaxies (string data){

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

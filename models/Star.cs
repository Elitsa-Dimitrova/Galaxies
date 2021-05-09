using System;
using System.Collections.Generic;
using Galaxies.enums;

namespace Galaxies.models
{
    class Star: SpaceObject
    {
        StarClass starClass;
        double mass;
        double size;
        int temperature;
        double luminosity;
        List<Planet> planets;

        public Star(string name, double mass, double size, int temperature, double luminosity): base(name)
        {
            this.mass = mass;
            this.size = size/2;
            this.temperature = temperature;
            this.luminosity = luminosity;
            this.starClass = determineGalaxyObjectClass();
            this.planets = new List<Planet>();
        }

        bool isBetween (double num, double lowerLimit, double upperLimit)
        {
            return num >= lowerLimit && num < upperLimit;
        }

        StarClass determineGalaxyObjectClass ()
        {
            // double size = size / 2;
            if(temperature >= 30000 && luminosity >= 30000 && mass >= 16 && size >= 6.6)
                return StarClass.O;

            if(isBetween(temperature, 10000, 30000) && isBetween(luminosity, 25, 30000) && isBetween(mass, 2.1, 16) && isBetween(size, 1.8, 6.6))
                return StarClass.B;

            if(isBetween(temperature, 7500, 10000) && isBetween(luminosity, 5, 25) && isBetween(mass, 1.4, 2.1) && isBetween(size, 1.4, 1.8))
                return StarClass.A;

            if(isBetween(temperature, 6000, 7500) && isBetween(luminosity, 1.5, 5) && isBetween(mass, 1.04, 1.4) && isBetween(size, 1.15, 1.4))
                return StarClass.F;

            if(isBetween(temperature, 5200, 6000) && isBetween(luminosity, 0.6, 1.5) && isBetween(mass, 0.8, 1.04) && isBetween(size, 0.96, 1.15))
                return StarClass.G;

            if(isBetween(temperature, 3700, 5200) && isBetween(luminosity, 0.08, 0.6) && isBetween(mass, 0.45, 0.8) && isBetween(size, 0.7, 0.96))
                return StarClass.K;

            if(isBetween(temperature, 2400, 3700) && luminosity <0.08 && isBetween(mass, 0.08, 0.45) && size <= 0.7)
                return StarClass.M;

            throw new System.Exception("Incorrect input!");
        }

        public void addPlanet (Planet planet)
        {
            this.planets.Add(planet);
        }

        public override void print()
        {
            Console.WriteLine(
            "   -  Name: Sun\n" +
            "      Class: {0} ({1:0.00}, {2:0.00}, {3}, {4:0.00})\n"+
            "      Planets:", this.starClass, this.mass, this.size, this.temperature, this.luminosity);
            this.planets.ForEach(planet => planet.print());

        }
    }
}
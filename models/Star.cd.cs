using System;
using System.Collections.Generic;
using Galaxies.enums;

namespace Galaxies.models
{
    class Star: SpaceObject
    {
        StarClass StarClass;
        double mass;
        double size;
        int temperature;
        double illumination;

        bool isBetween (double num, double upperLimit, double lowerLimit)
        {
            return num >= lowerLimit && num < upperLimit;
        }

        List<Planet> planets;

        StarClass determineGalaxyObjectClass ()
        {
            double radius = size / 2;
            if(temperature >= 30000 && illumination >= 30000 && mass >= 16 && radius >= 6.6)
                return StarClass.O;

            if(isBetween(temperature, 10000, 30000) && isBetween(illumination, 25, 30000) && isBetween(mass, 2.1, 16) && isBetween(radius, 1.8, 6.6))
                return StarClass.B;

            if(isBetween(temperature, 7500, 10000) && isBetween(illumination, 5, 25) && isBetween(mass, 1.4, 2.1) && isBetween(radius, 1.4, 1.8))
                return StarClass.A;

            if(isBetween(temperature, 6000, 7500) && isBetween(illumination, 1.5, 5) && isBetween(mass, 1.04, 1.4) && isBetween(radius, 1.15, 1.4))
                return StarClass.F;

            if(isBetween(temperature, 5200, 6000) && isBetween(illumination, 0.6, 1.5) && isBetween(mass, 0.8, 1.04) && isBetween(radius, 0.96, 1.15))
                return StarClass.G;

            if(isBetween(temperature, 3700, 5200) && isBetween(illumination, 0.08, 0.6) && isBetween(mass, 0.45, 0.8) && isBetween(radius, 0.7, 0.96))
                return StarClass.K;

            if(isBetween(temperature, 2400, 3700) && illumination <0.08 && isBetween(mass, 0.08, 0.45) && radius <= 0.7)
                return StarClass.M;

            throw new System.Exception("Incorrect input!");
        }

        public override void toString()
        {
            Console.WriteLine("Printing star.");
        }
    }
}
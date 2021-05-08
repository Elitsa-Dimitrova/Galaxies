using System;
using System.Collections.Generic;
using Galaxies.enums;

namespace Galaxies.models
{
    class Planet: SpaceObject
    {
        PlanetType type;
        bool isHabitat;

        List<Moon> moons;

        public override void toString()
        {
            Console.WriteLine("Printing planet.");
        }
    }
}
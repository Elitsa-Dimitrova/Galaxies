using System;
using Galaxies.enums;

namespace Galaxies.models
{
    class Planet: SpaceObject
    {
        PlanetType type;
        bool isHabitat;

        public override void toString()
        {
            Console.WriteLine("Printing planet.");
        }
    }
}
using System;
using System.Collections.Generic;
using Galaxies.enums;

namespace Galaxies.models
{
    class Galaxy: SpaceObject
    {
        string name;
        GalaxyType type;
        double age;
        string ageLiteral;

        public override void toString()
        {
            Console.WriteLine("Printing galaxy.");
        }
    }
}

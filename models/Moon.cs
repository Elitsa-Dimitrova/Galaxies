using System;

namespace Galaxies.models
{
    class Moon: SpaceObject
    {
        public Moon (string name): base(name){}
        public override void print()
        {
            Console.WriteLine("             §  {0}", this.name);
        }
    }
}
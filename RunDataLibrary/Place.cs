using System;
using System.Collections.Generic;
using System.Text;

namespace RunDataLibrary
{
    public class Place
    {
        public int PlaceId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public City City
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

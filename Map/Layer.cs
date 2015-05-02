using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gengine.Map
{
    public class Layer
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public List<Tile> Tiles { get; set; }

        public Layer()
        {
            Tiles = new List<Tile>();
        }

        public Layer(string name, int index) : base()
        {
            Name = name;
            Index = index;
            Tiles = new List<Tile>();
        }
        
        public string Serialize()
        {
            return Name + "," + Index;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gengine.Map {
    public interface IMapRepository {
        void WriteMap(int width, int height, string fileName, IList<Layer> layers, bool compress = false);
        TileMap LoadMap(string fileName, bool compressed = false);
    }
}

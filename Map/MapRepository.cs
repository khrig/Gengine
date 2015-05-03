using Gengine.Utils;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Gengine.Map
{
    public class MapRepository {
        private static readonly string COLUMNDELIMITER = ";";

        private struct LayerInfo {
            public string Name;
            public int Index;
        }

        public TileMap LoadMap(string fileName) {
            IEnumerable<string> lines;
            if (Compression.IsCompressed(fileName))
                lines = Compression.Decompress(fileName);
            else 
                lines = File.ReadAllLines(fileName);

            if (lines.Count() == 0)
                return null;

            TileMap tileMap = ReadHeader(lines.First());
            foreach (string line in lines.Skip(1))
            {
                LayerInfo layerInfo = GetLayerInfo(line);
                if (!tileMap.Layers.Any(l => l.Name == layerInfo.Name))
                    tileMap.Layers.Add(new Layer(layerInfo.Name, layerInfo.Index));

                var layer = tileMap.Layers.First(l => l.Name == layerInfo.Name);
                layer.Tiles.Add(GetTile(line));
            }

            return tileMap;
        }

        private static LayerInfo GetLayerInfo(string line) {
            string[] values = line.Split(COLUMNDELIMITER.ToCharArray());
            string[] info = values[0].Split(',');

            return new LayerInfo {
                Name = info[0],
                Index = int.Parse(info[1])
            };
        }

        private static TileMap ReadHeader(string header) {
            string[] parts = header.Split(',');
            TileMap t = new TileMap(int.Parse(parts[0]), int.Parse(parts[1]));
            return t;
        }

        private static Tile GetTile(string line) {
            string[] values = line.Split(COLUMNDELIMITER.ToCharArray());

            Tile tile = new Tile(values[1], new Vector2(int.Parse(values[2].Split(',')[0]),
                int.Parse(values[2].Split(',')[1])),
                StringToRectangle(values[4]));
            return tile;
        }

        private static Rectangle StringToRectangle(string rectangle) {
            string[] values = rectangle.Split(',');
            return new Rectangle(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]));
        }
    }
}

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Gengine.Utils;
using Microsoft.Xna.Framework;

namespace Gengine.Map
{
    public class MapRepository : IMapRepository {
        private const string Columndelimiter = ";";

        private readonly bool _useTitleContainer;

        private struct LayerInfo {
            public string Name;
            public int Index;
        }

        public MapRepository(bool useTitleContainer) {
            _useTitleContainer = useTitleContainer;
        }

        public TileMap LoadMap(string fileName, bool compressed = false) {
            IEnumerable<string> lines;
            if (compressed)
                lines = Compression.Decompress(fileName);
            else
                lines = ReadLines(fileName);

            if (!lines.Any())
                return null;

            var tileMap = ReadHeader(lines.First());
            foreach (string line in lines.Skip(1)) {
                LayerInfo layerInfo = GetLayerInfo(line);
                if (tileMap.Layers.All(l => l.Name != layerInfo.Name))
                    tileMap.AddLayer(new Layer(layerInfo.Name, layerInfo.Index));

                var layer = tileMap.Layers.First(l => l.Name == layerInfo.Name);
                layer.Tiles.Add(GetSprite(line));
            }
            tileMap.CreateCollisionLayer();
            tileMap.SetExitPoint();
            return tileMap;
        }

        private IEnumerable<string> ReadLines(string fileName) {
            var lines = _useTitleContainer ? LoadFromContainer(fileName) : File.ReadAllLines(fileName);
            return lines;
        }

        private IEnumerable<string> LoadFromContainer(string fileName) {
            var lines = new List<string>();
            using (var stream = TitleContainer.OpenStream(fileName)) {
                using (var sreader = new StreamReader(stream)) {
                    while (!sreader.EndOfStream)
                        lines.Add(sreader.ReadLine());
                }
            }
            return lines;
        }

        public void WriteMap(int width, int height, string fileName, IList<Layer> layers, bool compress = false) {
            var sb = new StringBuilder();

            AppendHeader(sb, width, height);

            foreach (var layer in layers) {
                foreach (var tile in layer.Tiles) {
                    WriteSpriteLine(sb, layer, tile);
                }
            }

            if (!compress)
                File.WriteAllText(fileName, sb.ToString());
            else
                Compression.Compress(fileName, sb.ToString());
        }

        private LayerInfo GetLayerInfo(string line) {
            string[] values = line.Split(Columndelimiter.ToCharArray());
            string[] info = values[0].Split(',');

            return new LayerInfo {
                Name = info[0],
                Index = int.Parse(info[1])
            };
        }

        private TileMap ReadHeader(string header) {
            string[] parts = header.Split(',');
            TileMap t = new TileMap(int.Parse(parts[0]), int.Parse(parts[1]));
            return t;
        }

        private Tile GetSprite(string line) {
            string[] values = line.Split(Columndelimiter.ToCharArray());

            Tile sprite = new Tile(values[1], new Vector2(int.Parse(values[2].Split(',')[0]),
                int.Parse(values[2].Split(',')[1])),
                StringToRectangle(values[3]));
            return sprite;
        }

        private Rectangle StringToRectangle(string rectangle) {
            string[] values = rectangle.Split(',');
            return new Rectangle(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]));
        }

        private void AppendHeader(StringBuilder sb, int width, int height) {
            sb.AppendLine(string.Format("{0},{1}", width, height));
        }

        private void WriteSpriteLine(StringBuilder sb, Layer layer, Tile tile) {
            sb.AppendLine(string.Format("{1}{0}{2}{0}{3},{4}{0}{5}", Columndelimiter, layer.Serialize(), tile.TextureName, tile.Position.X, tile.Position.Y, RectangleToString(tile.SourceRectangle)));
        }

        private string RectangleToString(Rectangle rect) {
            if (rect != null)
                return string.Format("{0},{1},{2},{3}", rect.X, rect.Y, rect.Width, rect.Height);
            return string.Empty;
        }
    }
}

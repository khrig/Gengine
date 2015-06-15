using Microsoft.Xna.Framework;

namespace Gengine.Background {
    public class BackgroundFactory {
        // TODO: Read from a file to get the name and info
        public BackgroundLayers CreateBackgroundLayers(string mapId){
            if (mapId == "test"){
                var backgroundLayers = new BackgroundLayers();

                var layer1 = new BackgroundLayer();
                layer1.AddTile(new BackgroundTile("bkg-layer-1", Vector2.Zero, new Rectangle(0, 0, 1280, 360)));
                backgroundLayers.AddLayer(layer1);

                var layer2 = new BackgroundLayer();
                layer2.AddTile(new ParallaxBackgroundTile("bkg-layer-2", new Vector2(350, 0), new Rectangle(0, 0, 120, 360), new Vector2(10, 0)));
                backgroundLayers.AddLayer(layer2);

                return backgroundLayers;
            }
            if (mapId == "testrepeat") {
                var backgroundLayers = new BackgroundLayers();

                var layer1 = new BackgroundLayer();
                layer1.AddRepeatedTile("tiles32.png", 32, 32, 1280, 360, 224, 0);
                backgroundLayers.AddLayer(layer1);

                var layer2 = new BackgroundLayer();
                layer2.AddTile(new ParallaxBackgroundTile("bkg-layer-2", new Vector2(800, 0), new Rectangle(0, 0, 120, 360), new Vector2(10, 0)));
                backgroundLayers.AddLayer(layer2);
                
                return backgroundLayers;
            }
            return null;
        }
    }
}

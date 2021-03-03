using System;
using TiledSharp;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace pt9
{
    public static class tile_importer
    {
        private struct tile_map_data
        {
            public Texture2D tile_set {get; set;}
            public Rectangle bounds {get; set;}
            public Rectangle optional_bound {get; set;}
        }

        private struct tile_object_data
        {
            public Texture2D tile_set {get; set;}
            public Rectangle bounds {get; set;}
            public Rectangle optional_bound {get; set;}
        }

        private struct tile_data
        {
            public tile_map_data map_data_1 {get; set;}
            //public tile_object_data map_data_2 {get; set;}
        }

        static List<tile_data> tile_map_processing(string tmx_map)
        {
            List<tile_data> TILE_DATA_LIST = new List<tile_data>();
            Game game = new Game();
            TmxMap TMX_MAP = new TmxMap(tmx_map);
            Texture2D TILE_SET = game.Content.Load<Texture2D>(TMX_MAP.Tilesets[0].Name.ToString());
            int TILE_WIDTH = TMX_MAP.Tilesets[0].TileWidth;
            int TILE_HEIGHT = TMX_MAP.Tilesets[0].TileHeight;
            int TILE_SET_TILES_WIDE = TILE_SET.Width / TILE_WIDTH; 
            int TILE_SET_TILES_HIGH = TILE_SET.Height / TILE_HEIGHT;

            for (int CURRENT_LAYER_COUNT = 0; CURRENT_LAYER_COUNT < TMX_MAP.Layers[0].Tiles.Count; CURRENT_LAYER_COUNT++)
            {
                int GID = TMX_MAP.Layers[0].Tiles[CURRENT_LAYER_COUNT].Gid;

                if (GID == 0)
                {
                    
                }
                else
                {
                    int TILE_FRAME = GID - 1;
                    int COLUMN = TILE_FRAME % TILE_SET_TILES_WIDE;
                    int ROW = (int)Math.Floor(TILE_FRAME / (double)TILE_SET_TILES_HIGH);
                    float X = (CURRENT_LAYER_COUNT % TMX_MAP.Width) * TMX_MAP.TileWidth;
                    float Y = (float)Math.Floor(CURRENT_LAYER_COUNT / (double)TMX_MAP.Width * TMX_MAP.TileHeight);

                    TILE_DATA_LIST.Add(
                        new tile_data()
                        {
                            map_data_1 = new tile_map_data()
                            {
                                tile_set = TILE_SET,
                                bounds = new Rectangle((int)X, (int)Y, TILE_WIDTH, TILE_HEIGHT),
                                optional_bound = new Rectangle(TILE_WIDTH * COLUMN, TILE_HEIGHT * ROW, TILE_WIDTH, TILE_HEIGHT)
                            },
                            //TODO: Implement tile object data 
                            //map_data_2 = new tile_object_data(){}
                        }
                    );
                }
            }

            return TILE_DATA_LIST;
        }
    }
}
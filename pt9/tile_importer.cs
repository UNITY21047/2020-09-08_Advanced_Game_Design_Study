using System;
using TiledSharp;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace pt9
{
    public static class tile_importer
    {
        public static List<tile_data> TILE_DATA_LIST {get; set;}
        private static Game GAME {get; set;}
        private static TmxMap TMX_MAP {get; set;}
        private static Texture2D TILE_SET {get; set;}
        private static int TILE_WIDTH {get; set;}
        private static int TILE_HEIGHT {get; set;}
        private static int TILE_SET_TILES_WIDE {get; set;} 
        private static int TILE_SET_TILES_HIGH {get; set;}

        public struct tile_map_data
        {
            public Texture2D tile_set {get; set;}
            public Rectangle bounds {get; set;}
            public Rectangle optional_bound {get; set;}
        }

        public struct tile_object_data
        {
            public Texture2D tile_set {get; set;}
            public Rectangle bounds {get; set;}
            public Rectangle optional_bound {get; set;}
        }

        public struct tile_data
        {
            public tile_map_data map_data_1 {get; set;}
            //public tile_object_data map_data_2 {get; set;}
        }

        public static void load(TmxMap tmx_map, Texture2D tile_set)
        {
            TILE_DATA_LIST = new List<tile_data>();
            TMX_MAP = tmx_map;
            TILE_SET = tile_set;
            TILE_WIDTH = TMX_MAP.Tilesets[0].TileWidth;
            TILE_HEIGHT = TMX_MAP.Tilesets[0].TileHeight;
            TILE_SET_TILES_WIDE = TILE_SET.Width / TILE_WIDTH; 
            TILE_SET_TILES_HIGH = TILE_SET.Height / TILE_HEIGHT;        
        }

        public static void process_tile_map()
        {
            TILE_DATA_LIST.Clear();
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
                    int ROW = (int)Math.Floor((double)TILE_FRAME / (double)TILE_SET_TILES_WIDE);

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
        }
    }
}
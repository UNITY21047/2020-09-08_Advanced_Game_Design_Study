using System;
using MonoGame.Extended.Tiled;
using System.Collections.Generic;

namespace pt9
{
    ///<summary>A non-static class with static functions to load tile map data.</summary>
    public class tile_map_importer
    {
        /**<summary>Struct <c>MAP_DATA</c> creates a model for layer <c>TiledMap</c> data and other markers.</summary>
        */
        public struct MAP_DATA
        {
            public TiledMap TILED_MAP;
            public string MAP_TYPE;
            public string TILE_MAP_NAME;
            public List<TiledMapLayer> TILE_DATA_LIST;
        }
        
        /**
        <summary>A static function to load tile map data into <c>MAP_DATA</c>.</summary>
        <returns>_DATA</returns>
        */
        public static MAP_DATA load(TiledMap map, string map_name)
        {
            MAP_DATA _DATA = new MAP_DATA();
            _DATA.TILED_MAP = map;
            _DATA.TILE_MAP_NAME = map_name;
            _DATA.TILE_DATA_LIST = new List<TiledMapLayer>();

            if (_DATA.TILE_MAP_NAME.Contains("object"))
            {
                _DATA.MAP_TYPE = "object";
            }
            else
            {
                _DATA.MAP_TYPE = "";
            }

            try
            {
                TiledMapLayer[] LAYERS = new TiledMapLayer[_DATA.TILED_MAP.Layers.Count];

                _DATA.TILED_MAP.Layers.CopyTo(LAYERS, 0);

                foreach (TiledMapLayer layer in LAYERS)
                {
                    _DATA.TILE_DATA_LIST.Add(layer);
                }
            }
            catch(Exception e)
            {
                debug.write_characters(e.Message);
            }

            return _DATA;
        }
    }
}
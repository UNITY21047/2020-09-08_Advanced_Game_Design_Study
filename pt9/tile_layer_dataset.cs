using MonoGame.Extended.Tiled;
using System.Collections.Generic;

namespace pt9
{
    ///<summary>Holds level layers.</summary>
    public class tile_layer_dataset
    {
        ///<summary>A list of <c>MAP_DATA</c> structs; A list of all level one map data.</summary>
        private List<tile_map_importer.MAP_DATA> LEVEL_ONE_MAP_DATA_LIST;

        ///<summary>Loads <c>tile_maps</c> into a <c>MAP_DATA</c> list.</summary>
        public void load_maps(List<TiledMap> tile_maps)
        {
            LEVEL_ONE_MAP_DATA_LIST = new List<tile_map_importer.MAP_DATA>();

            foreach (TiledMap MAP in tile_maps)
            {
                LEVEL_ONE_MAP_DATA_LIST.Add(tile_map_importer.load(MAP, MAP.Name));
            }
        }

        ///<summary>Gets <c>LEVEL_ONE_MAP_DATA_LIST</c>.</summary>
        ///<returns>LEVEL_ONE_MAP_DATA_LIST</returns>
        public List<tile_map_importer.MAP_DATA> level_one_map_data_list()
        {
            return LEVEL_ONE_MAP_DATA_LIST;
        }
    }
}
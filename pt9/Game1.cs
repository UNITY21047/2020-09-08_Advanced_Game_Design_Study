using TiledSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace pt9
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private static TmxMap TMX_MAP {get; set;}
        private static Texture2D TILE_SET {get; set;}

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            // TODO: check operating system.
            TMX_MAP = new TmxMap("/media/pup/Storage/assets/projects/2020-09-08_Advanced_Game_Design_Study/pt9/Content/grassland_map_1.tmx");
            TILE_SET = Content.Load<Texture2D>(TMX_MAP.Tilesets[0].Name.ToString());
            tile_importer.load(TMX_MAP, TILE_SET);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            tile_importer.process_tile_map();
            _spriteBatch.Begin();
            foreach (tile_importer.tile_data data in tile_importer.TILE_DATA_LIST)
            {
                _spriteBatch.Draw(data.map_data_1.tile_set, data.map_data_1.bounds, data.map_data_1.optional_bound, Color.White); 
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

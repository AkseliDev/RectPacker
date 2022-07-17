using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RectPacker;
using System;

namespace Game2 {
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 1024;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        Texture2D texture;

        (Size, Color[]) Create(int w, int h, Color color) {
            
            Color[] data = new Color[w * h];
            
            for(int i = 1; i < w - 2; i++) {
                for(int j = 1; j < h - 2; j++) {
                    data[i + j * w] = color;
                }
            }
            
            // uncomment this to disable padding
            // Array.Fill<Color>(data, color);

            return (new Size(w, h), data);
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = new Texture2D(_spriteBatch.GraphicsDevice, 1024, 1024);

            Color[] data = new Color[1024 * 1024];
            Array.Fill(data, Color.Black);

            texture.SetData(data);

            var tex = new (Size, Color[])[8];

            // random texture sizes
            tex[0] = Create(8, 8, Color.Red);
            tex[1] = Create(16, 8, Color.Green);
            tex[2] = Create(8, 16, Color.Cyan);
            tex[3] = Create(16, 16, Color.Blue);
            tex[4] = Create(9, 9, Color.Yellow);
            tex[5] = Create(12, 12, Color.Brown);
            tex[6] = Create(16, 20, Color.Beige);
            tex[7] = Create(32, 15, Color.Purple);


            // calculate average amount of sprites to fit in the packed area
            int total = 0;

            for(int i = 0; i < tex.Length; i++) {
                var size = tex[i].Item1;
                total += size.Width * size.Height;
            }

            int avgCount = total / tex.Length;

            Console.WriteLine("Average amount of sprites: " + (1024*1024)/avgCount);

            var packer = new Packer(1024, 1024);
            int packCount = 0;

            try {
                
                while(true) {
                    
                    var t = tex[Random.Shared.Next(tex.Length)];

                    var rect = packer.PackArea(t.Item1);

                    texture.SetData(0, new Rectangle(rect.X, rect.Y, rect.Width, rect.Height), t.Item2, 0, t.Item2.Length);

                    packCount++;
                }

            } catch {

            }

            Console.WriteLine("Sprite count: " + packCount);
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(texture, new Vector2(), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

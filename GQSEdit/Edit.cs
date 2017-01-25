using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using GQLib;


namespace GQSEdit
{
    class Edit : IState
    {
        private string location;
        private Texture2D bg, select, patterns;
        private Button selectButton, patternsButton, saveButton;
        private int currentState = 0;

        //General attributes
        private String title = "test title";
        private String subtitle = "test subtitle";
        private String audioFile = "test audio.mp3";
        private int stageLeadIn = 2000;

        //Design attributes
        private String background = "bg.png";


        public Edit(ContentManager Content, string location)
        {
            this.location = location;
            if (!Directory.Exists(location)) Directory.CreateDirectory(location);

            LoadContent(Content);
        }

        public void LoadContent(ContentManager Content)
        {
            bg = Content.Load<Texture2D>("editor_bg");
            select = Content.Load<Texture2D>("select");
            patterns = Content.Load<Texture2D>("patterns");
            selectButton = new Button(select, select, select, new Vector2(900, 200), EBState.active , true);
            patternsButton = new Button(patterns, patterns, patterns, new Vector2(900, 450), EBState.active, true);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bg, new Vector2(0), Color.White);
            selectButton.Draw(spriteBatch);
            patternsButton.Draw(spriteBatch);
            spriteBatch.DrawString(G.Instance.font,"" + currentState, new Vector2(900, 10), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            selectButton.Check(Mouse.GetState());
            if (selectButton.Check(Mouse.GetState())) currentState = 0;
            if (patternsButton.Check(Mouse.GetState())) currentState = 1;



            if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
                using (StreamWriter streamWriter = new StreamWriter(new FileStream(location + "\\stage.gqs", FileMode.Create)))
                {
                    streamWriter.WriteLine("[General]");
                    streamWriter.WriteLine("Title: " + title);
                    streamWriter.WriteLine("Subtitle: " + subtitle);
                    streamWriter.WriteLine("StageLeadIn: " + stageLeadIn);
                    streamWriter.WriteLine("MusicFilename: " + audioFile);
                    streamWriter.WriteLine("");
                    streamWriter.WriteLine("[Design]");
                    streamWriter.WriteLine("BackgroundFilename: " + background);
                    streamWriter.WriteLine("");
                    streamWriter.WriteLine("[Objects]");

                    streamWriter.WriteLine("");
                }
            }

        }
    }
}

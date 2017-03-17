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
using FLLib;
using System.Numerics;


namespace FLEdit
{
    class Edit : IState
    {
        private int scrollValue = 0;
        private string location;
        private Texture2D overlay, bg, select, patterns;
        private Button selectButton, patternsButton, saveButton;
        private int currentState = 0;
        private int timeSteps = 5;

        //General attributes
        private string title = "test title";
        private string subtitle = "test subtitle";
        private string audioFile = "test audio.mp3";
        private static int stageLeadIn = 2000;

        //Design attributes
        private string background = "editor_bg";

        //Object attributes
        private BigInteger currentTime = stageLeadIn;

        public Edit(ContentManager Content, string location)
        {
            this.location = location;
            if (!Directory.Exists(location)) Directory.CreateDirectory(location);
            this.scrollValue = Mouse.GetState().ScrollWheelValue;

            LoadContent(Content);
        }

        public void LoadContent(ContentManager Content)
        {
            overlay = Content.Load<Texture2D>("editor_overlay");
            bg = Content.Load<Texture2D>(background);
            select = Content.Load<Texture2D>("select");
            patterns = Content.Load<Texture2D>("patterns");
            selectButton = new Button(select, select, select, new Vector2(900, 200), EBState.active , true);
            patternsButton = new Button(patterns, patterns, patterns, new Vector2(900, 450), EBState.active, true);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bg, new Vector2(0), Color.White);
            spriteBatch.Draw(overlay, new Vector2(0), Color.White);
            selectButton.Draw(spriteBatch);
            patternsButton.Draw(spriteBatch);
            //spriteBatch.DrawString(G.Instance.font,"" + currentState, new Vector2(900, 10), Color.White);
            spriteBatch.DrawString(G.Instance.font, "[Time Properties]", new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(G.Instance.font, $"Current Time: {currentTime}", new Vector2(10, 30), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            selectButton.Check(Mouse.GetState());
            if (selectButton.Check(Mouse.GetState())) currentState = 0;
            if (patternsButton.Check(Mouse.GetState())) addPolar();


            //timeline scrolling
            if (Mouse.GetState().ScrollWheelValue > scrollValue) { currentTime += timeSteps; }
            if (Mouse.GetState().ScrollWheelValue < scrollValue) { if (currentTime >= stageLeadIn + timeSteps) { currentTime -= timeSteps; } }
            scrollValue = Mouse.GetState().ScrollWheelValue;

            //write the .gqs file
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

        private void addPolar()
        {

        }
    }
}

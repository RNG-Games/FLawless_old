using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FLLib
{
    public enum EBState
    {
        active,
        inactive,
        hover
    }

    public class Button
    {
        EBState current;
        Texture2D active;
        Texture2D inactive;
        Texture2D hover;
        Vector2 position;
        Vector2? textPosition;
        string text;
        bool visibility;
        string toolTipText;
        Vector2? toolTipPosition;
        Color? textColor;
        Color? toolTipColor;
        bool drawToolTip;
        SpriteFont font;

        public Button(Texture2D active, Texture2D inactive, Texture2D hover, Vector2 position,  EBState state, bool visibility,SpriteFont font = null, string text = "", Vector2? textPosition = null,
            Color? textColor = null, string toolTipText = "", Vector2? toolTipPosition = null, Color? toolTipColor = null)
        {
            this.active = active;
            this.inactive = inactive;
            this.hover = hover;
            this.position = position;
            current = state;
            this.visibility = visibility;
            this.text = text;
            this.textPosition = textPosition;
            this.textColor = textColor;
            this.toolTipText = toolTipText;
            this.toolTipPosition = toolTipPosition;
            this.toolTipColor = toolTipColor;
            drawToolTip = false;
            this.font = font;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visibility)
            {
                switch (current)
                {
                    case EBState.active:
                        spriteBatch.Draw(active, position, Color.White);
                        if (textColor != null) spriteBatch.DrawString(font, text,(Vector2) (position + textPosition),(Color) textColor);
                        break;
                    case EBState.inactive:
                        spriteBatch.Draw(inactive, position, Color.White);
                        if (textColor != null) spriteBatch.DrawString(font, text,(Vector2) (position + textPosition), (Color) textColor);
                        break;
                    case EBState.hover:
                        spriteBatch.Draw(hover, position, Color.White);
                        if (textColor != null) spriteBatch.DrawString(font, text,(Vector2) (position + textPosition),(Color) textColor);
                        break;
                }
                if (drawToolTip)
                    if (toolTipColor != null) spriteBatch.DrawString(font, toolTipText,(Vector2) toolTipPosition,(Color)toolTipColor);
            }
        }

        public bool Check(MouseState mouseState)
        {
            if (visibility)
            {
                if (mouseState.X >= position.X && mouseState.X <= (position.X + active.Width) && mouseState.Y >= position.Y && mouseState.Y <= (position.Y + active.Height))
                {
                    drawToolTip = true;
                    if (current == EBState.active || current == EBState.hover)
                    {
                        current = EBState.hover;

                        if (mouseState.LeftButton == ButtonState.Pressed)
                        {
                            return true;
                        }
                    }
                } else
                {
                    if (current == EBState.hover)
                        current = EBState.active;
                    drawToolTip = false;
                }
            }
            return false;
        }

        public void setState(EBState state)
        {
            current = state;
        }

        public void setVisibility(bool visibility)
        {
            this.visibility = visibility;
        }
    }
}

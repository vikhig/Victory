using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Victory
{
    class Animation
    {
        #region Declarations

        Texture2D SpriteSheet;
        float Scale;
        int ElapsedTime, FrameTime, FrameCount, CurrentFrame;
        Color Color;
        Rectangle Source = new Rectangle();
        Rectangle WorldLocation = new Rectangle();
        public int FrameWidth, FrameHeight;
        public static bool Active, Looping;
        public Vector2 Position;

        private List<Rectangle> frames = new List<Rectangle>();

        #endregion

        #region Initialization

        public void Initialize(Texture2D texture,
            Vector2 position,
            int frameWidth,
            int frameHeight,
            int frameCount,
            int frameTime,
            Color color,
            float scale,
            bool looping)
        {
            this.Color = color;
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;
            this.FrameCount = frameCount;
            this.FrameTime = frameTime;
            this.Scale = scale;

            Looping = looping;
            Position = position;
            SpriteSheet = texture;

            ElapsedTime = 0;
            CurrentFrame = 0;

            Active = true;

            Source = new Rectangle(CurrentFrame * FrameWidth, 0, FrameWidth, FrameHeight);
            WorldLocation = new Rectangle(
                (int)Position.X - (int)(FrameWidth * Scale) / 2,
                (int)Position.Y - (int)(FrameHeight * Scale) / 2,
                (int)(FrameWidth * Scale),
                (int)(FrameHeight * Scale));

            for (int x = 0; x < frameCount; x++)
            {
                frames.Add(new Rectangle((FrameWidth * x), 0, FrameWidth, FrameHeight));
            }
        }

        #endregion

        #region Update & Draw

        public void Update(GameTime gameTime)
        {
            if (Active == false) return;
            ElapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (ElapsedTime > FrameTime)
            {
                CurrentFrame++;
                if (CurrentFrame == FrameCount)
                {
                    CurrentFrame = 0;
                    if (Looping == false)
                        Active = false;
                }
                ElapsedTime = 0;
            }
            Source = frames[CurrentFrame];
            WorldLocation = new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                FrameWidth, FrameHeight);

        }

        public void Update2(GameTime gameTime)
        {
            if (Active == false)
            {
                CurrentFrame = 7;
                Source = frames[CurrentFrame];
                WorldLocation = new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                FrameWidth, FrameHeight);
            }
            ElapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (ElapsedTime > FrameTime)
            {
                CurrentFrame++;
                if (CurrentFrame == FrameCount)
                {
                    CurrentFrame = 0;
                    if (Looping == false)
                        Active = false;
                }
                ElapsedTime = 0;
            }
            if (Active == true)
            {
                Source = frames[CurrentFrame];
                WorldLocation = new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    FrameWidth, FrameHeight);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Active)
            {
                spriteBatch.Draw(SpriteSheet, WorldLocation, Source, Color);
            }
            if (Active == false)
            {
                spriteBatch.Draw(SpriteSheet, WorldLocation, Source, Color);
            }
        }

        public void DrawDMG(SpriteBatch spriteBatch) //drawing dmg icons
        {
            if (Active)
            {
                spriteBatch.Draw(SpriteSheet, new Rectangle(240, 700 , 125, 125), Source, Color);
            }
        }

        public void DrawNM(SpriteBatch spriteBatch) //NM-normal battle
        {
            spriteBatch.Draw(SpriteSheet, new Rectangle(1920 / 3, 1080 / 3, 500, 250), Source, Color);
        }

        #endregion
    }
}

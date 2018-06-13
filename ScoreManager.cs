using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Victory
{
    class ScoreManager
    {
        #region Khai's Declarations

        public static double dist;
        public static String distance;
        public static double dist1;
        private static TimeSpan frequency;
        private static SpriteFont font;
        private static Vector2 GraphicsInfo;

        #endregion

        #region Initialize

        public static void InitializedScore(SpriteFont Font, Vector2 graphicInfo)//initialize data from Game1 class
        {          
            distance = "M";
            font = Font;
            GraphicsInfo = graphicInfo;
            dist1 = 1.0;
            frequency = TimeSpan.Zero;      
        }

        #endregion

        #region Update & Draw

        public static void UpdateDistance(GameTime gameTime) //Update every 0.5Sec to increase 1M or 5sec to increase 0.01KM, then draw function
        {

            if (dist >= 1000)
            {
                distance = "KM";
                if (dist1 == 1001)
                {
                    if (frequency > TimeSpan.FromSeconds(5))
                    {
                        dist1 = Math.Truncate(dist1 / 1000);
                        dist++;
                        dist1 = Math.Round(dist1 + 0.01, 2);
                        frequency = TimeSpan.Zero;
                    }
                }
                else
                {
                    if (frequency > TimeSpan.FromSeconds(5))
                    {
                        dist++;
                        dist1 = Math.Round(dist1 + 0.01, 2);
                        frequency = TimeSpan.Zero;
                    }
                }

            }
            if (dist <= 999)
            {
                if (frequency > TimeSpan.FromSeconds(0.5))
                {
                    dist1++;
                    dist++;
                    distance = "M";
                    frequency = TimeSpan.Zero;
                }
            }

            frequency += gameTime.ElapsedGameTime;

            
        }

        public static void Draw(SpriteBatch spriteBatch)
        {       
            spriteBatch.DrawString(font, dist1 + distance, GraphicsInfo, Color.Black);
        }

        #endregion
    }
}

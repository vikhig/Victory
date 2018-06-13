using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Victory
{
    class ScrollingBG
    {
        #region Declarations

        //Position for the sprite to be display
        public static Vector2 Position1, Position2, Position4, Position5, Position01, Position02, Position04, Position05, Position07, Position08;

        //Variable that hold different background images and platform
        public static Texture2D mBG1, mBG2, pBG1, pBG2, mBG01, mBG02, pBG01, pBG02, SecBg01, SecBg02;

        //The size of the Sprite
        private static Rectangle Size1, Size2, Size01, Size02, Size03;

        //Used to size the Sprite up or down from the original image
        private static float Scale = 1.0f;


        #endregion

        #region Initialization
        public static void BGInitialization(Texture2D theAssetName, Texture2D theAssetName1) 
        {
            Size1 = new Rectangle(0, 0, (int)(theAssetName.Width * Scale), (int)(theAssetName.Height * Scale)); // Formula to resize the sprite
            Size2 = new Rectangle(0, 0, (int)(theAssetName1.Width * Scale), (int)(theAssetName1.Height * Scale));

            mBG1 = theAssetName; // To load main background image to main BackGround 1 (mBG1) & (mBG2)
            mBG2 = theAssetName;

            pBG1 = theAssetName1; // To load platform image to background Platform 1 (pBG1) & (pBG2)
            pBG2 = theAssetName1;

            Position1 = new Vector2(0, 0); // To set the 1st image to be (0, 0), so that when the game load the background will be at this location(0,0).
            Position2 = new Vector2(Position1.X + Size1.Width, 0); // To set the 2nd image to be after the 1st image, so when the game start the 2nd image will move together with the 1st image.

            Position4 = new Vector2(0, 0); // To set the 1st image (platform) to be (0, 0), so that when the game load the background will be at this location(0,0).
            Position5 = new Vector2(Position4.X + Size2.Width, 0); // To set the 2nd image (platform) to be after the 1st image, so when the game start the 2nd image will move together with the 1st image.
        }

        public static void BGInitializationTutorial(Texture2D theAssetName, Texture2D theAssetName1, Texture2D theAssetName2) // Same as method above, the differnt is this is for tutorial level.
        {
            Size01 = new Rectangle(0, 0, (int)(theAssetName.Width * Scale), (int)(theAssetName.Height * Scale));
            Size02 = new Rectangle(0, 0, (int)(theAssetName1.Width * Scale), (int)(theAssetName1.Height * Scale));
            Size03 = new Rectangle(0, 0, (int)(theAssetName2.Width * Scale), (int)(theAssetName2.Height * Scale));

            mBG01 = theAssetName; // This is for the main background, 3rd layer.
            mBG02 = theAssetName;

            pBG01 = theAssetName1; // this is for the platform, 1st layer.
            pBG02 = theAssetName1;

            SecBg01 = theAssetName2; // this is for the 2nd layer background.
            SecBg02 = theAssetName2;

            Position01 = new Vector2(0, 0);
            Position02 = new Vector2(Position01.X + Size01.Width - 1, 0);

            Position04 = new Vector2(0, 0);
            Position05 = new Vector2(Position04.X + Size02.Width, 0);

            Position07 = new Vector2(0, 0);
            Position08 = new Vector2(Position07.X + Size03.Width, 0);
        }


        #endregion

        #region Update and Draw
        public static void UpdateBG(GameTime gameTime)
        {
            
            if (Position1.X < -Size1.Width) //This section is to allocate the location for the 1st and 2nd images.  
            {
                Position1.X = Position2.X + Size1.Width - 1;
            }

            if (Position2.X < -Size1.Width)
            {
                Position2.X = Position1.X + Size1.Width - 1;
            }

            if (Position4.X < -Size2.Width) //This section is to allocate the location for the 1st and 2nd images.
            {
                Position4.X = Position5.X + Size2.Width;
            }

            if (Position5.X < -Size2.Width)
            {
                Position5.X = Position4.X + Size2.Width;
            }

            Vector2 aDirection = new Vector2(-6, 0); //speed for the platform (1st layer background)
            Vector2 aSpeed = new Vector2(150, 0); //speed for the platform (1st layer background)

            Vector2 aDirection1 = new Vector2(-3, 0); // speed for the 2nd layer background
            Vector2 aSpeed1 = new Vector2(160, 0); // speed for the 2nd layer background

            Position1 += aDirection1 * aSpeed1 * (float)gameTime.ElapsedGameTime.TotalSeconds; // speed for the 2nd layer background
            Position2 += aDirection1 * aSpeed1 * (float)gameTime.ElapsedGameTime.TotalSeconds; // speed for the 2nd layer background

            Position4 += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds; //speed for the platform (1st layer background)
            Position5 += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds; //speed for the platform (1st layer background)
        }

        public static void UpdateBGTutorial(GameTime gameTime)
        {

            if (Position01.X < -Size01.Width) //This section is to allocate the location for the 1st and 2nd images.
            {
                Position01.X = Position02.X + Size01.Width -1;
            }

            if (Position02.X < -Size01.Width)
            {
                Position02.X = Position01.X + Size01.Width -1;
            }

            if (Position04.X < -Size02.Width) //This section is to allocate the location for the 1st and 2nd images.
            {
                Position04.X = Position05.X + Size02.Width;
            }

            if (Position05.X < -Size02.Width)
            {
                Position05.X = Position04.X + Size02.Width;
            }

            if (Position07.X < -Size03.Width) //This section is to allocate the location for the 1st and 2nd images.
            {
                Position07.X = Position08.X + Size03.Width -1;
            }

            if (Position08.X < -Size03.Width)
            {
                Position08.X = Position07.X + Size03.Width -1;
            }

            Vector2 Direction = new Vector2(-6, 0); // scrolling speed for the platform / 1st layer background
            Vector2 Speed = new Vector2(150, 0);

            Vector2 Direction1 = new Vector2(-2, 0); // scrolling speed for the 3rd layer background
            Vector2 Speed1 = new Vector2(100, 0);

            Vector2 Direction2 = new Vector2(-2, 0); // scrolling speed for the 2nd layer background
            Vector2 Speed2 = new Vector2(150, 0);

            Position01 += Direction1 * Speed1 * (float)gameTime.ElapsedGameTime.TotalSeconds; // scrolling speed for the 3rd layer background
            Position02 += Direction1 * Speed1 * (float)gameTime.ElapsedGameTime.TotalSeconds;

            Position04 += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds; // scrolling speed for the platform / 1st layer background
            Position05 += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            Position07 += Direction2 * Speed2 * (float)gameTime.ElapsedGameTime.TotalSeconds; // scrolling speed for the 2nd layer background
            Position08 += Direction2 * Speed2 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }


        public static void Draw(SpriteBatch theSpriteBatch) // Draw session
        {
            theSpriteBatch.Draw(mBG1, Position1, new Rectangle(0, 0, mBG1.Width, mBG1.Height), Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
            theSpriteBatch.Draw(mBG2, Position2, new Rectangle(0, 0, mBG2.Width, mBG2.Height), Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);

            theSpriteBatch.Draw(pBG1, Position4, new Rectangle(0, 0, pBG1.Width, pBG1.Height), Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
            theSpriteBatch.Draw(pBG2, Position5, new Rectangle(0, 0, pBG2.Width, pBG2.Height), Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

        public static void DrawTutorial(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(mBG01, Position01, new Rectangle(0, 0, mBG01.Width, mBG01.Height), Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
            theSpriteBatch.Draw(mBG02, Position02, new Rectangle(0, 0, mBG02.Width, mBG02.Height), Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);         
        }

        public static void DrawTutorial2(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(SecBg01, Position07, new Rectangle(0, 0, pBG01.Width, pBG01.Height), Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
            theSpriteBatch.Draw(SecBg02, Position08, new Rectangle(0, 0, pBG02.Width, pBG02.Height), Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);

            theSpriteBatch.Draw(pBG01, Position04, new Rectangle(0, 0, pBG01.Width, pBG01.Height), Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
            theSpriteBatch.Draw(pBG02, Position05, new Rectangle(0, 0, pBG02.Width, pBG02.Height), Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

        #endregion
    }
}

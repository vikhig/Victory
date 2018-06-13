using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Victory
{
    class Object
    {
        #region Declaration

        public Animation Animation;
        public Vector2 HeroPosition, EnemyPosition, ObjectPosition, SnowPosition;
        public bool HActive, HActive1, Active, EActive, SnowActive;
        public static int HHP = 100, HTDMG = 0;
        public int HDMG, EHP, EDMG, Value = 0, Value1 = 0, Hvalue = 0, EMHP;
        public int MeleeDmg;

        public int HeroWidth
        {
            get { return Animation.FrameWidth; }
        }
        public int HeroHeight
        {
            get { return Animation.FrameHeight; }
        }

        public int EnemyWidth
        {
            get { return Animation.FrameWidth; }
        }
        public int EnemyHeight
        {
            get { return Animation.FrameHeight; }
        }

        public int ObjectWidth
        {
            get { return Animation.FrameWidth; }
        }
        public int ObjectHeight
        {
            get { return Animation.FrameHeight; }
        }

        #endregion

        #region Initializations

        public void InitializeHero(Animation animation, Vector2 position, int value)
        {
            Hvalue = value;
            Animation = animation;
            HeroPosition = position;
            HActive = true;
            HActive1 = true;
            HHP = 100;
            HDMG = 110;
        }
        public void InitializeEnemy(Animation animation, Vector2 position, int value)
        {
            Animation = animation;
            EnemyPosition = position;
            EActive = true;
            EHP = 100;
            EDMG = 110;
            EMHP = 1000;
            Value = value;
            MeleeDmg = 10;
        }
        public void InitializeBGObjects(Animation animation, Vector2 position)
        {
            Animation = animation;
            ObjectPosition = position;
            Active = true;
        }

        public void InitializeSnow(Animation animation, Vector2 position)
        {
            Animation = animation;
            SnowPosition = position;
            SnowActive = true;
        }

        #endregion

        #region Update and Draw
        public void UpdateHero(GameTime gameTime)
        {
            Animation.Position = HeroPosition;
            Animation.Update(gameTime);
            if (HHP <= 0)
            {
                HActive = false;
            }
        }
        public void DrawHero(SpriteBatch spriteBatch)
        {
            Animation.Draw(spriteBatch);
        }

        public void UpdateEnemy(GameTime gameTime, Vector2 enemyMove)
        {
            EnemyPosition -= enemyMove;
            Animation.Position = EnemyPosition;
            Animation.Update(gameTime);
            if (EnemyPosition.X < -EnemyWidth || EHP <= 0 || EMHP <=0)
            {
                EActive = false;
            }
        }
        public void DrawEnemy(SpriteBatch spriteBatch)
        {
            Animation.Draw(spriteBatch);
        }

        public void UpdateObject(GameTime gameTime, float objMoveSpeed)
        {
            ObjectPosition.X -= objMoveSpeed;
            Animation.Position = ObjectPosition;
            Animation.Update(gameTime);
            if (ObjectPosition.X < -ObjectWidth)
            {
                Active = false;
            }
        }

        public void UpdateSnow(GameTime gameTime, int objMoveSpeed, int objMoveSpeed2)
        {
            SnowPosition.X -= objMoveSpeed;
            SnowPosition.Y += objMoveSpeed2;
            Animation.Position = SnowPosition;
            Animation.Update(gameTime);
            if (SnowPosition.Y >= 900)
            {
                SnowActive = false;
            }
        }

        public void DrawObject(SpriteBatch spriteBatch)
        {
            Animation.Draw(spriteBatch);
        }

        #endregion
    }
}

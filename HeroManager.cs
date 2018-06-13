using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Storage;

namespace Victory
{
    class HeroManager
    {
        #region Declarations
        public static Texture2D hero1, army1, army2, army3;
        public static List<Object> heroes;

        Animation heroanim = new Animation();

        public static bool jumping = false;
        public static int jumpspeed = 0, jumpspeed2 = 0, jumpspeed3 = 0, jumpspeed4 = 0;

        static Object HERO1, HERO2;

        public static int Frames = 1;
        public static float delay = 60f;

        public static int totalHP;

        #endregion

        #region Initialize
        public static void InitializeHeroes(Texture2D texture1, Texture2D texture2, Texture2D texture3, Texture2D texture4)
        {
            heroes = new List<Object>();
            hero1 = texture1;
            army1 = texture2;
            army2 = texture3;
            army3 = texture4;

            totalHP = 4;

        }

        #endregion

        #region Hero Management
        
        public static void AddHero()//int i)
        {
            //if (i == 0)
            //{
                Animation heroAnimation1 = new Animation();
                heroAnimation1.Initialize(hero1, Vector2.Zero, 119, 140, 9, 50, Color.White, 1f, true);
                Vector2 position = new Vector2(240, 820);
                //Jump = position;
                HERO1 = new Object();
                HERO1.InitializeHero(heroAnimation1, position, 1);
                heroes.Add(HERO1);
            //}

            //if (i == 1)
            //{
                Animation ArmyAnimation1 = new Animation();
                ArmyAnimation1.Initialize(army1, Vector2.Zero, 119, 140, 9, 50, Color.White, 1f, true);
                Vector2 position1 = new Vector2(150, 820);
                //Jump = position1;
                HERO2 = new Object();
                HERO2.InitializeHero(ArmyAnimation1, position1, 2);
                heroes.Add(HERO2);
            //}

            //if (i == 2)
            //{
                Animation ArmyAnimation2 = new Animation();
                ArmyAnimation2.Initialize(army1, Vector2.Zero, 119, 140, 9, 50, Color.White, 1f, true);
                Vector2 position2 = new Vector2(80, 820);
                //Jump = position2;
                HERO2 = new Object();
                HERO2.InitializeHero(ArmyAnimation2, position2, 3);
                heroes.Add(HERO2);
            //}

            //if (i == 3)
            //{
                Animation ArmyAnimation3 = new Animation();
                ArmyAnimation3.Initialize(army1, Vector2.Zero, 119, 140, 9, 50, Color.White, 1f, true);
                Vector2 position3 = new Vector2(10, 820);
                //Jump = position3;
                HERO2 = new Object();
                HERO2.InitializeHero(ArmyAnimation3, position3, 4);
                heroes.Add(HERO2);
            //}
        }
        #endregion

        #region Update & Draw

        public static void UpdateHeroes(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

               
            /*for (int i = 0; i < totalHP; i++)
                {
                    //AddHero(i);
                    heroes[i].UpdateHero(gameTime);
                } */

            

            foreach (Object hero in heroes)
            {
                hero.UpdateHero(gameTime);
            }

            if (totalHP < heroes.Count)
            {
                heroes.RemoveAt(heroes.Count - 1);
            }

            if (jumping)
            {
                keyState = Keyboard.GetState();

                if (totalHP >= 1)
                {
                    EnemyManager.UpdateCollision(HERO1);
                    heroes[0].HeroPosition.Y += jumpspeed;
                    //heroes.Last().HeroPosition.Y += jumpspeed;
                    jumpspeed += 1;
                }
                if (totalHP >= 2)
                {
                    heroes[1].HeroPosition.Y += jumpspeed2;
                    //heroes.Last().HeroPosition.Y += jumpspeed2;
                    jumpspeed2 += 1;
                }
                if (totalHP >= 3)
                {
                    heroes[2].HeroPosition.Y += jumpspeed3;
                    //heroes.Last().HeroPosition.Y += jumpspeed3;
                    jumpspeed3 += 1;
                }
                if (totalHP >= 4)
                {
                    heroes[3].HeroPosition.Y += jumpspeed4;
                    //heroes.Last().HeroPosition.Y += jumpspeed4;
                    jumpspeed4 += 1;
                }


                if (totalHP >= 1 && heroes[0].HeroPosition.Y > 820)
                {
                    heroes[0].HeroPosition.Y = 820;
                    delay = 60f;
                    EnemyManager.UpdateCollision(HERO1);
                    if (totalHP == 1)
                    {
                        jumping = false;
                    }
                }

                if (totalHP >= 2 && heroes[1].HeroPosition.Y >= 820)
                {
                    heroes[1].HeroPosition.Y = 820;
                    delay = 60f;
                    if (totalHP == 2)
                    {
                        jumping = false;
                    }
                }

                if (totalHP >= 3 && heroes[2].HeroPosition.Y >= 820)
                {
                    heroes[2].HeroPosition.Y = 820;
                    delay = 60f;
                    if (totalHP == 3)
                    {
                        jumping = false;
                    }
                }

                if (totalHP >= 4 && heroes[3].HeroPosition.Y >= 820)
                {
                    heroes[3].HeroPosition.Y = 820;
                    //jumping = false;
                    delay = 60f;
                    if (totalHP == 4)
                    {
                        jumping = false;
                    }
                }

            }

            else
            {

                if (keyState.IsKeyDown(Keys.Up))
                {
                    jumping = true;
                    jumpspeed = -20;
                    jumpspeed2 = -20;
                    jumpspeed3 = -20;
                    jumpspeed4 = -20;
                }
            }
  
            if (jumping == false)
            {
                EnemyManager.UpdateCollision(HERO1);
            } 
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Object hero in heroes)
            {
                hero.DrawHero(spriteBatch);
            }
        } 

        #endregion
    }
}


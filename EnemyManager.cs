using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Victory
{
    class EnemyManager
    {
        #region Declarations

        public static Texture2D ground, trap, gate, arrow, dragon, dmgpic, nm, rollingstone;
        public static List<Object> Enem;
        public static TimeSpan enemySpawnTime = TimeSpan.FromSeconds(1.5f);
        public static TimeSpan previousEnemySpawnTime;
        public static Random random;
        public static Animation battleSceneAnimation = new Animation(), dmgAnimation = new Animation(), wdragonanim = new Animation();
        private static Vector2 enemyMove;
        private static int rand;

        #endregion

        #region Initialize

        public static void InitializeEnemy(Texture2D texture, Texture2D texture1, Texture2D texture2, Texture2D texture3, Texture2D texture4, Texture2D texture5, Texture2D texture6, Texture2D texture7)
        {
            Enem = new List<Object>();
            ground = texture;
            trap = texture1;
            gate = texture2;
            arrow = texture3;
            dragon = texture4;
            dmgpic = texture5;
            nm = texture6;
            rollingstone = texture7;
            random = new Random();
            
            previousEnemySpawnTime = TimeSpan.Zero;

            battleSceneAnimation.Initialize(nm, Vector2.Zero, 500, 250, 2, 100, Color.White, 1f, true);

            dmgAnimation.Initialize(dmgpic, Vector2.Zero, 125, 125, 1, 1, Color.White, 1f, true);
            Vector2 dmgposition = new Vector2(1920 / 4, 1080 / 2);
            Object dmg = new Object();
            dmg.InitializeEnemy(dmgAnimation, dmgposition, 1);
        }
        #endregion

        #region Enemy Management
        private static void AddEnemy(int rand)  // Random spawn of enemies and their placement
        {
            if (rand <= 30)
            {
                Animation enemyAnimation = new Animation();
                enemyAnimation.Initialize(ground, Vector2.Zero, 120, 140, 9, 100, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 815);
                Object enemy = new Object();
                enemy.InitializeEnemy(enemyAnimation, position, 1);
                Enem.Add(enemy);
            }
            if (rand > 30 && rand <= 60)
            {
                Animation enemyAnimation = new Animation();
                enemyAnimation.Initialize(trap, Vector2.Zero, 128, 128, 1, 1, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 830);
                Object enemy = new Object();
                enemy.InitializeEnemy(enemyAnimation, position, 2);
                Enem.Add(enemy);
            }
            /*if (rand == 2)
            {
                Animation enemyAnimation = new Animation();
                enemyAnimation.Initialize(gate, Vector2.Zero, 100, 100, 1, 1, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 750);
                Object enemy = new Object();
                enemy.InitializeEnemy(enemyAnimation, position, 2);
                Enem.Add(enemy);
            }
            if (rand == 3)
            {
                Animation enemyAnimation = new Animation();
                enemyAnimation.Initialize(arrow, Vector2.Zero, 300, 150, 1, 1, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 0);
                Object enemy1 = new Object();
                enemy1.InitializeEnemy(enemyAnimation, position, 3);
                Enem.Add(enemy1);
            }*/
            if (rand > 60 && rand <= 90)
            {
                Animation enemyAnimation = new Animation();
                enemyAnimation.Initialize(rollingstone, Vector2.Zero, 146, 140, 8, 100, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 815);
                Object enemy = new Object();
                enemy.InitializeEnemy(enemyAnimation, position, 2);
                Enem.Add(enemy);
            }
            if (rand > 90)
            {
                Animation enemyAnimation = new Animation();
                enemyAnimation.Initialize(dragon, Vector2.Zero, 440, 500, 8, 100, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 400);
                Object enemy = new Object();
                enemy.InitializeEnemy(enemyAnimation, position, 4);
                Enem.Add(enemy);
            }
            
        }

        #endregion

        #region Collision
        public static void UpdateCollision(Object player) 
        {
            Rectangle rectangle1;
            Rectangle rectangle2;

            rectangle1 = new Rectangle((int)player.HeroPosition.X, (int)player.HeroPosition.Y, player.HeroWidth, player.HeroHeight);

            for (int i = 0; i < Enem.Count; i++)
            {
                rectangle2 = new Rectangle((int)Enem[i].EnemyPosition.X, (int)Enem[i].EnemyPosition.Y, Enem[i].EnemyWidth, Enem[i].EnemyHeight);

                if (rectangle1.Intersects(rectangle2) && !Enem[i].Value.Equals(1) && !Enem[i].Value.Equals(4))
                {
                    Object.HHP -= Enem[i].EDMG;
                    Enem[i].EHP = 0;


                    if (Object.HHP <= 1)
                    {
                        player.HActive = false;
                        HeroManager.totalHP--;
                    }

                }

            }
        }

        #endregion

        #region Update & Draw
        public static void UpdateEnemy(GameTime gameTime) 
        {
            rand = random.Next(0, 101); //random generation of an enemy
            if (gameTime.TotalGameTime - previousEnemySpawnTime > enemySpawnTime)
            {
                previousEnemySpawnTime = gameTime.TotalGameTime;  //spawning time
                AddEnemy(rand);
            }

            for (int i = (Enem.Count - 1); i >= 0; i--)  // different speed movement of enemies
            {
                if (Enem[i].Value.Equals(1))
                {
                    enemyMove.X = 22;
                    enemyMove.Y = 0;
                }

                if (Enem[i].Value.Equals(2))
                {
                    enemyMove.X = 15;
                    enemyMove.Y = 0;
                }

                if (Enem[i].Value.Equals(3))
                {
                    enemyMove.X = 25;
                    enemyMove.Y = -10;
                }

                if (Enem[i].Value.Equals(4))
                {
                    enemyMove.X = 19;
                    enemyMove.Y = 0;
                }

                Enem[i].UpdateEnemy(gameTime, enemyMove);

                 if (Enem[i].EActive == false)
                 {
                     Enem.RemoveAt(i);
                 }
             }
        }

        public static void UpdateBS(GameTime gameTime)
        {
            battleSceneAnimation.Update(gameTime);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Enem.Count; i++)
            {
                Enem[i].DrawEnemy(spriteBatch);
            }
        }

        public static void DrawBattle(SpriteBatch spriteBatch)
        {
            battleSceneAnimation.DrawNM(spriteBatch);
        }

        public static void DrawDMGAnim(SpriteBatch spriteBatch)
        {
            dmgAnimation.DrawDMG(spriteBatch);
        }

        #endregion
    }
}

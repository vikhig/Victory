using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Victory
{
    class BgObjectsManager
    {
        #region Declarations

        private static Texture2D grass1, grass2, obj0, obj1, obj2, obj3, obj4, obj5, obj6, obj7, obj8, obj9, obj10, cloud1, cloud2, cloud3, snow1, snow2, Tree1, Tree2, Tobj0, Tobj1, Tobj2, Tobj3, Tobj4;

        public static List<Object> Grass, Tree, TBgobjects, Bgobjects, SkyObj, SnowFlakes;

        private static float objMoveSpeed = 15f, skyobjMoveSpeed = 2f, treeMoveSpeed = 5f;

        private static TimeSpan cloudSpawnTime = TimeSpan.FromSeconds(1.0f), cloudpreviousSpawnTime, previousSpawnTime = TimeSpan.Zero, previousSpawnTime1 = TimeSpan.Zero, previousSpawnTime2 = TimeSpan.Zero, objectSpawnTime, objectSpawnTime2, objectSpawnTime1, TreeSpawnTime = TimeSpan.Zero;

        private static Random random;

        #endregion

        #region Initialize
        public static void InitializeGrass(Texture2D texture, Texture2D texture1) //Initialise texture from Game1 class. Grass for desert map
        {
            Grass = new List<Object>();

            grass1 = texture;

            grass2 = texture1;

            random = new Random();

            objectSpawnTime = TimeSpan.FromMilliseconds(random.Next(0, 20));
        }

        public static void InitializeCloud(Texture2D texture, Texture2D texture1, Texture2D texture2) //Initialise texture from Game1 class. cloud in desert map
        {
            SkyObj = new List<Object>();
            cloud1 = texture;
            cloud2 = texture1;
            cloud3 = texture2;
            cloudpreviousSpawnTime = TimeSpan.Zero;
        }

        public static void InitializeTree(Texture2D texture, Texture2D texture1) //Initialise texture from Game1 class. Tree in Snow Land map
        {
            Tree = new List<Object>();

            Tree1 = texture;

            Tree2 = texture1;

            random = new Random();

            TreeSpawnTime = TimeSpan.FromSeconds(random.Next(0, 2));
        }

        public static void InitializeObjects(Texture2D texture, Texture2D texture1, Texture2D texture2, Texture2D texture3, Texture2D texture4, Texture2D texture5, Texture2D texture6, Texture2D texture7, Texture2D texture8, Texture2D texture9, Texture2D texture10) //Initialise texture from Game1 class. Background objects in desert map.
        {
            Bgobjects = new List<Object>();
            obj0 = texture;
            obj1 = texture1;
            obj2 = texture2;
            obj3 = texture3;
            obj4 = texture4;
            obj5 = texture5;
            obj6 = texture6;
            obj7 = texture7;
            obj8 = texture8;
            obj9 = texture9;
            obj10 = texture10;

            objectSpawnTime2 = TimeSpan.FromSeconds(random.Next(1, 6));
        }

        public static void InitializeTObjects(Texture2D texture, Texture2D texture1, Texture2D texture2, Texture2D texture3, Texture2D texture4) //Initialise texture from Game1 class. Background object in Snow land.
        {
            TBgobjects = new List<Object>();
            Tobj0 = texture;
            Tobj1 = texture1;
            Tobj2 = texture2;
            Tobj3 = texture3;
            Tobj4 = texture4;           

            objectSpawnTime1 = TimeSpan.FromSeconds(random.Next(1, 6));
        }

        public static void InitializeSnow(Texture2D texture, Texture2D texture1) //Initialise texture from Game1 class. Snow Flakes in Snow land.
        {
            SnowFlakes = new List<Object>();

            snow1 = texture;

            snow2 = texture1;

            random = new Random();

            objectSpawnTime = TimeSpan.FromMilliseconds(random.Next(0, 20));
        }

        #endregion

        #region Objects Management

        private static void AddSkyObj(int rand, int rand1, int scale) //To add random object at sepcific location based on random int rand, rand2 is for random Y position and random size as scale. (desert map)
        {
            if (rand == 0)
            {
                Animation skyobj = new Animation();
                skyobj.Initialize(cloud1, Vector2.Zero, 100, 100, 1, 5, Color.White, 0.5f, true);
                Vector2 position = new Vector2(1900, rand1);
                Object Cloud1 = new Object();
                Cloud1.InitializeBGObjects(skyobj, position);
                skyobj.FrameHeight = skyobj.FrameHeight * scale;
                skyobj.FrameWidth = skyobj.FrameWidth * scale;
                SkyObj.Add(Cloud1);
            }

            if (rand == 1)
            {
                Animation skyobj = new Animation();
                skyobj.Initialize(cloud2, Vector2.Zero, 100, 100, 1, 5, Color.White, 4f, true);
                Vector2 position = new Vector2(1900, rand1);
                Object Cloud1 = new Object();
                Cloud1.InitializeBGObjects(skyobj, position);
                skyobj.FrameHeight = skyobj.FrameHeight * scale;
                skyobj.FrameWidth = skyobj.FrameWidth * scale;
                SkyObj.Add(Cloud1);
            }

            if (rand == 2)
            {
                Animation skyobj = new Animation();
                skyobj.Initialize(cloud3, Vector2.Zero, 100, 100, 1, 5, Color.White, 10f, true);
                Vector2 position = new Vector2(1900, rand1);
                Object Cloud1 = new Object();
                Cloud1.InitializeBGObjects(skyobj, position);
                skyobj.FrameHeight = skyobj.FrameHeight * scale;
                skyobj.FrameWidth = skyobj.FrameWidth * scale;
                SkyObj.Add(Cloud1);
            }
        }
        private static void AddGrass(int rand) //To add random grass at specific location, rand is for which type of grass to add. (desert map)
        {
            if (rand == 0)
            {
                Animation grass01 = new Animation();
                grass01.Initialize(grass1, Vector2.Zero, 102, 50, 1, 5, Color.White, 1f, true);
                Vector2 position = new Vector2(1900, 905);
                Object grass02 = new Object();
                grass02.InitializeBGObjects(grass01, position);
                Grass.Add(grass02);
            }

            if (rand == 1)
            {
                Animation grass01 = new Animation();
                grass01.Initialize(grass2, Vector2.Zero, 102, 50, 1, 5, Color.White, 1f, true);
                Vector2 position = new Vector2(1900, 905);
                Object grass02 = new Object();
                grass02.InitializeBGObjects(grass01, position);
                Grass.Add(grass02); ;
            }
        }
        private static void AddBgobjects(int rand) // To add random background objects with int rand at specific location. (desert map)
        {

            if (rand == 0)
            {
                Animation bgobject = new Animation();
                bgobject.Initialize(obj0, Vector2.Zero, 108, 111, 1, 5, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 845);
                Object bgobject01 = new Object();
                bgobject01.InitializeBGObjects(bgobject, position);
                Bgobjects.Add(bgobject01);
            }

            if (rand == 1)
            {
                Animation bgobject = new Animation();
                bgobject.Initialize(obj1, Vector2.Zero, 70, 45, 1, 5, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 910);
                Object bgobject01 = new Object();
                bgobject01.InitializeBGObjects(bgobject, position);
                Bgobjects.Add(bgobject01);
            }

            if (rand == 2)
            {
                Animation bgobject = new Animation();
                bgobject.Initialize(obj2, Vector2.Zero, 86, 96, 1, 5, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 859);
                Object bgobject01 = new Object();
                bgobject01.InitializeBGObjects(bgobject, position);
                Bgobjects.Add(bgobject01);
            }

            if (rand == 3)
            {
                Animation bgobject = new Animation();
                bgobject.Initialize(obj3, Vector2.Zero, 145, 88, 1, 5, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 867);
                Object bgobject01 = new Object();
                bgobject01.InitializeBGObjects(bgobject, position);
                Bgobjects.Add(bgobject01);
            }

            if (rand == 4)
            {
                Animation bgobject = new Animation();
                bgobject.Initialize(obj4, Vector2.Zero, 131, 74, 1, 5, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 881);
                Object bgobject01 = new Object();
                bgobject01.InitializeBGObjects(bgobject, position);
                Bgobjects.Add(bgobject01);
            }

            if (rand == 5)
            {
                Animation bgobject = new Animation();
                bgobject.Initialize(obj5, Vector2.Zero, 101, 150, 6, 300, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 805);
                Object bgobject01 = new Object();
                bgobject01.InitializeBGObjects(bgobject, position);
                Bgobjects.Add(bgobject01);
            }

            if (rand == 6)
            {
                Animation bgobject = new Animation();
                bgobject.Initialize(obj6, Vector2.Zero, 193, 150, 5, 200, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 200);
                Object bgobject01 = new Object();
                bgobject01.InitializeBGObjects(bgobject, position);
                Bgobjects.Add(bgobject01);
            }

            if (rand == 7)
            {
                Animation bgobject = new Animation();
                bgobject.Initialize(obj7, Vector2.Zero, 84, 87, 8, 200, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 868);
                Object bgobject01 = new Object();
                bgobject01.InitializeBGObjects(bgobject, position);
                Bgobjects.Add(bgobject01);
            }

            if (rand == 8)
            {
                Animation bgobject = new Animation();
                bgobject.Initialize(obj8, Vector2.Zero, 150, 51, 5, 350, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 1000);
                Object bgobject01 = new Object();
                bgobject01.InitializeBGObjects(bgobject, position);
                Bgobjects.Add(bgobject01);
            }

            if (rand == 9)
            {
                Animation bgobject = new Animation();
                bgobject.Initialize(obj9, Vector2.Zero, 313, 260, 1, 5, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 700);
                Object bgobject01 = new Object();
                bgobject01.InitializeBGObjects(bgobject, position);
                Bgobjects.Add(bgobject01);
            }

            if (rand == 10)
            {
                Animation bgobject = new Animation();
                bgobject.Initialize(obj10, Vector2.Zero, 124, 73, 1, 5, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 882);
                Object bgobject01 = new Object();
                bgobject01.InitializeBGObjects(bgobject, position);
                Bgobjects.Add(bgobject01);
            }
        }

        private static void AddTBgobjects(int rand) // To add random background objects with int rand at specific location. (snow land map)
        {

            if (rand == 0)
            {
                Animation Tbgobject = new Animation();
                Tbgobject.Initialize(Tobj0, Vector2.Zero, 97, 120, 5, 1500, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 750);
                Object Tbgobject01 = new Object();
                Tbgobject01.InitializeBGObjects(Tbgobject, position);
                TBgobjects.Add(Tbgobject01);
            }

            if (rand == 1)
            {
                Animation Tbgobject = new Animation();
                Tbgobject.Initialize(Tobj1, Vector2.Zero, 511, 201, 1, 5, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 690);
                Object Tbgobject01 = new Object();
                Tbgobject01.InitializeBGObjects(Tbgobject, position);
                TBgobjects.Add(Tbgobject01);
            }

            if (rand == 2)
            {
                Animation Tbgobject = new Animation();
                Tbgobject.Initialize(Tobj2, Vector2.Zero, 87, 93, 4, 500, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 790);
                Object Tbgobject01 = new Object();
                Tbgobject01.InitializeBGObjects(Tbgobject, position);
                TBgobjects.Add(Tbgobject01);
            }

            if (rand == 3)
            {
                Animation Tbgobject = new Animation();
                Tbgobject.Initialize(Tobj3, Vector2.Zero, 193, 210, 4, 1000, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 700);
                Object Tbgobject01 = new Object();
                Tbgobject01.InitializeBGObjects(Tbgobject, position);
                TBgobjects.Add(Tbgobject01);
            }

            if (rand == 4)
            {
                Animation Tbgobject = new Animation();
                Tbgobject.Initialize(Tobj4, Vector2.Zero, 124, 120, 7, 1000, Color.White, 1f, true);
                Vector2 position = new Vector2(1920, 750);
                Object Tbgobject01 = new Object();
                Tbgobject01.InitializeBGObjects(Tbgobject, position);
                TBgobjects.Add(Tbgobject01);
            }
        }

        private static void AddSnow(int rand, int rand02) //Add random snow flakes based on rand, and rand02 is for random X position. (snow land map)
        {
            if (rand == 0)
            {
                Animation snow01 = new Animation();
                snow01.Initialize(snow1, Vector2.Zero, 20, 20, 1, 5, Color.White, 1f, true);
                Vector2 Snowposition = new Vector2(rand02, 0);
                Object snow02 = new Object();
                snow02.InitializeSnow(snow01, Snowposition);
                SnowFlakes.Add(snow02);
            }

            if (rand == 1)
            {
                Animation snow03 = new Animation();
                snow03.Initialize(snow2, Vector2.Zero, 20, 20, 1, 5, Color.White, 1f, true);
                Vector2 Snowposition = new Vector2(rand02, 0);
                Object snow04 = new Object();
                snow04.InitializeSnow(snow03, Snowposition);
                SnowFlakes.Add(snow04); ;
            }
        }

        private static void AddTree(int rand) //To add random tree at specific location, rand is for which type of tree to add. (snow land map)
        {
            if (rand == 0)
            {
                Animation tree01 = new Animation();
                tree01.Initialize(Tree1, Vector2.Zero, 364, 280, 1, 5, Color.White, 1f, true);
                Vector2 position = new Vector2(1900, 610);
                Object tree02 = new Object();
                tree02.InitializeBGObjects(tree01, position);
                Tree.Add(tree02);
            }

            if (rand == 1)
            {
                Animation tree1 = new Animation();
                tree1.Initialize(Tree2, Vector2.Zero, 228, 280, 1, 5, Color.White, 1f, true);
                Vector2 position = new Vector2(1900, 610);
                Object tree2 = new Object();
                tree2.InitializeBGObjects(tree1, position);
                Tree.Add(tree2); ;
            }
        }

        #endregion

        #region Update & Draw

        public static void UpdateObjects(GameTime gameTime) //To generate random int (rand, rand1, scale) and to add different objects after random duration / at certain duration (desert map). Update object location as specific and remove object from list if object no longer active.
        {
            if (gameTime.TotalGameTime - cloudpreviousSpawnTime > cloudSpawnTime)
            {
                int rand = random.Next(0, 3);
                int rand1 = random.Next(100, 400);
                int scale = random.Next(0, 4);
                cloudpreviousSpawnTime = gameTime.TotalGameTime;
                AddSkyObj(rand, rand1, scale);
            }

            for (int x = (SkyObj.Count - 1); x >= 0; x--)
            {
                SkyObj[x].UpdateObject(gameTime, skyobjMoveSpeed);
                if (SkyObj[x].Active == false)
                {
                    SkyObj.RemoveAt(x);
                }
            }

            if (gameTime.TotalGameTime - previousSpawnTime > objectSpawnTime)
            {
                int rand = random.Next(0, 2);
                previousSpawnTime = gameTime.TotalGameTime;
                AddGrass(rand);
                objectSpawnTime = TimeSpan.FromMilliseconds(random.Next(5, 100));
            }

            for (int i = (Grass.Count - 1); i >= 0; i--)
            {
                Grass[i].UpdateObject(gameTime, objMoveSpeed);
                if (Grass[i].Active == false)
                {
                    Grass.RemoveAt(i);
                }
            }

            if (gameTime.TotalGameTime - previousSpawnTime1 > objectSpawnTime2)
            {
                int rand = random.Next(0, 11);
                previousSpawnTime1 = gameTime.TotalGameTime;
                AddBgobjects(rand);
                objectSpawnTime2 = TimeSpan.FromSeconds(random.Next(1, 6));
            }

            for (int y = (Bgobjects.Count - 1); y >= 0; y--)
            {
                Bgobjects[y].UpdateObject(gameTime, objMoveSpeed);
                if (Bgobjects[y].Active == false)
                {
                    Bgobjects.RemoveAt(y);
                }
            }
        }

        public static void UpdateTObjects(GameTime gameTime) //To generate random int (rand) and to add different objects after random duration / at certain duration (snow land map). Update object location as specific and remove object from list if object no longer active.
        {
            if (gameTime.TotalGameTime - previousSpawnTime2 > objectSpawnTime1)
            {
                int rand = random.Next(0, 5);
                previousSpawnTime2 = gameTime.TotalGameTime;
                AddTBgobjects(rand);
                objectSpawnTime1 = TimeSpan.FromSeconds(random.Next(1, 6));
            }

            for (int y = (TBgobjects.Count - 1); y >= 0; y--)
            {
                TBgobjects[y].UpdateObject(gameTime, treeMoveSpeed);
                if (TBgobjects[y].Active == false)
                {
                    TBgobjects.RemoveAt(y);
                }
            }
        }
        public static void UpdateSnow(GameTime gameTime) //To generate random int (rand, rand2) and to add different snow flakes after random duration (snow land map). Update object location randomly and remove object from list if object no longer active.
        {

            if (gameTime.TotalGameTime - previousSpawnTime1 > objectSpawnTime2)
            {
                int rand = random.Next(0, 2);
                int rand2 = random.Next(100, 3000);
                previousSpawnTime1 = gameTime.TotalGameTime;
                AddSnow(rand, rand2);
                objectSpawnTime2 = TimeSpan.FromMilliseconds(random.Next(0, 20));
            }

            for (int z = (SnowFlakes.Count - 1); z >= 0; z--)
            {
                int snowMoveSpeed01 = random.Next(10, 25);
                int snowMoveSpeed02 = random.Next(5, 20);
                SnowFlakes[z].UpdateSnow(gameTime, snowMoveSpeed01, snowMoveSpeed02);
                if (SnowFlakes[z].SnowActive == false)
                {
                    SnowFlakes.RemoveAt(z);
                }
            }
        }
        public static void UpdateTree(GameTime gameTime) //To generate random int (rand) and to add different tree after random duration (snow land map). Update object location and remove object from list if object no longer active.
        {
            if (gameTime.TotalGameTime - previousSpawnTime > TreeSpawnTime)
            {
                int rand = random.Next(0, 2);
                previousSpawnTime = gameTime.TotalGameTime;
                AddTree(rand);
                TreeSpawnTime = TimeSpan.FromMilliseconds(random.Next(100, 1000));
            }

            for (int i = (Tree.Count - 1); i >= 0; i--)
            {
                Tree[i].UpdateObject(gameTime, treeMoveSpeed);
                if (Tree[i].Active == false)
                {
                    Tree.RemoveAt(i);
                }
            }
        }
        
        public static void DrawObjects(SpriteBatch spriteBatch) // draw object for background object (desert map)
        {
            for (int i = 0; i < SkyObj.Count; i++)
            {
                SkyObj[i].DrawObject(spriteBatch);
            }

            for (int i = 0; i < Bgobjects.Count; i++)
            {
                Bgobjects[i].DrawObject(spriteBatch);
            }

            for (int i = 0; i < Grass.Count; i++)
            {
                Grass[i].DrawObject(spriteBatch);
            }
        }

        public static void DrawSnow(SpriteBatch spriteBatch) // draw snow (snow land map)
        {
            for (int i = 0; i < SnowFlakes.Count; i++)
            {
                SnowFlakes[i].DrawObject(spriteBatch);
            }
        }

        public static void DrawTree(SpriteBatch spriteBatch) //draw tree (snow land map)
        {
            for (int X = 0; X < Tree.Count; X++)
            {
                Tree[X].DrawObject(spriteBatch);
            }
        }

        public static void DrawTBgObjects(SpriteBatch spriteBatch) //draw background objects (snow land map)
        {
            for (int X = 0; X < TBgobjects.Count; X++)
            {
                TBgobjects[X].DrawObject(spriteBatch);
            }
        }
        #endregion
    }
}

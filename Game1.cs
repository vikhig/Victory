using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace Victory
{
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        #region Khai's Declarations

        private Texture2D MBG1, PBG1, MBG01, PBG01, secBG;

        Vector2 graphicsInfo, graphicsInfo1, startButtonlocation = new Vector2(400, 500); // this is for the distance and gold display.

        //int gold;

        //private String goldsign = "$";

        private SpriteFont font;

        TimeSpan frequency = TimeSpan.Zero;

        Texture2D tipTutorial, Grass1, Grass2, bgobj0, bgobjt1, bgobjt2, bgobjt3, bgobjt4, bgobjt5, bgobjt6, bgobjt7, bgobjt8, bgobjt9, bgobjt10, cloud1, cloud2, cloud3, snow01, snow02, tree1, tree2, Tbgobj0, Tbgobjt1, Tbgobjt2, Tbgobjt3, Tbgobjt4;

        enum GameStates { TitleScreen, Playing, GameOver, Credits, NormalBattle, TutorialBattle, PauseMenu, Tutorial, TipTutorial};
        GameStates gameState = GameStates.TitleScreen;

        float gameOverTimer = 0.0f, gameOverDelay = 6.0f;

        Texture2D gameOverScreen, titleScreen, creditScreen, startButton, pauseScreen, CreditScreen, DragonTitleScreen, ReturnAnimation, PauseAnimation, TitleScreen;

        Animation StartAnimation = new Animation(), Credits = new Animation(), DragonAnimation = new Animation(), returnAnimation = new Animation(), pauseAnimation = new Animation(), titleScreenAnimation = new Animation();
        #endregion

        #region Slava's Declarations

        Texture2D ground, trap, gate, arrow, dragon, dmgpic, nm, rollingst;
        TimeSpan Duration;

        #endregion

        #region Giulia's Declarations

        Texture2D hero1, army1, army2, army3;

        bool keypress;

        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

    
        protected override void Initialize()
        {
            graphicsInfo.Y = GraphicsDevice.Viewport.Height / 5; //use to specific location to draw score/distance
            graphicsInfo.X = GraphicsDevice.Viewport.Width / 1; //use to specific location to draw score/distance

            graphicsInfo1.Y = GraphicsDevice.Viewport.Height / 5; //use to specific location to draw gold
            graphicsInfo1.X = GraphicsDevice.Viewport.Width * 2; //use to specific location to draw gold

            #region Resolution

            this.graphics.PreferredBackBufferHeight = 1080; //720/1080
            this.graphics.PreferredBackBufferWidth = 1920; // 1280/1920
            //this.graphics.IsFullScreen = true;
            this.graphics.ApplyChanges();

            #endregion

            IsMouseVisible = true;

            base.Initialize();
        }

  
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            #region Slava's Content and Initializations

            ground = Content.Load<Texture2D>("OgreAttack");
            trap = Content.Load<Texture2D>("SpikeTrap");
            gate = Content.Load<Texture2D>("gate");
            arrow = Content.Load<Texture2D>("ArrowShower");
            dragon = Content.Load<Texture2D>("Dragon");
            dmgpic = Content.Load<Texture2D>("DMG");
            nm = Content.Load<Texture2D>("NorMelee");
            rollingst = Content.Load<Texture2D>("RollingStone");
            
            EnemyManager.InitializeEnemy(ground, trap, gate, arrow, dragon,dmgpic, nm, rollingst);

            #endregion

            #region Khai's Content and Initializations

            font = Content.Load<SpriteFont>("Info"); // in game font for dist.

            ScoreManager.InitializedScore(font, graphicsInfo);//dist, dist1, distance, font, graphicsInfo);


            MBG1 = Content.Load<Texture2D>("BG");
            PBG1 = Content.Load<Texture2D>("PBG");

            ScrollingBG.BGInitialization(MBG1, PBG1); //initialize background images for desert map.

            MBG01 = Content.Load<Texture2D>("BonusBG");
            PBG01 = Content.Load<Texture2D>("BonusTile");
            secBG = Content.Load<Texture2D>("BonusSnow1");

            ScrollingBG.BGInitializationTutorial(MBG01, PBG01, secBG); // initialize background images for snow land map.

            Grass1 = Content.Load<Texture2D>("Grass1");
            Grass2 = Content.Load<Texture2D>("Grass2");
            bgobj0 = Content.Load<Texture2D>("Cactus1");
            bgobjt1 = Content.Load<Texture2D>("Cactus2");
            bgobjt2 = Content.Load<Texture2D>("Cactus3");
            bgobjt3 = Content.Load<Texture2D>("Bush1");
            bgobjt4 = Content.Load<Texture2D>("Bush2");
            bgobjt5 = Content.Load<Texture2D>("CrateWOgre");
            bgobjt6 = Content.Load<Texture2D>("FlyingDragon");
            bgobjt7 = Content.Load<Texture2D>("ToHellSign");
            bgobjt8 = Content.Load<Texture2D>("SkeletonWeyes");
            bgobjt9 = Content.Load<Texture2D>("Tree");
            bgobjt10 = Content.Load<Texture2D>("Stone");

            cloud1 = Content.Load<Texture2D>("cloud1");
            cloud2 = Content.Load<Texture2D>("cloud2");
            cloud3 = Content.Load<Texture2D>("cloud3");

            BgObjectsManager.InitializeGrass(Grass1, Grass2); // Initialize background object images for desert map.
            BgObjectsManager.InitializeObjects(bgobj0, bgobjt1, bgobjt2, bgobjt3, bgobjt4, bgobjt5, bgobjt6, bgobjt7, bgobjt8, bgobjt9, bgobjt10); // Initialize background object images for desert map.
            BgObjectsManager.InitializeCloud(cloud1, cloud2, cloud3); // Initialize background object images for desert map.

            Tbgobj0 = Content.Load<Texture2D>("GrowingCrystal");
            Tbgobjt1 = Content.Load<Texture2D>("Igloo");
            Tbgobjt2 = Content.Load<Texture2D>("GoSign");
            Tbgobjt3 = Content.Load<Texture2D>("SnowMan");
            Tbgobjt4 = Content.Load<Texture2D>("OgreWStone");

            BgObjectsManager.InitializeTObjects(Tbgobj0, Tbgobjt1, Tbgobjt2, Tbgobjt3, Tbgobjt4); // Initialize background object images for snow land map.

            snow01 = Content.Load<Texture2D>("snow1");
            snow02 = Content.Load<Texture2D>("snow2");

            tree1 = Content.Load<Texture2D>("Tree_1");
            tree2 = Content.Load<Texture2D>("Tree_2");

            BgObjectsManager.InitializeTree(tree1, tree2); // Initialize background object images for snow land map.
            BgObjectsManager.InitializeSnow(snow01, snow02); // Initialize background object images for snow land map.

            gameOverScreen = Content.Load<Texture2D>("GameOver");
            creditScreen = Content.Load<Texture2D>("Credits");
            titleScreen = Content.Load<Texture2D>("TitleScreen");
            pauseScreen = Content.Load<Texture2D>("PauseScreen");

            startButton = Content.Load<Texture2D>("StartAnimation");
            DragonTitleScreen = Content.Load<Texture2D>("DragonTitle");
            tipTutorial = Content.Load<Texture2D>("AllTutorial");
            ReturnAnimation = Content.Load<Texture2D>("ReturnAnimation");
            PauseAnimation = Content.Load<Texture2D>("PauseAnimation");
            TitleScreen = Content.Load<Texture2D>("TitleScreenAnimation");

            CreditScreen = Content.Load<Texture2D>("CreditsScreen");

            StartAnimation.Initialize(startButton, startButtonlocation, 1225, 110, 2, 1000, Color.White, 1f, true); //Initialize animation of start button for the title screen.
            DragonAnimation.Initialize(DragonTitleScreen, new Vector2(1000, 400), 440, 500, 8, 150, Color.White, 1f, true); //Initialize animation of flying dragon for the title screen.
            returnAnimation.Initialize(ReturnAnimation, new Vector2(300, 850), 1225, 110, 2, 800, Color.White, 1f, true); //Initialize animation of return to title screen for the credits screen.
            pauseAnimation.Initialize(PauseAnimation, new Vector2(300, 10), 1225, 110, 2, 800, Color.White, 1f, true); //Initialize animation of pause button for the playing state.
            titleScreenAnimation.Initialize(TitleScreen, new Vector2(300, 200), 1225, 110, 2, 800, Color.White, 1f, true); //Initialize animation of return to title screen from tutorial.

            #endregion

            #region Giulia's Content and Initializations

            hero1 = Content.Load<Texture2D>("HeroRun3.0");

            army1 = Content.Load<Texture2D>("ArmyRun3.0");
            army2 = Content.Load<Texture2D>("ArmyRun3.0");
            army3 = Content.Load<Texture2D>("ArmyRun3.0");
            HeroManager.InitializeHeroes(hero1, army1, army2, army3);
            
            #endregion 

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            #region Gamestate Update

            if (IsActive)
            {

                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.LeftControl) & Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                switch (gameState) // Game menu function, including start game, pause game, credits, tutorial level and normal battle scene.
                {
                    case GameStates.TitleScreen:

                        if ((GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed) || (Keyboard.GetState().IsKeyDown(Keys.Space)))
                        {
                            GameManager.StartNewGame(); //Game Manager is call to reset all necessary data to start a fresh game.
                            gameState = GameStates.Playing;
                        }
                        if ((GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed) || (Keyboard.GetState().IsKeyDown(Keys.C)))
                        {
                            Animation.Active = true;
                            Credits.Initialize(CreditScreen, new Vector2(150, 0), 1600, 1080, 8, 100, Color.White, 1f, false); // To re-animate the animation in credits.
                            gameState = GameStates.Credits;
                        }

                        if ((GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed) || (Keyboard.GetState().IsKeyDown(Keys.T)))
                        {
                            GameManager.StartNewTutorial(); //Game Manager is call to reset all necessary data to start a fresh tutorial.
                            gameState = GameStates.TipTutorial;
                        }


                        break;

                    case GameStates.Playing: // while in playing state, to update all required function such as, scrolling background class, background object class, hero manager class, enemy manager class and score manager class.
                        ScrollingBG.UpdateBG(gameTime);
                        BgObjectsManager.UpdateObjects(gameTime);
                        HeroManager.UpdateHeroes(gameTime);
                        EnemyManager.UpdateEnemy(gameTime);
                        ScoreManager.UpdateDistance(gameTime);
                        break;

                    case GameStates.GameOver:
                        gameOverTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        if (gameOverTimer > gameOverDelay)
                        {
                            gameState = GameStates.TitleScreen;
                            gameOverTimer = 0.0f; // reset time delay back to 0.
                        }
                        break;

                    case GameStates.Credits:
                        if ((GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed) || (Keyboard.GetState().IsKeyDown(Keys.Back)))
                        {
                            DragonAnimation.Initialize(DragonTitleScreen, new Vector2(1000, 400), 440, 500, 8, 150, Color.White, 1f, true); // To re-animate the animation in title screen.
                            gameState = GameStates.TitleScreen;
                        }
                        break;

                    case GameStates.NormalBattle:
         
                        break;

                    case GameStates.TutorialBattle:

                        break;

                    case GameStates.PauseMenu:
                        if ((GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed) || (Keyboard.GetState().IsKeyDown(Keys.Back)))
                        {
                            gameState = GameStates.Playing;
                        }
                        if ((GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed) || (Keyboard.GetState().IsKeyDown(Keys.Enter)))
                        {
                            DragonAnimation.Initialize(DragonTitleScreen, new Vector2(1000, 400), 440, 500, 8, 150, Color.White, 1f, true); // To re-animate the animation in title screen.
                            gameState = GameStates.TitleScreen;
                        }
                        break;

                    case GameStates.Tutorial: // function similar to playing state.
                        if ((GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed) || (Keyboard.GetState().IsKeyDown(Keys.Back)))
                        {
                            DragonAnimation.Initialize(DragonTitleScreen, new Vector2(1000, 400), 440, 500, 8, 150, Color.White, 1f, true); // To re-animate the animation in title screen.
                            gameState = GameStates.TitleScreen;
                        }
                        ScrollingBG.UpdateBGTutorial(gameTime);
                        BgObjectsManager.UpdateSnow(gameTime);
                        BgObjectsManager.UpdateTree(gameTime);
                        BgObjectsManager.UpdateTObjects(gameTime);
                        HeroManager.UpdateHeroes(gameTime);
                        EnemyManager.UpdateEnemy(gameTime);
                        unlimitedhealth();
                        ScoreManager.UpdateDistance(gameTime);
                        break;
                    case GameStates.TipTutorial:
                        if ((GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed) || (Keyboard.GetState().IsKeyDown(Keys.Space)))
                        {
                            gameState = GameStates.Tutorial;
                        }
                        break;
                }
            }

            #endregion

            base.Update(gameTime);
        
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            #region Gamestate Draw

            if (gameState == GameStates.TitleScreen) // Draw function while game state is in title screen.
            {
                spriteBatch.Draw(titleScreen, new Rectangle(0, 0, 1980, 1080), Color.White);              
                DragonAnimation.Draw(spriteBatch); // Flying dragon animation
                DragonAnimation.Update(gameTime); // Update dragon animation
                StartAnimation.Draw(spriteBatch); // Start button animation
                StartAnimation.Update(gameTime); // Update Start button animation
            }

            if (gameState == GameStates.TipTutorial) //Draw function for tips for tutorial. 
            {
                spriteBatch.Draw(tipTutorial, new Rectangle(0, 0, 1920, 1080), Color.White);
                StartAnimation.Draw(spriteBatch); // Start button animation
                StartAnimation.Update(gameTime); // Update Start button animation           
            }

            if (gameState == GameStates.Playing || gameState == GameStates.GameOver || gameState == GameStates.NormalBattle)
            {

                #region Khai's Draw

                ScrollingBG.Draw(spriteBatch); // Draw scrolling background while in playing state.

                //spriteBatch.DrawString(font, goldsign + gold, graphicsInfo1, Color.DarkGoldenrod); // Display amount of gold earn in game while in playing state.

                BgObjectsManager.DrawObjects(spriteBatch); // Draw background objects while in playing state.

                #endregion

                #region Slava's Draw

                EnemyManager.Draw(spriteBatch);

                #endregion

                #region Giulia's Draw

                HeroManager.Draw(spriteBatch);

                #endregion

                ScoreManager.Draw(spriteBatch);

                pauseGame(gameTime); // call the pause function when player press pause button

                checkPlayerDeath(); // check if player is death 0HP then display game over screen.
                
                checkBattle(gameTime); // to check collision between melee enemies then commence battle.

                pauseAnimation.Draw(spriteBatch); // Pause button animation
                pauseAnimation.Update(gameTime); // Update pause button animation
            }

            if (gameState == GameStates.GameOver)
            {
                spriteBatch.Draw(gameOverScreen, new Rectangle(0, 0, 1980, 1080), Color.White);
            }

            if (gameState == GameStates.Credits)
            {
                Credits.Draw(spriteBatch); // Draw credits animation 
                Credits.Update2(gameTime); // Update credits animation
                spriteBatch.DrawString(font, "Press Back or B to return.", new Vector2(300, 850), Color.Black);
                //returnAnimation.Draw(spriteBatch); // Return button animation
                //returnAnimation.Update(gameTime); // Update return button animation
            }

            if (gameState == GameStates.NormalBattle)
            {
                //spriteBatch.DrawString(font, goldsign + gold, graphicsInfo1, Color.DarkGoldenrod);
                normalBattle(gameTime);
                //checkBattle(gameTime);
                EnemyManager.DrawBattle(spriteBatch);
                EnemyManager.UpdateBS(gameTime);
            }
          
            if (gameState == GameStates.PauseMenu)
            {
                spriteBatch.Draw(pauseScreen, new Rectangle(0, 0, 1980, 1080), Color.White); // To displat pause screen.
                //spriteBatch.DrawString(font, goldsign + gold, graphicsInfo1, Color.DarkGoldenrod); // Show gold earned in game.
            }

            if (gameState == GameStates.Tutorial || gameState == GameStates.TutorialBattle) //Same as playing state, except in tutorial unlimited health function is call.
            {
                ScrollingBG.DrawTutorial(spriteBatch);
                BgObjectsManager.DrawTree(spriteBatch);
                BgObjectsManager.DrawTBgObjects(spriteBatch);
                ScrollingBG.DrawTutorial2(spriteBatch);
                BgObjectsManager.DrawSnow(spriteBatch);

                EnemyManager.Draw(spriteBatch);
                unlimitedhealth();
                ScoreManager.Draw(spriteBatch);
                HeroManager.Draw(spriteBatch);
                checkBattleTutorial(gameTime);
                unlimitedhealth();
                titleScreenAnimation.Draw(spriteBatch); // Return to title screen button animation
                titleScreenAnimation.Update(gameTime); // Update return to title screen button animation
            }

            if (gameState == GameStates.TutorialBattle)
            {
                normalBattle(gameTime);
                EnemyManager.DrawBattle(spriteBatch);
                EnemyManager.UpdateBS(gameTime);
            }

            spriteBatch.End();

            #endregion

            base.Draw(gameTime);
        }

        #region Game Methods

        public void checkPlayerDeath() //if hero's health is 0, then game state switch to game over.
        {
            if (HeroManager.totalHP == 0)
            {
                gameState = GameStates.GameOver;
            }
        }

        public void unlimitedhealth() //to increase hero's health when damaged.
        {
            if (HeroManager.totalHP <= 3)
            {
                HeroManager.totalHP++;
            }
        }

        public void pauseGame(GameTime gameTime) //method - when player press the pause button, game state will change to pause.
        {
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed) || (Keyboard.GetState().IsKeyDown(Keys.Escape)))
            {
                gameState = GameStates.PauseMenu; 
            }
        }

        public void checkBattle(GameTime gameTime)  // method - player enters battle with dragon or ogre
        {
            Rectangle rectangle1;
            Rectangle rectangle2;

            rectangle1 = new Rectangle((int)HeroManager.heroes[0].HeroPosition.X, (int)HeroManager.heroes[0].HeroPosition.Y, HeroManager.heroes[0].HeroWidth, HeroManager.heroes[0].HeroHeight);

            for (int i = 0; i < EnemyManager.Enem.Count; i++)
            {
                rectangle2 = new Rectangle((int)EnemyManager.Enem[i].EnemyPosition.X, (int)EnemyManager.Enem[i].EnemyPosition.Y, EnemyManager.Enem[i].EnemyWidth, EnemyManager.Enem[i].EnemyHeight);

                if (rectangle1.Intersects(rectangle2) && EnemyManager.Enem[i].Value.Equals(4))//collision and enemy type(dragon)
                {
                    int enemyhp = 200;
                    int bremainingenemyhp = enemyhp - Object.HTDMG;
                    spriteBatch.DrawString(font, "hp " + bremainingenemyhp.ToString(), new Vector2(400, 750), Color.White);

                    Duration = TimeSpan.FromSeconds(5);

                    if (EnemyManager.Enem[i].EMHP != 0) // declarations for the battle
                    {
                        TimeSpan d = frequency - Duration;
                        spriteBatch.DrawString(font, d.ToString("ss\\:ff"), new Vector2(750, 300), Color.Black);
                        gameState = GameStates.NormalBattle;

                        if (Object.HTDMG >= 200)
                        {
                            gameState = GameStates.Playing;
                            Object.HTDMG = 0;
                            Duration = new TimeSpan(5);
                            frequency = new TimeSpan(0);
                            EnemyManager.Enem[i].EMHP = 0;
                        }
                        if (frequency >= Duration)
                        {
                            EnemyManager.Enem[i].EMHP = 0;
                            HeroManager.totalHP--;
                            frequency = new TimeSpan(0);
                            gameState = GameStates.Playing;
                            Object.HTDMG = 0;
                            checkPlayerDeath();
                        }
                        checkPlayerDeath();
                    }
                    frequency += gameTime.ElapsedGameTime;
                }

                if (rectangle1.Intersects(rectangle2) && EnemyManager.Enem[i].Value.Equals(1)) //collision and enemy type(ogre)
                {
                    int enemyhp = 100;
                    int bremainingenemyhp = enemyhp - Object.HTDMG;
                    spriteBatch.DrawString(font, "hp " + bremainingenemyhp.ToString(), new Vector2(400, 750), Color.White);

                    Duration = TimeSpan.FromSeconds(3);
                    
                    if (EnemyManager.Enem[i].EMHP != 0)
                    {
                        TimeSpan d=frequency - Duration;
                        spriteBatch.DrawString(font,d.ToString("ss\\:ff"), new Vector2(750, 300), Color.Black);
                        gameState = GameStates.NormalBattle;

                        if (Object.HTDMG >= 100)
                        {
                            gameState = GameStates.Playing;
                            Object.HTDMG = 0;
                            Duration = new TimeSpan(3);
                            frequency = new TimeSpan(0);
                            EnemyManager.Enem[i].EMHP = 0;
                        }
                        if (frequency >= Duration)
                        {
                            EnemyManager.Enem[i].EMHP = 0;
                            HeroManager.totalHP--;
                            frequency = new TimeSpan(0);
                            gameState = GameStates.Playing;
                            Object.HTDMG = 0;
                            checkPlayerDeath();
                        }
                        checkPlayerDeath();
                    }
                    frequency += gameTime.ElapsedGameTime;
                }
            }
        }

        public void checkBattleTutorial(GameTime gameTime)  // method - player enters battle with dragon or ogre
        {
            Rectangle rectangle1;
            Rectangle rectangle2;

            rectangle1 = new Rectangle((int)HeroManager.heroes[0].HeroPosition.X, (int)HeroManager.heroes[0].HeroPosition.Y, HeroManager.heroes[0].HeroWidth, HeroManager.heroes[0].HeroHeight);

            for (int i = 0; i < EnemyManager.Enem.Count; i++)
            {
                rectangle2 = new Rectangle((int)EnemyManager.Enem[i].EnemyPosition.X, (int)EnemyManager.Enem[i].EnemyPosition.Y, EnemyManager.Enem[i].EnemyWidth, EnemyManager.Enem[i].EnemyHeight);

                if (rectangle1.Intersects(rectangle2) && EnemyManager.Enem[i].Value.Equals(4))//collision and enemy type(dragon)
                {
                    int enemyhp = 200;
                    int bremainingenemyhp = enemyhp - Object.HTDMG;
                    spriteBatch.DrawString(font, "hp " + bremainingenemyhp.ToString(), new Vector2(400, 750), Color.White);

                    Duration = TimeSpan.FromSeconds(5);

                    if (EnemyManager.Enem[i].EMHP != 0) // declarations for the battle
                    {
                        TimeSpan d = frequency - Duration;
                        spriteBatch.DrawString(font, d.ToString("ss\\:ff"), new Vector2(750, 300), Color.Black);
                        gameState = GameStates.TutorialBattle;

                        if (Object.HTDMG >= 200)
                        {
                            gameState = GameStates.Tutorial;
                            Object.HTDMG = 0;
                            Duration = new TimeSpan(5);
                            frequency = new TimeSpan(0);
                            EnemyManager.Enem[i].EMHP = 0;
                        }
                        if (frequency >= Duration)
                        {
                            EnemyManager.Enem[i].EMHP = 0;
                            HeroManager.totalHP--;
                            frequency = new TimeSpan(0);
                            gameState = GameStates.Tutorial;
                            Object.HTDMG = 0;
                        }
                        checkPlayerDeath();
                    }
                    frequency += gameTime.ElapsedGameTime;
                }

                if (rectangle1.Intersects(rectangle2) && EnemyManager.Enem[i].Value.Equals(1)) //collision and enemy type(ogre)
                {
                    int enemyhp = 100;
                    int bremainingenemyhp = enemyhp - Object.HTDMG;
                    spriteBatch.DrawString(font, "hp " + bremainingenemyhp.ToString(), new Vector2(400, 750), Color.White);

                    Duration = TimeSpan.FromSeconds(3);

                    if (EnemyManager.Enem[i].EMHP != 0)
                    {
                        TimeSpan d = frequency - Duration;
                        spriteBatch.DrawString(font, d.ToString("ss\\:ff"), new Vector2(750, 300), Color.Black);
                        gameState = GameStates.TutorialBattle;

                        if (Object.HTDMG >= 100)
                        {
                            gameState = GameStates.Tutorial;
                            Object.HTDMG = 0;
                            Duration = new TimeSpan(3);
                            frequency = new TimeSpan(0);
                            EnemyManager.Enem[i].EMHP = 0;
                        }
                        if (frequency >= Duration)
                        {
                            EnemyManager.Enem[i].EMHP = 0;
                            HeroManager.totalHP--;
                            frequency = new TimeSpan(0);
                            gameState = GameStates.Tutorial;
                            Object.HTDMG = 0;
                        }
                        checkPlayerDeath();
                    }
                    frequency += gameTime.ElapsedGameTime;
                }
            }
        }

        public void normalBattle(GameTime gameTime) //method for battle (pressing buttons)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                keypress = true;
                EnemyManager.DrawBattle(spriteBatch);
                EnemyManager.DrawDMGAnim(spriteBatch);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && keypress)
            {
                EnemyManager.DrawDMGAnim(spriteBatch);
                EnemyManager.DrawBattle(spriteBatch);
                Object.HTDMG += 10;
                keypress = false;
            }
        }



        #endregion 

    }
}

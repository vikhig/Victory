using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Victory
{
    static class GameManager
    {     
        #region Public Methods

        public static void StartNewGame() // Used to reset the game by clearing all list, dist, TotalHP & Add heroes.
        {
            EnemyManager.Enem.Clear(); 
            BgObjectsManager.Grass.Clear();
            BgObjectsManager.SkyObj.Clear();
            BgObjectsManager.Bgobjects.Clear();
            HeroManager.heroes.Clear();
            ScoreManager.dist = 0;
            ScoreManager.dist1 = 0;
            ScoreManager.distance = "M";
            HeroManager.totalHP = 4;
            HeroManager.AddHero();
        }

        public static void StartNewTutorial() // used to reset the tutorial level by clearing all list, dist, TotalHP & Add heroes.
        {
            EnemyManager.Enem.Clear();
            BgObjectsManager.TBgobjects.Clear();
            BgObjectsManager.SnowFlakes.Clear();
            BgObjectsManager.Tree.Clear();
            HeroManager.heroes.Clear();
            ScoreManager.dist = 0;
            ScoreManager.dist1 = 0;
            ScoreManager.distance = "M";
            HeroManager.totalHP = 4;
            HeroManager.AddHero();
        }
    }

        #endregion
   
}

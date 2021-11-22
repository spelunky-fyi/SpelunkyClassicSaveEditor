using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpelunkyClassicSaveEditor
{
    public static class SpelunkySaveManager
    {
        public static ulong GetScore()
        {
            return GameMakerHighScore.FromRegistry("Rank1").score - 9000000;
        }

        public static void SetScore(ulong score)
        {
            var highScore = new GameMakerHighScore(score + 9000000, "MONEY");
            highScore.SaveToRegistry("Rank1");
        }

        public static ulong GetTime()
        {
            return GameMakerHighScore.FromRegistry("Rank2").score - 8000000;
        }

        public static void SetTime(ulong score)
        {
            var highScore = new GameMakerHighScore(score + 8000000, "TIME");
            highScore.SaveToRegistry("Rank2");
        }

        public static ulong GetKills()
        {
            return GameMakerHighScore.FromRegistry("Rank3").score - 7000000;

        }

        public static void SetKills(ulong score)
        {
            var highScore = new GameMakerHighScore(score + 7000000, "KILLS");
            highScore.SaveToRegistry("Rank3");
        }

        public static ulong GetSaves()
        {
            return GameMakerHighScore.FromRegistry("Rank4").score - 6000000;

        }

        public static void SetSaves(ulong score)
        {
            var highScore = new GameMakerHighScore(score + 6000000, "SAVES");
            highScore.SaveToRegistry("Rank4");
        }

        public static ulong GetPlays()
        {
            return GameMakerHighScore.FromRegistry("Rank5").score - 5000000;

        }

        public static void SetPlays(ulong score)
        {
            var highScore = new GameMakerHighScore(score + 5000000, "PLAYS");
            highScore.SaveToRegistry("Rank5");
        }

        public static ulong GetWins()
        {
            return GameMakerHighScore.FromRegistry("Rank6").score - 4000000;

        }

        public static void SetWins(ulong score)
        {
            var highScore = new GameMakerHighScore(score + 4000000, "WINS");
            highScore.SaveToRegistry("Rank6");
        }


        public static ulong GetDeaths()
        {
            return GameMakerHighScore.FromRegistry("Rank7").score - 3000000;

        }

        public static void SetDeaths(ulong score)
        {
            var highScore = new GameMakerHighScore(score + 3000000, "DEATHS");
            highScore.SaveToRegistry("Rank7");
        }

        public static ulong GetTunnel1()
        {
            return GameMakerHighScore.FromRegistry("Rank8").score - 2000000;

        }

        public static void SetTunnel1(ulong score)
        {
            var highScore = new GameMakerHighScore(score + 2000000, "TUNNEL1");
            highScore.SaveToRegistry("Rank8");
        }

        public static ulong GetTunnel2()
        {
            return GameMakerHighScore.FromRegistry("Rank9").score - 1000000;

        }

        public static void SetTunnel2(ulong score)
        {
            var highScore = new GameMakerHighScore(score + 1000000, "TUNNEL2");
            highScore.SaveToRegistry("Rank9");
        }

        public static ulong GetMinigames()
        {
            return GameMakerHighScore.FromRegistry("Rank10").score;

        }

        public static void SetMinigames(ulong sun, ulong moon, ulong stars)
        {
            var score = (sun * 10000) + (moon * 100) + stars;
            var highScore = new GameMakerHighScore(score, "MINIGAMES");
            highScore.SaveToRegistry("Rank10");
        }

        public static uint GetSunChallenge(ulong minigamesScore)
        {
            return (uint)(minigamesScore / 10000);
        }

        public static uint GetMoonChallenge(ulong minigamesScore)
        {
            var mini1 = SpelunkySaveManager.GetSunChallenge(minigamesScore);
            return (uint)((minigamesScore - (mini1 * 10000)) / 100);
        }

        public static uint GetStarsChallenge(ulong minigamesScore)
        {
            var mini1 = SpelunkySaveManager.GetSunChallenge(minigamesScore);
            var mini2 = SpelunkySaveManager.GetMoonChallenge(minigamesScore);
            return (uint)(minigamesScore - mini1 * 10000 - mini2 * 100);
        }

    }
}

using System;
using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int points1;
        private int points2;
        
        private string name1;
        private string name2;

        public TennisGame2(string player1Name, string player2Name)
        {
            name1 = player1Name;
            name2 = player2Name;
        }

        public string GetScore()
        {
            var pointsDiff = Math.Abs(points1 - points2) >= 2;
            var isGameOver = (points1 >= 4 || points2 >= 4) && pointsDiff;
            if (isGameOver) {
                return ScoreGameOver();
            }
            
            if (points1 == points2) {
                return ScoreEqual(points1);
            }

            if (points1 >= 3 && points2 >= 3) {
                return ScoreAdvantage();
            }
            return ScoreMidgame();
        }

        private string ScoreGameOver()
        {
            return points1 > points2 ? "Win for player1" : "Win for player2";
        }

        private string ScoreMidgame()
        {
            return $"{GetPointName(points1)}-{GetPointName(points2)}";
        }

        private string ScoreAdvantage()
        {
            return points1 > points2 ? "Advantage player1" : "Advantage player2";
        }

        private string ScoreEqual(int points)
        {
            if (points < 3) {
                return $"{GetPointName(points)}-All";
            }
            return "Deuce";
        }

        private readonly Dictionary<int, string> scoreNames = new Dictionary<int, string>() {
            { 0, "Love" },
            { 1, "Fifteen" },
            { 2, "Thirty" },
            { 3, "Forty" },
        };
            
        private string GetPointName(int points)
        {
            return scoreNames[points];
        }

        public void WonPoint(string player)
        {
            if (player == "player1") {
                points1++;
            }
            else {
                points2++;
            }
        }
    }
}


using System;
using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private readonly Dictionary<int, string> scoreNames = new Dictionary<int, string> {
            { 0, "Love" },
            { 1, "Fifteen" },
            { 2, "Thirty" },
            { 3, "Forty" },
        };
        private readonly string deuceName = "Deuce";
        private int mScore1 = 0;
        private int mScore2 = 0;

        public TennisGame1(string player1Name, string player2Name)
        {
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1") {
                mScore1++;
            }
            else {
                mScore2++;
            }
        }

        public string GetScore()
        {
            var isEqualScore = mScore1 == mScore2;
            if (isEqualScore) {
                return AnnounceEqualPoints(mScore1);
            }

            var isBeforeLateGame = mScore1 < 4 && mScore2 < 4;
            if (isBeforeLateGame) {
                return $"{GetScoreName(mScore1)}-{GetScoreName(mScore2)}";
            }
            
            var isGameEnded = Math.Abs(mScore1 - mScore2) >= 2;
            if (isGameEnded) {
                return DeclareWinner(mScore1, mScore2);
            }
            return AnnounceAdvantage(mScore1, mScore2);
        }

        private string DeclareWinner(int points1, int points2)
        {
            return points1 > points2 ? "Win for player1" : "Win for player2";
        }

        private string GetScoreName(int points)
        {
            return scoreNames[points];
        }

        private string AnnounceAdvantage(int points1, int points2)
        {
            return points1 > points2 ? "Advantage player1" : "Advantage player2";
        }
        
        private string AnnounceEqualPoints(int points)
        {
            if (points < 3) {
                return $"{scoreNames[points]}-All";
            }
            return deuceName;
        }
    }
}


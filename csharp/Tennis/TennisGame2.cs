using System;
using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point => players[player1Name].Points;
        private int p2point => players[player2Name].Points;
        
        private string player1Name;
        private string player2Name;

        private Dictionary<string, Player> players = new();

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
            players[player1Name] = new Player(player1Name);
            players[player2Name] = new Player(player2Name);
        }

        public string GetScore()
        {
            if (p1point >= 4 && p2point >= 0){
                if (p1point - p2point >= 2) {
                    return "Win for player1";    
                }
            }
            
            if (p2point >= 4 && p1point >= 0 && (p2point - p1point) >= 2) {
                return "Win for player2";
            }
            
            if (p1point > p2point && p2point >= 3) {
                return "Advantage player1";
            }

            if (p2point > p1point && p1point >= 3) {
                return "Advantage player2";
            }
            
            if (p1point == p2point) {
                if (p1point >= 3) {
                    return "Deuce";
                }
                return GetPointsName(p1point) + "-All";
            }
            
            return GetPointsName(p1point) + "-" + GetPointsName(p2point);
        }

        private string GetPointsName(int points)
        {
            if (points == 0)
                return "Love";
            if (points == 1)
                return "Fifteen";
            if (points == 2)
                return "Thirty";
            if (points == 3)
                return "Forty";
            
            return String.Empty;
        }

        public void WonPoint(string player)
        {
            players[player].Score();
        }

    }

    public class Player
    {
        public string Name { get; }
        public int Points { get; private set; }

        public Player(string name)
        {
            Name = name;
            Points = 0;
        }

        public void Score()
        {
            Points++;
        }
    }
    
}


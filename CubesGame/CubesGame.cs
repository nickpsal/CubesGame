using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubesGame
{
    internal class CubesGame
    {
        public int K { get; set; }
        public int M { get; set; }
        public bool isGameFinished { get; set; }
        public CubesGame(int K, int M, Player Player1, Player Computer)
        {
            this.K = K;
            this.M = M;
            StartGame(Player1,Computer);
        }

        private void StartGame(Player Player1, Player Computer)
        {
            int player_number;
            Player CurrentPlayer = Computer;
            while (true)
            {
                Console.WriteLine("================================================================");
                Console.WriteLine($"Πάνω στο τραπέζι υπάρχουν {this.M} κύβοι");
                Console.WriteLine($"Παίζει ο {CurrentPlayer.PlayerName}");
                if (CurrentPlayer.PlayerName == "Computer")
                {
                    player_number = MakeAIMove();
                }
                else
                {
                    player_number = checkPlayerInput();
                }
                this.M -= player_number;
                Console.WriteLine($"Ο {CurrentPlayer.PlayerName} Πήρε {player_number} κύβους απο το Τραπέζι");
                Console.WriteLine("================================================================");
                if (CheckifTableisEmpty(CurrentPlayer))
                {
                    CurrentPlayer.PlayerScore++;
                    break;
                }
                CurrentPlayer = PlayerTurn(CurrentPlayer, Player1, Computer);
            }
        }

        private static Player PlayerTurn(Player CurrentPlayer, Player Player1, Player Computer)
        {
            return CurrentPlayer == Player1 ? Computer : Player1;
        }

        private int MakeAIMove()
        {
            MiniMax minimax = new MiniMax();
            return minimax.FindBestMove(M, 5, K, true);
        }

        private int checkPlayerInput()
        {
            int choose_number;
            while (true)
            {
                if (this.K <= this.M)
                {
                    Console.WriteLine($"Μπορείς να σηκώσεις 1,2,{this.K}, e για έξοδο");
                }
                else
                {
                    Console.WriteLine($"Μπορείς να σηκώσεις 1,2, e για έξοδο");
                }
                string? choose = Console.ReadLine();
                if (choose == "e" || choose == "E")
                {
                    GameInfo();
                    Console.Read();
                    Environment.Exit(0);
                }
                if (string.IsNullOrWhiteSpace(choose) || !int.TryParse(choose, out choose_number))
                {
                    Console.WriteLine("Δεν πληκτρολόγησες Κάτι ή δεν έδωσες Νούμερο");
                }
                else
                {
                    if (this.K <= this.M && (choose_number == 1 || choose_number == 2 || choose_number == this.K))
                    {
                        break;
                    }else if (this.K > this.M && (choose_number == 1 || choose_number == 2))
                    {
                        break;
                    }else
                    {
                        Console.WriteLine("Εδωσες Νούμερο εκτός ορίων");
                    }
                }
            }
            return choose_number;
        }

        private bool CheckifTableisEmpty(Player CurentPlayer)
        {
            if (this.M ==  0)
            {
                Console.WriteLine($"Το Παιχνίδι τελείωσε Νίκησε ο {CurentPlayer.PlayerName}");
                return true;
            }
            return false;
        }

        public static void GameInfo()
        {
            Console.WriteLine("Το παίχνιδι αυτό φτιάχτηκε για εκπαιδευτικούς σκοπούς");
            Console.WriteLine("Όνομα Προγραμματιστή : Ψαλτάκης Νικόλαος");
            Console.WriteLine("(C) 06/2023 V 2.0 using .NET");
        }
    }
}

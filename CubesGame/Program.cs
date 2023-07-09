using System.Runtime.Intrinsics.X86;

namespace CubesGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cubes_num;
            int max_num;
            Player Player1 = new Player("Player1");
            Player Computer = new Player("Computer");
            while (true)
            {
                Console.WriteLine("================================================================");
                Console.WriteLine("||          Πάνω στο τράπέζι υπάρχουν αρχικά Μ Κύβοι          ||");
                Console.WriteLine("||       Ο κάθε παίχτης μπορεί να σηκώσει 1,2,Κ κυβους        ||");
                Console.WriteLine("||   Νικητης οποιος σηκώσει τον τελυταιο κύβο απο το τραπέζι  ||");
                Console.WriteLine("================================================================");
                Console.WriteLine("||                  Player 1 - Computer :  {0} - {1}              ||", Player1.PlayerScore, Computer.PlayerScore);
                while(true)
                {
                    Console.WriteLine("Δώσε τον αριθμό τον Μέγιστο Αριθμό Κύβων που μπορεί να σηκώσει σε κάθε γύρο ο Κάθε χρήστης");
                    
                    string? cubes = Console.ReadLine();
                    if (int.TryParse(cubes, out cubes_num) && cubes_num >2) 
                    {
                        break;
                    }else
                    {
                        Console.WriteLine("Δώδατε Λανθασμένη Επιλογή");
                    }
                }
                while (true)
                {
                    Console.WriteLine("Δώσε τον αριθμό τον Μέγιστο Αριθμό των κύβων που είναι στο Τραπέζι");
                    string? max = Console.ReadLine();
                    if (int.TryParse(max, out max_num) && max_num > 2 && max_num > cubes_num)
                    {
                        break;
                    }else
                    {
                        Console.WriteLine("Δώδατε Λανθασμένη Επιλογή");
                    }
                }
                CubesGame game = new CubesGame(cubes_num,max_num, Player1, Computer);
            }
        }
    }
}
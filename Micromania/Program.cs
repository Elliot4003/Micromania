using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania
{
    internal class Program
    {
        // On peut imaginer ici un appel de la bdd
        public static List<Article> articlesList = new List<Article> { 
            new Article("Ratchet & Clank: Rift Apart", 59.99), 
            new Article("The Last of Us Part I", 59.99), 
            new Article("God of War: Ragnarök", 59.99), 
            new Article("Uncharted 4", 59.99), 
            new Article("Spider-Man 2", 69.99), 
            new Article("Kingdom Hearts II", 49.99), 
            new Article("Resident Evil 4", 29.99),
            new Article("Far Cry 3", 24.99),
            new Article("Minecraft", 29.99),
            new Article("The Legend of Zelda: Breath of the Wild", 39.99),
            new Article("Elden Ring", 59.99),
            new Article("Luigi's Mansion 3", 39.99),
            new Article("Animal Crossing: New Horizons", 39.99),
            new Article("Grand Theft Auto V", 49.99),
            new Article("Star Wars Battlefront II", 29.99)
        };

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("        *******************************************************************************************************");
                Console.WriteLine("        *   ___      ___    _    ______    _____    _____    ___      ___    _____    ___   _    _    _____   *");
                Console.WriteLine("        *  |   \\    /   |  | |  | _____|  |  _  |  |  _  |  |   \\    /   |  |  _  |  |   \\ | |  | |  |  _  |  *");
                Console.WriteLine("        *  | |\\ \\  / /| |  | |  | |       | |_| |  | | | |  | |\\ \\  / /| |  | |_| |  | |\\ \\| |  | |  | |_| |  *");
                Console.WriteLine("        *  | | \\ \\/ / | |  | |  | |       |    _|  | | | |  | | \\ \\/ / | |  |  _  |  | | \\ \\ |  | |  |  _  |  *");
                Console.WriteLine("        *  | |  \\__/  | |  | |  | |____   | |\\ \\   | |_| |  | |  \\__/  | |  | | | |  | |  \\  |  | |  | | | |  *");
                Console.WriteLine("        *  |_|        |_|  |_|  |______|  |_| \\_\\  |_____|  |_|        |_|  |_| |_|  |_|   \\_|  |_|  |_| |_|  *");
                Console.WriteLine("        *                                                                                                     *");
                Console.WriteLine("        *******************************************************************************************************");
                Console.WriteLine("");

                // Ajout
                Console.WriteLine("\n  1 - Ajout");

                // Suppression
                Console.WriteLine("\n  2 - Suppression");

                // Update
                Console.WriteLine("\n  3 - Modification");

                // Listing
                Console.WriteLine("\n  4 - Liste des articles");

                // Recherche par ref
                Console.WriteLine("\n  5 - Recherche par référence");

                // Recherche par nom
                Console.WriteLine("\n  6 - Recherche par nom");

                // Recherche par prix
                Console.WriteLine("\n  7 - Recherche par prix");

                // Quitter l'application
                Console.WriteLine("\n  8 - Quitter");

                Console.Write("\n");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        AddArticle();
                        break;
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        RemoveByRef();
                        break;
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        UpdateByRef();
                        break;
                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        PrintArticles();
                        break;
                    case ConsoleKey.NumPad5:
                        Console.Clear();
                        SearchByRef();
                        break;
                    case ConsoleKey.NumPad6:
                        Console.Clear();
                        SearchByName();
                        break;
                    case ConsoleKey.NumPad7:
                        Console.Clear();
                        SearchByPrice();
                        break;
                    case ConsoleKey.NumPad8:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        break;

                }
            } while (true);

        }

        static void PrintArticles()
        {
            Article.PrintArticles(articlesList);
        }

        static void AddArticle()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n  -------------------");
            Console.WriteLine("  | AJOUT D'ARTICLE |");
            Console.WriteLine("  -------------------\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Entrez le nom de l'article : ");
            Console.ResetColor();

            string name = Console.ReadLine();

            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Entrez le prix de l'article : ");
            Console.ResetColor();

            string price = Console.ReadLine();


            Console.WriteLine("\n");

            Article.AddArticle(articlesList, name, price);
        }

        static void UpdateByRef()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n  --------------------------");
            Console.WriteLine("  | MODIFICATION D'ARTICLE |");
            Console.WriteLine("  --------------------------\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Entrez un numéro de référence : ");
            Console.ResetColor();

            string numRef = Console.ReadLine();

            Console.WriteLine("\n");

            Article.UpdateByRef(articlesList, numRef);

        }

        static void RemoveByRef()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n  -------------------------");
            Console.WriteLine("  | SUPPRESSION D'ARTICLE |");
            Console.WriteLine("  -------------------------\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Entrez un numéro de référence : ");
            Console.ResetColor();

            string numRef = Console.ReadLine();

            Console.WriteLine("\n");

            Article.RemoveByRef(articlesList, numRef);

        }

        static void SearchByRef()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n  ---------------------------");
            Console.WriteLine("  | RECHERCHE PAR REFERENCE |");
            Console.WriteLine("  ---------------------------\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Entrez un numéro de référence : ");
            Console.ResetColor();
            
            string numRef = Console.ReadLine();

            Console.WriteLine("\n");

            Article.SearchByRef(articlesList, numRef);

        }

        static void SearchByName()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n  ---------------------");
            Console.WriteLine("  | RECHERCHE PAR NOM |");
            Console.WriteLine("  ---------------------\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Entrez un nom d'article : ");
            Console.ResetColor();

            string name = Console.ReadLine();

            Console.WriteLine("\n");

            Article.SearchByName(articlesList, name);

        }

        static void SearchByPrice()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n  ----------------------");
            Console.WriteLine("  | RECHERCHE PAR PRIX |");
            Console.WriteLine("  ----------------------\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Entrez un prix minimum : ");
            Console.ResetColor();

            string priceMin = Console.ReadLine();

            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Entrez un prix maximum : ");
            Console.ResetColor();

            string priceMax = Console.ReadLine();


            Console.WriteLine("\n");

            Article.SearchByPrice(articlesList, priceMin, priceMax);
        }
    }
}

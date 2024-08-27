using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania
{
    internal class Article
    {
        private static int numCounter;
        private int numRef;
        public string name;
        public double price;
        private static int quantity;

        public Article(string name, double price)
        {
            Name = name;
            Price = price;
            NumCounter++;
            NumRef = NumCounter;
            Quantity++;
        }

        public static int NumCounter
        {
            get { return numCounter; }
            private set { numCounter = value; }
        }

        public int NumRef
        {
            get { return numRef; }
            private set { numRef = value; }
        }

        public string Name
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }

        public static int Quantity
        {
            get { return quantity; }
            private set { quantity = value; }
        }

        public static void PrintArticles(List<Article> articlesList)
        {
            Console.WriteLine("\n" + Article.Quantity.ToString() + " articles en stock.\n");
            Console.Write("\nAppuyez sur la barre espace pour quitter...");
            foreach (Article article in articlesList)
            {
                string articleFormat = "Ref : " + article.NumRef + "\n" +
                                       "Nom : " + article.Name + "\n" +
                                       "Prix : " + article.Price + "\n";

                Console.WriteLine("\n");
                Console.WriteLine(articleFormat);
            }

            // Attendre la confirmation de l'utilisateur
            Console.Write("\nAppuyez sur la barre espace pour quitter...");
            // Commencer en haut de la liste
            Console.SetCursorPosition(0, 0);
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) { }
            Console.Clear();
        }

        public static void SearchByRef(List<Article> articlesList, string numRefStr)
        {
            if (Int32.TryParse(numRefStr, out int numRef))
            {
                bool result = false;
                foreach (Article article in articlesList)
                {
                    if (article.NumRef == numRef)
                    {
                        string articleFormat = "Article trouvé en stock : \n\n" +
                                               "Ref : " + article.NumRef + "\n" +
                                               "Nom : " + article.Name + "\n" +
                                               "Prix : " + article.Price + "\n";

                        Console.WriteLine(articleFormat);
                        result = true;
                        break;
                    }
                }
                if (result == false) Console.WriteLine("Aucun résultat. \n");
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Le numéro de référence est composé uniquement de chiffres. \n");
                Console.ResetColor();
            }
            
            // Attendre la confirmation de l'utilisateur
            Console.Write("\nAppuyez sur la barre espace pour quitter...");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) { }
            Console.Clear();
        }

        public static void SearchByName(List<Article> articlesList, string name)
        {
            if (name == "") Console.WriteLine("Aucun résultat. \n");
            else
            {
                name = name.ToLower();

                var queryName = from a in articlesList
                                where a.Name.ToLower().Contains(name)
                                select a;

                if (queryName.Count() > 0)
                {
                    string foundString;
                    if (queryName.Count() == 1) foundString = $"1 article trouvé en stock : \n";
                    else foundString = $"{queryName.Count()} articles trouvés en stock : \n";
                    Console.WriteLine(foundString);

                    foreach (Article a in queryName)
                    {
                        string articleFormat = "Ref : " + a.NumRef + "\n" +
                                               "Nom : " + a.Name + "\n" +
                                               "Prix : " + a.Price + "\n";

                        Console.WriteLine(articleFormat);
                    }

                }

                else Console.WriteLine("Aucun résultat. \n");
            }
            
            // Attendre la confirmation de l'utilisateur
            Console.Write("\nAppuyez sur la barre espace pour quitter...");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) { }
            Console.Clear();
        }

        public static void SearchByPrice(List<Article> articlesList, string priceMin, string priceMax)
        {
            if (Int32.TryParse(priceMin, out int lowerPrice) && Int32.TryParse(priceMax, out int upperPrice))
            {
                var queryPrice = from a in articlesList
                                 where a.Price > lowerPrice && a.Price < upperPrice
                                 select a;

                if (queryPrice.Count() > 0)
                {
                    string foundString;
                    if (queryPrice.Count() == 1) foundString = $"1 article trouvé en stock : \n";
                    else foundString = $"{queryPrice.Count()} articles trouvés en stock : \n";
                    Console.WriteLine(foundString);
                    Console.WriteLine("\nAppuyez sur la barre espace pour quitter...\n");

                    foreach (Article a in queryPrice)
                    {
                        string articleFormat = "Ref : " + a.NumRef + "\n" +
                                               "Nom : " + a.Name + "\n" +
                                               "Prix : " + a.Price + "\n";

                        Console.WriteLine(articleFormat);
                    }

                }
                else Console.WriteLine("Aucun résultat. \n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Le prix ne peut être composé que de chiffres \n");
                Console.ResetColor();
            }

            // Attendre la confirmation de l'utilisateur
            Console.Write("\nAppuyez sur la barre espace pour quitter...");
            // Commencer en haut de la liste
            Console.SetCursorPosition(0, 0);
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) { }
            Console.Clear();
        }

        public static void RemoveByRef(List<Article> articlesList, string numRefStr)
        {
            if (Int32.TryParse(numRefStr, out int numRef))
            {
                for (int i = 0; i < articlesList.Count; i++)
                {
                    if (articlesList[i].NumRef == numRef)
                    {
                        // Afficher les informations
                        string articleFormat = "Ref : " + articlesList[i].NumRef + "\n" +
                                               "Nom : " + articlesList[i].Name + "\n" +
                                               "Prix : " + articlesList[i].Price + "\n";
                        Console.WriteLine("Article à supprimer : \n");
                        Console.WriteLine(articleFormat + "\n");

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Voulez-vous supprimer l'article? (O/N) ");
                        Console.ResetColor();

                        string deleteArticle = Console.ReadLine();

                        if (deleteArticle == "O" || deleteArticle == "o")
                        {
                            Console.WriteLine("\nL'article '" + articlesList[i].Name + "' a été supprimé. \n");
                            articlesList.RemoveAt(i);
                            Article.Quantity--;
                            break;
                        }
                        else break;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Le numéro de référence est composé uniquement de chiffres. \n");
                Console.ResetColor();
            }

            // Attendre la confirmation de l'utilisateur
            Console.Write("\nAppuyez sur la barre espace pour quitter...");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) { }
            Console.Clear();
        }

        public static void UpdateByRef(List<Article> articlesList, string numRefStr)
        {
            if (Int32.TryParse(numRefStr, out int numRef))
            {
                foreach (Article article in articlesList)
                {
                    if (article.NumRef == numRef)
                    {
                        // Afficher les informations
                        string articleFormat = "Ref : " + article.NumRef + "\n" +
                                               "Nom : " + article.Name + "\n" +
                                               "Prix : " + article.Price + "\n";
                        Console.WriteLine("Article à modifier : \n");
                        Console.WriteLine(articleFormat + "\n");

                        string name = article.Name;
                        bool isUpdatedName = false;

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Modifier le nom ? (O/N) ");
                        Console.ResetColor();
                        string nameUpdate = Console.ReadLine();

                        while (isUpdatedName == false)
                        {
                            if (nameUpdate == "O" || nameUpdate == "o")
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("\nNouveau nom : ");
                                Console.ResetColor();
                                name = Console.ReadLine();
                            }
                            else break;
                            if (name == "")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nL'article doit avoir un nom.");
                                Console.ResetColor();
                            }
                            else isUpdatedName = true;
                        }
                        article.Name = name;

                        string price = article.Price.ToString();
                        bool isUpdatedPrice = false;
                        bool isDigitsOnly = true;

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\nModifier le prix ? (O/N) ");
                        Console.ResetColor();
                        string priceUpdate = Console.ReadLine();

                        while (isUpdatedPrice == false)
                        {
                            if (priceUpdate == "O" || priceUpdate == "o")
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("\nNouveau prix : ");
                                Console.ResetColor();
                                price = Console.ReadLine();
                            }
                            else break;

                            foreach (char c in price)
                            {
                                if (c < '0' || c > '9')
                                {
                                    if (!(c == '.' || c == ','))
                                    {
                                        isDigitsOnly = false;
                                        break;
                                    }
                                }
                                else isDigitsOnly = true;
                            }

                            if (price == "")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nL'article doit avoir un prix.");
                                Console.ResetColor();
                            }
                            else if (isDigitsOnly == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nLe prix ne peut être composé que de chiffres.");
                                Console.ResetColor();
                            }
                            else if (price.Contains('-'))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nLe prix ne peut pas être négatif.");
                                Console.ResetColor();
                            }
                            else isUpdatedPrice = true;
                        }
                        price = price.Replace('.', ',');
                        double priceFinal = Convert.ToDouble(price);
                        article.Price = priceFinal;

                        // Afficher les modifications
                        string articleFormatFinal = "Ref : " + article.NumRef + "\n" +
                                               "Nom : " + article.Name + "\n" +
                                               "Prix : " + article.Price + "\n";

                        Console.WriteLine("\n" + articleFormatFinal + "\n");

                        break;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Le numéro de référence est composé uniquement de chiffres. \n");
                Console.ResetColor();
            }

            // Attendre la confirmation de l'utilisateur
            Console.Write("\nAppuyez sur la barre espace pour quitter...");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) { }
            Console.Clear();
        }

        public static void AddArticle(List<Article> articlesList, string name, string priceStr)
        {
            bool isDigitsOnly = true;
            foreach (char c in priceStr)
            {
                if (c < '0' || c > '9')
                {
                    if (!(c == '.' || c == ','))
                    {
                        isDigitsOnly = false;
                        break;
                    }
                }
                else isDigitsOnly = true;
            }
            if (name == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nL'article doit avoir un nom.");
                Console.ResetColor();
            }
            else if (priceStr == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nL'article doit avoir un prix.");
                Console.ResetColor();
            }
            else if (isDigitsOnly == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nLe prix ne peut être composé que de chiffres.");
                Console.ResetColor();
            }
            else if (priceStr.Contains('-'))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nLe prix ne peut pas être négatif.");
                Console.ResetColor();
            }
            else 
            {
                priceStr = priceStr.Replace('.', ',');
                if (Double.TryParse(priceStr, out double price))
                {

                    articlesList.Add(new Article(name, price));

                    for (int i = 0; i < Article.Quantity; i++)
                    {
                        if (i > Article.Quantity - 2)
                        {
                            string articleFormatFinal = "Ref : " + articlesList[i].NumRef + "\n" +
                                                   "Nom : " + articlesList[i].Name + "\n" +
                                                   "Prix : " + articlesList[i].Price + "\n";

                            Console.WriteLine("\n" + articleFormatFinal + "\n");
                            break;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Le prix ne peut être composé que de chiffres. \n");
                    Console.ResetColor();
                }
            }

            // Attendre la confirmation de l'utilisateur
            Console.Write("\nAppuyez sur la barre espace pour quitter...");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) { }
            Console.Clear();
        }
    }
}

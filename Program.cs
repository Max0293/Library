using Library.Interfaces;
using Library.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository repository = null;
            Console.WriteLine("Write \"End\" if you want to finish programm. \nPress Enter if you want to continue");
            string inputEnd = Console.ReadLine();
            Console.WriteLine("Hello, choice your repository variant");
            Console.WriteLine("1 - Filerepository, 2 - Memoryrepository");
            string input = Console.ReadLine();

            do
                switch (input)
                {
                    case "1":
                        {
                            repository = new FileRepository();
                            break;
                        }
                    case "2":
                        {
                            repository = new MemoryRepository();
                            break;
                        }
                    case "End":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Fool, choice your destiny");
                            input = Console.ReadLine();
                            break;
                        }

                }
            while (input != "1" && input != "2");

            while (inputEnd != "End")
            {
                Console.WriteLine("\nWhat do you want");
                Console.WriteLine("1 - View all books");
                Console.WriteLine("2 - Create new book");
                Console.WriteLine("3 - Update book");
                Console.WriteLine("4 - Delete book");
                input = Console.ReadLine();

                do
                {
                    switch (input)
                    {
                        case "1":
                            {
                                List<Book> libraryList = repository.Read();
                                if (libraryList != null && libraryList.Count != 0)
                                {
                                    foreach (Book list in libraryList)
                                    {
                                        Console.WriteLine($"\n{list.BooksId}, {list.BooksName}, {list.BooksWriter}, {list.Pages}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nFirst entry any book");
                                }
                                break;
                            }
                        case "2":
                            {
                                Book book = new Book();
                                Console.WriteLine("Enter ID wish you didt see in Library");
                                book.BooksId = ValidInt();
                                Console.WriteLine("Now enter books name");
                                book.BooksName = Console.ReadLine();
                                Console.WriteLine("Now enter books writer");
                                book.BooksWriter = Console.ReadLine();
                                Console.WriteLine("And enter pages of book");
                                book.Pages = ValidInt();
                                repository.Create(book);
                                break;
                            }
                        case "3":
                            {
                                Book book = new Book();
                                Console.WriteLine("Enter ID did you see in Library");
                                book.BooksId = ValidInt();
                                Console.WriteLine("Now update books name");
                                book.BooksName = Console.ReadLine();
                                Console.WriteLine("Now update books writer");
                                book.BooksWriter = Console.ReadLine();
                                Console.WriteLine("And update pages of book");
                                book.Pages = ValidInt();
                                repository.Update(book);
                                break;
                            }
                        case "4":
                            {
                                Console.WriteLine("Enter ID of book did you see in Library for delete this book");
                                int id = ValidInt();
                                repository.Delete(id);
                                break;
                            }
                        case "End":
                            {
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("You are Fools King");
                                input = Console.ReadLine();
                                break;
                            }
                    }

                } while (input != "1" && input != "2" && input != "3" && input != "4");
            }
        }

        public static int ValidInt()
        {
            int id;
            bool result = false;
            do
            {
                result = Int32.TryParse(Console.ReadLine(), out id);
                if (!result)
                {
                    Console.WriteLine("I sayd enter valid value!!!");
                }
            } while (!result);
            return id;
        }
    }
}

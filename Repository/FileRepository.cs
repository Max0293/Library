using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    class FileRepository : IRepository
    {
        string path = @"..\..\Concrete\BooksData.txt";

        public bool Create(Book book)
        {

            string text = "";
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                bool findIdCurrentBook = false;
                while (!sr.EndOfStream)
                {
                    text = sr.ReadLine();
                    string[] arrayString = text.Split(',');
                    if (!findIdCurrentBook)
                    {
                        findIdCurrentBook = arrayString[0] == book.BooksId.ToString();
                    }
                    else
                    {
                        break;
                    }
                }
                sr.Close();
                if (!findIdCurrentBook)
                {
                    using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
                    {
                        sw.WriteLine($"{book.BooksId}, {book.BooksName}, {book.BooksWriter}, {book.Pages}");
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Delete(int bookId)
        {
            List<string[]> listMass = new List<string[]>();
            string text;

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    text = sr.ReadLine();
                    string[] massLine = text.Split(',');
                    listMass.Add(massLine);
                }

                string[] resault = null;

                foreach (string[] line in listMass)
                {
                    if (bookId == Int32.Parse(line[0]))
                    {
                        resault = line;
                        break;
                    }
                }
                if (resault != null)
                {
                    listMass.Remove(resault);
                }
            }

            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                foreach (string[] line in listMass)
                {
                    sw.WriteLine($"{line[0]}, {line[1]}, {line[2]}, {line[3]}");
                }
            }
            return true;
        }

        public List<Book> Read()
        {
            List<Book> books = new List<Book>();
            string text;

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    Book book = new Book();
                    text = sr.ReadLine();
                    string[] massLine = text.Split(',');
                    book.BooksId = Int32.Parse(massLine[0]);
                    book.BooksName = massLine[1];
                    book.BooksWriter = massLine[2];
                    book.Pages = Int32.Parse(massLine[3]);
                    books.Add(book);
                }
                return books;
            }
        }

        public bool Update(Book book)
        {
            List<string[]> listMass = new List<string[]>();
            string text;

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    text = sr.ReadLine();
                    string[] massLine = text.Split(',');
                    listMass.Add(massLine);
                }
            }

            foreach (string[] line in listMass)

                if (book.BooksId == Int32.Parse(line[0]))
                {
                    if (book.BooksName != line[1])
                    {
                        line[1] = book.BooksName;
                    }
                    if (book.BooksWriter != line[2])
                    {
                        line[2] = book.BooksWriter;
                    }
                    if (book.Pages != Int32.Parse(line[3]))
                    {
                        line[3] = book.Pages.ToString();
                    }
                }

            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                foreach (string[] line in listMass)
                    sw.WriteLine($"{line[0]}, {line[1]}, {line[2]}, {line[3]}");
                return true;
            }

        }

    }
}


using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    class MemoryRepository : IRepository
    {
        List<Book> books = new List<Book>();

        public bool Create(Book book)
        {
            var b = FindBook(book);
            if (book != null && b == null)
            {
                books.Add(book);
                return true;
            }
            else
            {
                Console.WriteLine("\nError on create");
                return false;
            }
        }

        public bool Delete(int bookId)
        {
            var b = FindBook(bookId);
            if (b != null)
            {
                return books.Remove(b);
            }
            else
            {
                Console.WriteLine("\nError on delete");
                return false;
            }
        }

        public List<Book> Read()
        {
            return books;
        }

        public bool Update(Book book)
        {
            var b = FindBook(book);
            if (b != null)
            {
                b.BooksWriter = book.BooksWriter;
                b.BooksName = book.BooksName;
                b.Pages = book.Pages;
                return true;
            }
            else
            {
                Console.WriteLine("\nError on update");
                return false;
            }
        }

        public Book FindBook(Book book)
        {
            return books.FirstOrDefault<Book>(x => x.BooksId == book.BooksId);
        }

        public Book FindBook(int bookId)
        {
            return books.FirstOrDefault<Book>(x => x.BooksId == bookId);
        }
    }
}

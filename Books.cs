namespace Library
{
    public class Book
    {
        public string BooksName { get; set; }
        public string BooksWriter { get; set; }
        public int Pages { get; set; }
        public int BooksId { get; set; }

        public Book() { }
        public Book(int id, string name, string author, int page)
        {
            BooksId = id;
            BooksName = name;
            BooksWriter = author;
            Pages = page;
        }
    }
}

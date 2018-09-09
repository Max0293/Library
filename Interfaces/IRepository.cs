using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
   public interface IRepository
    {
        bool Create(Book book);
        bool Delete(int bookId);
        bool Update(Book book);
        List<Book> Read();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryNamespace
{
    public interface IBookService
    {
        void AddBook(Book book);
        void DeleteBook(Book book);
        void PrintBooks();
        Book SearchBook(Guid id);
    }
}

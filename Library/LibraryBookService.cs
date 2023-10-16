using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryNamespace
{
    public class LibraryBookService : IBookService
    {
        private List<LibraryBook> books;

        public LibraryBookService() 
        { 
            books = new List<LibraryBook>();
        }

        public List<LibraryBook> GetBooks() => books;

        public Book FindBook(String bookName)
        {
            foreach (LibraryBook book in books)
            {
                if (book.GetBookName() == bookName)
                {
                    return book;
                }
            }
            return null;
        }

        public Book SearchBook(Guid id)
        {
            foreach (LibraryBook book in books)
            {
                if (book.GetId() == id)
                {
                    return book;
                }
            }
            return null;
        }

        public int FindBookStock(String bookName)
        {
            int number = 0;
            foreach (LibraryBook book in books)
            {
                if (book.GetBookName() == bookName)
                {
                    number++;
                }
            }
            return number;
        }

        public void AddBook(Book book)
        {
            books.Add((LibraryBook)book);
        }

        public void DeleteBook(Book book)
        {
            books.Remove((LibraryBook)book);
        }

        public void PrintBooks()
        {
            Console.WriteLine("Books in library:");
            foreach (LibraryBook book in books)
            {
                Console.WriteLine(book.GetBookName() + ", " + book.GetISBN() + ", price: " + book.GetPrice() + ", ID = " + book.GetId());
            }
        }

    }
}

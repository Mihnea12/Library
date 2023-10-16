using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryNamespace
{
    public class RentedBookService : IBookService
    {
        private List<RentedBook> rentedBooks;
        
        public RentedBookService() 
        {
           rentedBooks = new List<RentedBook>();
        }

        public List<RentedBook> GetRentedBooks() => rentedBooks;

        public void IncreaseRentedDay()
        {
            foreach (RentedBook book in rentedBooks)
            {
                book.SetRentedDays(book.GetRentedDays() + 1);
            }
        }

        public void CalculateExtraPay()
        {
            foreach (RentedBook book in rentedBooks)
            {
                if (book.GetRentedDays() > 14)
                {
                    book.SetExtraPrice((float)(book.GetPrice() * 0.01) * (book.GetRentedDays() - 14));
                }
            }
        }

        public Book SearchBook(Guid id)
        {
            foreach (RentedBook book in rentedBooks)
            {
                if (book.GetId() == id)
                {
                    return book;
                }
            }
            return null;
        }

        public Book FindBook(String bookName, String clientName)
        {
            foreach (RentedBook book in rentedBooks)
            {
                if (book.GetBookName() == bookName && book.GetClientName() == clientName)
                {
                    return book;
                }
            }
            return null;
        }

        public void AddBook(Book book)
        {
           rentedBooks.Add((RentedBook)book);
        }

        public void DeleteBook(Book book)
        {
            rentedBooks.Remove((RentedBook)book);
        }

        public void PrintBooks()
        {
            Console.WriteLine("Rented Books:");
            foreach (RentedBook book in rentedBooks)
            {
                Console.WriteLine("Client: " + book.GetClientName() + ", "+ book.GetBookName() + ", " + book.GetISBN() + ", price: " + book.GetPrice() + ", rented days: " + book.GetRentedDays() + ", extra price: " + book.GetExtraPrice() + ", ID = " + book.GetId());
            }
        }

    }
}

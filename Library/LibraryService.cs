using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryNamespace
{
    public class LibraryService
    {
        private RentedBookService rentedBookService;
        private LibraryBookService libraryBookService;
        private ClientsService clientsService;

        public LibraryService()
        {
            rentedBookService = new RentedBookService();
            libraryBookService = new LibraryBookService();
            clientsService = new ClientsService();
        }

        public RentedBookService GetRentedBookService() => rentedBookService;
        public LibraryBookService GetLibraryBookService() => libraryBookService;
        public ClientsService GetClientsService() => clientsService;

        public void AddBookInLibrary(LibraryBook book)
        {
            libraryBookService.AddBook(book);
            Console.WriteLine("New book created, id=%s", book.GetId());
        }

        public void RentBook(String bookName, String clientName)
        {
            LibraryBook book = (LibraryBook)libraryBookService.FindBook(bookName);
            if (book != null)
            {
                Client client = clientsService.FindClient(clientName);
                if (client == null)
                {
                    clientsService.AddClient(new Client(clientName));
                }

                libraryBookService.DeleteBook(book);

                RentedBook rentedBook = new RentedBook(book, clientName);
                rentedBookService.AddBook(rentedBook);
            }
            else
            {
                Console.WriteLine("Book with name=%s not found", bookName);
            }
        }

        public void ReturnBook(Guid id)
        {
            RentedBook foundBook = (RentedBook)rentedBookService.SearchBook(id);
            if (foundBook != null)
            {
                rentedBookService.DeleteBook(foundBook);
                LibraryBook libraryBook = new LibraryBook(foundBook);
                libraryBookService.AddBook(libraryBook);
            }
            else
            {
                Console.WriteLine("Rented book with id=%s not found", id);
            }
        }

        public int BookStock(String bookName)
        {
            return libraryBookService.FindBookStock(bookName);
        }

        public List<LibraryBook> GetAllLibraryBooks()
        {
            return libraryBookService.GetBooks();
        }

        public List<RentedBook> GetAllRentedBooks()
        {
            return rentedBookService.GetRentedBooks();
        }

        public void EndDay()
        {
            rentedBookService.IncreaseRentedDay();
            rentedBookService.CalculateExtraPay();
        }

    }
}

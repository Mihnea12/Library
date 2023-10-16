using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryNamespace
{
    public class RentedBook : Book
    {
        private int RentedDays;
        private float ExtraPrice;
        private String ClientName;

        public void SetClientName(String clientName) => ClientName = clientName;

        public String GetClientName() => ClientName;

        public void SetRentedDays(int rentedDays) => RentedDays = rentedDays;

        public int GetRentedDays() => RentedDays;

        public void SetExtraPrice(float extraPrice) => ExtraPrice = extraPrice;

        public float GetExtraPrice() => ExtraPrice;

        public RentedBook(String bookName, String isbn, float price, String clientName) : base(bookName, isbn, price)
        {
            RentedDays = 0;
            ExtraPrice = 0;
            ClientName = clientName;
        }
        public RentedBook(String bookName, String isbn, float price, Guid id , String clientName) : base(bookName, isbn, price, id)
        {
            RentedDays = 0;
            ExtraPrice = 0;
            ClientName = clientName;
        }

        public RentedBook(Book book, String clientName) : base(book.GetBookName(), book.GetISBN(), book.GetPrice(), book.GetId())
        {
            RentedDays = 0;
            ExtraPrice = 0;
            ClientName = clientName;
        }
    }
}

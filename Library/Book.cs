using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryNamespace
{
    public abstract class Book
    {
        private Guid id;
        private String BookName;
        private String ISBN;
        private float Price;

        public Guid GetId() => id;
        public void SetBookName(String bookName) => BookName = bookName;
        public String GetBookName() => BookName;
        public void SetISBN(String isbn) => ISBN = isbn;
        public String GetISBN() => ISBN;
        public void SetPrice(float price) => Price = price;
        public float GetPrice() => Price;

        public Book(String bookName, String isbn, float price)
        {
            BookName = bookName;   
            ISBN = isbn;
            Price = price;
            id = Guid.NewGuid();
        }
        public Book(String bookName, String isbn, float price, Guid id)
        {
            BookName = bookName;
            ISBN = isbn;
            Price = price;
            this.id = id;
        }

    }
}

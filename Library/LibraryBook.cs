using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryNamespace
{
    public class LibraryBook : Book
    {
        private int SectionNumber;
        public void SetSectionNumber(int sectionNumber) => SectionNumber = sectionNumber;
        public int GetSectionNumber() => SectionNumber;

        public LibraryBook(string bookName, string isbn, float price) : base(bookName, isbn, price)
        {
            SectionNumber = 0;
        }
        public LibraryBook(string bookName, string isbn, float price, Guid id) : base(bookName, isbn, price, id)
        {
            SectionNumber = 0;
        }

        public LibraryBook (Book book) : base(book.GetBookName(), book.GetISBN(), book.GetPrice(), book.GetId())
        {
            SectionNumber = 0;
        }
    }
}

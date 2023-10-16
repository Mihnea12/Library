using LibraryNamespace;

namespace LibraryUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        /* Checking the add function */
        [TestMethod]
        public void TestAddBooks()
        {
            Library app = new Library();

            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Carte 1", "122-233-45", 9.5f));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Carte 2", "12211-23113-4115", 19));
            List<LibraryBook> list = app.GetLibraryService().GetAllLibraryBooks();
            app.GetLibraryService().GetLibraryBookService().PrintBooks();

            Assert.AreEqual(5, list.Count);
        }


        /* Checking a simple rent book function */
        [TestMethod]
        public void TestRentBook1()
        {
            Library app = new Library();

            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Carte 1", "122-233-45", 9.5f));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Carte 2", "12211-23113-4115", 19));

            app.GetLibraryService().RentBook("Cei trei purcelusi", "Mihnea Pascu");

            Assert.AreEqual("Cei trei purcelusi", (app.GetLibraryService().GetAllRentedBooks()[0].GetBookName()));
            Assert.AreEqual(2, app.GetLibraryService().BookStock("Cei trei purcelusi"));
            app.GetLibraryService().GetLibraryBookService().PrintBooks();
        }

        /* Return a rented book by id */
        [TestMethod]
        public void TestRentBook2() 
        {
            Library app = new Library();

            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f, new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00")));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f, new Guid("11223343-5566-7788-99AA-BBCCDDEEFF00")));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f, new Guid("11223345-5566-7788-99AA-BBCCDDEEFF00")));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Carte 1", "122-233-45", 9.5f));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Carte 2", "12211-23113-4115", 19));

            app.GetLibraryService().RentBook("Cei trei purcelusi", "Mihnea Pascu");
            app.GetLibraryService().RentBook("Carte 2", "Corina Andreea");
            app.GetLibraryService().RentBook("Cei trei purcelusi", "Tudor Pascu");

            app.GetLibraryService().ReturnBook(new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00"));

            Assert.IsNull(app.GetLibraryService().GetRentedBookService().FindBook("Cei trei purcelusi", "Mihnea Pascu"));
            Assert.IsNotNull(app.GetLibraryService().GetRentedBookService().FindBook("Cei trei purcelusi", "Tudor Pascu"));

            app.GetLibraryService().GetLibraryBookService().PrintBooks();
            app.GetLibraryService().GetRentedBookService().PrintBooks();

        }

        /* Returns a rented book by id from the same person who rented more than one same book */
        [TestMethod]
        public void TestRentBook3()
        {
            Library app = new Library();

            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f, new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00")));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f, new Guid("11111111-5566-7788-99AA-BBCCDDEEFF00")));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f, new Guid("11223345-5566-7788-99AA-BBCCDDEEFF00")));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Carte 1", "122-233-45", 9.5f));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Carte 2", "12211-23113-4115", 19));

            app.GetLibraryService().RentBook("Cei trei purcelusi", "Mihnea Pascu");
            app.GetLibraryService().RentBook("Cei trei purcelusi", "Mihnea Pascu");

            app.GetLibraryService().ReturnBook(new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00"));

            Assert.IsNotNull(app.GetLibraryService().GetRentedBookService().FindBook("Cei trei purcelusi", "Mihnea Pascu"));
            Assert.IsNotNull(app.GetLibraryService().GetRentedBookService().SearchBook(new Guid("11111111-5566-7788-99AA-BBCCDDEEFF00")));

            app.GetLibraryService().GetLibraryBookService().PrintBooks();
            app.GetLibraryService().GetRentedBookService().PrintBooks();
        }

        /* Checking a wrong rented book  */
        [TestMethod]
        public void TestRentBook4()
        {
            Library app = new Library();

            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f, new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00")));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f, new Guid("11111111-5566-7788-99AA-BBCCDDEEFF00")));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f, new Guid("11223345-5566-7788-99AA-BBCCDDEEFF00")));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Carte 1", "122-233-45", 9.5f));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Carte 2", "12211-23113-4115", 19));

            app.GetLibraryService().RentBook("TEST TEST", "Mihnea Pascu");


            Assert.IsNull(app.GetLibraryService().GetRentedBookService().FindBook("TEST TEST", "Mihnea Pascu"));

            app.GetLibraryService().GetLibraryBookService().PrintBooks();
            app.GetLibraryService().GetRentedBookService().PrintBooks();
        }


        /* Price check */
        [TestMethod]
        public void TestPrice1()
        {
            Library app = new Library();

            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f, new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00")));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f, new Guid("11111111-5566-7788-99AA-BBCCDDEEFF00")));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f, new Guid("11223345-5566-7788-99AA-BBCCDDEEFF00")));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Carte 1", "122-233-45", 9.5f));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Carte 2", "12211-23113-4115", 19));


            app.GetLibraryService().RentBook("Cei trei purcelusi", "Mihnea Pascu");
            app.GetLibraryService().RentBook("Carte 2", "Corina Andreea");

            for (int i = 0; i < 20; i++)
            {
                app.GetLibraryService().EndDay();
            }

            Assert.AreEqual(20, ((RentedBook)app.GetLibraryService().GetRentedBookService().SearchBook(new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00"))).GetRentedDays());

            Assert.AreEqual(1.14, Math.Round(((RentedBook)app.GetLibraryService().GetRentedBookService().FindBook("Carte 2", "Corina Andreea")).GetExtraPrice()), 2);
            Assert.AreEqual(0.75, Math.Round(((RentedBook)app.GetLibraryService().GetRentedBookService().SearchBook(new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00"))).GetExtraPrice()), 2);

            app.GetLibraryService().GetLibraryBookService().PrintBooks();
            app.GetLibraryService().GetRentedBookService().PrintBooks();
        }

        /* Checking maximum rent period */
        [TestMethod]
        public void TestPrice2()
        {
            Library app = new Library();

            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f, new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00")));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f, new Guid("11111111-5566-7788-99AA-BBCCDDEEFF00")));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Cei trei purcelusi", "12-23-45", 12.5f, new Guid("11223345-5566-7788-99AA-BBCCDDEEFF00")));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Carte 1", "122-233-45", 9.5f));
            app.GetLibraryService().AddBookInLibrary(new LibraryBook("Carte 2", "12211-23113-4115", 19));


            app.GetLibraryService().RentBook("Cei trei purcelusi", "Mihnea Pascu");

            for (int i = 0; i < 14; i++)
            {
                app.GetLibraryService().EndDay();
            }

            Assert.AreEqual(14, ((RentedBook)app.GetLibraryService().GetRentedBookService().SearchBook(new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00"))).GetRentedDays());
            Assert.AreEqual(0, Math.Round(((RentedBook)app.GetLibraryService().GetRentedBookService().SearchBook(new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00"))).GetExtraPrice()), 2);

            app.GetLibraryService().GetLibraryBookService().PrintBooks();
            app.GetLibraryService().GetRentedBookService().PrintBooks();
        }
    }
}
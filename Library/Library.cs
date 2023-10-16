namespace LibraryNamespace
{
    public class Library
    {
        private LibraryService libraryService;

        public LibraryService GetLibraryService() => libraryService;

        public Library()
        {
            libraryService = new LibraryService();
        }

        static void Main() { }
    }
}
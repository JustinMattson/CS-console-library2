using System;
using System.Collections.Generic;
using console_library2.Enums;

namespace console_library2.Models
{
  public class Library
  {
    public List<Publication> Publications { get; set; }
    public List<Book> Books { get; set; } = new List<Book>();
    public List<Magazine> Magazines { get; set; }
    public BookClassification classification { get; set; } = new BookClassification();
    public PublicationType format { get; set; } = new PublicationType();

    public void Initialize()
    {
      // Create default books
      Book WhereTheSidewalkEnds = new Book(
        "Where the Sidewalk Ends",
        "Shel Silverstein",
        PublicationType.book,
        546,
        "Hardcover",
        BookClassification.Fiction,
        false,
        0);
      Book TheHobbit = new Book(
        "The Hobbit",
        "J.R.R. Tolkien",
        PublicationType.book,
        12000,
        "Softcover",
        BookClassification.Nonfiction,
        false,
        2);
      Book TheHobbit_E = new Book(
        "The Hobbit",
        "J.R.R. Tolkien",
        PublicationType.book,
        12000,
        "N/A",
        BookClassification.Nonfiction,
        true,
        10);
      Book TheLionTheWitchAndTheWardrobe = new Book(
        "The Lion, The Witch, and the Wardrobe",
        "C.S. Lewis",
        PublicationType.epub,
        1300,
        "N/A",
        BookClassification.Fiction,
        true,
        12);
      Book HarryPotterAndTheSorcerersStone = new Book(
        "Harry Potter and the Sorcerer's Stone",
        "J.K. Rowling",
        PublicationType.book,
        400,
        "Leather",
        BookClassification.Nonfiction,
        true,
        15);

      // Add the default books to the library
      Books.Add(WhereTheSidewalkEnds);
      Books.Add(TheHobbit);
      Books.Add(TheHobbit_E);
      Books.Add(TheLionTheWitchAndTheWardrobe);
      Books.Add(HarryPotterAndTheSorcerersStone);

      Magazine People = new Magazine(
        "People",
        "John Smith",
        PublicationType.magazine,
        "Monthly",
        132);

      // Magazine.Add(People);
    }

    public string ViewLibrary()
    {
      Console.Clear();
      System.Console.WriteLine(@"
ID  Title               Downloadable");
      // List<Book> books = Books;
      int bookCount = 0;
      string template = "";
      foreach (var book in Books)
      {
        bookCount++;
        template += $"\n{bookCount}. {book.Title} - {book.Downloadable}";
      }
      return template;
    }

    public Library()
    {
      Initialize();
    }
  }
}
using System;
using System.Collections.Generic;
using console_library2.Enums;

namespace console_library2.Models
{
  public class Library
  {
    public List<Publication> Publications { get; set; }
    public List<Book> Books { get; set; } = new List<Book>();
    public List<Magazine> Magazines { get; set; } = new List<Magazine>();
    public BookClassification classification { get; set; } = new BookClassification();
    public PublicationType format { get; set; } = new PublicationType();

    public void Initialize()
    {
      // Create default books
      Book WhereTheSidewalkEnds = new Book(
        "Where the Sidewalk Ends",
        "Shel Silverstein",
        false,
        PublicationType.book,
        546,
        "Hardcover",
        BookClassification.Fiction,
        false,
        0);
      Book TheHobbit = new Book(
        "The Hobbit",
        "J.R.R. Tolkien",
        true,
        PublicationType.book,
        12000,
        "Softcover",
        BookClassification.Nonfiction,
        false,
        2);
      Book TheHobbit_E = new Book(
        "The Hobbit",
        "J.R.R. Tolkien",
        true,
        PublicationType.book,
        12000,
        "N/A",
        BookClassification.Nonfiction,
        true,
        10);
      Book TheLionTheWitchAndTheWardrobe = new Book(
        "The Lion, The Witch, and the Wardrobe",
        "C.S. Lewis",
        true,
        PublicationType.epub,
        1300,
        "N/A",
        BookClassification.Fiction,
        true,
        12);
      Book HarryPotterAndTheSorcerersStone = new Book(
        "Harry Potter and the Sorcerer's Stone",
        "J.K. Rowling",
        true,
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
        false,
        PublicationType.magazine,
        "Monthly",
        132);
      Magazine Playboy = new Magazine(
        "Playboy",
        "Hugh Hefner",
        true,
        PublicationType.magazine,
        "Monthly",
        13);

      Magazines.Add(People);
      Magazines.Add(Playboy);
    }

    public string ViewLibrary()
    {
      string template = "";
      Console.Clear();
      template += @"
ID  Title                 ~Available
------------------------------------";
      // List<Book> books = Books;
      int bookCount = 1;
      foreach (var book in Books)
      {
        if (!book.Available)
        {
          bookCount--;
        }
        if (book.Available == true)
        {
          template += $"\n{bookCount}. {book.Title} ~{book.Available}";
        }
        else
        {
          template += $"\n   {book.Title} ~{book.Available}";
        }
        bookCount++;
      }
      template += @"
------------------------------------";
      int magCount = 1;
      foreach (var magazine in Magazines)
      {
        if (!magazine.Available)
        {
          magCount--;
        }
        if (magazine.Available == true)
        {
          template += $"\n{magCount}. {magazine.Title} - {magazine.IssueId} ~{magazine.Available}";
        }
        else
        {
          template += $"\n   {magazine.Title} - Issue: {magazine.IssueId} ~{magazine.Available}";
        }
        magCount++;
      }
      return template;
    }
    public void Checkout()
    {
      ViewLibrary();
      System.Console.WriteLine("\n[B]ook or [M]agazine?");
      string pc = Console.ReadLine().ToLower();
      switch (pc)
      {
        case "b":
          System.Console.Write($"\nEnter Book ID to checkout: ");
          int b_num = 0;
          bool isNum = false;
          List<Book> books = Books.FindAll(b => b.Available);
          while (!isNum)
          {
            isNum = Int32.TryParse(Console.ReadLine(), out b_num);
            if (!isNum)
            {
              Console.WriteLine("Please enter Book ID: ");
              continue;
            }
            if (b_num < 1 || b_num > books.Count)
            {
              Console.ForegroundColor = ConsoleColor.Blue;
              Console.WriteLine("Not a valid number.");
              Console.ForegroundColor = ConsoleColor.White;

              isNum = false;
            }
          }

          Book b_choice = books[b_num - 1];
          b_choice.Available = false;
          Console.Clear();
          Console.WriteLine($"You checked out: {b_choice.Title}.");
          break;
        case "m":
          System.Console.Write($"\nEnter Magazine ID to checkout:");
          int m_num = 0;
          isNum = false;
          List<Magazine> magazines = Magazines.FindAll(b => b.Available);
          while (!isNum)
          {
            isNum = Int32.TryParse(Console.ReadLine(), out m_num);
            if (!isNum)
            {
              Console.WriteLine("Please enter Magazine ID: ");
              continue;
            }
            if (m_num < 1 || m_num > magazines.Count)
            {
              Console.ForegroundColor = ConsoleColor.Green;
              Console.WriteLine("Not a valid number.");
              Console.ForegroundColor = ConsoleColor.White;

              isNum = false;
            }
          }

          Magazine m_choice = magazines[m_num - 1];
          m_choice.Available = false;
          Console.Clear();
          Console.WriteLine($"You checked out: {m_choice.Title}.");
          break;
        default:
          Console.ForegroundColor = ConsoleColor.DarkMagenta;
          System.Console.WriteLine("Invalid Choice");
          Console.ForegroundColor = ConsoleColor.White;

          Checkout();
          break;
      }

    }
    public void Return()
    {
      Console.Clear();
      System.Console.WriteLine("\n[B]ook or [M]agazine?");
      string pc = Console.ReadLine().ToLower();
      switch (pc)
      {
        case "b":
          Console.WriteLine("\nPlease enter the book Title you are returning:");
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Title must match punctution and spelling exactly.\n");
          Console.ForegroundColor = ConsoleColor.White;
          Book returnBook = null;
          while (returnBook == null)
          {
            string bookTitle = Console.ReadLine().ToUpper();
            returnBook = Books.Find(b => b.Title.ToUpper() == bookTitle);
            // Book title needs to match inventory or user will be stuck in this loop
          }
          returnBook.Available = true;
          Console.Clear();
          Console.WriteLine($"\nThanks for returning: {returnBook.Title}.");
          break;
        case "m":
          Console.WriteLine("\nPlease enter the magazine Title you are returning:");
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Title must match punctution and spelling exactly.\n");
          Console.ForegroundColor = ConsoleColor.White;
          Magazine returnMagazine = null;
          while (returnMagazine == null)
          {
            string magazineTitle = Console.ReadLine().ToUpper();
            returnMagazine = Magazines.Find(m => m.Title.ToUpper() == magazineTitle);
            // Magazine title needs to match inventory or user will be stuck in this loop
          }
          returnMagazine.Available = true;
          Console.Clear();
          Console.WriteLine($"\nThanks for returning: {returnMagazine.Title}.");
          break;
        default:
          break;
      }
    }
    public Library()
    {
      Initialize();
    }
  }
}
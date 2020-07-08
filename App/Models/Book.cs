using console_library2.Enums;
using console_library2.Interfaces;

namespace console_library2.Models
{
  public class Book : Publication, IElectronic
  {
    public Book(string title, string author, PublicationType format, int numPages, string binding, BookClassification classification, bool downloadable, int maxDownloads) : base(title, author, format)
    {
      NumPages = numPages;
      Binding = binding;
      Classification = classification;
      Downloadable = downloadable;
      MaxDownloads = maxDownloads;
    }

    public int NumPages { get; set; }
    public string Binding { get; set; }
    public BookClassification Classification { get; set; }
    public bool Downloadable { get; set; }
    public int MaxDownloads { get; set; }

  }
}
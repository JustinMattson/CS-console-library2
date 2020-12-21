using console_library2.Enums;

namespace console_library2.Models
{
  public abstract partial class Publication
  {
    // public Publication()
    // {
    // }

    public Publication(string title, string author, bool available, PublicationType format)
    {
      Title = title;
      Author = author;
      Available = available;
      Format = format;
    }

    public string Title { get; set; }
    public string Author { get; set; }
    public bool Available { get; set; }
    public PublicationType Format { get; set; }
  }
}
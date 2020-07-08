using console_library2.Enums;

namespace console_library2.Models
{
  public partial class Publication
  {
    public Publication()
    {
    }

    public Publication(string title, string author, PublicationType format)
    {
      Title = title;
      Author = author;
      Available = true;
      Format = format;
    }

    public string Title { get; set; }
    public string Author { get; set; }
    public bool Available { get; set; }
    public PublicationType Format { get; set; }
  }
}
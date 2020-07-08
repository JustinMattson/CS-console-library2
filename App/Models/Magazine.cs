using console_library2.Enums;

namespace console_library2.Models
{
  public class Magazine : Publication
  {
    public Magazine(string title, string author, PublicationType format, string pubFrequency, int issueId) : base(title, author, format)
    {
      PubFrequency = pubFrequency;
      IssueId = issueId;
    }

    public string PubFrequency { get; set; }
    public int IssueId { get; set; }
  }
}
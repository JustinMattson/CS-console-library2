namespace console_library2.Interfaces
{
    public interface IElectronic
    {
        bool Downloadable { get; set; }
        int MaxDownloads { get; set; }
    }
}
namespace RestAPIClient
{
    public interface IAPIConfiguration
    {
        int Timeout { get; set; }
        string Url { get; set; }
    }
}
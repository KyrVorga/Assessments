namespace RestAPIClient
{
    public class APIConfiguration : IAPIConfiguration
    {
        /// <summary>
        /// The url of the REST service
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The timeout in seconds for a http request
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Creates a new instance of the APIConfiguration class
        /// </summary>
        public APIConfiguration()
        {
            Timeout = 60;
            Url = "http://localhost:5128";
        }
    }
}

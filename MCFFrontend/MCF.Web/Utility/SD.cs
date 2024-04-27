namespace MCF.Web.Utility
{
    public class SD
    {
        public static string? MCFAPIBase { get; set; }
        public const string TokenCookie = "JwtToken";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}

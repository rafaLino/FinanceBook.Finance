namespace FinanceBook.Finance.API.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class JwtSettings
    {
        public const string SectionName = "Jwt";
        public string Secret { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Authority { get; set; }
    }
}

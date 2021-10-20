namespace FinanceBook.Finance.API.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// Section name in appsettings
        /// </summary>
        public const string SectionName = "Jwt";

        /// <summary>
        /// 
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Authority { get; set; }
    }
}

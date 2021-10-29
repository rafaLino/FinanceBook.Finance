namespace FinanceBook.Finance.API.Settings
{
    /// <summary>
    /// cors settings
    /// </summary>
    public class CorsSettings
    {
        /// <summary>
        /// policy name for setup
        /// </summary>
        public const string PolicyName = "financePolicy";
        /// <summary>
        /// section name in appsettings
        /// </summary>
        public const string SectionName = "Cors";

        /// <summary>
        /// origin's list
        /// </summary>
        public string[] AllowedOrigins { get; set; }

        /// <summary>
        /// method's list
        /// </summary>
        public string[] AllowedMethods { get; set; }

        /// <summary>
        /// header's list
        /// </summary>
        public string[] AllowedHeaders { get; set; }
    }
}

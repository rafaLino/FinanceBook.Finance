using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceBook.Finance.API.Settings
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiKeySettings
    {
        /// <summary>
        ///  name in appsettings
        /// </summary>
        public const string ApiKeySectionName = "API_KEY";

        /// <summary>
        /// name of the key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }
    }
}

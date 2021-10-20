namespace FinanceBook.Finance.API.Models
{
    /// <summary>
    /// model from body request
    /// </summary>
    public class UpdateOperationRequestModel
    {
        /// <summary>
        /// 
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
    }
}

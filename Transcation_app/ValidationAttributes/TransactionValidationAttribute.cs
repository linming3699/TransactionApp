using System.ComponentModel.DataAnnotations;
using Transcation_app.Models;

namespace Transcation_app.ValidationAttributes
{
    public class TransactionValidationAttribute : ValidationAttribute
    {
        //protected override ValidationAttribute IsValid(object value , ValidationContext validationContext)
        //{ 
        //    TransactionDbContext transactionDbContext = (TransactionDbContext)validationContext.GetService(typeof(TransactionDbContext));

        //}
    }
}

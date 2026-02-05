using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Transcation_app.Dtos;
using Transcation_app.Models;
using Transcation_app.ViewModel;

namespace Transcation_app.Interfaces
{
    public interface ITransactionService
    {
        Task<TransactionIndexViewModel> Index(TransactionIndexViewModel vm);
        Task<TransactionDto_Get> Details(Guid? id);
        Task Create(TransactionDto_Post transaction);
        Task<TransactionDto_Post> Edit_Get(Guid? id);
        Task Edit_Post(TransactionDto_Post data);
        Task<Transaction> Delete_Get(Guid? id);

        Task DeleteConfirmed(Guid id);
    }
}

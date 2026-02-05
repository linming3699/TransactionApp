using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Transcation_app.Dtos;
using Transcation_app.Interfaces;
using Transcation_app.Models;
using Transcation_app.ViewModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Transcation_app.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly TransactionDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TransactionService(TransactionDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<TransactionIndexViewModel> Index(TransactionIndexViewModel vm)
        {
            var result = from a in _context.Transactions
                         join b in _context.Users
                         on a.UpdateUserId equals b.Id
                         orderby a.CreatedDateTime descending
                         select new TransactionDto_Get
                         {
                             Id = a.Id,
                             Amount = a.Amount,
                             Status = a.Status,
                             CreatedDateTime = a.CreatedDateTime,
                             UpdateDateTime = a.UpdateDateTime,
                             Contents = a.Contents,
                             UpdateUserName = b.Name
                         };
            if (!vm.Keyword.IsNullOrEmpty())
            {
                result = result.Where(x => x.Contents.Contains(vm.Keyword) || x.UpdateUserName.Contains(vm.Keyword));
            }
            if (!string.IsNullOrWhiteSpace(vm.Status))
            {
                result = result.Where(x => x.Status == vm.Status);
            }
            if (vm.StartDate.HasValue)
            {
                result = result.Where(x => x.CreatedDateTime >= vm.StartDate.Value);
            }
            if (vm.EndDate.HasValue)
            {
                result = result.Where(x => x.CreatedDateTime <= vm.EndDate.Value);
            }
            result = vm.Desc == true ? result.OrderByDescending(x => x.Amount) : result.OrderBy(x => x.Amount);

            //vm.TotalCount = result.Count();
            //vm.Data = await result
            //    .Skip((vm.Page - 1) * vm.PageSize)
            //    .Take(vm.PageSize)
            //   .ToListAsync();
            vm.Data = await result.ToListAsync();
            return vm;
        }
        public async Task<TransactionDto_Get> Details(Guid? id)
        {
            var result = (from a in _context.Transactions
                          join b in _context.Users
                          on a.UpdateUserId equals b.Id
                          where a.Id == id
                          select new TransactionDto_Get
                          {
                              Id = a.Id,
                              Amount = a.Amount,
                              Status = a.Status,
                              CreatedDateTime = a.CreatedDateTime,
                              UpdateDateTime = a.UpdateDateTime,
                              Contents = a.Contents,
                              UpdateUserName = b.Name
                          }).SingleOrDefaultAsync();
            return await result;
        }
        public async Task Create(TransactionDto_Post transaction)
        {
            var id = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x=>x.Type =="UserId").Value;
            Transaction create = new Transaction
            {
                Amount = transaction.Amount,
                Status = transaction.Status,
                Contents = transaction.Contents,
                CreatedDateTime = transaction.CreatedDateTime,
                UpdateDateTime = DateTime.Now,
                UpdateUserId = int.Parse(id)
            };
            _context.Transactions.Add(create);
            await _context.SaveChangesAsync();
        }
        public async Task<TransactionDto_Post> Edit_Get(Guid? id)
        {
            TransactionDto_Post Transaction =
                await (from a in _context.Transactions
                       where a.Id == id
                       select new TransactionDto_Post
                       {
                           Id = a.Id,
                           Status = a.Status,
                           Contents = a.Contents,
                           CreatedDateTime = a.CreatedDateTime,
                           Amount = a.Amount,
                           UpdateUserId = a.UpdateUserId
                       }).SingleOrDefaultAsync();
            return Transaction;
        }
        public async Task Edit_Post(TransactionDto_Post data)
        {
            var id = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
            var update = _context.Transactions.Find(data.Id);
            if (update != null)
            {
                update.Amount = data.Amount;
                update.Status = data.Status;
                update.Contents = data.Contents;
                update.CreatedDateTime = data.CreatedDateTime;
                update.UpdateUserId = int.Parse(id);
                update.UpdateDateTime = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Transaction> Delete_Get(Guid? id)
        {
            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.Id == id);
            return transaction;
        }
        public async Task DeleteConfirmed(Guid id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
            }

            await _context.SaveChangesAsync();
        }

    }
}

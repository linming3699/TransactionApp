using Microsoft.AspNetCore.Mvc.Rendering;
using Transcation_app.Dtos;
using Transcation_app.Enum;

namespace Transcation_app.ViewModel
{
    public class TransactionUpdateViewModel
    {
        public List<SelectListItem> status { get; set; }
        public TransactionDto_Post data { get; set; }
    }
    public class TransactionIndexViewModel
    {
        public string? Keyword { get; set; }
        public string? Status { get; set; }
        public bool? Desc { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Page { get; set; } = 1;// 目前頁數
        public int PageSize { get; set; } = 15;// 每頁 15 筆
        public int TotalCount { get; set; }// 總筆數
        public int TotalPages =>
            (int)Math.Ceiling(TotalCount / (double)PageSize);
        public List<TransactionDto_Get> Data { get; set; } = new();
    }
}

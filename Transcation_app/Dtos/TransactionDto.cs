using System.ComponentModel.DataAnnotations;

namespace Transcation_app.Dtos
{
    public class TransactionDto_Get : IValidatableObject
    {
        public Guid Id { get; set; }
        [Display(Name = "金額")]
        [Required(ErrorMessage = "請輸入金額!")]
        public int Amount { get; set; }
        [Display(Name = "狀態")]
        [Required(ErrorMessage = "請選擇狀態!")]
        public string Status { get; set; }
        [Display(Name = "記錄時間")]
        [Required(ErrorMessage = "請選擇日期!")]
        public DateTime CreatedDateTime { get; set; }
        [Display(Name = "最後更新時間")]
        public DateTime UpdateDateTime { get; set; }
        [Display(Name = "項目")]
        [Required(ErrorMessage = "請輸入項目!")]
        public string Contents { get; set; }
        [Display(Name = "更新者")]
        public string UpdateUserName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CreatedDateTime > UpdateDateTime)
            {
                yield return new ValidationResult("紀錄日期不可大於更新日期!", new[] { nameof(CreatedDateTime) });
            }
        }
    }
    public class TransactionDto_Post : IValidatableObject
    {
        public Guid Id { get; set; }
        [Display(Name = "金額")]
        [Required(ErrorMessage = "請輸入金額!")]
        public int Amount { get; set; }
        [Display(Name = "狀態")]
        [Required(ErrorMessage = "請選擇狀態!")]
        public string Status { get; set; }
        [Display(Name = "記錄時間")]
        [Required(ErrorMessage = "請選擇日期!")]
        public DateTime CreatedDateTime { get; set; }
        [Display(Name = "項目")]
        [Required(ErrorMessage = "請輸入項目!")]
        public string Contents { get; set; }
        public int UpdateUserId { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CreatedDateTime > DateTime.Now)
            {
                yield return new ValidationResult("紀錄日期不可大於現在時間!", new[] { nameof(CreatedDateTime) });
            }
        }
    }
}

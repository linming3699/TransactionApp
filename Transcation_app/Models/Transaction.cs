using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Transcation_app.Models;

public partial class Transaction
{
    public Guid Id { get; set; }
    [Display(Name = "金額")]
    public int Amount { get; set; }
    [Display(Name = "狀態")]

    public string Status { get; set; } = null!;
    [Display(Name = "建立時間")]

    public DateTime CreatedDateTime { get; set; }
    [Display(Name = "最後更新時間")]

    public DateTime UpdateDateTime { get; set; }
    [Display(Name = "更新者ID")]

    public int UpdateUserId { get; set; }
    [Display(Name = "項目")]

    public string Contents { get; set; } = null!;
}

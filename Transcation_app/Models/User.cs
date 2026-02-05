using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Transcation_app.Models;

public partial class User
{
    public int Id { get; set; }
    [Display(Name = "Email")]

    public string Email { get; set; } = null!;
    [Display(Name = "密碼")]

    public string Password { get; set; } = null!;
    [Display(Name = "使用者名稱")]

    public string Name { get; set; } = null!;
}


using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureApp.Shared;

[Table("SetupCurrency")]
[DisplayName("Currency")]
public class SetupCurrency
{
    public SetupCurrency()
    {
    }

    [Key]
    [Required]
    [MaxLength(10)]
    [DisplayName("Currency")]
    [Comment("Primary Key")]
    public string Code { get; set; } = string.Empty;
}

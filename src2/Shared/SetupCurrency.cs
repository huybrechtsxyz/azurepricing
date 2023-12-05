
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureApp.Shared;

[Table("SetupCurrency")]
public class SetupCurrency
{
    public SetupCurrency()
    {
    }

    [Key]
    [Required]
    [MaxLength(10)]
    [DisplayName("Currency Code")]
    [Comment("Primary Key")]
    public string Code { get; set; } = string.Empty;
}

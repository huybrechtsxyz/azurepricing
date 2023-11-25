using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureApp.Shared;

[NotMapped]
public class SearchParameters
{
    [Required]
    public string? Service { get; set; }

    [Required]
    public string? Location { get; set; }

    [Required]
    public string? CurrencyCode { get; set; }
}

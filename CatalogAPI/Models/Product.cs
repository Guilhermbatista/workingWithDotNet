using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using CatalogAPI.Validation;

namespace CatalogAPI.Models;

[Table("Products")]
public class Product : IValidatableObject
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    [StringLength(80)]
    public string? Name { get; set; }
    [Required]
    [StringLength(300)]
    public string? Description { get; set; }
    [Required]
    [Column(TypeName ="decimal(10,2)")]
    public decimal Price { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImgURL { get; set; }
    public float Stock { get; set; }
    public DateTime DateRegister { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!string.IsNullOrEmpty(this.Name))
        {
            var firstLetter = this.Name[0].ToString();
            if(firstLetter != firstLetter.ToUpper())
            {
                yield return new ValidationResult("A primeira letra do produto deve ser maiuscula",
                    new[]
                    {nameof(this.Name)}
                    );
            }
        }
        if (this.Stock <= 0)
        {
            yield return new ValidationResult("o estoque deve ser maior que zero",
                    new[]
                    {nameof(this.Stock)}
                    );
        }
    }
}

﻿using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CatalogAPI.Models;

[Table("Categories")]
public class Category
{

    public Category()
    {
        Products = new Collection<Product>();
    }

    [Key]
    public int CategoryId { get; set; }
    [Required]
    [StringLength(80)]
    public string? Name { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImgURL { get; set; }
    [JsonIgnore]
    public ICollection<Product>? Products { get; set; }

}

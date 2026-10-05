using System;
using System.ComponentModel.DataAnnotations;

namespace API_CRUD.Models;

public class Item
{
    public long Id {get; set;}

    [Required]
    [MaxLength(100)]
    public string Name {get; set;} = String.Empty;
    public string? Description {get; set;}
}

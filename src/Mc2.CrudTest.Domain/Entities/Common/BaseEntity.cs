           
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Domain.Entities.Common;

/// <summary>
/// Base Entity Class Which is base of the every entity. 
/// </summary>
/// <typeparam name="TKey"></typeparam>
public abstract class BaseEntity<TKey>
{
    [Key]
    public TKey? Id { get; set; }

    [Required]
    public short Status { get; set; }

    [Required]
    public DateTime CreateDateTime { get; set; }

    [Required]
    public DateTime UpdateDateTime { get; set; }

    [StringLength(250)]
    public string? Description { get; set; }
}

 
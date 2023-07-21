           
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Domain.Entities.Common;

/// <summary>
/// Base Entity Class Which is base of the every entity. 
/// </summary>
/// <typeparam name="TKey"></typeparam>
public abstract class BaseEntity<TKey>
{

    /// <summary>
    /// Identity Key
    /// </summary>
    [Key]
    public TKey? Id { get; set; }

    /// <summary>
    /// Create DateTime
    /// </summary>
    [Required]
    public DateTime CreateDateTime { get; set; }

    /// <summary>
    /// Update DateTime
    /// </summary>
    [Required]
    public DateTime UpdateDateTime { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    [StringLength(250)]
    public string? Description { get; set; }
}

 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw7_s33103.Models;

[Table("ComponentManufacturers")]
public class ComponentManufacturers
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Abbreviation { get; set; }
    [MaxLength(300)]
    public string FullName { get; set; }
    [Column(TypeName = "date")]
    public DateOnly FoundationDate { get; set; }
    
    public IEnumerable<Components> Components { get; set; } = [];
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw7_s33103.Models;

[Table("Components")]
public class Components
{
    [Key]
    [Column(TypeName = "char(10)")]
    public string Code { get; set; } = string.Empty;
    
    [MaxLength(300)]
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; }
    
    public int ComponentManufacturersId { get; set; }
    public int ComponentTypesId { get; set; }

    [ForeignKey(nameof(ComponentManufacturersId))]
    public ComponentManufacturers Manufacturer { get; set; } = null!;
    
    [ForeignKey(nameof(ComponentTypesId))]
    public ComponentTypes Type { get; set; } = null!;
    
    
    public IEnumerable<PcComponents> PcComponents { get; set; } = [];
}
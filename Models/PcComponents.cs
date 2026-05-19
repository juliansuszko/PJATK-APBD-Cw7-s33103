using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PJATK_APBD_Cw7_s33103.Models;

[Table("PCComponents"), PrimaryKey(nameof(PcId), nameof(ComponentCode))]
public class PcComponents
{
    [Column("PCId")]
    public int PcId { get; set; }
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; }
    public int Amount { get; set; }

    [ForeignKey(nameof(PcId))]
    public PCs PCs { get; set; } = null!;
    [ForeignKey(nameof(ComponentCode))]
    public Components Components { get; set; } = null!;

}
namespace PJATK_APBD_Cw7_s33103.DTOs;

public class PcWithComponentsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
    public IEnumerable<PcComponentDto> Components { get; set; } = [];
}
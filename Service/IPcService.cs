using PJATK_APBD_Cw7_s33103.DTOs;

namespace PJATK_APBD_Cw7_s33103.Service;

public interface IPcService
{
    Task<IEnumerable<PcDto>> GetPcsAsync();
    
    Task<PcWithComponentsDto> GetPcComponentsAsync(int pcId);
    
    Task<PcDto> AddPcAsync(CreateUpdatePcDto dto);
    
    Task UpdatePcAsync(int pcId, CreateUpdatePcDto dto);
    
    Task DeletePcAsync(int pcId);
}
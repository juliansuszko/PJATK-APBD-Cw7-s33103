using PJATK_APBD_Cw7_s33103.DTOs;

namespace PJATK_APBD_Cw7_s33103.Service;

public interface IPcService
{
    Task<IEnumerable<PcDto>> GetPcsAsync(CancellationToken cancellationToken);
    
    Task<PcWithComponentsDto> GetPcComponentsAsync(int id, CancellationToken cancellationToken);
    
    Task<PcDto> AddPcAsync(CreateUpdatePcDto request, CancellationToken cancellationToken);
    
    Task UpdatePcAsync(int id, CreateUpdatePcDto request, CancellationToken cancellationToken);
    
    Task DeletePcAsync(int id, CancellationToken cancellationToken);
}
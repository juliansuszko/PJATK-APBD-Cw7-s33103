using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s33103.DTOs;
using PJATK_APBD_Cw7_s33103.Exceptions;
using PJATK_APBD_Cw7_s33103.Infrastructure;
using PJATK_APBD_Cw7_s33103.Models;

namespace PJATK_APBD_Cw7_s33103.Service;

public class PcService(DatabaseContext ctx) : IPcService
{
    public async Task<IEnumerable<PcDto>> GetPcsAsync(CancellationToken cancellationToken)
    {
        return await ctx.Pcs
            .Select(p => new PcDto
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock
            }).ToListAsync(cancellationToken);
    }

    public async Task<PcWithComponentsDto> GetPcComponentsAsync(int id, CancellationToken cancellationToken)
    {
        return await ctx.Pcs
                   .Where(p => p.Id == id)
                   .Select(p => new PcWithComponentsDto
                   {
                       Id = p.Id,
                       Name = p.Name,
                       Weight = p.Weight,
                       Warranty = p.Warranty,
                       CreatedAt = p.CreatedAt,
                       Stock = p.Stock,
                       Components = p.PcComponents.Select(c => new PcComponentDto
                       {
                           Amount = c.Amount,
                           Component = new ComponentDto
                           {
                               Code = c.Components.Code,
                               Name = c.Components.Name,
                               Description = c.Components.Description,
                               Manufacturer = new ManufacturerDto
                               {
                                   Id = c.Components.Manufacturer.Id,
                                   Abbreviation = c.Components.Manufacturer.Abbreviation,
                                   FullName = c.Components.Manufacturer.FullName,
                                   FoundationDate = c.Components.Manufacturer.FoundationDate
                               },
                               Type = new TypeDto
                               {
                                   Id = c.Components.Type.Id,
                                   Abbreviation = c.Components.Type.Abbreviation,
                                   Name = c.Components.Type.Name
                               }
                           }
                       })
                   }).FirstOrDefaultAsync(cancellationToken)
               ?? throw new NotFoundException($"PC {id} not found");
    }

    public async Task<PcDto> AddPcAsync(CreateUpdatePcDto request, CancellationToken cancellationToken)
    {
        var newPc = new PCs
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };

        ctx.Pcs.Add(newPc);
        await ctx.SaveChangesAsync(cancellationToken);

        return new PcDto
        {
            Id = newPc.Id,
            Name = newPc.Name,
            Weight = newPc.Weight,
            Warranty = newPc.Warranty,
            CreatedAt = newPc.CreatedAt,
            Stock = newPc.Stock
        };
    }

    public async Task UpdatePcAsync(int id, CreateUpdatePcDto request, CancellationToken cancellationToken)
    {
        int affectedRows = await ctx.Pcs
            .Where(e => e.Id == id)
            .ExecuteUpdateAsync(setters => setters
                    .SetProperty(e => e.Name, request.Name)
                    .SetProperty(e => e.Weight, request.Weight)
                    .SetProperty(e => e.Warranty, request.Warranty)
                    .SetProperty(e => e.CreatedAt, request.CreatedAt)
                    .SetProperty(e => e.Stock, request.Stock),
                cancellationToken);

        if (affectedRows == 0)
        {
            throw new NotFoundException($"PC {id} not found");
        }
    }

    public async Task DeletePcAsync(int id, CancellationToken cancellationToken)
    {
        int affectedRows = await ctx.Pcs
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync(cancellationToken);

        if (affectedRows == 0)
        {
            throw new NotFoundException($"PC {id} not found");
        }
    }
}
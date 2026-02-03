using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Return.Web.Api.Database;
using Returns.Models;

namespace Return.Web.Api.Services;

public class InvestmentService(IMapper mapper): IInvestmentService
{
    public static Guid Investment1Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
    public static Guid Investment2Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
    public static Guid Investment3Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");
    
    public static string Stock1Name = "Stock1";
    public static string Stock2Name = "Stock2";
    public static string Stock3Name = "Stock3";
    
    public static Guid Stock1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
    public static Guid Stock2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
    public static Guid Stock3Id = Guid.Parse("33333333-3333-3333-3333-333333333333");
    
    public static Guid User1Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
    public static Guid User2Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
    public static Guid User3Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");
    
    public static IReadOnlyList<Investment> DatabaseData = [
        new(Guid.NewGuid(), User1Id, Stock1Name, 5, 10, new()),
        new(Guid.NewGuid(), User1Id,  Stock2Name, 10, 20, new()),
        new(Guid.NewGuid(), User2Id,  Stock2Name, 15, 30, new()),
        new(Guid.NewGuid(), User2Id, Stock3Name, 20, 40, new()),
    ];

    public Task<IReadOnlyList<InvestmentRes>?> GetByUserId(Guid userId, CancellationToken cts = default)
    {
        return Task.FromResult<IReadOnlyList<InvestmentRes>?>(DatabaseData.Select(i => i.UserId == userId).ToList());
    }

    public async Task<IReadOnlyList<InvestmentRes>> Query(InvestmentQuery query, CancellationToken cts = default)
    {
        var queryable = DatabaseData.AsQueryable();
        //usually would use expression builder or generic, but this also works as a quick example
        if(query.UserId.HasValue)
            queryable = queryable.Where(i => i.UserId == query.UserId.Value);

        if (query.Start.HasValue)
            queryable = queryable.Skip(query.Start.Value);
        
        //materialize
        var items = await queryable.ToListAsync(cts);
        return mapper.Map<IReadOnlyList<InvestmentRes>>(items);
    }
}
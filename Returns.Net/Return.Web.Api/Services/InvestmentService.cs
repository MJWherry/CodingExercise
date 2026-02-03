using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Return.Web.Api.Database;
using Returns.Models;

namespace Return.Web.Api.Services;

public class InvestmentService: IInvestmentService
{
    public static string Stock1Name = "Stock1";
    public static string Stock2Name = "Stock2";
    public static string Stock3Name = "Stock3";
    public static Guid Stock1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
    public static Guid Stock2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
    public static Guid Stock3Id = Guid.Parse("33333333-3333-3333-3333-333333333333");
    public static string User1Id = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa";
    public static string User2Id = "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb";
    public static string User3Id = "cccccccc-cccc-cccc-cccc-cccccccccccc";
    
    public static IReadOnlyList<Investment> DatabaseData = [

    ]; 
    
    public Task<IReadOnlyList<InvestmentRes>?> GetByUserId(Guid userId, CancellationToken cts = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<InvestmentRes>> Query(InvestmentQuery query, CancellationToken cts = default)
    {
        throw new NotImplementedException();
    }
}
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Return.Web.Api.Services;
using Returns.Models;

namespace Return.Web.Api.Controllers;

[ApiController]
public class InvestmentController(IInvestmentService investmentService): ControllerBase 
{
    [HttpGet(ApiRoutes.User.Base + "/{userId:guid}/Investments")]
    public async Task<ActionResult<IReadOnlyList<InvestmentRes>>> GetUserInvestments(
        Guid userId,
        CancellationToken cts = default)
    {
        try {
            //usually should check for existing user
            var results = await investmentService.GetByUserId(userId, cts);
            return Ok(results);
        }
        catch (Exception ex) {
            return Problem(ex.Message);
        }
    }
    
    [HttpPost(ApiRoutes.Investment.Query)]
    public async Task<ActionResult<IReadOnlyList<InvestmentRes>>> QueryInvestments(
        [FromBody]InvestmentQuery query, 
        CancellationToken cts = default)
    {
        try {
            var results = await investmentService.Query(query, cts);
            return Ok(results);
        }
        catch (Exception ex) {
            return Problem(ex.Message);
        }
    }
}
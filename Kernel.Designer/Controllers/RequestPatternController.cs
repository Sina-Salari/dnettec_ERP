using Kernel.Persistence.Common.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kernel.Designer.Controllers
{
    public class RequestPatternController : Infrastructure.ControllerBase
    {
        public RequestPatternController(DatabaseContext context) : base(context)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Domain.Models.RequestPattern data)
        {
            var RequestPattern = Context.RequestPatterns
                .FirstOrDefault(p => p.WorkFlowId == data.WorkFlowId);

            if (RequestPattern is null)
            {
                await Context.RequestPatterns.AddAsync(data);
            }
            else
            {
                RequestPattern.Controller = data.Controller;
                RequestPattern.Action = data.Action;
                RequestPattern.Status = data.Status;
            }
            await Context.SaveChangesAsync();

            return Ok();
        }
    }
}

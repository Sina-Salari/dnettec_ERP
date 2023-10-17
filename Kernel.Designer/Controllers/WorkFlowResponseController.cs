using Kernel.Persistence.Common.Context;
using Microsoft.AspNetCore.Mvc;

namespace Kernel.Designer.Controllers
{
    public class WorkFlowResponseController : Infrastructure.ControllerBase
    {
        public WorkFlowResponseController(DatabaseContext context) : base(context)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Domain.Models.WorkFlowResponse data)
        {
            var entity = Context.WorkFlowResponses
                .FirstOrDefault(p => p.WorkFlowId == data.WorkFlowId);

            if (entity is null)
            {
                await Context.WorkFlowResponses.AddAsync(data);
            }
            else
            {
                entity.ResponseJson = data.ResponseJson;
            }
            await Context.SaveChangesAsync();

            return Ok();
        }
    }
}

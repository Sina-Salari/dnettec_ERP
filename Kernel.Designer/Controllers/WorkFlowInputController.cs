using Kernel.Persistence.Common.Context;
using Microsoft.AspNetCore.Mvc;

namespace Kernel.Designer.Controllers
{
    public class WorkFlowInputController : Infrastructure.ControllerBase
    {
        public WorkFlowInputController(DatabaseContext context) : base(context)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Domain.Models.WorkFlowInput data)
        {
            var entity = Context.WorkFlowInputs
                .FirstOrDefault(p => p.WorkFlowId == data.WorkFlowId);

            if (entity is null)
            {
                await Context.WorkFlowInputs.AddAsync(data);
            }
            else
            {
                entity.BodyJson = data.BodyJson;
            }
            await Context.SaveChangesAsync();

            return Ok();
        }
    }
}

using Kernel.Persistence.Common.Context;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kernel.Designer.Controllers
{
    public class ApplicationsController : Infrastructure.ControllerBase
    {
        public ApplicationsController(DatabaseContext context) : base(context)
        {
        }

        public async Task<IActionResult> Index()
        {
            var Result = await Context.Applications
                .Where(p => p.Status != Dnettec.Persistence.Common.RecordStatus.Deleted)
                .ToListAsync();

            return View(Result);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Domain.Models.Application data)
        {
            if (data.Id == Guid.Empty)
            {
                await Context.Applications.AddAsync(data);
            }
            else
            {
                Context.Applications.Update(data);
            }
            await Context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return BadRequest();
            }

            var Application = await Context.Applications.FindAsync(Id);
            Application.Status = Dnettec.Persistence.Common.RecordStatus.Deleted;
            await Context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return BadRequest();
            }

            return Ok(await Context.Applications.FindAsync(Id));
        }
    }
}

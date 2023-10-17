using Kernel.Persistence.Common.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kernel.Designer.Controllers
{
    public class EntityController : Infrastructure.ControllerBase
    {
        protected DapperDatabaseContext DapperDatabase { get; }

        public EntityController(DatabaseContext context, DapperDatabaseContext dapperDatabase) : base(context)
        {
            DapperDatabase = dapperDatabase;
        }

        public async Task<IActionResult> Index(Guid AppId)
        {
            var data = await Context.Entities.Where(p => p.ApplicationId == AppId).ToListAsync();
            ViewData["AppId"] = AppId;
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Domain.Models.Entity data)
        {
            if (data.Id == Guid.Empty)
            {
                try
                {
                    await DapperDatabase.CreateTableAsync(data.EntityName);
                    await Context.Entities.AddAsync(data);
                }
                catch (Exception ex)
                {
                    return Conflict();
                }
            }
            else
            {
                var OldName = Context.Entities
                    .Where(p => p.Id == data.Id)
                    .Select(p => p.EntityName)
                    .FirstOrDefault();

                data.EntityName = OldName;

                Context.Entities.Update(data);
            }
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

            return Ok(await Context.Entities.FindAsync(Id));
        }
    }
}

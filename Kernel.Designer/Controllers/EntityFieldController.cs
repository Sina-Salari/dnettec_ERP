using Kernel.Persistence.Common.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kernel.Designer.Controllers
{
    public class EntityFieldController : Infrastructure.ControllerBase
    {
        protected DapperDatabaseContext DapperDatabase { get; }

        public EntityFieldController(DatabaseContext context, DapperDatabaseContext dapperDatabase) : base(context)
        {
            DapperDatabase = dapperDatabase;
        }

        public async Task<IActionResult> Index(Guid EntityId)
        {
            var data = await Context.EntityFields.Where(p => p.EntityId == EntityId).ToListAsync();
            ViewData["EntityId"] = EntityId;
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Domain.Models.EntityField data)
        {
            if (data.Id == Guid.Empty)
            {
                try
                {
                    var EntityName = await Context.Entities
                        .Where(p => p.Id == data.EntityId)
                        .Select(p => p.EntityName)
                        .FirstOrDefaultAsync();

                    await DapperDatabase
                        .CreateColumnAsync(EntityName,data.FieldName,data.FeildType.ToString());

                    await Context.EntityFields.AddAsync(data);
                }
                catch (Exception ex)
                {
                    return Conflict();
                }
            }
            else
            {
                var OldName = await Context.EntityFields
                    .Where(p => p.Id == data.Id)
                    .Select(p => p.FieldName)
                    .FirstOrDefaultAsync();

                data.FieldName = OldName;

                Context.EntityFields.Update(data);
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

            return Ok(await Context.EntityFields.FindAsync(Id));
        }
    }
}

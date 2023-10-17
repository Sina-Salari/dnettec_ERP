using Kernel.Persistence.Common.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kernel.Designer.Infrastructure
{
    [Route(Constant.Router.Controller)]
    public abstract class ControllerBase : Controller
    {
        protected ControllerBase(DatabaseContext context) : base()
        {
            Context = context;
        }

        protected DatabaseContext Context { get; }
    }
}

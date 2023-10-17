using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection
//namespace Kernel.Designer.Infrastructure.Middlewares
{
	public static class MiddlewareExtensions
	{
		static MiddlewareExtensions()
		{
		}

		public static Microsoft.AspNetCore.Builder.IApplicationBuilder
			UseExceptionHandlingMiddleware(this Microsoft.AspNetCore.Builder.IApplicationBuilder builder)
		{
			// UseMiddleware -> Extension Method -> using Microsoft.AspNetCore.Builder;
			return builder.UseMiddleware
				<Kernel.Designer.Infrastructure.Middlewares.ExceptionHandlingMiddleware>();
		}
	}
}

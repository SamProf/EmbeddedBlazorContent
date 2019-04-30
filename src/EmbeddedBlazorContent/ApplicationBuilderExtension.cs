using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.AspNetCore.Builder;

namespace EmbeddedBlazorContent
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseEmbeddedBlazorContent(this IApplicationBuilder app, Assembly assembly,
            string requestPath = EmbeddedBlazorContentConst.RequestPath)
        {
            return app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new EmbeddedBlazorContentProvider(assembly),
                RequestPath = requestPath,
            });
        }
    }
}
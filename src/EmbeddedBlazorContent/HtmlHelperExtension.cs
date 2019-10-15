using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace EmbeddedBlazorContent
{
    public static class HtmlHelperExtension
    {
        public static IHtmlContent EmbeddedBlazorContent<T>(this IHtmlHelper<T> html, Assembly assembly = null,
            string requestPath = EmbeddedBlazorContentConst.RequestPath)
        {
            var urlHelperFactory =
                (IUrlHelperFactory) html.ViewContext.HttpContext.RequestServices.GetService(typeof(IUrlHelperFactory));
            var urlHelper = urlHelperFactory.GetUrlHelper(html.ViewContext);

            var sb = new StringBuilder();


            IEnumerable<EmbeddedBlazorContentFileInfo> files;
            if (assembly == null)
            {
                files = EmbeddedBlazorContentManager.Instance.GetAllFiles();
            }
            else
            {
                files = EmbeddedBlazorContentManager.Instance.GetFiles(assembly);
            }

            foreach (var fileInfo in files)
            {
                switch (fileInfo.Type)
                {
                    case EmbeddedBlazorContentFileType.None:
                        break;
                    case EmbeddedBlazorContentFileType.Js:
                        sb.AppendLine($"<script src=\"{urlHelper.Content(requestPath + fileInfo.Name)}\"></script>");
                        break;
                    case EmbeddedBlazorContentFileType.Css:
                        sb.AppendLine(
                            $"<link href=\"{urlHelper.Content(requestPath + fileInfo.Name)}\" rel=\"stylesheet\" />");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }


            return new HtmlString(sb.ToString());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmbeddedBlazorContent
{
    public static class HtmlHelperExtension
    {
        public static IHtmlContent EmbeddedBlazorContent<T>(this IHtmlHelper<T> html, Assembly assembly = null,
            string requestPath = EmbeddedBlazorContentConst.RequestPath)
        {
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
                        sb.AppendLine($"<script src=\"{requestPath}{fileInfo.Name}\"></script>");
                        break;
                    case EmbeddedBlazorContentFileType.Css:
                        sb.AppendLine($"<link href=\"{requestPath}{fileInfo.Name}\" rel=\"stylesheet\" />");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }


            return new HtmlString(sb.ToString());
        }
    }
}
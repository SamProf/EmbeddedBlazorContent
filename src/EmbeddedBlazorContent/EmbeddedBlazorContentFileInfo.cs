using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.FileProviders.Embedded;

namespace EmbeddedBlazorContent
{
    public class EmbeddedBlazorContentFileInfo : EmbeddedResourceFileInfo
    {

        public EmbeddedBlazorContentFileType Type { get; }
        public EmbeddedBlazorContentFileInfo(Assembly assembly, string resourcePath, string name, DateTimeOffset lastModified, EmbeddedBlazorContentFileType type) : base(assembly, resourcePath, name, lastModified)
        {
            Type = type;
        }
    }


    public enum EmbeddedBlazorContentFileType
    {
        None,
        Js,
        Css
    }
}




using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Embedded;
using Microsoft.Extensions.Primitives;


namespace EmbeddedBlazorContent
{
    public class EmbeddedBlazorContentProvider : IFileProvider
    {
        private static readonly char[] _invalidFileNameChars = Path.GetInvalidFileNameChars()
            .Where(c => c != '/' && c != '\\').ToArray();


        private Dictionary<string, EmbeddedBlazorContentFileInfo> dic;

        public EmbeddedBlazorContentProvider(Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }

            dic = EmbeddedBlazorContentManager.Instance.GetFiles(assembly).ToDictionary(i => i.Name);
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            if (string.IsNullOrEmpty(subpath))
            {
                return new NotFoundFileInfo(subpath);
            }

            EmbeddedBlazorContentFileInfo fileInfo;
            if (dic.TryGetValue(subpath, out fileInfo))
            {
                return fileInfo;
            }

            return new NotFoundFileInfo(subpath);
        }


        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            return NotFoundDirectoryContents.Singleton;
        }


        public IChangeToken Watch(string pattern)
        {
            return NullChangeToken.Singleton;
        }

        private static bool HasInvalidPathChars(string path)
        {
            return path.IndexOfAny(_invalidFileNameChars) != -1;
        }
    }
}
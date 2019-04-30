using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EmbeddedBlazorContent
{
    public class EmbeddedBlazorContentManager
    {
        private object syncObj = new object();

        private Dictionary<Assembly, EmbeddedBlazorContentFileInfo[]> dic =
            new Dictionary<Assembly, EmbeddedBlazorContentFileInfo[]>();

        public static EmbeddedBlazorContentManager Instance { get; } = new EmbeddedBlazorContentManager();


        private IEnumerable<EmbeddedBlazorContentFileInfo> LoadFiles(Assembly assembly)
        {
            var lastModified = DateTimeOffset.UtcNow;

            if (!string.IsNullOrEmpty(assembly.Location))
            {
                try
                {
                    lastModified = File.GetLastWriteTimeUtc(assembly.Location);
                }
                catch (PathTooLongException)
                {
                }
                catch (UnauthorizedAccessException)
                {
                }
            }

            foreach (var resourceName in assembly.GetManifestResourceNames())
            {
                var parts = resourceName.Split(":");
                if (parts.Length < 3)
                {
                    continue;
                }

                if (!string.Equals("blazor", parts[0]))
                {
                    continue;
                }

                var type = EmbeddedBlazorContentFileType.None;

                switch (parts[1])
                {
                    case "js":
                        type = EmbeddedBlazorContentFileType.Js;
                        break;
                    case "css":
                        type = EmbeddedBlazorContentFileType.Css;
                        break;
                }

                var fileInfo =
                    new EmbeddedBlazorContentFileInfo(assembly, resourceName, "/" + parts[2].Replace("\\", "/"),
                        lastModified, type);
                yield return fileInfo;
            }
        }

        public IEnumerable<EmbeddedBlazorContentFileInfo> GetAllFiles()
        {
            return dic.SelectMany(i => i.Value);
        }

        public IEnumerable<EmbeddedBlazorContentFileInfo> GetFiles(Assembly assembly)
        {
            lock (syncObj)
            {
                EmbeddedBlazorContentFileInfo[] value;
                if (!this.dic.TryGetValue(assembly, out value))
                {
                    value = LoadFiles(assembly).ToArray();
                    dic.Add(assembly, value);
                }


                return value;
            }
        }
    }
}
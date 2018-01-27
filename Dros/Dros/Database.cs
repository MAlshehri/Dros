using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Realms;

namespace Dros
{
    public static class Database
    {
        private static Realm database;

        public static Realm Instance
        {
            get
            {
                if (database == null)
                {
#if __IOS__
                    string dbPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    dbPath = Path.Combine(dbPath, "..", "Library", "Databases");
                    dbPath = Path.Combine(dbPath, "dros.realm");
#endif
#if __ANDROID__
                    string dbPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    dbPath = Path.Combine(dbPath, "dros.realm");
#endif
                    var assembly = typeof(Database).GetTypeInfo().Assembly;
                    SaveEmbeddedResourceLocally(assembly, "dros.realm", dbPath);
                    database = Realm.GetInstance(dbPath);
                }
                return database;
            }
        }

        public static void SaveEmbeddedResourceLocally(Assembly assembly, string resourceFileName, string path)
        {
            var stream = GetEmbeddedResourceStream(assembly, resourceFileName);
            using (var fileStream = File.Create(path))
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }
        }

        public static Stream GetEmbeddedResourceStream(Assembly assembly, string resourceFileName)
        {
            var resourceNames = assembly.GetManifestResourceNames();

            var resourcePaths = resourceNames
                .Where(x => x.EndsWith(resourceFileName, StringComparison.CurrentCultureIgnoreCase))
                .ToArray();

            if (!resourcePaths.Any())
            {
                throw new Exception(string.Format("Resource ending with {0} not found.", resourceFileName));
            }

            if (resourcePaths.Count() > 1)
            {
                throw new Exception(string.Format("Multiple resources ending with {0} found: {1}{2}", resourceFileName, Environment.NewLine, string.Join(Environment.NewLine, resourcePaths)));
            }

            return assembly.GetManifestResourceStream(resourcePaths.Single());
        }
    }
}

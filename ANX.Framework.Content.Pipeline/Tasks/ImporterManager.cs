﻿#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using ANX.Framework.NonXNA.Reflection;

#endregion

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Content.Pipeline.Tasks
{
    public class ImporterManager
    {
        private Dictionary<String, Type> importerTypes = new Dictionary<string,Type>();
        private Dictionary<String, String> defaultProcessor = new Dictionary<string, string>();

        public ImporterManager()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
#if LINUX
                //Apparently these Assemblies are bad juju, so lets blacklist them as we don't need to check them anyway
                if (assembly.FullName == "MonoDevelop.Core, Version=2.6.0.0, Culture=neutral, PublicKeyToken=null" || assembly.FullName == "pango-sharp, Version=2.12.0.0, Culture=neutral, PublicKeyToken=35e10195dab3c99f"
                    || assembly.FullName == "Mono.TextEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" || assembly.FullName == "MonoDevelop.Ide, Version=2.6.0.0, Culture=neutral, PublicKeyToken=null")
                    return;

                Console.WriteLine("ImporterManager: Checking " + assembly.FullName);
#endif
				foreach (Type type in TypeHelper.SafelyExtractTypesFrom(assembly))
                {
                    if (type == null)
                        continue;
                    ContentImporterAttribute[] value = (ContentImporterAttribute[])type.GetCustomAttributes(typeof(ContentImporterAttribute), true);
                    if (value.Length > 0)
                    {
                        importerTypes[type.Name] = type;

                        foreach (ContentImporterAttribute cia in value)
                        {
                            if (!String.IsNullOrEmpty(cia.DefaultProcessor))
                            {
                                defaultProcessor.Add(type.Name, cia.DefaultProcessor);
                            }
                        }
                    }
                }
            }
        }

        public IContentImporter GetInstance(string importerName)
        {
            Type type;
            if (!this.importerTypes.TryGetValue(importerName, out type))
            {
                throw new Exception(String.Format("can't find importer {0}", importerName));
            }
            return (IContentImporter)Activator.CreateInstance(type);
        }

        public String GetDefaultProcessor(string importerName)
        {
            if (defaultProcessor.ContainsKey(importerName))
            {
                return defaultProcessor[importerName];
            }

            return String.Empty;
        }

        public static String GuessImporterByFileExtension(string filename)
        {
            String extension = System.IO.Path.GetExtension(filename);

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    ContentImporterAttribute[] value = (ContentImporterAttribute[])type.GetCustomAttributes(typeof(ContentImporterAttribute), true);
                    foreach (ContentImporterAttribute cia in value)
                    {
                        foreach (string fe in cia.FileExtensions)
                        {
                            if (string.Equals(fe, extension, StringComparison.InvariantCultureIgnoreCase))
                            {
                                return type.Name;
                            }
                        }
                    }
                }
            }

            return String.Empty;
        }

        public IEnumerable<KeyValuePair<string, Type>> AvailableImporters
        {
            get 
            {
                return importerTypes;
            }
        }
    }
}

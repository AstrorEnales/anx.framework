#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

#endregion // Using Statements

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace StockShaderCodeGenerator
{
    public static class Configuration
    {
        private static string buildFileName;
        private static bool configurationValid;
        private static string licenseFile;
        private static string target;
        private static string outputNamespace;
        public readonly static List<Shader> Shaders = new List<Shader>();

        public static void LoadConfiguration(String file)
        {
            buildFileName = file;

            if (!System.IO.File.Exists(file))
            {
                Console.WriteLine("Could not find build file...");
                return;
            }

            XDocument doc = XDocument.Load(buildFileName);
            if (doc.Root.Name.LocalName != "Build")
            {
                Console.WriteLine("Failed to load configuration because the build file has no Build-Node as the root element!");
                return;
            }
            else
            {
                if (doc.Root.HasAttributes)
                {
                    licenseFile = doc.Root.Attribute("License").Value;
                    if (System.IO.File.Exists(licenseFile))
                    {
                        Console.WriteLine("using license file '{0}' to include", licenseFile);
                    }
                    else
                    {
                        Console.WriteLine("license file '{0}' does not exist", licenseFile);
                        return;
                    }

                    target = doc.Root.Attribute("Target").Value;
                    Console.WriteLine("writing output to '{0}'", target);

                    outputNamespace = doc.Root.Attribute("Namespace").Value;
                    Console.WriteLine("using namespace '{0}'", outputNamespace);
                }

                if (doc.Root.HasElements)
                {
                    XElement[] shaderElements = doc.Root.Elements("Shader").ToArray<XElement>();

                    if (shaderElements.Length > 0)
                    {
                        foreach (XElement shaderElement in shaderElements)
                        {
                            Shader shader = new Shader();
                            shader.Type = shaderElement.Attribute("Type").Value;
                            shader.RenderSystem = shaderElement.Attribute("RenderSystem").Value;
                            shader.Source = shaderElement.Attribute("Source").Value;

                            Shaders.Add(shader);
                        }
                    }
                    else
                    {
                        Console.WriteLine("no shader tags found in configuration file...");
                        return;
                    }
                }
            }

            configurationValid = true;
        }

        public static bool ConfigurationValid
        {
            get
            {
                return configurationValid;
            }
        }

        public static string Target
        {
            get
            {
                return target;
            }
        }

        public static string LicenseFile
        {
            get
            {
                return licenseFile;
            }
        }

        public static string Namespace
        {
            get
            {
                return outputNamespace;
            }
        }
    }
}

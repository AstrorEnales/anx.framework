﻿#region Using Statements
using ANX.Framework.NonXNA.Development;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Content.Pipeline
{
    [AttributeUsage(AttributeTargets.Class)]
    [Serializable]
    public class ContentImporterAttribute : Attribute
    {
        public ContentImporterAttribute(string fileExtension)
        {
            FileExtensions = new string[] { fileExtension };
        }

        [CLSCompliant(false)]
        public ContentImporterAttribute(params string[] fileExtensions)
        {
            FileExtensions = fileExtensions;
        }

        public bool CacheImportedData
        {
            get;
            set;
        }

        public string DefaultProcessor
        {
            get;
            set;
        }

        
        public virtual string DisplayName
        {
            get;
            set;
        }

        
        public IEnumerable<string> FileExtensions
        {
            get;
            protected set;
        }

        
        public string Category
        {
            get;
            set;
        }
    }
}

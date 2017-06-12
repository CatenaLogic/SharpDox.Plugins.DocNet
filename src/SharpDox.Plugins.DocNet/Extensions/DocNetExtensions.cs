// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinkExtensions.cs" company="CatenaLogic">
//   Copyright (c) 2008 - 2017 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace SharpDox.Plugins.DocNet
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Model.Repository;
    using Model.Repository.Members;
    using Steps;

    public static class LinkExtensions
    {
        private static readonly List<string> NewlineReplacements = new List<string>();

        static LinkExtensions()
        {
            for (int i = 25; i > 2; i--)
            {
                var newlinesToReplace = string.Empty;

                for (int j = 0; j < i; j++)
                {
                    newlinesToReplace += '\n';
                }

                NewlineReplacements.Add(newlinesToReplace);
            }
        }

        public static string ResolvePath(this SDMemberBase member)
        {
            return "./home.md";
        }

        public static string ResolvePath(this SDType type, string rootPath = "/")
        {
            var typeNamespace = type.Namespace;
            var typeNamespaceFullName = typeNamespace.Fullname.Replace("GlobalNamespace", string.Empty);

            // A directory consists of [assembly]/[namespace] (e.g. catel-core/catel/logging/)
            var assemblyNameForPath = $"{typeNamespace.Assemblyname.RemoveIllegalPathChars()}";
            var namespaceForPath = string.Join(Path.DirectorySeparatorChar.ToString(), typeNamespaceFullName.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries));
            var fileNameForPath = type.Name.RemoveIllegalPathChars();

            var fileName = Path.Combine(rootPath, assemblyNameForPath, namespaceForPath, fileNameForPath + ".md");
            return fileName;
        }

        public static string CleanUp(this string content)
        {
            foreach (var newlineReplacement in NewlineReplacements)
            {
                content = content.Replace(newlineReplacement, "\n\n");
            }

            return content;
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepInput.cs" company="CatenaLogic">
//   Copyright (c) 2008 - 2017 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace SharpDox.Plugins.DocNet.Steps
{
    using Model;

    internal static class StepInput
    {
        public static SDProject SDProject { get; set; }
        public static string OutputPath { get; set; }
        public static string CurrentLanguage { get; set; }
        public static DocNetStrings DocStrings { get; set; }
        public static DocNetStrings DocNetStrings { get; set; }
        public static DocNetConfig Config { get; set; }

        public static void InitStepinput(SDProject sdProject, string outputPath, string currentLanguage,
            DocNetStrings docStrings, DocNetStrings htmlStrings, DocNetConfig config)
        {
            SDProject = sdProject;
            OutputPath = outputPath;
            CurrentLanguage = currentLanguage;
            DocStrings = docStrings;
            DocNetStrings = htmlStrings;
            Config = config;
        }
    }
}
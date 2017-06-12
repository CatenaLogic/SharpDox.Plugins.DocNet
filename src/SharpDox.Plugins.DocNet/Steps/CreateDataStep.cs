// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateDataStep.cs" company="CatenaLogic">
//   Copyright (c) 2008 - 2017 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace SharpDox.Plugins.DocNet.Steps
{
    using System;
    using System.IO;
    using System.Linq;
    using Model.Documentation;
    using Model.Documentation.Article;
    using Templates.Repository;

    internal class CreateDataStep : StepBase
    {
        public CreateDataStep(int progressStart, int progressEnd) : base(new StepRange(progressStart, progressEnd))
        {
        }

        public override void RunStep()
        {
            CreateNamespaceData();
            CreateTypeData();
        }

        private void CreateNamespaceData()
        {
            // Note: namespaces in DocNet are automatically created based on the __index file

            //ExecuteOnStepProgress(30);
            //foreach (var sdSolution in StepInput.SDProject.Solutions)
            //{
            //    foreach (var targetFxNamespace in sdSolution.Value.GetAllSolutionNamespaces())
            //    {
            //        ExecuteOnStepMessage(string.Format(StepInput.DocNetStrings.CreatingNamespaceData, targetFxNamespace.Key));

            //        var namespaceString = string.Format("{{{0}}}", string.Join(",", targetFxNamespace.Value.Select(sdTargetNamespace =>
            //            new NamespaceData {Namespace = sdTargetNamespace.Value, TargetFx = sdTargetNamespace.Key.TargetFx}.TransformText())));

            //        File.WriteAllText(Path.Combine(StepInput.OutputPath, "data", "namespaces", targetFxNamespace.Key + ".json"), namespaceString.MinifyJson());
            //    }
            //}
        }

        private void CreateTypeData()
        {
            ExecuteOnStepProgress(60);
            foreach (var sdSolution in StepInput.SDProject.Solutions)
            {
                foreach (var targetFxType in sdSolution.Value.GetAllSolutionTypes())
                {
                    ExecuteOnStepMessage(string.Format(StepInput.DocNetStrings.CreatingTypeData, targetFxType.Key));

                    var firstValue = targetFxType.Value.Select(x => x.Value).FirstOrDefault();
                    if (firstValue != null)
                    {
                        continue;
                    }

                    var typeNamespace = firstValue.Namespace;

                    // A diretory consists of [assembly]/[namespace] (e.g. catel-core/catel/logging/)
                    var assemblyNameForPath = $"{typeNamespace.Assemblyname.RemoveIllegalPathChars()}";
                    var namespaceForPath = string.Join(Path.DirectorySeparatorChar.ToString(), typeNamespace.Fullname.Split(new[] {'.'}, StringSplitOptions.RemoveEmptyEntries));
                    var fileNameForPath = firstValue.Name.RemoveIllegalPathChars();

                    var fileName = Path.Combine(StepInput.OutputPath, assemblyNameForPath, namespaceForPath, fileNameForPath + ".md");
                    var content = string.Empty;

                    var typeString = targetFxType.Value.Select(sdTargetType =>
                        new TypeData
                        {
                            Type = sdTargetType.Value,
                            TargetFx = sdTargetType.Key.TargetFx,
                            Repository = sdTargetType.Key
                        }.TransformText());

                    File.WriteAllText(fileName, content);
                }
            }
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateDataStep.cs" company="CatenaLogic">
//   Copyright (c) 2008 - 2017 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace SharpDox.Plugins.DocNet.Steps
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Model.Documentation;
    using Model.Documentation.Article;
    using Model.Repository;
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

            // Note: this isn't 100 % accurate. Best would be to create sets of data *per* target fx, then 
            // dynamically use this. But since we are converting this to MarkDown, we need to make a decision:
            //
            // 1. Create single file assuming most types cover all the methods
            // 2. Create separate files ([assembly]/[namespace]/[type]_[targetfx].md)
            //
            // Since we will put availability to all types (and maybe methods in the future), option 1 has been chosen 

            var allTypes = new Dictionary<string, List<Tuple<SDType, SDTargetFx>>>();

            foreach (var sdSolution in StepInput.SDProject.Solutions)
            {
                foreach (var targetFxType in sdSolution.Value.GetAllSolutionTypes())
                {
                    foreach (var keyValuePair in targetFxType.Value)
                    {
                        var typeKey = keyValuePair.Value.Fullname;
                        if (!allTypes.ContainsKey(typeKey))
                        {
                            allTypes[typeKey] = new List<Tuple<SDType, SDTargetFx>>();
                        }

                        var targetFxs = allTypes[typeKey];
                        targetFxs.Add(new Tuple<SDType, SDTargetFx>(keyValuePair.Value, keyValuePair.Key.TargetFx));
                    }
                }
            }

            foreach (var sdType in allTypes)
            {
                if (sdType.Value.Count == 0)
                {
                    continue;
                }

                var type = sdType.Value.First().Item1;
                var targetFxs = sdType.Value.Select(x => x.Item2).ToList();

                ExecuteOnStepMessage(string.Format(StepInput.DocNetStrings.CreatingTypeData, type));

                var typeData = new TypeData
                {
                    Type = type,
                    TargetFxs = targetFxs.ToArray()
                };

                var fileName = type.ResolvePath(StepInput.OutputPath);
                var content = typeData.TransformText();
                content = content.CleanUp();

                var directoryName = Path.GetDirectoryName(fileName);
                Directory.CreateDirectory(directoryName);

                File.WriteAllText(fileName, content);
            }
        }
    }
}
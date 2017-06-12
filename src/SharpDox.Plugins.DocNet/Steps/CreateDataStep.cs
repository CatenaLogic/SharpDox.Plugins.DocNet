// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateDataStep.cs" company="CatenaLogic">
//   Copyright (c) 2008 - 2017 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace SharpDox.Plugins.DocNet.Steps
{
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
            CreateArticleData();
            CreateNamespaceData();
            CreateTypeData();
        }

        private void CreateNamespaceData()
        {
            ExecuteOnStepProgress(30);
            foreach (var sdSolution in StepInput.SDProject.Solutions)
            {
                foreach (var targetFxNamespace in sdSolution.Value.GetAllSolutionNamespaces())
                {
                    ExecuteOnStepMessage(string.Format(StepInput.DocNetStrings.CreatingNamespaceData, targetFxNamespace.Key));

                    var namespaceString = string.Format("{{{0}}}", string.Join(",", targetFxNamespace.Value.Select(sdTargetNamespace =>
                        new NamespaceData {Namespace = sdTargetNamespace.Value, TargetFx = sdTargetNamespace.Key.TargetFx}.TransformText())));

                    File.WriteAllText(Path.Combine(StepInput.OutputPath, "data", "namespaces", targetFxNamespace.Key + ".json"), namespaceString.MinifyJson());
                }
            }
        }

        private void CreateTypeData()
        {
            ExecuteOnStepProgress(60);
            foreach (var sdSolution in StepInput.SDProject.Solutions)
            {
                foreach (var targetFxType in sdSolution.Value.GetAllSolutionTypes())
                {
                    ExecuteOnStepMessage(string.Format(StepInput.DocNetStrings.CreatingTypeData, targetFxType.Key));

                    var typeString = string.Format("{{{0}}}", string.Join(",", targetFxType.Value.Select(sdTargetType =>
                        new TypeData {Type = sdTargetType.Value, TargetFx = sdTargetType.Key.TargetFx, Repository = sdTargetType.Key}.TransformText())));

                    File.WriteAllText(Path.Combine(StepInput.OutputPath, "data", "types", targetFxType.Key.RemoveIllegalPathChars() + ".json"), typeString.MinifyJson());
                }
            }
        }

        private void CreateArticleData()
        {
            ExecuteOnStepProgress(90);
            ExecuteOnStepMessage(StepInput.DocNetStrings.CreatingArticleData);

            //var projectDescription = StepInput.SDProject.Descriptions.GetElementOrDefault(StepInput.CurrentLanguage) ?? new SDTemplate(string.Empty);
            //var homeData = new ArticleData()
            //{
            //    Title = "Home",
            //    SubTitle = StepInput.DocNetStrings.Description,
            //    Content = CommonMarkConverter.Convert(projectDescription.Transform(Helper.TransformLinkToken)).ToObjectString()
            //};

            //File.WriteAllText(Path.Combine(StepInput.OutputPath, "data", "articles", "home.json"), homeData.TransformText().MinifyJson());

            var articles = StepInput.SDProject.Articles.GetElementOrDefault(StepInput.CurrentLanguage);
            if (articles != null)
            {
                foreach (var article in articles)
                {
                    AddArticle(article);
                }
            }
        }

        private void AddArticle(SDArticle sdArticle)
        {
            if (!(sdArticle is SDArticlePlaceholder) && !(sdArticle is SDDocPlaceholder))
            {
                var articleData = new ArticleData
                {
                    Title = sdArticle.Title,
                    Content = sdArticle.Content.Transform(Helper.TransformLinkToken)
                };

                File.WriteAllText(Path.Combine(StepInput.OutputPath, sdArticle.Id + ".md"), articleData.TransformText().MinifyJson());
            }

            foreach (var article in sdArticle.Children)
            {
                AddArticle(article);
            }
        }
    }
}
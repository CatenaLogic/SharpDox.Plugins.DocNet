﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocNetStrings.cs" company="CatenaLogic">
//   Copyright (c) 2008 - 2017 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace SharpDox.Plugins.DocNet
{
    using Sdk.Local;

    public class DocNetStrings : ILocalStrings
    {
        private string _assembly = "Assembly";
        private string _constructors = "Constructors";
        private string _constValue = "Constant Value";
        private string _createNamespaceData = "Creating Namespace Data: {0}";
        private string _createTypeData = "Creating Type Data: {0}";
        private string _creatingArticleData = "Creating Article Data";
        private string _creatingNavigationData = "Creating Navigation Data";

        private string _creatingProjectData = "Creating Project Data";
        private string _creatingStringData = "Creating String Data";

        private string _description = "Description";
        private string _events = "Events";
        private string _example = "Example";
        private string _exceptions = "Exceptions";
        private string _fields = "Fields";
        private string _footerLine = "Footer Line";
        private string _generatedBy = "generated by";
        private string _home = "Home";
        private string _docNet = "DocNet";
        private string _methods = "Methods";
        private string _name = "Name";
        private string _namespace = "Namespace";
        private string _parameters = "Parameters";
        private string _primaryColor = "Primary Color";
        private string _properties = "Properties";
        private string _remarks = "Remarks";
        private string _reset = "reset";
        private string _returns = "Returns";
        private string _save = "save";
        private string _secondaryColor = "Secondary Color";
        private string _seeAlso = "See Also";
        private string _syntax = "Syntax";

        private string _typeParameters = "Type Parameters";
        private string _types = "Types";
        private string _usedBy = "Used by";
        private string _uses = "Uses";

        public string DocNet
        {
            get { return _docNet; }
            set { _docNet = value; }
        }

        public string PrimaryColor
        {
            get { return _primaryColor; }
            set { _primaryColor = value; }
        }

        public string SecondaryColor
        {
            get { return _secondaryColor; }
            set { _secondaryColor = value; }
        }

        public string FooterLine
        {
            get { return _footerLine; }
            set { _footerLine = value; }
        }

        public string CreatingProjectData
        {
            get { return _creatingProjectData; }
            set { _creatingProjectData = value; }
        }

        public string CreatingStringData
        {
            get { return _creatingStringData; }
            set { _creatingStringData = value; }
        }

        public string CreatingNavigationData
        {
            get { return _creatingNavigationData; }
            set { _creatingNavigationData = value; }
        }

        public string CreatingNamespaceData
        {
            get { return _createNamespaceData; }
            set { _createNamespaceData = value; }
        }

        public string CreatingTypeData
        {
            get { return _createTypeData; }
            set { _createTypeData = value; }
        }

        public string CreatingArticleData
        {
            get { return _creatingArticleData; }
            set { _creatingArticleData = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string SeeAlso
        {
            get { return _seeAlso; }
            set { _seeAlso = value; }
        }

        public string Types
        {
            get { return _types; }
            set { _types = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Assembly
        {
            get { return _assembly; }
            set { _assembly = value; }
        }

        public string Namespace
        {
            get { return _namespace; }
            set { _namespace = value; }
        }

        public string Home
        {
            get { return _home; }
            set { _home = value; }
        }

        public string Syntax
        {
            get { return _syntax; }
            set { _syntax = value; }
        }

        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        public string Example
        {
            get { return _example; }
            set { _example = value; }
        }

        public string Returns
        {
            get { return _returns; }
            set { _returns = value; }
        }

        public string Exceptions
        {
            get { return _exceptions; }
            set { _exceptions = value; }
        }

        public string Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public string TypeParameters
        {
            get { return _typeParameters; }
            set { _typeParameters = value; }
        }

        public string Uses
        {
            get { return _uses; }
            set { _uses = value; }
        }

        public string UsedBy
        {
            get { return _usedBy; }
            set { _usedBy = value; }
        }

        public string Save
        {
            get { return _save; }
            set { _save = value; }
        }

        public string Reset
        {
            get { return _reset; }
            set { _reset = value; }
        }

        public string Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }

        public string Constructors
        {
            get { return _constructors; }
            set { _constructors = value; }
        }

        public string Methods
        {
            get { return _methods; }
            set { _methods = value; }
        }

        public string Events
        {
            get { return _events; }
            set { _events = value; }
        }

        public string Properties
        {
            get { return _properties; }
            set { _properties = value; }
        }

        public string GeneratedBy
        {
            get { return _generatedBy; }
            set { _generatedBy = value; }
        }

        public string ConstValue
        {
            get { return _constValue; }
            set { _constValue = value; }
        }

        public string DisplayName
        {
            get { return "HtmlExporter"; }
        }
    }
}
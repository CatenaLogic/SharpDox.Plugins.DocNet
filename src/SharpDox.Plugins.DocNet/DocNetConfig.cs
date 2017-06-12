// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocNetConfig.cs" company="CatenaLogic">
//   Copyright (c) 2008 - 2017 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace SharpDox.Plugins.DocNet
{
    using System;
    using System.ComponentModel;
    using Sdk.Config;
    using Sdk.Config.Attributes;

    [Name(typeof(DocNetStrings), "DocNet")]
    public class DocNetConfig : IConfigSection
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool? _ignorePrivateMembers;
        //private string _primaryColor;
        //private string _secondaryColor;

        [Name(typeof(DocNetStrings), nameof(IgnorePrivateMembers))]
        public bool IgnorePrivateMembers
        {
            get { return _ignorePrivateMembers ?? true; }
            set
            {
                _ignorePrivateMembers = value;
                OnPropertyChanged(nameof(IgnorePrivateMembers));
            }
        }

        //[Name(typeof(DocNetStrings), nameof(PrimaryColor))]
        //[ConfigEditor(EditorType.Colorpicker)]
        //public string PrimaryColor
        //{
        //    get { return _primaryColor ?? "#F58026"; }
        //    set
        //    {
        //        _primaryColor = value;
        //        OnPropertyChanged(nameof(PrimaryColor));
        //    }
        //}

        //[Name(typeof(DocNetStrings), nameof(SecondaryColor))]
        //[ConfigEditor(EditorType.Colorpicker)]
        //public string SecondaryColor
        //{
        //    get { return _secondaryColor ?? "#F58026"; }
        //    set
        //    {
        //        _secondaryColor = value;
        //        OnPropertyChanged(nameof(SecondaryColor));
        //    }
        //}

        public Guid Guid
        {
            get { return new Guid("9B4136AB-AABE-41C3-848E-37CC39ED7FBB"); }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
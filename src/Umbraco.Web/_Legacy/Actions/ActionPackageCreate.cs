﻿using System;
using Umbraco.Web.UI.Pages;

namespace Umbraco.Web._Legacy.Actions
{
    /// <summary>
    /// This action is invoked upon creation of a document, media, member
    /// </summary>
    public class ActionPackageCreate : IAction
    {
        //create singleton
#pragma warning disable 612,618
        private static readonly ActionPackageCreate m_instance = new ActionPackageCreate();
#pragma warning restore 612,618

        public static ActionPackageCreate Instance
        {
            get { return m_instance; }
        }

        #region IAction Members

        public char Letter
        {
            get
            {
                return 'Y';
            }
        }

        public string JsFunctionName
        {
            get
            {
                return string.Format("{0}.actionPackageCreate()", ClientTools.Scripts.GetAppActions);
            }
        }

        public string JsSource
        {
            get
            {
                return null;
            }
        }

        public string Alias
        {
            get
            {
                return "createPackage";
            }
        }

        public string Icon
        {
            get
            {
                return "gift";
            }
        }

        public bool ShowInNotifier
        {
            get
            {
                return false;
            }
        }
        public bool CanBePermissionAssigned
        {
            get
            {
                return false;
            }
        }

        #endregion
    }
}

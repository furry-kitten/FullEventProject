﻿#pragma checksum "..\..\..\Pages\SampoPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "370B74B08B64BA35D0969600AD6F6DBD8458DDB91C5C594F2653C77D5DB8ECFC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Xpf.DXBinding;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Сампо.Models;
using Сампо.Pages;
using Сампо.ViewModels;


namespace Сампо.Pages {
    
    
    /// <summary>
    /// Sampo
    /// </summary>
    public partial class Sampo : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\Pages\SampoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Сампо.Pages.Sampo Window;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\Pages\SampoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock sampoPrice;
        
        #line default
        #line hidden
        
        
        #line 204 "..\..\..\Pages\SampoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl footer;
        
        #line default
        #line hidden
        
        
        #line 205 "..\..\..\Pages\SampoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem rules;
        
        #line default
        #line hidden
        
        
        #line 214 "..\..\..\Pages\SampoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox SampoRules;
        
        #line default
        #line hidden
        
        
        #line 219 "..\..\..\Pages\SampoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem location;
        
        #line default
        #line hidden
        
        
        #line 220 "..\..\..\Pages\SampoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label SampoLocation;
        
        #line default
        #line hidden
        
        
        #line 222 "..\..\..\Pages\SampoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem Info;
        
        #line default
        #line hidden
        
        
        #line 223 "..\..\..\Pages\SampoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label g123;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Сампо;component/pages/sampopage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\SampoPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Window = ((Сампо.Pages.Sampo)(target));
            return;
            case 2:
            this.sampoPrice = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.footer = ((System.Windows.Controls.TabControl)(target));
            return;
            case 4:
            this.rules = ((System.Windows.Controls.TabItem)(target));
            return;
            case 5:
            this.SampoRules = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.location = ((System.Windows.Controls.TabItem)(target));
            return;
            case 7:
            this.SampoLocation = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.Info = ((System.Windows.Controls.TabItem)(target));
            return;
            case 9:
            this.g123 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\Pages\PageSingIn.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "024F48969114D9AD97E8FC5286CD5446ABE6CAC67EDBC4DCCD12BB68468E26EE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfApp;


namespace WpfApp {
    
    
    /// <summary>
    /// PageSingIn
    /// </summary>
    public partial class PageSingIn : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\Pages\PageSingIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApp.PageSingIn Page1;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Pages\PageSingIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label23;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Pages\PageSingIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxLogin;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Pages\PageSingIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox TextBoxLoginPassword;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Pages\PageSingIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabeWarning;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\Pages\PageSingIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonExit;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Pages\PageSingIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonLogin;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp;component/pages/pagesingin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\PageSingIn.xaml"
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
            this.Page1 = ((WpfApp.PageSingIn)(target));
            return;
            case 2:
            this.Label23 = ((System.Windows.Controls.Label)(target));
            
            #line 51 "..\..\..\Pages\PageSingIn.xaml"
            this.Label23.Loaded += new System.Windows.RoutedEventHandler(this.Label23_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TextBoxLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TextBoxLoginPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            this.LabeWarning = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.ButtonExit = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\..\Pages\PageSingIn.xaml"
            this.ButtonExit.Click += new System.Windows.RoutedEventHandler(this.ButtonExit_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonLogin = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\Pages\PageSingIn.xaml"
            this.ButtonLogin.Click += new System.Windows.RoutedEventHandler(this.ButtonLogin_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


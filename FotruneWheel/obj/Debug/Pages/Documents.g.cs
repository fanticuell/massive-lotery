﻿#pragma checksum "..\..\..\Pages\Documents.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C80B0AA6398CB9C832172F134DB05A72E61D76BABEDCB683AC616CD0F5555551"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FotruneWheel.Pages;
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


namespace FotruneWheel.Pages {
    
    
    /// <summary>
    /// Documents
    /// </summary>
    public partial class Documents : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 64 "..\..\..\Pages\Documents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainGrid;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Pages\Documents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton checked1;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Pages\Documents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton checked3;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Pages\Documents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton checked3_3;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\Pages\Documents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton checked4;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Pages\Documents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateDocs;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\Pages\Documents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox numberDocs;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Pages\Documents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button tshirtButton;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\Pages\Documents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button minimalWindow;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Pages\Documents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button closeWindow;
        
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
            System.Uri resourceLocater = new System.Uri("/FotruneWheel;component/pages/documents.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Documents.xaml"
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
            this.mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.checked1 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 3:
            this.checked3 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.checked3_3 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.checked4 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.dateDocs = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.numberDocs = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.tshirtButton = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\Pages\Documents.xaml"
            this.tshirtButton.Click += new System.Windows.RoutedEventHandler(this.createDocument);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 90 "..\..\..\Pages\Documents.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.onMain);
            
            #line default
            #line hidden
            return;
            case 10:
            this.minimalWindow = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            
            #line 96 "..\..\..\Pages\Documents.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.TakeOff);
            
            #line default
            #line hidden
            return;
            case 12:
            this.closeWindow = ((System.Windows.Controls.Button)(target));
            return;
            case 13:
            
            #line 99 "..\..\..\Pages\Documents.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Exit);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


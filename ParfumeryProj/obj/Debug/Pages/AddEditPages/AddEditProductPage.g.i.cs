﻿#pragma checksum "..\..\..\..\Pages\AddEditPages\AddEditProductPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8C0593C0364DBB80A742A451C83F66443B191C4B5E2B8031D4387E677E324439"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ParfumeryProj.Pages.AddEditPages;
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


namespace ParfumeryProj.Pages.AddEditPages {
    
    
    /// <summary>
    /// AddEditProductPage
    /// </summary>
    public partial class AddEditProductPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\Pages\AddEditPages\AddEditProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TitleTb;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Pages\AddEditPages\AddEditProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ArticleTb;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Pages\AddEditPages\AddEditProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MinCostTb;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Pages\AddEditPages\AddEditProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ProdTypeCb;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Pages\AddEditPages\AddEditProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ProdImage;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Pages\AddEditPages\AddEditProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangeImageBtn;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Pages\AddEditPages\AddEditProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveBtn;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Pages\AddEditPages\AddEditProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteBtn;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Pages\AddEditPages\AddEditProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/ParfumeryProj;component/pages/addeditpages/addeditproductpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\AddEditPages\AddEditProductPage.xaml"
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
            this.TitleTb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ArticleTb = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\..\Pages\AddEditPages\AddEditProductPage.xaml"
            this.ArticleTb.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ArticleTb_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MinCostTb = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\..\..\Pages\AddEditPages\AddEditProductPage.xaml"
            this.MinCostTb.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.MinCostTb_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ProdTypeCb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.ProdImage = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.ChangeImageBtn = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Pages\AddEditPages\AddEditProductPage.xaml"
            this.ChangeImageBtn.Click += new System.Windows.RoutedEventHandler(this.ChangeImageBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SaveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\Pages\AddEditPages\AddEditProductPage.xaml"
            this.SaveBtn.Click += new System.Windows.RoutedEventHandler(this.SaveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DeleteBtn = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\Pages\AddEditPages\AddEditProductPage.xaml"
            this.DeleteBtn.Click += new System.Windows.RoutedEventHandler(this.DeleteBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BackBtn = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\Pages\AddEditPages\AddEditProductPage.xaml"
            this.BackBtn.Click += new System.Windows.RoutedEventHandler(this.BackBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\..\Views\EmployeesView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "46CED44248195E269834D3925EC93412D624D89E"
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
using System.Windows.Controls.Ribbon;
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
using ZooManager.Views;


namespace ZooManager.Views {
    
    
    /// <summary>
    /// EmployeesView
    /// </summary>
    public partial class EmployeesView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\Views\EmployeesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateEmployees;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Views\EmployeesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddEmployee;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Views\EmployeesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditEmployee;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Views\EmployeesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteEmployee;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Views\EmployeesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView employeesListView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ZooManager;component/views/employeesview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\EmployeesView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.UpdateEmployees = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\Views\EmployeesView.xaml"
            this.UpdateEmployees.Click += new System.Windows.RoutedEventHandler(this.UpdateEmployees_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AddEmployee = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\Views\EmployeesView.xaml"
            this.AddEmployee.Click += new System.Windows.RoutedEventHandler(this.AddEmployee_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EditEmployee = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\Views\EmployeesView.xaml"
            this.EditEmployee.Click += new System.Windows.RoutedEventHandler(this.EditEmployee_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DeleteEmployee = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Views\EmployeesView.xaml"
            this.DeleteEmployee.Click += new System.Windows.RoutedEventHandler(this.DeleteEmployee_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.employeesListView = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


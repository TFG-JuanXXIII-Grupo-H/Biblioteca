﻿#pragma checksum "..\..\WindowRegTrabajador.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3B97C6D7B25C3340899CC8E1706FB6EB6E9139E748208A76992434C35BC1544D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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
using TrabajoSGE1;


namespace TrabajoSGE1 {
    
    
    /// <summary>
    /// WindowRegTrabajador
    /// </summary>
    public partial class WindowRegTrabajador : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\WindowRegTrabajador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_usuLog;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\WindowRegTrabajador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_rango;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\WindowRegTrabajador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_volver;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\WindowRegTrabajador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lst_trabajadores;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\WindowRegTrabajador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_addTrabajador;
        
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
            System.Uri resourceLocater = new System.Uri("/TrabajoSGE1;component/windowregtrabajador.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowRegTrabajador.xaml"
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
            this.lbl_usuLog = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lbl_rango = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.btn_volver = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\WindowRegTrabajador.xaml"
            this.btn_volver.Click += new System.Windows.RoutedEventHandler(this.btn_volver_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lst_trabajadores = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.btn_addTrabajador = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\WindowRegTrabajador.xaml"
            this.btn_addTrabajador.Click += new System.Windows.RoutedEventHandler(this.btn_addTrabajador_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


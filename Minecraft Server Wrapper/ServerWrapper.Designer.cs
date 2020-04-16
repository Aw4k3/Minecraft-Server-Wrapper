﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Minecraft_Server_Wrapper {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.4.0.0")]
    internal sealed partial class ServerWrapper : global::System.Configuration.ApplicationSettingsBase {
        
        private static ServerWrapper defaultInstance = ((ServerWrapper)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new ServerWrapper())));
        
        public static ServerWrapper Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("...\\server.jar")]
        public string ServerPath {
            get {
                return ((string)(this["ServerPath"]));
            }
            set {
                this["ServerPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2048")]
        public int ServerRAM {
            get {
                return ((int)(this["ServerRAM"]));
            }
            set {
                this["ServerRAM"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ServerForceOnlineMode {
            get {
                return ((bool)(this["ServerForceOnlineMode"]));
            }
            set {
                this["ServerForceOnlineMode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool RunServerOnStartUp {
            get {
                return ((bool)(this["RunServerOnStartUp"]));
            }
            set {
                this["RunServerOnStartUp"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("50, 50, 128")]
        public global::System.Drawing.Color TitleBarColor {
            get {
                return ((global::System.Drawing.Color)(this["TitleBarColor"]));
            }
            set {
                this["TitleBarColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("White")]
        public global::System.Drawing.Color DefaultOutputColor {
            get {
                return ((global::System.Drawing.Color)(this["DefaultOutputColor"]));
            }
            set {
                this["DefaultOutputColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Yellow")]
        public global::System.Drawing.Color WarningOutputColor {
            get {
                return ((global::System.Drawing.Color)(this["WarningOutputColor"]));
            }
            set {
                this["WarningOutputColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("255, 64, 64")]
        public global::System.Drawing.Color ErrorOutputColor {
            get {
                return ((global::System.Drawing.Color)(this["ErrorOutputColor"]));
            }
            set {
                this["ErrorOutputColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ShowWarningOutput {
            get {
                return ((bool)(this["ShowWarningOutput"]));
            }
            set {
                this["ShowWarningOutput"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ShowErrorOutput {
            get {
                return ((bool)(this["ShowErrorOutput"]));
            }
            set {
                this["ShowErrorOutput"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public float ForegroundOpacity {
            get {
                return ((float)(this["ForegroundOpacity"]));
            }
            set {
                this["ForegroundOpacity"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string BackgroundSkin {
            get {
                return ((string)(this["BackgroundSkin"]));
            }
            set {
                this["BackgroundSkin"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("150, 190, 255")]
        public global::System.Drawing.Color PlayerEventOutputColor {
            get {
                return ((global::System.Drawing.Color)(this["PlayerEventOutputColor"]));
            }
            set {
                this["PlayerEventOutputColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Lime")]
        public global::System.Drawing.Color ServerLoadingDoneColor {
            get {
                return ((global::System.Drawing.Color)(this["ServerLoadingDoneColor"]));
            }
            set {
                this["ServerLoadingDoneColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Notes {
            get {
                return ((string)(this["Notes"]));
            }
            set {
                this["Notes"] = value;
            }
        }
    }
}

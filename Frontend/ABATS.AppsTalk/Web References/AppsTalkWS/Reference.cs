﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace ABATS.AppsTalk.AppsTalkWS {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="AppsTalkWebServiceInterfaceSoap", Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DisposableBase))]
    public partial class AppsTalkWebServiceInterface : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback LanuchIntegrationProcessAsyncOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public AppsTalkWebServiceInterface() {
            this.Url = global::ABATS.AppsTalk.Properties.Settings.Default.ABATS_AppsTalk_AppsTalkWS_AppsTalkWebServiceInterface;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event LanuchIntegrationProcessAsyncCompletedEventHandler LanuchIntegrationProcessAsyncCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/LanuchIntegrationProcessAsync", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public LanuchIntegrationProcessResponse LanuchIntegrationProcessAsync(LanuchIntegrationProcessRequest pRequest) {
            object[] results = this.Invoke("LanuchIntegrationProcessAsync", new object[] {
                        pRequest});
            return ((LanuchIntegrationProcessResponse)(results[0]));
        }
        
        /// <remarks/>
        public void LanuchIntegrationProcessAsyncAsync(LanuchIntegrationProcessRequest pRequest) {
            this.LanuchIntegrationProcessAsyncAsync(pRequest, null);
        }
        
        /// <remarks/>
        public void LanuchIntegrationProcessAsyncAsync(LanuchIntegrationProcessRequest pRequest, object userState) {
            if ((this.LanuchIntegrationProcessAsyncOperationCompleted == null)) {
                this.LanuchIntegrationProcessAsyncOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLanuchIntegrationProcessAsyncOperationCompleted);
            }
            this.InvokeAsync("LanuchIntegrationProcessAsync", new object[] {
                        pRequest}, this.LanuchIntegrationProcessAsyncOperationCompleted, userState);
        }
        
        private void OnLanuchIntegrationProcessAsyncOperationCompleted(object arg) {
            if ((this.LanuchIntegrationProcessAsyncCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LanuchIntegrationProcessAsyncCompleted(this, new LanuchIntegrationProcessAsyncCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class LanuchIntegrationProcessRequest : RequestBase {
        
        private ParameterInfo[] parametersField;
        
        /// <remarks/>
        public ParameterInfo[] Parameters {
            get {
                return this.parametersField;
            }
            set {
                this.parametersField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ParameterInfo : DTOBase {
        
        private SystemParameter systemParameterField;
        
        private string parameterValueField;
        
        /// <remarks/>
        public SystemParameter SystemParameter {
            get {
                return this.systemParameterField;
            }
            set {
                this.systemParameterField = value;
            }
        }
        
        /// <remarks/>
        public string ParameterValue {
            get {
                return this.parameterValueField;
            }
            set {
                this.parameterValueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum SystemParameter {
        
        /// <remarks/>
        None,
        
        /// <remarks/>
        code,
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ParameterInfo))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public abstract partial class DTOBase : DisposableBase {
        
        private string groupingField_Level_1Field;
        
        private string groupingField_Level_2Field;
        
        private string descriptionField;
        
        private bool isActiveField;
        
        private string creationUserField;
        
        private System.DateTime creationDateField;
        
        private string lastUpdateUserField;
        
        private System.DateTime lastUpdateField;
        
        /// <remarks/>
        public string GroupingField_Level_1 {
            get {
                return this.groupingField_Level_1Field;
            }
            set {
                this.groupingField_Level_1Field = value;
            }
        }
        
        /// <remarks/>
        public string GroupingField_Level_2 {
            get {
                return this.groupingField_Level_2Field;
            }
            set {
                this.groupingField_Level_2Field = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public bool IsActive {
            get {
                return this.isActiveField;
            }
            set {
                this.isActiveField = value;
            }
        }
        
        /// <remarks/>
        public string CreationUser {
            get {
                return this.creationUserField;
            }
            set {
                this.creationUserField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime CreationDate {
            get {
                return this.creationDateField;
            }
            set {
                this.creationDateField = value;
            }
        }
        
        /// <remarks/>
        public string LastUpdateUser {
            get {
                return this.lastUpdateUserField;
            }
            set {
                this.lastUpdateUserField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime LastUpdate {
            get {
                return this.lastUpdateField;
            }
            set {
                this.lastUpdateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ResponseBase))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LanuchIntegrationProcessResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DTOBase))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ParameterInfo))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RequestBase))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LanuchIntegrationProcessRequest))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public abstract partial class DisposableBase {
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LanuchIntegrationProcessResponse))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public abstract partial class ResponseBase : DisposableBase {
        
        private RequestBase requestField;
        
        private OperationStatus statusField;
        
        private string statusDescriptionField;
        
        private string messageField;
        
        /// <remarks/>
        public RequestBase Request {
            get {
                return this.requestField;
            }
            set {
                this.requestField = value;
            }
        }
        
        /// <remarks/>
        public OperationStatus Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        public string StatusDescription {
            get {
                return this.statusDescriptionField;
            }
            set {
                this.statusDescriptionField = value;
            }
        }
        
        /// <remarks/>
        public string Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LanuchIntegrationProcessRequest))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public abstract partial class RequestBase : DisposableBase {
        
        private System.DateTime requestDateField;
        
        private string requestUserField;
        
        /// <remarks/>
        public System.DateTime RequestDate {
            get {
                return this.requestDateField;
            }
            set {
                this.requestDateField = value;
            }
        }
        
        /// <remarks/>
        public string RequestUser {
            get {
                return this.requestUserField;
            }
            set {
                this.requestUserField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum OperationStatus {
        
        /// <remarks/>
        Succeeded,
        
        /// <remarks/>
        Failed,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class LanuchIntegrationProcessResponse : ResponseBase {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void LanuchIntegrationProcessAsyncCompletedEventHandler(object sender, LanuchIntegrationProcessAsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LanuchIntegrationProcessAsyncCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LanuchIntegrationProcessAsyncCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public LanuchIntegrationProcessResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((LanuchIntegrationProcessResponse)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SOA.UnitTest.SOAUnitTest {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SOAUnitTest.MyWebServiceSoap")]
    public interface MyWebServiceSoap {
        
        // CODEGEN: Generating message contract since element name HelloWorldResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        SOA.UnitTest.SOAUnitTest.HelloWorldResponse HelloWorld(SOA.UnitTest.SOAUnitTest.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<SOA.UnitTest.SOAUnitTest.HelloWorldResponse> HelloWorldAsync(SOA.UnitTest.SOAUnitTest.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Plus", ReplyAction="*")]
        int Plus(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Plus", ReplyAction="*")]
        System.Threading.Tasks.Task<int> PlusAsync(int x, int y);
        
        // CODEGEN: Generating message contract since element name GetResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get", ReplyAction="*")]
        SOA.UnitTest.SOAUnitTest.GetResponse Get(SOA.UnitTest.SOAUnitTest.GetRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get", ReplyAction="*")]
        System.Threading.Tasks.Task<SOA.UnitTest.SOAUnitTest.GetResponse> GetAsync(SOA.UnitTest.SOAUnitTest.GetRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public SOA.UnitTest.SOAUnitTest.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(SOA.UnitTest.SOAUnitTest.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://tempuri.org/", Order=0)]
        public SOA.UnitTest.SOAUnitTest.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(SOA.UnitTest.SOAUnitTest.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Get", Namespace="http://tempuri.org/", Order=0)]
        public SOA.UnitTest.SOAUnitTest.GetRequestBody Body;
        
        public GetRequest() {
        }
        
        public GetRequest(SOA.UnitTest.SOAUnitTest.GetRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetRequestBody {
        
        public GetRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetResponse", Namespace="http://tempuri.org/", Order=0)]
        public SOA.UnitTest.SOAUnitTest.GetResponseBody Body;
        
        public GetResponse() {
        }
        
        public GetResponse(SOA.UnitTest.SOAUnitTest.GetResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public SOA.UnitTest.SOAUnitTest.User[] GetResult;
        
        public GetResponseBody() {
        }
        
        public GetResponseBody(SOA.UnitTest.SOAUnitTest.User[] GetResult) {
            this.GetResult = GetResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface MyWebServiceSoapChannel : SOA.UnitTest.SOAUnitTest.MyWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MyWebServiceSoapClient : System.ServiceModel.ClientBase<SOA.UnitTest.SOAUnitTest.MyWebServiceSoap>, SOA.UnitTest.SOAUnitTest.MyWebServiceSoap {
        
        public MyWebServiceSoapClient() {
        }
        
        public MyWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MyWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SOA.UnitTest.SOAUnitTest.HelloWorldResponse SOA.UnitTest.SOAUnitTest.MyWebServiceSoap.HelloWorld(SOA.UnitTest.SOAUnitTest.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            SOA.UnitTest.SOAUnitTest.HelloWorldRequest inValue = new SOA.UnitTest.SOAUnitTest.HelloWorldRequest();
            inValue.Body = new SOA.UnitTest.SOAUnitTest.HelloWorldRequestBody();
            SOA.UnitTest.SOAUnitTest.HelloWorldResponse retVal = ((SOA.UnitTest.SOAUnitTest.MyWebServiceSoap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SOA.UnitTest.SOAUnitTest.HelloWorldResponse> SOA.UnitTest.SOAUnitTest.MyWebServiceSoap.HelloWorldAsync(SOA.UnitTest.SOAUnitTest.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<SOA.UnitTest.SOAUnitTest.HelloWorldResponse> HelloWorldAsync() {
            SOA.UnitTest.SOAUnitTest.HelloWorldRequest inValue = new SOA.UnitTest.SOAUnitTest.HelloWorldRequest();
            inValue.Body = new SOA.UnitTest.SOAUnitTest.HelloWorldRequestBody();
            return ((SOA.UnitTest.SOAUnitTest.MyWebServiceSoap)(this)).HelloWorldAsync(inValue);
        }
        
        public int Plus(int x, int y) {
            return base.Channel.Plus(x, y);
        }
        
        public System.Threading.Tasks.Task<int> PlusAsync(int x, int y) {
            return base.Channel.PlusAsync(x, y);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SOA.UnitTest.SOAUnitTest.GetResponse SOA.UnitTest.SOAUnitTest.MyWebServiceSoap.Get(SOA.UnitTest.SOAUnitTest.GetRequest request) {
            return base.Channel.Get(request);
        }
        
        public SOA.UnitTest.SOAUnitTest.User[] Get() {
            SOA.UnitTest.SOAUnitTest.GetRequest inValue = new SOA.UnitTest.SOAUnitTest.GetRequest();
            inValue.Body = new SOA.UnitTest.SOAUnitTest.GetRequestBody();
            SOA.UnitTest.SOAUnitTest.GetResponse retVal = ((SOA.UnitTest.SOAUnitTest.MyWebServiceSoap)(this)).Get(inValue);
            return retVal.Body.GetResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SOA.UnitTest.SOAUnitTest.GetResponse> SOA.UnitTest.SOAUnitTest.MyWebServiceSoap.GetAsync(SOA.UnitTest.SOAUnitTest.GetRequest request) {
            return base.Channel.GetAsync(request);
        }
        
        public System.Threading.Tasks.Task<SOA.UnitTest.SOAUnitTest.GetResponse> GetAsync() {
            SOA.UnitTest.SOAUnitTest.GetRequest inValue = new SOA.UnitTest.SOAUnitTest.GetRequest();
            inValue.Body = new SOA.UnitTest.SOAUnitTest.GetRequestBody();
            return ((SOA.UnitTest.SOAUnitTest.MyWebServiceSoap)(this)).GetAsync(inValue);
        }
    }
}
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.36279
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IAutorize")]
    public interface IAutorize {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAutorize/SignIn", ReplyAction="http://tempuri.org/IAutorize/SignInResponse")]
        string SignIn(string login, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAutorize/SignIn", ReplyAction="http://tempuri.org/IAutorize/SignInResponse")]
        System.Threading.Tasks.Task<string> SignInAsync(string login, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAutorize/GetInfo", ReplyAction="http://tempuri.org/IAutorize/GetInfoResponse")]
        string GetInfo(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAutorize/GetInfo", ReplyAction="http://tempuri.org/IAutorize/GetInfoResponse")]
        System.Threading.Tasks.Task<string> GetInfoAsync(string token);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAutorizeChannel : Client.ServiceReference1.IAutorize, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AutorizeClient : System.ServiceModel.ClientBase<Client.ServiceReference1.IAutorize>, Client.ServiceReference1.IAutorize {
        
        public AutorizeClient() {
        }
        
        public AutorizeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AutorizeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AutorizeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AutorizeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string SignIn(string login, string pass) {
            return base.Channel.SignIn(login, pass);
        }
        
        public System.Threading.Tasks.Task<string> SignInAsync(string login, string pass) {
            return base.Channel.SignInAsync(login, pass);
        }
        
        public string GetInfo(string token) {
            return base.Channel.GetInfo(token);
        }
        
        public System.Threading.Tasks.Task<string> GetInfoAsync(string token) {
            return base.Channel.GetInfoAsync(token);
        }
    }
}
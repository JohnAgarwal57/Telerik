﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DateTimeConsole.ServiceDateTime {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceDateTime.IServiceDateTime")]
    public interface IServiceDateTime {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDateTime/GetDay", ReplyAction="http://tempuri.org/IServiceDateTime/GetDayResponse")]
        string GetDay(System.DateTime value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDateTime/GetDay", ReplyAction="http://tempuri.org/IServiceDateTime/GetDayResponse")]
        System.Threading.Tasks.Task<string> GetDayAsync(System.DateTime value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceDateTimeChannel : DateTimeConsole.ServiceDateTime.IServiceDateTime, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceDateTimeClient : System.ServiceModel.ClientBase<DateTimeConsole.ServiceDateTime.IServiceDateTime>, DateTimeConsole.ServiceDateTime.IServiceDateTime {
        
        public ServiceDateTimeClient() {
        }
        
        public ServiceDateTimeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceDateTimeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceDateTimeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceDateTimeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetDay(System.DateTime value) {
            return base.Channel.GetDay(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDayAsync(System.DateTime value) {
            return base.Channel.GetDayAsync(value);
        }
    }
}

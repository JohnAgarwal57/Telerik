﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IServiceSubstringCount")]
public interface IServiceSubstringCount
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceSubstringCount/Count", ReplyAction="http://tempuri.org/IServiceSubstringCount/CountResponse")]
    int Count(string firstString, string substring);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceSubstringCount/Count", ReplyAction="http://tempuri.org/IServiceSubstringCount/CountResponse")]
    System.Threading.Tasks.Task<int> CountAsync(string firstString, string substring);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IServiceSubstringCountChannel : IServiceSubstringCount, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class ServiceSubstringCountClient : System.ServiceModel.ClientBase<IServiceSubstringCount>, IServiceSubstringCount
{
    
    public ServiceSubstringCountClient()
    {
    }
    
    public ServiceSubstringCountClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public ServiceSubstringCountClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServiceSubstringCountClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServiceSubstringCountClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public int Count(string firstString, string substring)
    {
        return base.Channel.Count(firstString, substring);
    }
    
    public System.Threading.Tasks.Task<int> CountAsync(string firstString, string substring)
    {
        return base.Channel.CountAsync(firstString, substring);
    }
}

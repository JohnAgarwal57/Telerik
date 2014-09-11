namespace DateTimeService
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IServiceDateTime
    {
        [OperationContract]
        string GetDay(DateTime value);
    }   
}

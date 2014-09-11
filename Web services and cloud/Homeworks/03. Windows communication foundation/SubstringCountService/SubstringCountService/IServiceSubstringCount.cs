namespace SubstringCountService
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IServiceSubstringCount
    {
        [OperationContract]
        int Count(string firstString, string substring);
    }
}

namespace Mobile.Models
{
    using System.Collections.Generic;

    public class Producer
    {
        public string Name { get; set; }

        public IEnumerable<Model> Models { get; set; }
    }
}
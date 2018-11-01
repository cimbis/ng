using System;

namespace Ngtryout.Models
{
    public interface IDatapoint
    {
        string Name { get; }
        DateTime RecordedAt { get; }
        double Value { get; }
    }

    public class DatapointDomain : IDatapoint
    {
        public DatapointDomain(
            string name,
            DateTime recAt,
            double val)
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime RecordedAt { get; set; }
        public double Value { get; set; }
    }


}
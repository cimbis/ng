using System;

namespace Ngtryout.Models
{
    public class DatapointEntity
    {
        public DatapointEntity()
        {
            Id = Guid.NewGuid().ToString();
        }

        public DatapointEntity(IDatapoint dp)
        {
            Id = Guid.NewGuid().ToString();
            Name = dp.Name;
            RecordedAt = dp.RecordedAt;
            Value = dp.Value;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime RecordedAt { get; set; }
        public double Value { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using SharedLibrary;

namespace Models
{
    public class RoomModel : IRoomModel
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("quality")]
        public string Quality { get; set; }

        [JsonPropertyName("size")]
        public string Size { get; set; }

        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("notes")]
        public string? Notes { get; set; }


        public QualityEnum GetQualityType()
        {
            return (QualityEnum)Enum.Parse(typeof(QualityEnum), Quality);
        }

        public void SetQualityType(QualityEnum type)
        {
            Quality = type.ToString();
        }

        public SizeEnum GetSizeType()
        {
            return (SizeEnum)Enum.Parse(typeof(SizeEnum), Size);
        }

        public void SetSizeType(SizeEnum type)
        {
            Size = type.ToString();
        }

        public StatusEnum GetStatusType()
        {
            return Status ? StatusEnum.Available : StatusEnum.Unavailable;
        }

        public void SetStatusType(StatusEnum type)
        {
            Status = type == StatusEnum.Available;
        }
        public override string ToString()
        {
            return Number.ToString();
        }
    }
}

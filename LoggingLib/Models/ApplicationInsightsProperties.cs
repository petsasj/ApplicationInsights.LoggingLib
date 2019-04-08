using System.Collections.Generic;
using LoggingLib.Extensions;

namespace LoggingLib.Models
{
    public class ApplicationInsightsProperties
    {
        public string MachineName { get; set; }

        public string LogTag => "ApplicationInsightsLogger";

        public string Action { get; set; }

        public string Tag { get; set; }

        public string Method { get; set; }

        public string ProgramUnit { get; set; }

        public string Error { get; set; }

        public string AdditionalInfo { get; set; }

        public string Message { get; set; }

        public string User { get; set; }

        public string Agent { get; set; }

        public string Arguments { get; set; }

        public string Company { get; set; }

        public string Entity { get; set; }

        public string EntityId { get; set; }

        public string TimeElapsed { get; set; } 

        public Dictionary<string, object> ExtraProperties { get; set; } = new Dictionary<string, object>();

        public void AddExtraProperty(string name, object value)
        {
            this.ExtraProperties.Add(name, value);
        }

        public IReadOnlyList<KeyValuePair<string, object>> Serialize() => this.GetProperties();
    }
}
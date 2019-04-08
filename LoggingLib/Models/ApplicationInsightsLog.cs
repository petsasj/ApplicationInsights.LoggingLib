using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LoggingLib.Models
{
    public class ApplicationInsightsLog : IReadOnlyList<KeyValuePair<string, object>>
    {
        private readonly IReadOnlyList<KeyValuePair<string, object>> _keyValuePairs;

        public ApplicationInsightsLog(ApplicationInsightsProperties props)
        {
            this._keyValuePairs = props.Serialize();
        }
      
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return this._keyValuePairs?.GetEnumerator() ?? throw new InvalidOperationException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => this._keyValuePairs.Count;

        public KeyValuePair<string, object> this[int index] => _keyValuePairs[index];

        public string Name => _keyValuePairs.FirstOrDefault(v => v.Key == "LogTag").Value.ToString();

        public string Message => _keyValuePairs.FirstOrDefault(v => v.Key == "Message").Value.ToString();
    }
}
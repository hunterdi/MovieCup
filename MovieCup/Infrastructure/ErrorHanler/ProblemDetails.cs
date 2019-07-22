using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Infrastructure
{
	public class ProblemDetails
	{
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "type")]
		public string Type { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "title")]
		public string Title { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "status")]
		public int? Status { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "detail")]
		public string Detail { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "instance")]
		public string Instance { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "successful")]
		public virtual bool Successful => string.IsNullOrWhiteSpace(Detail);

		[JsonExtensionData]
		public IDictionary<string, object> Extensions { get; } = new Dictionary<string, object>(StringComparer.Ordinal);
	}
}

﻿using Bedrock.Entities.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class EnvironmentTrigger : IJToken {
        public IFilter Filters { get; set; }
        public string Event { get; set; }
        public string Target { get; set; }

        public EnvironmentTrigger(IFilter filters, string entityEvent, string target = null) {
            Filters = filters;
            Event = entityEvent;
            Target = target;
        }

        public JObject ToJObject() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull(Filters);
            jObject.AddIfNotNull("event", Event);
            jObject.AddIfNotNull("target", Target);

            return jObject;
        }

        public JToken ToJToken() {
            return ToJObject();
        }

        public static implicit operator JObject(EnvironmentTrigger et) {
            return et?.ToJObject();
        }

        public static implicit operator JToken(EnvironmentTrigger et) {
            return et?.ToJToken();
        }
    }
}

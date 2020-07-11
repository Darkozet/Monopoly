using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly.Classes.Card.Property
{
    public class PropertiesList
    {
        // Variables
        #region Properties
        [JsonProperty("rue")]
        public IList<Street> Rue { get; set; }

        [JsonProperty("gare")]
        public IList<Station> gare { get; set; }

        [JsonProperty("speciale")]
        public IList<Special> speciale { get; set; }
        #endregion
    }
}

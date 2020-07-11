using Monopoly.Classes.Card.Action;
using Monopoly.Classes.Card.Property;
using Monopoly.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Monopoly.Classes.Card
{
    public class ActionCard
    {
        // Variables
        #region Properties
        [JsonProperty("chance")]
        public IList<Chance> chance { get; set; }

        [JsonProperty("communaute")]
        public IList<Community> communaute { get; set; }
        #endregion
    }
}

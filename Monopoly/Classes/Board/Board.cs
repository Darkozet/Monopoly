using Monopoly.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Monopoly.Classes.Board
{
    class Board
    {
        // Variables
        #region Properties
        [JsonProperty("case")]
        public IList<Square> square { get; set; }
        #endregion
    }
}

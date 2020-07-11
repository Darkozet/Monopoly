using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly.Classes.Card.Action
{
    public class Chance
    {
        // Variables
        #region Properties
        public string nom { get; set; }
        public string type { get; set; }
        public int? montant { get; set; }
        public int? destination { get; set; }
        public bool? direct { get; set; }
        public int? hotel { get; set; }
        public int? maison { get; set; }
        public int? nb { get; set; }
        #endregion
    }
}

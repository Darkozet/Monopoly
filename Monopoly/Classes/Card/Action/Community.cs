using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly.Classes.Card.Action
{
    public class Community
    {
        // Variables
        #region Properties
        public string nom { get; set; }
        public string type { get; set; }
        public int montant { get; set; }
        public int? destination { get; set; }
        public bool? direct { get; set; }
        #endregion
    }
}

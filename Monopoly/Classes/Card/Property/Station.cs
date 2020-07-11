using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly.Classes.Card
{
    public class Station
    {
        // Variables
        #region Properties
        public string nom { get; set; }
        public IList<string> colors { get; set; }
        public int prix { get; set; }
        public IList<int> loyers { get; set; }
        #endregion
    }
}

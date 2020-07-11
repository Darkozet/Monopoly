using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly.Classes.Board
{
    class Square
    {
        // Variables
        #region Properties
        public int numero { get; set; }
        public string type { get; set; }
        public int axeX { get; set; }
        public int axeY { get; set; }
        public string nom { get; set; }
        public string groupe { get; set; }

        // Variable facultative pour les case taxe
        public int? prix { get; set; }

        // Variable facultative pour la case parc gratuit
        public int? gain { get; set; }
        #endregion
    }
}

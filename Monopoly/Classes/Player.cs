using Monopoly.Classes.Board;
using Monopoly.Classes.Card;
using Monopoly.Classes.Card.Action;
using Monopoly.Classes.Card.Property;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly.Classes
{
    class Player
    {
        // Variables
        #region Properties
        // Informations générale
        public string strName { get; set; }
        public int iPlayerNumber { get; set; }
        public int iActualLocationX { get; set; }
        public int iActualLocationY { get; set; }
        public int iBudget { get; set; }

        // possessions
        public List<Chance> liChance = new List<Chance>();
        public List<Community> liCommunity = new List<Community>();
        public List<Special> liSpecial = new List<Special>();
        public List<Station> liStation = new List<Station>();
        public List<Street> liStreet = new List<Street>();

        // Case
        public Square square = new Square();
        #endregion

        // Constructor
        public Player(string name, int number, Square square)
        {
            // Initialisation des variables (avec paramètres)
            this.strName = name;
            this.iPlayerNumber = number;

            // Initialisation des variables (sans paramètres)
            this.iBudget = 150000;
        }

        // Lancer les dés
        public List<int> FaireLancerDes()
        {
            var rnd = new Random();
            List<int> listDes = new List<int>();

            int de1 = rnd.Next(1, 7);
            int de2 = rnd.Next(1, 7);

            listDes.Add(de1);
            listDes.Add(de2);

            return listDes;
        }
    }
}

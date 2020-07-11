using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Monopoly.Classes.Card;

namespace Monopoly.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyCardView : ContentView
    {
        public PropertyCardView(Street street)
        {
            InitializeComponent();

            InitializeStreetCard(street);
        }

        private void InitializeStreetCard(Street street)
        {
            // On initialise le contenu de la carte avec les informations de l'objet
            this.lblTitleCard.Text = street.nom;
            this.lblTitleCard.BackgroundColor = Color.FromHex(street.colors[0]);
            this.lblLoyerBase.Text = "M " + street.loyers[0];
            this.lblLoyerMaison1.Text = "M " + street.loyers[1];
            this.lblLoyerMaison2.Text = "M " + street.loyers[2];
            this.lblLoyerMaison3.Text = "M " + street.loyers[3];
            this.lblLoyerMaison4.Text = "M " + street.loyers[4];
            this.lblLoyerHotel.Text = "M " + street.loyers[5];
            this.lblCoutMaison.Text = "M "+ street.prixMaison;
            this.lblCoutHotel.Text = "M "+ street.prixMaison + " (4 Maisons)";
            this.lblCoutProprite.Text = "M "+ street.prix;
        }
    }
}
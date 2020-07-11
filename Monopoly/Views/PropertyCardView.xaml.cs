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
        public string strName = "";
        public PropertyCardView(Street street, bool bMode)
        {
            InitializeComponent();

            InitializeStreetCard(street, bMode);
        }

        private void InitializeStreetCard(Street street, bool bMode)
        {
            this.strName = street.nom;
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

            if(bMode)
            {
                this.lblTitleCard.FontSize = 15;
                this.lblLoyerBase.FontSize = 12;
                this.lblLoyerMaison1.FontSize = 12;
                this.lblLoyerMaison2.FontSize = 12;
                this.lblLoyerMaison3.FontSize = 12;
                this.lblLoyerMaison4.FontSize = 12;
                this.lblLoyerHotel.FontSize = 12;
                this.lblCoutMaison.FontSize = 12;
                this.lblCoutHotel.FontSize = 12;
                this.lblCoutProprite.FontSize = 15;

                this.lblBase.FontSize = 12;
                this.lblMaison1.FontSize = 12;
                this.lblMaison2.FontSize = 12;
                this.lblMaison3.FontSize = 12;
                this.lblMaison4.FontSize = 12;
                this.lblHotel.FontSize = 12;

                //this.lblLoyerBase.IsVisible = true;
                //this.lblLoyerMaison1.IsVisible = true;
                //this.lblLoyerMaison2.IsVisible = true;
                //this.lblLoyerMaison3.IsVisible = true;
                //this.lblLoyerMaison4.IsVisible = true;
                //this.lblLoyerHotel.IsVisible = true;
                //this.lblCoutMaison.IsVisible = true;
                //this.lblCoutHotel.IsVisible = true;
                //this.lblCoutProprite.IsVisible = true;
            }
            else
            {
                this.lblTitleCard.FontSize = 3;
                this.lblLoyerBase.FontSize = 1;
                this.lblLoyerMaison1.FontSize = 1;
                this.lblLoyerMaison2.FontSize = 1;
                this.lblLoyerMaison3.FontSize = 1;
                this.lblLoyerMaison4.FontSize = 1;
                this.lblLoyerHotel.FontSize = 1;
                this.lblCoutMaison.FontSize = 1;
                this.lblCoutHotel.FontSize = 1;
                this.lblCoutProprite.FontSize = 3;

                this.lblBase.FontSize = 1;
                this.lblMaison1.FontSize = 1;
                this.lblMaison2.FontSize = 1;
                this.lblMaison3.FontSize = 1;
                this.lblMaison4.FontSize = 1;
                this.lblHotel.FontSize = 1;

                //this.lblLoyerBase.IsVisible = false;
                //this.lblLoyerMaison1.IsVisible = false;
                //this.lblLoyerMaison2.IsVisible = false;
                //this.lblLoyerMaison3.IsVisible = false;
                //this.lblLoyerMaison4.IsVisible = false;
                //this.lblLoyerHotel.IsVisible = false;
                //this.lblCoutMaison.IsVisible = false;
                //this.lblCoutHotel.IsVisible = false;
                //this.lblCoutProprite.IsVisible = false;
            }
        }
    }
}
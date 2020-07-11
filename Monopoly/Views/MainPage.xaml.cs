using Monopoly.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Monopoly.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //
        // Bouton commencer la partie
        //
        async void OnBtnCommencerClicked(object sender, EventArgs args)
        {
            try
            {
                // Ouvrir une page de joueur (PlayerPage)
                await Navigation.PushAsync(new PlayerPage(this.EnPseudo.Text));
                Navigation.RemovePage(this);

            }
            catch (Exception e)
            {
                await DisplayAlert("Warning", e.Message, "OK");
            }
        }
    }
}
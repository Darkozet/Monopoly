using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Monopoly.Views;
using Monopoly.Classes.Board;
using Monopoly.Classes.Card;
using Monopoly.Classes;

namespace Monopoly
{
    public partial class App : Application
    {
        Game game;
        Player player1;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

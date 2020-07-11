using Monopoly.Classes;
using Monopoly.Classes.Board;
using Monopoly.Classes.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Monopoly.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPage : ContentPage
    {
        //
        // Variables
        //
        #region Variables
        Classes.Game game;
        Classes.Player player1;
        #endregion

        public PlayerPage(string strPseudo)
        {
            InitializeComponent();

            // Création jeu
            game = new Classes.Game();
            // Création joueur
            player1 = new Classes.Player(strPseudo, 1, GetSQuare("depart"));

            // Initialisation affichage
            InitInfosPlayer();
        }

        // Initialisation informations joueur
        private void InitInfosPlayer()
        {
            this.lblPlayerBudget.Text = this.player1.iBudget.ToString();
            this.lblPlayerName.Text = this.player1.strName;
            this.lblPlayerNumber.Text = "Joueur " + this.player1.iPlayerNumber;

            this.InitializeListCards(this.player1);
        }

        private void InitializeListCards(Player player)
        {
            if (player.liStreet.Count + player.liStation.Count + player.liSpecial.Count == 0)
                this.lblNoProperty.IsVisible = true;
            else
            {
                this.lblNoProperty.IsVisible = false;

                // Street
                foreach (var item in player.liStreet)
                {
                    PropertyCardView pcv = new PropertyCardView(item);
                    this.StackGallery.Children.Add(pcv);
                }
            }
        }

        //
        // Partie qui concerne le lancer de dés
        //
        #region Lancer de des
        // Fonction sur le tapped de l'image de lancer de dés
        async void OnImgLancerDesTapped(object sender, EventArgs args)
        {
            try
            {
                // Recuperer l'image
                Image image = (Image)sender;

                // Generation de nombres aléatoir
                int iNumberDice1;
                int iNumberDice2;

                // Assigniation
                List<int> liRandomNumber = this.player1.FaireLancerDes();
                iNumberDice1 = liRandomNumber[0];
                iNumberDice2 = liRandomNumber[1];

                // Afficher celui des dés
                this.DisplayDice(iNumberDice1, iNumberDice2);

            }
            catch (Exception e)
            {
                await DisplayAlert("Warning", e.Message, "OK");
            }
        }

        async void DisplayLauncherDice()
        {
            // On rend visible le content de lancer de dés
            this.ContentLaunchDice.IsVisible = true;

            // Animation opacity grid et image
            double dScale = 0.67;
            double dScale1 = this.imgResultDe1.Scale;
            double dScale2 = this.imgResultDe2.Scale;

            // Animation
            await Task.WhenAll(
                this.ContentLaunchDice.FadeTo(1, 2000),
                this.GridResultDice.FadeTo(0, 2000),
                this.imgLancerDes.FadeTo(1, 2000),
                this.imgLancerDes.ScaleTo(dScale * 1.5, 2000),
                this.imgResultDe1.FadeTo(0, 2000),
                this.imgResultDe1.ScaleTo(dScale1 * 0.00015, 2000),
                this.imgResultDe2.FadeTo(0, 2000),
                this.imgResultDe2.ScaleTo(dScale2 * 0.00015, 2000));

            // Assignation du label du resultat
            this.lblResultDice.Text = "Vous avez fait ";

            // On rend visible le content view avec les images des des
            this.GridResultDice.IsVisible = false;
        }
        #endregion


        //
        // Partie qui concerne l'affichage des dés
        //
        #region Affichage des dés
        async void DisplayDice(int NumberDice1, int NumberDice2)
        {
            // On rend visible le content view avec les images des des
            this.GridResultDice.IsVisible = true;

            // Assignation des images
            // Dé 1
            this.AssignImage(NumberDice1, this.imgResultDe1);
            // Dé 2
            this.AssignImage(NumberDice2, this.imgResultDe2);

            // Animation opacity grid et image
            double dScale = this.imgLancerDes.Scale;
            double dScale1 = 0.67;
            double dScale2 = 0.67;

            // Reset angle image
            this.imgResultDe1.RotationY = 0;
            this.imgResultDe2.RotationY = 0;

            // Modifier square player
            this.MovePlayer(NumberDice1 + NumberDice2);

            // Affichage de la case d'arrivée
            this.lblResultDice.Text = "Vous avez fait " + (NumberDice1 + NumberDice2).ToString() + Environment.NewLine +
                "Vous êtes ici : " + player1.square.nom;

            // Animation
            await Task.WhenAll(
                this.ContentLaunchDice.FadeTo(0, 2000),
                this.GridResultDice.FadeTo(1, 2000),
                this.imgLancerDes.FadeTo(0, 2000),
                this.imgLancerDes.ScaleTo(dScale * 0.00015, 2000),
                this.imgResultDe1.FadeTo(1, 2000),
                this.imgResultDe1.ScaleTo(dScale1 * 1.5, 2000),
                this.imgResultDe1.RotateYTo(3600, 2000),
                this.imgResultDe2.FadeTo(1, 2000),
                this.imgResultDe2.ScaleTo(dScale2 * 1.5, 2000),
                this.imgResultDe2.RotateYTo(3600, 2000));

            // On rend invisible le content de lancer de dés
            this.ContentLaunchDice.IsVisible = false;

            // Afficher bouton fin tour
            this.btnFinTour.IsVisible = true;

            // Action du joueur
            this.PlayerAction(this.player1);

            // Rejouer
            // this.DisplayLauncherDice();
        }

        // Fonction qui permet d'assigner la source d'une image
        private void AssignImage(int number, Image image)
        {
            try
            {
                switch (number)
                {
                    case 1:
                        image.Source = ImageSource.FromFile("Dice1.png");
                        break;
                    case 2:
                        image.Source = ImageSource.FromFile("Dice2.png");
                        break;
                    case 3:
                        image.Source = ImageSource.FromFile("Dice3.png");
                        break;
                    case 4:
                        image.Source = ImageSource.FromFile("Dice4.png");
                        break;
                    case 5:
                        image.Source = ImageSource.FromFile("Dice5.png");
                        break;
                    case 6:
                        image.Source = ImageSource.FromFile("Dice6.png");
                        break;
                    default:
                        image.Source = ImageSource.FromFile("Dice1.png");
                        break;
                }
            }
            catch (Exception e)
            {
                DisplayAlert("Warning", e.Message, "OK");
            }
        }
        #endregion


        // Recupération d'un square
        private Classes.Board.Square GetSQuare(string strSquareName)
        {
            return (from square in this.game.board.square
                    where square.nom == strSquareName
                    select square).FirstOrDefault();
        }
        private Classes.Board.Square GetSQuare(int iSquareNumber)
        {
            return (from square in this.game.board.square
                    where square.numero == iSquareNumber
                    select square).FirstOrDefault();
        }


        //
        // Méthodes du joueur
        //
        #region Joueur
        // Déplacer le joueur
        private void MovePlayer(int iSumDice)
        {
            // Calculer la position du nouveau square
            int iNewSquare = this.player1.square.numero + iSumDice;
            iNewSquare = (iNewSquare > 40) ? iNewSquare - 40 : iNewSquare;

            // Modifier la square du player
            this.player1.square = GetSQuare(iNewSquare);
        }

        // Proposer Action
        private void PlayerAction(Player player)
        {
            try
            {
                switch (player.square.type)
                {
                    // Si c'est une propriete
                    case "propriete":
                    case "speciale":
                    case "gare":
                        // Prix correspondante à la square depuis les carte
                        int prixCase = 0;

                        // Demander l'achate si le budget est ok
                        bool cardExist = (from card in game.card.property.Rue
                                          where card.nom == player.square.nom
                                          select card).Any();
                        if (!cardExist)
                        {
                            cardExist = (from card in game.card.property.gare
                                         where card.nom == player.square.nom
                                         select card).Any();

                            if (!cardExist)
                            {
                                cardExist = (from card in game.card.property.speciale
                                             where card.nom == player.square.nom
                                             select card).Any();

                                if (!cardExist)
                                {

                                }
                                else
                                {
                                    Special sp = (from card in game.card.property.speciale
                                                  where card.nom == player.square.nom
                                                  select card).FirstOrDefault();
                                    prixCase = sp.prix;
                                }
                            }
                            else
                            {
                                Station st = (from card in game.card.property.gare
                                              where card.nom == player.square.nom
                                              select card).FirstOrDefault();
                                prixCase = st.prix;
                            }
                        }
                        else
                        {
                            Street s = (from card in game.card.property.Rue
                                        where card.nom == player.square.nom
                                        select card).FirstOrDefault();
                            prixCase = s.prix;
                        }

                        if (player.iBudget >= prixCase && cardExist)
                        {
                            this.btnAcheter.IsVisible = true;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                DisplayAlert("warning", e.Message, "OK");
            }
        }

        // Achat
        private async void btnAcheter_Clicked(object sender, EventArgs args)
        {
            // Demande d'achat
            var result = await DisplayAlert("Achat", "Voulez-vous acheter " + player1.square.nom, "Oui", "Non"); // since we are using async, we should specify the DisplayAlert as awaiting.
            if (result) // if it's equal to Ok
            {
                switch (player1.square.type)
                {
                    case "propriete":
                        Street s = (from card in game.card.property.Rue
                                    where card.nom == player1.square.nom
                                    select card).FirstOrDefault();
                        this.game.card.property.Rue.Remove(s);
                        player1.liStreet.Add(s);
                        player1.iBudget -= s.prix;
                        break;
                    case "speciale":
                        Special sp = (from card in game.card.property.speciale
                                      where card.nom == player1.square.nom
                                      select card).FirstOrDefault();
                        this.game.card.property.speciale.Remove(sp);
                        player1.liSpecial.Add(sp);
                        player1.iBudget -= sp.prix;
                        break;
                    case "gare":
                        Station st = (from card in game.card.property.gare
                                      where card.nom == player1.square.nom
                                      select card).FirstOrDefault();
                        this.game.card.property.gare.Remove(st);
                        player1.liStation.Add(st);
                        player1.iBudget -= st.prix;
                        break;
                }

                // Reset affichage
                this.InitInfosPlayer();
            }
            else // if it's equal to Cancel
            {
                return; // just return to the page and do nothing.
            }
        }

        // Fin du tour
        private void btnFinTour_Clicked(object sender, EventArgs e)
        {
            // Fin du tour => relancer les dès
            this.DisplayLauncherDice();
        }

        #endregion







        public async void OnImageNameTapped(object sender, EventArgs args)
        {
            try
            {
                Image i = (Image)sender;
                ContentView cv = (ContentView)this.FindByName("MainContent");
                cv.BackgroundColor = i.BackgroundColor;


                await Navigation.PushAsync(new MainPage());
                Navigation.RemovePage(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
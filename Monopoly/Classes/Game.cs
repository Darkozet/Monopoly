using Monopoly.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Monopoly.Classes.Board;
using Newtonsoft.Json;
using Monopoly.Classes.Card;
using Monopoly.Classes.Card.Property;

namespace Monopoly.Classes
{
    class Game
    {
        public Board.Board board;
        public Card.Card card;

        // Constructor
        public Game()
        {
            try
            {
                card = new Card.Card();

                // Recuperation fichiers json
                string jsonSquareName = "Files.MonopolyCases.json";

                var assembly = typeof(MainPage).GetTypeInfo().Assembly;

                Stream streamBoard = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonSquareName}");

                // Plateau
                string jsonToStringBoard = "";
                using (var reader = new StreamReader(streamBoard))
                {
                    jsonToStringBoard = reader.ReadToEnd();
                }
                board = JsonConvert.DeserializeObject<Board.Board>(jsonToStringBoard);

                Console.WriteLine("Ours Bleu");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

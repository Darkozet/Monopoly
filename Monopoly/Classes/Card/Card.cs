using Monopoly.Classes.Card.Property;
using Monopoly.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Monopoly.Classes.Card
{
    public class Card
    {
        // Listes
        public PropertiesCard property;
        public ActionCard action;

        public Card()
        {
            try
            {
                // Recuperation fichiers json
                string jsonProprietesName = "Files.MonopolyProprietes.json";
                string jsonActionsName = "Files.MonopolyCartes.json";

                var assembly = typeof(MainPage).GetTypeInfo().Assembly;

                Stream streamProp = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonProprietesName}");
                Stream streamAct = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonActionsName}");

                // Propriétés
                string jsonToStringProp = "";
                using (var reader = new StreamReader(streamProp))
                {
                    jsonToStringProp = reader.ReadToEnd();
                }
                property = JsonConvert.DeserializeObject<PropertiesCard>(jsonToStringProp);

                // Actions
                string jsonToStringAct = "";
                using (var reader = new StreamReader(streamAct))
                {
                    jsonToStringAct = reader.ReadToEnd();
                }
                action = JsonConvert.DeserializeObject<ActionCard>(jsonToStringAct);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

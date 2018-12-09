using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VulnerabilitiesApp.Models
{
    public class VulnerabilitiesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<VulnerabilitiesContext>
    {
        protected override void Seed(VulnerabilitiesContext context)
        {
            var categorii = new List<Categorie>
            {
                new Categorie
                {
                    Nume = "Imobiliare"
                },
                new Categorie
                {
                    Nume = "Vanzare"
                },
                new Categorie
                {
                    Nume = "Inchiriere"
                },
                new Categorie
                {
                    Nume = "Ofer"
                },
                new Categorie
                {
                    Nume = "Caut"
                },
                new Categorie
                {
                    Nume = "Automobile"
                }
            };

            categorii.ForEach(c => context.Categorii.Add(c));
            context.SaveChanges();

            var valute = new List<Valuta>
            {
                new Valuta
                {
                    Nume = "RON"
                },
                new Valuta
                {
                    Nume = "EUR"
                }
            };

            valute.ForEach(v => context.Valute.Add(v));
            context.SaveChanges();

            var anunturi = new List<Anunt>
            {
                new Anunt
                {
                    Titlu = "Apartament 3 camere",
                    Activ = true,
                    Data = new DateTime(),
                    Descriere = "Apartament nou situat in zona Tineretului",
                    IdCategorie = 1,
                    IdSubCategorie = 3,
                    Pret = 1000,
                    IdValuta = 1
                }
            };

            anunturi.ForEach(a => context.Anunturi.Add(a));
            context.SaveChanges();

            var utilizatori = new List<Utilizator>
            {
                new Utilizator
                {
                    Nume = "Vladau",
                    Prenume = "Denisa",
                    Telefon = "0755224161",
                    Email = "denisa.vladau@yahoo.com"
                }
            };

            utilizatori.ForEach(u => context.Utilizatori.Add(u));
            context.SaveChanges();

            var anunturiUtilizatori = new List<AnuntUtilizator>
            {
                new AnuntUtilizator
                {
                    IdAnunt = 1,
                    IdUtilizator = 1
                }
            };

            anunturiUtilizatori.ForEach(au => context.AnunturiUtilizatori.Add(au));
            context.SaveChanges();
        }
    }
}

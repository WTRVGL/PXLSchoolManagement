using PXLSchoolManagement.Models;

namespace PXLSchoolManagement.Data
{
    public static class DatabaseInitializer
    {
        public static void InitializeDb(DataContext context)
        {
            if (context.Studenten.Any())
            {
                return;
            }

            var gebruikers = new List<Gebruiker>
            {
                new Gebruiker {Voornaam = "Wouter", Naam = "Vangeel", Email = "wouter_vangeel4@hotmail.com"},
                new Gebruiker {Voornaam = "Dieter", Naam = "Caerpentier", Email = "dieter.carpentier@gmail.com"},
                new Gebruiker {Voornaam = "Pieterjan", Naam = "Mahieu", Email = "pieterjan.mahieu@pxl.be"},
                new Gebruiker {Voornaam = "Wout", Naam = "Dhondt", Email = "wouter.dhont@hotmail.be"},
                new Gebruiker {Voornaam = "Steve", Naam = "Vandewiele", Email = "steve_vandewiele@pxl.be"},
                new Gebruiker {Voornaam = "Ilke", Naam = "Mortier", Email = "ilke.mortier@pxl.be"},
                new Gebruiker {Voornaam = "Anke", Naam = "Beyls", Email = "anke-beyls@hotmail.com"},
                new Gebruiker {Voornaam = "Mélodie", Naam = "De Maseneer", Email = "melodie_dm@pxl.be"},
                new Gebruiker {Voornaam = "Cathy", Naam = "Blomme", Email = "cathyblomme@pxl.be"},
                new Gebruiker {Voornaam = "Jeffry", Naam= "Steegmans", Email= "jeffrey.steegmans@pxl.be"},
                new Gebruiker {Voornaam = "Kristof", Naam = "Palmaers", Email = "kristof.palmaers@pxl.be"},
                new Gebruiker {Voornaam = "Paul", Naam = "Dox", Email = "paul.dox@pxl.be"},
                new Gebruiker {Voornaam = "Patricia", Naam = "Briers", Email = "patricia.briers@pxl.be"}
            };

            context.Gebruikers.AddRange(gebruikers);
            context.SaveChanges();

            var vakken = new List<Vak>
            {
                new Vak { Studiepunten= 5, VakNaam= "C# Web"},
                new Vak { Studiepunten= 4, VakNaam= "Web Advanced"},
                new Vak { Studiepunten= 6, VakNaam= "C# Advanced"},
                new Vak { Studiepunten= 2, VakNaam= "Data Essentials"},
                new Vak { Studiepunten= 3, VakNaam= "Data Advanced"},
                new Vak { Studiepunten= 4, VakNaam= "C# Mobile"},
                new Vak { Studiepunten= 5, VakNaam= "C# Essentials"},

            };

            context.Vakken.AddRange(vakken);
            context.SaveChanges();

            var academiejaren = new List<Academiejaar>
            {
                new Academiejaar { Startdatum= DateTime.Parse("2013-09-14")},
                new Academiejaar { Startdatum= DateTime.Parse("2014-09-14")},
                new Academiejaar { Startdatum= DateTime.Parse("2015-09-14")},
                new Academiejaar { Startdatum= DateTime.Parse("2016-09-14")},
                new Academiejaar { Startdatum= DateTime.Parse("2017-09-14")},
                new Academiejaar { Startdatum= DateTime.Parse("2018-09-14")},
                new Academiejaar { Startdatum= DateTime.Parse("2019-09-14")},
                new Academiejaar { Startdatum= DateTime.Parse("2020-09-14")},
                new Academiejaar { Startdatum= DateTime.Parse("2021-09-14")},
                new Academiejaar { Startdatum= DateTime.Parse("2022-09-14")},

            };

            context.Academiejaren.AddRange(academiejaren);
            context.SaveChanges();

            var inschrijvingen = new List<Inschrijving>
            {
                new Inschrijving {
                    AcademiejaarId = 10, 
                    Vak = vakken.FirstOrDefault<Vak>(vak => vak.VakNaam == "C# Web"), 
                    Studenten = new List<Student>(),
                    Vaklectors = new List<Vaklector>()
                },
                new Inschrijving {
                    AcademiejaarId = 10,
                    Vak = vakken.FirstOrDefault<Vak>(vak => vak.VakNaam == "Data Essentials"),
                    Studenten = new List<Student>(),
                    Vaklectors = new List<Vaklector>()
                },
                new Inschrijving {
                    AcademiejaarId = 10,
                    Vak = vakken.FirstOrDefault<Vak>(vak => vak.VakNaam == "C# Advanced"),
                    Studenten = new List<Student>(),
                    Vaklectors = new List<Vaklector>()
                },
                new Inschrijving {
                    AcademiejaarId = 10,
                    Vak = vakken.FirstOrDefault<Vak>(vak => vak.VakNaam == "Web Advanced"),
                    Studenten = new List<Student>(),
                    Vaklectors = new List<Vaklector>()
                },
                new Inschrijving {
                    AcademiejaarId = 10,
                    Vak = vakken.FirstOrDefault<Vak>(vak => vak.VakNaam == "C# Essentials"),
                    Studenten = new List<Student>(),
                    Vaklectors = new List<Vaklector>()
                }

            };


            context.Inschrijvingen.AddRange(inschrijvingen);
            context.SaveChanges();

            var studenten = new List<Student>
            {
                new Student { GebruikerId = gebruikers[0].Id, Handboeken = new List<Handboek>(), Inschrijvingen = new List<Inschrijving>()},
                new Student { GebruikerId = gebruikers[1].Id, Handboeken = new List<Handboek>(), Inschrijvingen = new List<Inschrijving>()},
                new Student { GebruikerId = gebruikers[2].Id, Handboeken = new List<Handboek>(), Inschrijvingen = new List<Inschrijving>()},
                new Student { GebruikerId = gebruikers[3].Id, Handboeken = new List<Handboek>(), Inschrijvingen = new List<Inschrijving>()},
                new Student { GebruikerId = gebruikers[4].Id, Handboeken = new List<Handboek>(), Inschrijvingen = new List<Inschrijving>()},
                new Student { GebruikerId = gebruikers[5].Id, Handboeken = new List<Handboek>(), Inschrijvingen = new List<Inschrijving>()},
                new Student { GebruikerId = gebruikers[6].Id, Handboeken = new List<Handboek>(), Inschrijvingen = new List<Inschrijving>()},
                new Student { GebruikerId = gebruikers[7].Id, Handboeken = new List<Handboek>(), Inschrijvingen = new List<Inschrijving>()},
                new Student { GebruikerId = gebruikers[8].Id, Handboeken = new List<Handboek>(), Inschrijvingen = new List<Inschrijving>()},

            };

            // Voeg voor elke Student willekeurige inschrijving toe.
            studenten.ForEach(student =>
            {
                var rngInschrijvingen = new Random().Next(inschrijvingen.Count);
                for (int i = 0; i < rngInschrijvingen; i++)
                {
                    student.Inschrijvingen.Add(inschrijvingen[i]);
                }
            });

            context.Studenten.AddRange(studenten);
            context.SaveChanges();

            var lectoren = new List<Lector>(){
                new Lector { Gebruiker = gebruikers.First<Gebruiker>(g => g.Voornaam == "Jeffry") },
                new Lector { Gebruiker = gebruikers.First<Gebruiker>(g => g.Voornaam == "Kristof") },
                new Lector { Gebruiker = gebruikers.First<Gebruiker>(g => g.Voornaam == "Paul") },
                new Lector { Gebruiker = gebruikers.First<Gebruiker>(g => g.Voornaam == "Patricia") }
            };

            context.Lectoren.AddRange(lectoren);
            context.SaveChanges();

            var vaklectoren = new List<Vaklector>()
            {
                new Vaklector { LectorId = 1, Inschrijvingen = new List<Inschrijving>() },
                new Vaklector { LectorId = 2, Inschrijvingen = new List<Inschrijving>() },
                new Vaklector { LectorId = 3, Inschrijvingen = new List <Inschrijving >() },
                new Vaklector { LectorId = 4, Inschrijvingen = new List <Inschrijving >() }
            };

            vaklectoren[0].Inschrijvingen.Add(inschrijvingen[3]);
            vaklectoren[1].Inschrijvingen.Add(inschrijvingen[0]);

            vaklectoren[2].Inschrijvingen.Add(inschrijvingen[2]);
            vaklectoren[2].Inschrijvingen.Add(inschrijvingen[4]);

            vaklectoren[3].Inschrijvingen.Add(inschrijvingen[1]);

            context.Vaklectoren.AddRange(vaklectoren);
            context.SaveChanges();

            var handboeken = new List<Handboek>()
            {
                new Handboek {
                    Kostprijs = 25, 
                    Studenten = new List<Student>(), 
                    Titel = "C# Web voor Dummies", 
                    VakId = 1,
                    Afbeelding = "",
                    UitgifteDatum = new DateTime(2012, 1, 5)
                },
                new Handboek {
                    Kostprijs = 30,
                    Studenten = new List<Student>(),
                    Titel = "JavaScript voor gevorderden",
                    VakId = 2,
                    Afbeelding = "",
                    UitgifteDatum = new DateTime(2016,2, 5)
                }
            };

            context.Handboeken.AddRange(handboeken);
            context.SaveChanges();

        }
    }
}

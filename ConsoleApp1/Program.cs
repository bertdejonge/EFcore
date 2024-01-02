using Microsoft.IdentityModel.Protocols;
using ParkBusinessLayer.Beheerders;
using ParkBusinessLayer.Model;
using ParkDataLayer;
using ParkDataLayer.Repositories;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using Spectre.Console;
using Spectre.Console.Rendering;


namespace ConsoleApp1 {
    public class Program {
        static void Main(string[] args) {
            DatabaseInitializer.InitializeDatabase();

            BeheerHuizen huisManager = new BeheerHuizen(new HuizenRepositoryEF());
            BeheerHuurders huurderManager = new BeheerHuurders(new HuurderRepositoryEF());
            BeheerContracten contractManager = new BeheerContracten(new ContractenRepositoryEF());

            //Voorbeeld van Tom
            //Console.WriteLine("parkbeheer!");

            //Park p = new("p2", "Binnenhoeve", "Gent");
            //bh.VoegNieuwHuisToe("parklaan", 1, p);
            //bh.VoegNieuwHuisToe("parklaan", 2, p);
            //bh.VoegNieuwHuisToe("parklaan", 3, p);
            //var x = bh.GeefHuis(1);
            //x.ZetStraat("Kerkstraat");
            //x.ZetNr(11);
            //bh.UpdateHuis(x);
            //bh.ArchiveerHuis(x);
            ////Huis h1 = new Huis();
            //ParkEF pdb = new("p1", "naam", "locatie");
            //HuisEF hdb = new("straat", 5, true);
            //hdb.Park = pdb;
            //ctx.Huizen.Add(hdb);
            //ctx.SaveChanges();
            ////huurder
            //bhuur.VoegNieuweHuurderToe("jos", new Contactgegevens("email1", "tel", "adres"));
            //bhuur.VoegNieuweHuurderToe("jef", new Contactgegevens("email2", "tel", "adres"));

            //Huurperiode hp = new(DateTime.Now, 10);
            //Huurder h = new(2, "Jos", new Contactgegevens("email1", "tel", "adres"));
            //p = new Park("p1", "Buitenhoeve", "Deinze");
            //Huis huis = new(1, "Kerkstraat", 5, true, p);
            //bc.MaakContract("c2", hp, h, huis);

            //var y = bc.GeefContract("c2");
            //var t = bh.GeefHuis(1);
            //Console.WriteLine(t);            

            for (int i = 0; i < 3; i++) {
                Console.Clear();
                AnsiConsole.Write(new FigletText("PARKBEHEER").Color(Color.Maroon));
                Console.WriteLine();
                if(i == 0) {
                    AnsiConsole.MarkupLine("[bold]Start Parkbeheer![/]\n");
                } else {
                    AnsiConsole.MarkupLine("[bold]Continue Parkbeheer![/]\n");
                }
                AnsiConsole.MarkupLine("[maroon]====================================================================[/]");
                AnsiConsole.MarkupLine("[maroon]====================================================================[/]\n \n");

                var choice = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Which part of the demo would you like to see?")
                            .PageSize(10)
                            .MoreChoicesText("[grey](Navigate by using the arrow keys.)[/]")
                            .AddChoices(new[] {
                            "Huisbeheer", "Huurderbeheer", "Contractbeheer"
                            }));

                AnsiConsole.MarkupLine($"[bold green3_1]Let's get started with {choice}![/]");
                
                Thread.Sleep(3000);
                Console.Clear();

                if (choice == "Huisbeheer") {

                    // BEHEER HUIZEN
                    AnsiConsole.MarkupLine("[underline bold blue]BEHEER HUIZEN[/]");
                    AnsiConsole.MarkupLine("[teal]Huizen toevoegen: [/]\n");

                    // Park & huizen toevoegen
                    Park park = new Park("CP-EH-3990", "Centerparcs Erperheide", "Erperheidestraat 2, 3990 Peer");
                    huisManager.VoegNieuwHuisToe("Erperheidestraat", 101, park);
                    huisManager.VoegNieuwHuisToe("Erperheidestraat", 102, park);
                    huisManager.VoegNieuwHuisToe("Erperheidestraat", 103, park);
                    Console.WriteLine("Huizen toegevoegd.");

                    AnsiConsole.MarkupLine("[red]--------------------------------------------------------------------[/]\n");

                    // PArk & Huizen opvragen
                    AnsiConsole.MarkupLine("[teal]Huizen opvragen: [/]\n");

                    Huis huis = huisManager.GeefHuis(1);
                    Huis huis1 = huisManager.GeefHuis(2);
                    Huis huis2 = huisManager.GeefHuis(3);
                    AnsiConsole.MarkupLine($"[underline]{park.Naam} met huizen:[/]");
                    Console.WriteLine($"  {huis}\n  {huis1}\n  {huis2} \n");

                    AnsiConsole.MarkupLine("[red]--------------------------------------------------------------------[/]\n");

                    // Huis updaten
                    AnsiConsole.MarkupLine("[teal]Huis updaten: [/]\n");
                    var updated = huisManager.GeefHuis(1);
                    updated.ZetNr(1);
                    updated.ZetStraat("Herpereidestraat");
                    huisManager.UpdateHuis(updated);
                    Console.WriteLine(updated);

                    AnsiConsole.MarkupLine("[red]--------------------------------------------------------------------[/]\n");

                    // Delete huis
                    AnsiConsole.MarkupLine("[teal]Huis archiveren: [/]\n");
                    huisManager.ArchiveerHuis(updated);
                    Console.WriteLine($"{updated}\n");

                    AnsiConsole.MarkupLine("[darkred]====================================================================[/]");
                    AnsiConsole.MarkupLine("[darkred]====================================================================[/]\n");
                }

                if (choice == "Huurderbeheer") {

                    // BEHEER HUURDER
                    AnsiConsole.MarkupLine("[underline bold blue]BEHEER HUURDERS[/]");
                    AnsiConsole.MarkupLine("[teal]Huurder Toevoegen: [/]\n");

                    // Voeg huurder toe & toon huurder
                    if (huurderManager.GeefHuurder(1) == null) {

                        huurderManager.VoegNieuweHuurderToe("Xavier", new Contactgegevens("xavierw@ab.be", "0478162356", "Zeugsteeg 23"));
                        Console.WriteLine(huurderManager.GeefHuurder(1));
                        Console.WriteLine();

                        huurderManager.VoegNieuweHuurderToe("Carmen", new Contactgegevens("carmen@libelle.be", "0471352645", "Zeugsteeg 23"));
                        Console.WriteLine(huurderManager.GeefHuurder(2));
                        Console.WriteLine();
                    } else {
                        huurderManager.VoegNieuweHuurderToe("Xavier", new Contactgegevens("xavierw@ab.be", "0478162356", "Zeugsteeg 23"));
                        Console.WriteLine(huurderManager.GeefHuurder(2));
                        Console.WriteLine();

                        huurderManager.VoegNieuweHuurderToe("Carmen", new Contactgegevens("carmen@libelle.be", "0471352645", "Zeugsteeg 23"));
                        Console.WriteLine(huurderManager.GeefHuurder(2));
                        Console.WriteLine();
                    }                    

                    Console.WriteLine();

                    // Huurders met 'naam' opvragen
                    AnsiConsole.MarkupLine($"[underline]Huurders met de naam Xavier:[/]");
                    huurderManager.GeefHuurders("xavier").ForEach(h => Console.WriteLine(h));

                    AnsiConsole.MarkupLine("[red]--------------------------------------------------------------------[/]\n");

                    // Huurder met ID opvragen
                    AnsiConsole.MarkupLine($"[underline]Huurders met ID 1:[/]");
                    Console.WriteLine(huurderManager.GeefHuurder(1));

                    // Update huurder
                    AnsiConsole.MarkupLine("[teal]Huurder updaten: [/]\n");

                    Huurder huurder = huurderManager.GeefHuurders("carmen")[0];
                    huurder.ZetContactgegevens(new Contactgegevens("carmen@story.be", "044444444", "Steugzeeg 18"));
                    huurderManager.UpdateHuurder(huurder);
                    Console.WriteLine(huurder);

                    AnsiConsole.MarkupLine("[darkred]====================================================================[/]");
                    AnsiConsole.MarkupLine("[darkred]====================================================================[/]\n");
                }

                if (choice == "Contractbeheer") {

                    AnsiConsole.MarkupLine("[underline bold blue]BEHEER CONTRACTEN[/]");
                    AnsiConsole.MarkupLine("[teal]Contract Toevoegen: [/]\n");

                    huurderManager.VoegNieuweHuurderToe("Jan", new Contactgegevens("jan@dejan.be", "04478-JAN", "Sint-Jansstraat 18, Jansberg"));
                    Huurder jan = huurderManager.GeefHuurders("jan")[0];

                    Huis huis;
                    if (huisManager.GeefHuis(1) == null) {
                        huisManager.VoegNieuwHuisToe("Erperheidestraat", 104, new Park("CenterParcs-EH", "Centerparcs Erperheide", "Erperheidestraat 2, 3990 Peer"));
                        huis = huisManager.GeefHuis(1);
                    } else {
                        huis = huisManager.GeefHuis(1);
                    }


                    // Contract toevoegen
                    Huurperiode huurperiode = new Huurperiode(new(2024,02,12), 45);
                    contractManager.MaakContract("C1-CW-EH1", huurperiode, jan, huis);
                    Console.WriteLine(contractManager.GeefContract("C1-CW-EH1"));

                    Huurperiode huurperiode1 = new Huurperiode(DateTime.Now.AddDays(5), 20);
                    contractManager.MaakContract("C2-CW-EH1", huurperiode1, jan, huis);
                    Console.WriteLine(contractManager.GeefContract("C2-CW-EH1"));

                    AnsiConsole.MarkupLine("[red]--------------------------------------------------------------------[/]\n");

                    AnsiConsole.MarkupLine("[teal]Contract updaten: [/]\n");

                    Huurperiode updatedHuurperiode = new Huurperiode(DateTime.Now, 50);
                    Huurcontract huurcontract = contractManager.GeefContract("C2-CW-EH1");
                    huurcontract.ZetHuurperiode(updatedHuurperiode);
                    contractManager.UpdateContract(huurcontract);
                    Console.WriteLine(huurcontract);

                    AnsiConsole.MarkupLine("[red]--------------------------------------------------------------------[/]\n");


                    AnsiConsole.MarkupLine("[teal]Contracten opvragen: [/]\n");
                    contractManager.GeefContracten(DateTime.Now, DateTime.Now.AddDays(356)).ForEach(h => Console.WriteLine(h));

                    AnsiConsole.MarkupLine("[teal]Contracten opvragen (enkel startdatum): [/]\n");
                    contractManager.GeefContracten(DateTime.Now, null).ForEach(h => Console.WriteLine(h));

                    AnsiConsole.MarkupLine("[red]--------------------------------------------------------------------[/]\n");

                    AnsiConsole.MarkupLine("[teal]Contracten annuleren: [/]\n");
                    Huurcontract cancelledContract = contractManager.GeefContract("C1-CW-EH1");
                    contractManager.AnnuleerContract(cancelledContract);

                    string id = cancelledContract.Id;
                    cancelledContract = contractManager.GeefContract("C1-CW-EH1");
                    if (cancelledContract == null) {
                        Console.WriteLine($"Contract geannuleerd met Id: {id}\n");
                    }

                    AnsiConsole.MarkupLine("[darkred]====================================================================[/]");
                    AnsiConsole.MarkupLine("[darkred]====================================================================[/]\n");
                }
            }

            Console.Clear();
            AnsiConsole.Write(new FigletText("The end").Color(Color.DarkRed).Centered());


        }
    }
}
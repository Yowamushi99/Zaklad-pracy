using System;

class Pracownik
{
    public int Id { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public DateTime DataUrodzenia { get; set; }
    public string Stanowisko { get; set; }
    public decimal PensjaStala { get; set; }
    public decimal StawkaGodzinowa { get; set; }

    public decimal ObliczWynagrodzenie(int dniPracy)
    {
        decimal podstawa = 0;

        if (Stanowisko == "urzednik")
        {
            podstawa = PensjaStala * (dniPracy == 20 ? 1.0m : 0.8m);
        }
        else // pracownik fizyczny
        {
            podstawa = dniPracy * StawkaGodzinowa * 8;
        }

        decimal wynagrodzenieBrutto = podstawa;
        decimal podatek = (DateTime.Now.Year - DataUrodzenia.Year) > 26 ? 0.18m * wynagrodzenieBrutto : 0;
        decimal wynagrodzenieNetto = wynagrodzenieBrutto - podatek;

        Console.WriteLine($"Wynagrodzenie brutto: {wynagrodzenieBrutto}");
        Console.WriteLine($"Podatek: {podatek}");
        Console.WriteLine($"Wynagrodzenie netto: {wynagrodzenieNetto}");

        return wynagrodzenieBrutto;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Pracownik[] pracownicy = new Pracownik[]
        {
            new Pracownik { Id = 1, Imie = "Jan", Nazwisko = "Nowak", DataUrodzenia = new DateTime(2002, 3, 4), Stanowisko = "pracownik fizyczny", StawkaGodzinowa = 18.5m },
            new Pracownik { Id = 2, Imie = "Agnieszka", Nazwisko = "Kowalska", DataUrodzenia = new DateTime(1973, 12, 15), Stanowisko = "urzednik", PensjaStala = 2800 },
            new Pracownik { Id = 3, Imie = "Robert", Nazwisko = "Lewandowski", DataUrodzenia = new DateTime(1980, 5, 23), Stanowisko = "pracownik fizyczny", StawkaGodzinowa = 29.0m },
            new Pracownik { Id = 4, Imie = "Zofia", Nazwisko = "Plucińska", DataUrodzenia = new DateTime(1998, 11, 2), Stanowisko = "urzednik", PensjaStala = 4750 },
            new Pracownik { Id = 5, Imie = "Grzegorz", Nazwisko = "Braun", DataUrodzenia = new DateTime(1960, 1, 29), Stanowisko = "pracownik fizyczny", StawkaGodzinowa = 48.0m }
        };

        Console.WriteLine("Podaj Id pracownika:");
        int idPracownika = int.Parse(Console.ReadLine());

        Pracownik pracownik = pracownicy.FirstOrDefault(p => p.Id == idPracownika);

        if (pracownik != null)
        {
            Console.WriteLine($"Imię i nazwisko: {pracownik.Imie} {pracownik.Nazwisko}");
            Console.WriteLine($"Wiek: {DateTime.Now.Year - pracownik.DataUrodzenia.Year}");
            Console.WriteLine($"Stanowisko: {pracownik.Stanowisko}");

            Console.WriteLine("Podaj ilość dni przepracowanych w miesiącu (max. 20):");
            int dniPracy = int.Parse(Console.ReadLine());

            pracownik.ObliczWynagrodzenie(dniPracy);
        }
        else
        {
            Console.WriteLine("Nie ma pracownika o podanym Id.");
        }
    }
}

using CA240119;

//metódusok, függvények
static void Beolvasas(List<Iroda> lista) 
{
    StreamReader sr = new(@"..\..\..\src\irodahaz.txt");
    while (!sr.EndOfStream) lista.Add(new Iroda(sr.ReadLine()));

    for (int i = 0; i < lista.Count; i++)
        lista[i].OsszDolgozo = lista[i].DolgozoSzamolo();
}
static void Feladat7(List<Iroda> lista) 
{
    lista
    .Select((c, i) => $"\t{i + 1}.{c}")
    .ToList()
    .ForEach(i => Console.WriteLine(i));
}
static void Feladat8(List<Iroda> lista)
{
    var emelet = lista
        .Select((iroda, index) => new { Iroda = iroda, Index = index+1 })
        .OrderByDescending(info => info.Iroda.OsszDolgozo)
        .Select(i => i.Index)
        .First();

    Console.WriteLine($"\t{emelet}.emeleten dolgoznak a legtöbben");
}
static void Feladat9(List<Iroda> lista)
{
    try
    {
         string vane = lista
        .SelectMany(a => a.Irodak, (c, d) => new { Ceg = c.Kod, Dolgozok = d })
        .GroupBy(c => c.Ceg)
        .SelectMany(cegek => cegek.Select((c, i) => new { IrodaSzam = i + 1, Ceg = c.Ceg, Dolgozok = c.Dolgozok }))
        .Where(c => c.Dolgozok == 9)
        .Select(c => $"Cég: {c.Ceg}, Iroda: {c.IrodaSzam}.")
        .First();

        Console.WriteLine($"\n9.feladat: \n\t{vane}");
    }
    catch
    {
        Console.WriteLine("\n9.feladat: \n\tNincs a keresettnek megfelelő találat!");
    }
}
static void Feladat10(List<Iroda> lista) 
{
    int valamennyi = lista
        .SelectMany(i => i.Irodak, (c, i) => new { Ceg = c.Kod, Dolgozok = i })
        .Count(i => i.Dolgozok > 5);

    Console.WriteLine($"\n10.feladat: \n\t{valamennyi}db irodában dolgoznak többen mint 5");
}
static void Feladat11(List<Iroda> lista) 
{
    StreamWriter sw = new(@"..\..\..\src\ujfile.txt");
    try
    {
        lista
            .SelectMany(e => e.Irodak, (c, d) => new { Ceg = c.Kod, Dolgozok = d })
            .GroupBy(c => c.Ceg)
            .SelectMany(cegek => cegek.Select((c, i) => new { IrodaSzam = i + 1, Ceg = c.Ceg, Dolgozok = c.Dolgozok }))
            .Where(c => c.Dolgozok == 0)
            .GroupBy(c => c.Ceg)
            .Select(cegek => new { Ceg = cegek.Key, Irodak = cegek.Select(c => c.IrodaSzam).ToList() })
            .ToList()
            .ForEach(i => sw.WriteLine($"{i.Ceg} {string.Join(" ", i.Irodak)}"));

        Console.WriteLine("\n11.feladat: \n\tSikeres kiírás!");

        sw.WriteLine("Emelet\\dolgozó fő");

        lista
            .Select((d, i) => $"{i + 1} {d.OsszDolgozo}")
            .ToList()
            .ForEach(k => sw.WriteLine(k));

        Console.WriteLine("\n13.feladat: \n\tSikeres kiírás!");

        sw.Close();
    }
    catch
    {
        Console.WriteLine("Hiba a fájlba való kiírás során!");
    }

}
static void Feladat12and13(List<Iroda> lista) 
{
    double atlag = lista
        .SelectMany(e => e.Irodak, (c,i) => new {Ceg=c.Kod,Dolgozo=i})
        .Where(c => c.Ceg.Contains("LOGMEIN"))
        .Average(c => c.Dolgozo);

    Console.WriteLine($"\n12.feladat: \n\tÁtlagosan {Math.Round(atlag)}db ember dolgozik egy irodában!");
}
static void Feladat14(List<Iroda> lista) 
{
    int ossz = lista.Sum(i => i.OsszDolgozo);
    Console.WriteLine($"\n14.feladat: \n\tAz irodaházban összesen: {ossz} ember dolgozik!");
}
static void Feladat15(List<Iroda> lista) 
{
    int elsoBerles = lista.Min(i => i.Evjarat);
    Console.WriteLine($"\n15.feladat: \n\tElső irodabérlés dátuma: {elsoBerles}");
}
static void Feladat16(List<Iroda> lista) 
{
    DateTime most = DateTime.Now;
    int legregebbiBerles = lista.Max(c => c.Evjarat);
    int valasz = most.Year - legregebbiBerles;

    Console.WriteLine($"\n16.feladat: \n\t{valasz} éve nem történt iroda bérlés!");
}

//Main
List<Iroda> irodak = new();
try
{
    Beolvasas(irodak);
    Console.WriteLine("Sikeres fájl beolvasás!");
}
catch
{
    Console.WriteLine("Hiba a fájl beolvasása során!");
}

//7.feladat
Console.WriteLine("\n7.feladat: ");
Console.WriteLine($"\t{"Kód",-15}{"Kezdet",-10} 1.  2.  3.  4.  5.  6.  7.  8.  9.  10. 11. 12. ");
Feladat7(irodak);

//8.feladat
Console.WriteLine("\n8.feladat: ");
Feladat8(irodak);

//9.feladat
Feladat9(irodak);

//10.feladat
Feladat10(irodak);

//11.feladat
Feladat11(irodak);

//12.feladat és 13.feladat
Feladat12and13(irodak);

//14.feladat
Feladat14(irodak);

//15.feladat
Feladat15(irodak);

//16.feladat
Feladat16(irodak);
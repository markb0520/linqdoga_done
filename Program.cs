List<Games> games = [];
const string FilePath = "..\\..\\..\\data\\videogames.csv";
using StreamReader sr = new(FilePath);
_ = sr.ReadLine();
while (!sr.EndOfStream)
{
    var tmp = sr.ReadLine().Split(',');
    games.Add(new()
    {
        Cim = tmp[0],
        Mufaj = tmp[1],
        KiadasDatum = DateTime.Parse(tmp[2]),
        AktivJatekosok = int.Parse(tmp[3]),
        Ertekeles = double.Parse(tmp[4].Replace('.', ','))
    });
}


//feladatok
//1. Hány olyan játék van a listában, aminek az értékelése szigorúan nagyobb, mint 4.5?
var countRating = games.Count(g => g.Ertekeles > 4.5);
Console.WriteLine($"4.5 értékelés feletti játékok száma: {countRating} db");

//2. Melyik az a játék a teljes kínálatból, amellyel a legtöbben játszanak?
var highestPlayerCount = games.MaxBy(g => g.AktivJatekosok);
Console.WriteLine($"legtöbb játékossal rendelkező játék: {highestPlayerCount.Cim} - {highestPlayerCount.AktivJatekosok}");

//3. Van-e egyáltalán olyan játék a listában, amit 2020. január 1. előtt adtak ki?
var releaseBefore = games.Any(g => g.KiadasDatum < new DateTime(2020, 1, 1));
Console.WriteLine($"{(releaseBefore ? "van" : "nincs")} 2020. jan. 1. előtti kiadású játék.");

//4. Mennyi a listában szereplő összes játék értékelésének az átlaga?
var avgRating = games.Average(g => g.Ertekeles);
Console.WriteLine($"a listában szereplő összes játék átlag értékelése: {avgRating:0.0}");

//5. Keresd meg a listában azt az EGYETLEN játékot, aminek a címe pontosan "Cyber City 2077"!
var gameSearch = games.FirstOrDefault(g => g.Cim == "Cyber City 2077");
Console.WriteLine($"az egyetlen Cyber City 2077 című játék:\n\n{gameSearch}");

//6.Listázd ki az összes "RPG" műfajú játékot, majd rendezd őket a kiadás dátuma szerint csökkenő sorrendbe!
var rpgGames = games.Where(g => g.Mufaj == "RPG").OrderByDescending(g => g.KiadasDatum);
foreach (var game in rpgGames)
{
    Console.WriteLine(game.Cim + " - " + game.KiadasDatum);
}

//7. Melyik a 3 legjobbra értékelt játék a teljes listában?
var top3Game = games.OrderByDescending(g => g.Ertekeles).Take(3);
foreach (var game in top3Game)
{
    Console.WriteLine("\n" + game.Cim + " - " + game.Ertekeles);
}

//8. Mennyi az átlagos aktív játékosszám azokban a játékokban, amelyeket 2022-ben vagy azután adtak ki?
var avgActive = games.Where(g => g.KiadasDatum.Year >= 2022).Average(g => g.AktivJatekosok);
Console.WriteLine($"\n{avgActive:0.00} db\n");

//9.Csoportosítsd a játékokat műfaj szerint, és add meg, hogy az egyes műfajokban hány darab játék található!
var groupByMufaj = games.GroupBy(g => g.Mufaj);
foreach (var group in groupByMufaj)
{
    Console.WriteLine(group.Key + ": " + group.Count() + " db");
}
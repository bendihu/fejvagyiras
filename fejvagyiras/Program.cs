namespace fejvagyiras;

public class Program
{
    static List<String> lista = new List<String>(File.ReadAllLines(@"kiserlet.txt"));
    static Random rnd = new Random();
    static char[] erme = { 'F', 'I' };
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        //1. feladat
        Feladat1();

        //2. feladat
        Feladat2();

        //3. feladat
        Feladat3();

        //4. feladat
        Feladat4();

        //5. feladat
        Feladat5();

        //6. feladat
        Feladat6();

        //7. feladat
        Feladat7();

        Console.ReadKey();
    }
    private static void Feladat1()
    {
        Console.WriteLine("1. feladat");
        
        int index = rnd.Next(erme.Length);

        Console.WriteLine($"A pénzfeldobás eredménye: {erme[index]}");
    }
    private static void Feladat2()
    {
        Console.WriteLine("2. feladat");
        Console.Write("Tippeljen! (F/I) = ");
        char tipp = char.Parse(Console.ReadLine().ToUpper());

        int index = rnd.Next(erme.Length);

        Console.WriteLine($"Tipp {tipp}, a doás eredménye {erme[index]} volt.");
        if (erme[index] == tipp) Console.WriteLine("Ön eltalálta!");
        else Console.WriteLine("Ön nem találta el!");
    }
    private static void Feladat3()
    {
        Console.WriteLine("3. feladat");
        Console.WriteLine($"A kísérlet {lista.Count} dobásból állt.");
    }
    private static void Feladat4()
    {
        Console.WriteLine("4. feladat");

        int fej = lista.Where(x => x.Equals("F")).Count();
        int ossz = lista.Count();
        decimal gyakorisag = (decimal)fej / ossz * 100;

        Console.WriteLine($"A kísérlet során a fej relatív gyakorisága {gyakorisag:N2}% volt.");
    }
    private static void Feladat5()
    {
        Console.WriteLine("5. feladat");

        int count = 0, fejek = 0;

        for (int i = 1; i < lista.Count - 2; i++)
        {
            if (!lista[i - 1].Equals("F") && lista[i].Equals("F") 
                && lista[i + 1].Equals("F") && !lista[i + 2].Equals("F")) count++;
        }

        Console.WriteLine($"A kísérlet során {count} alkalommal dobtak pontosan két fejet egymás után.");
    }
    private static void Feladat6()
    {
        Console.WriteLine("6. feladat");

        int max = 0, count = 0, index = 0, dobas = 0;

        foreach (var item in lista)
        {
            index++;

            if (item.Equals("F")) count++;
            else count = 0;

            if (count > max)
            {
                max = count;
                dobas = index - max + 1;
            }
        }

        Console.WriteLine($"A leghosszabb tisztafej sorozat {max} tagból állt, kezdete a(z) {dobas}. dobás.");
    }
    private static void Feladat7()
    {
        StreamWriter sw = new StreamWriter(@"dobasok.txt");

        List<String> dobasok = new List<String>();

        for (int i = 0; i < 1000; i++)
        {
            string dobas = "";

            for (int j = 0; j < 4; j++)
            {
                int index = rnd.Next(erme.Length);
                dobas += erme[index];
            }

            dobasok.Add(dobas);
        }

        int FFFF = 0, FFFI = 0;

        foreach (var item in dobasok)
        {
            if(item.Equals("FFFF")) FFFF++;
            else if(item.Equals("FFFI")) FFFI++;
        }

        sw.WriteLine($"FFFF: {FFFF}, FFFI: {FFFI}");

        foreach (var item in dobasok)
        {
            sw.Write($"{item} ");
        }

        sw.Close();
    }
}
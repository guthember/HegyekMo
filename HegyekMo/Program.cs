using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HegyekMo
{
  class Program
  {
    static List<Hegy> hegyek = new List<Hegy>();
    const double LAB = 3.280839895;

    static void Beolvasas()
    {
      StreamReader be = new StreamReader("hegyekMO.txt");

      be.ReadLine();

      while (!be.EndOfStream)
      {
        string[] a = be.ReadLine().Split(';');
        hegyek.Add(new Hegy(a[0], a[1], int.Parse(a[2])));
      }

      be.Close();
    }

    static void Harmadik()
    {
      Console.WriteLine($"3. feladat: Hegycsúcsok száma: {hegyek.Count} db");
    }

    static void Negyedik()
    {
      //hagyományos megoldás
      //int ossz = 0;
      //foreach (var h in hegyek)
      //{
      //  ossz += h.Magassag;
      //}
      //double atlag = (double)ossz / hegyek.Count;
      double atlag = hegyek.Average(x => x.Magassag);
      Console.WriteLine($"4. feladat: Hegycsúcsok átlagos magassága: {atlag} m");
    }

    static void Otodik()
    {
      Console.WriteLine("5. feladat: A legmagasabb hegycsúcs adatai:");
      //hagyományos megoldás
      //int max = 0;
      //for (int i = 1; i < hegyek.Count; i++)
      //{
      //  if (hegyek[i].Magassag > hegyek[max].Magassag)
      //  {
      //    max = i;
      //  }
      //}
      //Console.WriteLine($"\tNév: {hegyek[max].Nev}");
      //Console.WriteLine($"\tHegység: {hegyek[max].Hegyseg}");
      //Console.WriteLine($"\tMagasság: {hegyek[max].Magassag} m");
      var max = (from h in hegyek
                 orderby h.Magassag descending
                 select h).ToArray();
      Console.WriteLine($"\tNév: {max[0].Nev}");
      Console.WriteLine($"\tHegység: {max[0].Hegyseg}");
      Console.WriteLine($"\tMagasság: {max[0].Magassag} m");

    }

    static void Hatodik()
    {
      Console.Write("6. feladat: Kérek egy magasságot: ");
      int mag = int.Parse(Console.ReadLine());
      int i = 0;
      while ( i < hegyek.Count && !(hegyek[i].Magassag > mag && hegyek[i].Hegyseg == "Börzsöny"))
      {
        i++;
      }

      if (i < hegyek.Count)
      {
        Console.WriteLine($"\tVan {mag}m magasabb hegycsúcs a Börzsönyben!");
      }
      else
      {
        Console.WriteLine($"\tNincs {mag}m magasabb hegycsúcs a Börzsönyben!");
      }
    }

    static void Hetedik()
    {
      //hagyományos megoldás
      //int nagyobb = 0;

      //foreach (var h in hegyek)
      //{
      //  if (h.Magassag * LAB > 3000)
      //  {
      //    nagyobb++;
      //  }
      //}
      int nagyobb = (from h in hegyek
                     where h.Magassag * LAB > 3000
                     select h).ToList().Count;
      Console.WriteLine($"7. feladat: 3000 lábnál magasabb hegycsúcsok száma: {nagyobb}");
    }

    static void Nyolcadik()
    {
      Dictionary<string, int> stat = new Dictionary<string, int>();

      foreach (var h in hegyek)
      {
        if (stat.ContainsKey(h.Hegyseg))
        {
          stat[h.Hegyseg]++;
        }
        else
        {
          stat.Add(h.Hegyseg, 1);
        }
      }
      Console.WriteLine("8. feladat: Hegység statisztika:");
      foreach (var s in stat)
      {
        Console.WriteLine($"\t{s.Key} - {s.Value} db");
      }

    }

    static string Atvalt(int mag)
    {
      double magLab = Math.Round(mag * LAB, 1);
      return magLab.ToString().Replace(',','.');
    }

    static void Kilencedik()
    {
      Console.WriteLine("9. feladat: bukk-videk.txt");
      StreamWriter ki = new StreamWriter("bukk-videk.txt");
      ki.WriteLine("Hegycsúcs neve;Magasság láb");
      foreach (var h in hegyek)
      {
        if (h.Hegyseg == "Bükk-vidék")
        {
          ki.WriteLine($"{h.Nev};{Atvalt(h.Magassag)}");
        }
      }

      ki.Close();
    }

    static void Main(string[] args)
    {
      Beolvasas();
      Harmadik();
      Negyedik();
      Otodik();
      Hatodik();
      Hetedik();
      Nyolcadik();
      Kilencedik();

      Console.ReadLine();
    }
  }
}

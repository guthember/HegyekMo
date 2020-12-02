﻿using System;
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

    static void Main(string[] args)
    {
      Beolvasas();
      Harmadik();
      Negyedik();
      Otodik();

      Console.ReadLine();
    }
  }
}

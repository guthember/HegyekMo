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
    static void Main(string[] args)
    {
      Beolvasas();
      Harmadik();

      Console.ReadLine();
    }
  }
}

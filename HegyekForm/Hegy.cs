using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HegyekForm
{
  class Hegy
  {
    private const double LAB = 3.280839895;

    private string nev;

    public string Nev
    {
      get { return nev; }
    }

    private string hegyseg;

    public string Hegyseg
    {
      get { return hegyseg; }
    }

    private int magassag;

    public int Magassag
    {
      get { return magassag; }
    }

    private double labertek;

    public double Labertek
    {
      get { return labertek; }
    }

    private string labSzoveg;

    public string LabSzoveg
    {
      get { return labSzoveg; }
    }

    public Hegy(string nev, string hegyseg, int magassag)
    {
      this.nev = nev;
      this.hegyseg = hegyseg;
      this.magassag = magassag;
      labertek = magassag * LAB;
      labSzoveg = Math.Round(labertek, 1).ToString().Replace(',', '.');
    }
  }
}

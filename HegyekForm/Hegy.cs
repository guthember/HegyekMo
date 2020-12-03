using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HegyekForm
{
  class Hegy
  {

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

    public Hegy(string nev, string hegyseg, int magassag)
    {
      this.nev = nev;
      this.hegyseg = hegyseg;
      this.magassag = magassag;
    }
  }
}

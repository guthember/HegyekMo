using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HegyekForm
{
  public partial class Form1 : Form
  {
    List<Hegy> hegyek = new List<Hegy>();
    

    #region Beolvasás
    void Beolvasas()
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
    #endregion

    public Form1()
    {
      InitializeComponent();
      Beolvasas();
    }
  }
}

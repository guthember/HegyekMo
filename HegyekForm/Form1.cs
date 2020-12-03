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

    private void btnHarom_Click(object sender, EventArgs e)
    {
      lbKimenet.Items.Clear();
      lbKimenet.Items.Add($"3. feladat: Hegycsúcsok száma: {hegyek.Count} db");
    }

    private void btnNegyedik_Click(object sender, EventArgs e)
    {
      lbKimenet.Items.Clear();
      double atlag = hegyek.Average(x => x.Magassag);
      lbKimenet.Items.Add($"4. feladat: Hegycsúcsok átlagos magassága: {atlag} m");
    }

    private void btnOtodik_Click(object sender, EventArgs e)
    {
      lbKimenet.Items.Clear();
      lbKimenet.Items.Add("5. feladat: A legmagasabb hegycsúcs adatai:");
      var max = (from h in hegyek
                 orderby h.Magassag descending
                 select h).ToArray();
      lbKimenet.Items.Add($"\tNév: {max[0].Nev}");
      lbKimenet.Items.Add($"\tHegység: {max[0].Hegyseg}");
      lbKimenet.Items.Add($"\tMagasság: {max[0].Magassag} m");
    }

    private void btnHatodik_Click(object sender, EventArgs e)
    {
      if (tbMagassag.Text == "")
      {
        MessageBox.Show("Előbb írj be egy magasságot!", "Hiányzó feltétel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }
      else
      {
        lbKimenet.Items.Clear();
        lbKimenet.Items.Add("6. feladat: Kérek egy magasságot: ");
        int mag = int.Parse(tbMagassag.Text);
        int i = 0;
        while (i < hegyek.Count && !(hegyek[i].Magassag > mag && hegyek[i].Hegyseg == "Börzsöny"))
        {
          i++;
        }

        if (i < hegyek.Count)
        {
          lbKimenet.Items.Add($"\tVan {mag}m magasabb hegycsúcs a Börzsönyben!");
        }
        else
        {
          lbKimenet.Items.Add($"\tNincs {mag}m magasabb hegycsúcs a Börzsönyben!");
        }
      }
    }

    private void btnHetedik_Click(object sender, EventArgs e)
    {
      lbKimenet.Items.Clear();
      int nagyobb = (from h in hegyek
                     where h.Labertek > 3000
                     select h).ToList().Count;
      lbKimenet.Items.Add($"7. feladat: 3000 lábnál magasabb hegycsúcsok száma: {nagyobb}");
    }

    private void btnNyolcadik_Click(object sender, EventArgs e)
    {
      lbKimenet.Items.Clear();
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
      lbKimenet.Items.Add("8. feladat: Hegység statisztika:");
      foreach (var s in stat)
      {
        lbKimenet.Items.Add($"\t{s.Key} - {s.Value} db");
      }

    }

    private void btnKilencedik_Click(object sender, EventArgs e)
    {
      lbKimenet.Items.Clear();
      lbKimenet.Items.Add("9. feladat: bukk-videk.txt");
      StreamWriter ki = new StreamWriter("bukk-videk.txt");
      ki.WriteLine("Hegycsúcs neve;Magasság láb");
      foreach (var h in hegyek)
      {
        if (h.Hegyseg == "Bükk-vidék")
        {
          ki.WriteLine($"{h.Nev};{h.LabSzoveg}");
        }
      }

      ki.Close();
    }
  }
}

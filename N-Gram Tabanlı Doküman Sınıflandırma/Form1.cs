using System;
using System.Collections.Generic;
using System.ComponentModel;
using net.zemberek.erisim;
using net.zemberek.tr.yapi;
using net.zemberek.yapi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public FileInfo[] file1;
        public string[] path;
        public string[] pathEko;
        public string[] pathMag;
        public string[] pathSag;
        public string[] pathSiy;
        public string[] pathSpr;
        List<string> ekoTxt = new List<string>();
        List<string> magTxt = new List<string>();
        List<string> sagTxt = new List<string>();
        List<string> siyTxt = new List<string>();
        List<string> sprTxt = new List<string>();

        List<string> ekoTxt1 = new List<string>();
        List<string> magTxt1 = new List<string>();
        List<string> sagTxt1 = new List<string>();
        List<string> siyTxt1 = new List<string>();
        List<string> sprTxt1 = new List<string>();

        List<string> ekoKrktr = new List<string>();
        List<string> magKrktr = new List<string>();
        List<string> sagKrktr = new List<string>();
        List<string> siyKrktr = new List<string>();
        List<string> sprKrktr = new List<string>();

        List<string> ekoikili = new List<string>();
        List<string> magikili = new List<string>();
        List<string> sagikili = new List<string>();
        List<string> siyikili = new List<string>();
        List<string> sprikili = new List<string>();

        List<string> ekouclu = new List<string>();
        List<string> maguclu = new List<string>();
        List<string> saguclu = new List<string>();
        List<string> siyuclu = new List<string>();
        List<string> spruclu = new List<string>();

        List<List<string>> list = new List<List<string>>();
        public int oran;
        public int uzunluk;
        public int fark;
        private void button1_Click(object sender, EventArgs e)
        {
            string path1 = "C:\\Users\\USER\\Desktop\\Yazlab2.3\\1150haber\\raw_texts";
            string[] file = Directory.GetDirectories(path1);//raww içindeki dosyaların tamamı
            TextYol(file);
            TextOku();
            Nzemberek();
            uzunluk = pathEko.Length /5;
            //uzunluk = pathEko.Length;           
            oran = (pathEko.Length /5)* 25 / 100;
            //oran = pathEko.Length  * 25 / 100;
            fark = uzunluk - oran;
            Ayristir();
            // UcluAyristir();
            TemizleBinary();
            //TemizleThree();
          //  EkrandaGoster();
           
        }

       
        private void TextYol(string[] file)
        {
          
            for (int i = 0; i < file.Length; i++)
            {
                if (i == 0)
                {
                    //Ekonomi içindeki dosyaların okunması
                    file1 = TextYolOku(i, file);
                    int j = 0;
                    pathEko = new string[file1.Length];
                    foreach (FileInfo fi in file1)
                    {
                        pathEko[j] = fi.FullName;
                        j++;
                    }

                }
                //Magazin içindeki dosyaların okunması
                else if (i == 1)
                {
                    file1 = TextYolOku(i, file);
                    int j = 0;
                    pathMag = new string[file1.Length];
                    foreach (FileInfo fi in file1)
                    {
                        pathMag[j] = fi.FullName;
                        j++;
                    }
                }
                //Saglik içindeki dosyaların okunması
                else if (i == 2)
                {
                    file1 = TextYolOku(i, file);
                    int j = 0;
                    pathSag = new string[file1.Length];
                    foreach (FileInfo fi in file1)
                    {
                        pathSag[j] = fi.FullName;
                        j++;
                    }
                }
                //siyaset içindeki dosyaların okunması
                else if (i == 3)
                {
                    file1 = TextYolOku(i, file);
                    int j = 0;
                    pathSiy = new string[file1.Length];
                    foreach (FileInfo fi in file1)
                    {
                        pathSiy[j] = fi.FullName;
                        j++;
                    }
                }
                else
                {
                    file1 = TextYolOku(i, file);
                    int j = 0;
                    pathSpr = new string[file1.Length];//her bir türun içindeki dosyaların yolunu tutar
                    foreach (FileInfo fi in file1)
                    {
                        pathSpr[j] = fi.FullName;
                        j++;
                    }
                }

            }

        }
        private FileInfo[] TextYolOku(int index, string[] file)
        {
            DirectoryInfo dinfo = new DirectoryInfo(file[index]);
            FileInfo[] file1 = dinfo.GetFiles();
            return file1;
        }

        private void TextOku()
        {
            string text;

            for (int i = 0; i < pathEko.Length/5; i++)
                //for (int i = 0; i < pathEko.Length; i++)
            {
                StreamReader sr = new StreamReader(pathEko[i], Encoding.GetEncoding("iso-8859-9"), false);
                text = sr.ReadToEnd(); //text dosyasının tamamını okur   
                ekoTxt.Add(text);//her tur için okunan dosyalar bir dizide tutulur

                //  listBox2.Items.Add(pathEko[i]);

            }
            for (int i = 0; i < pathMag.Length/5; i++)
               // for (int i = 0; i < pathMag.Length; i++)
            {
                StreamReader sr = new StreamReader(pathMag[i], Encoding.GetEncoding("iso-8859-9"), false);
                text = sr.ReadToEnd(); //text dosyasının tamamını okur   
                magTxt.Add(text);
            }
            for (int i = 0; i < pathSag.Length/5; i++)
             //   for (int i = 0; i < pathSag.Length; i++)
                {
                StreamReader sr = new StreamReader(pathSag[i], Encoding.GetEncoding("iso-8859-9"), false);
                text = sr.ReadToEnd(); //text dosyasının tamamını okur   
                sagTxt.Add(text);
            }
            for (int i = 0; i < pathSiy.Length/5; i++)
               // for (int i = 0; i < pathSiy.Length; i++)
            {
                StreamReader sr = new StreamReader(pathSiy[i], Encoding.GetEncoding("iso-8859-9"), false);
                text = sr.ReadToEnd(); //text dosyasının tamamını okur   
                siyTxt.Add(text);
            }
            for (int i = 0; i < pathSpr.Length/5; i++)
                //for (int i = 0; i < pathSpr.Length; i++)
            {
                 StreamReader sr = new StreamReader(pathSpr[i], Encoding.GetEncoding("iso-8859-9"), false);
                text = sr.ReadToEnd(); //text dosyasının tamamını okur   
                sprTxt.Add(text);
            }
        }
        private void Nzemberek()
        {

            for (int i = 0; i < 1; i++)
            {
                string duzeltilmistext = " ";
                //string sonkelime = " ";
                string[] kelimeler = TextAyristir(ekoTxt[i]);
                 for(int j=0; j<kelimeler.Length; j++)
                 {
                    kelimeler[j]=TakilarinaAyir(kelimeler[j],ekoTxt1);
                     duzeltilmistext += kelimeler[j]+" ";
                 }

                /* for (int j = 0; j < kelimeler.Length; j++)
                 {
                     duzeltilmistext += kelimeler[j] + "_";
                 }*/
              /*  richTextBox1.Text = duzeltilmistext;
                MessageBox.Show("bthrtr");*/
                ekoTxt1.Add(duzeltilmistext);  //ekotxt1 her bir katogori için ön işlenmiş veriyi tutar
             /*   richTextBox1.Text = duzeltilmistext;
                MessageBox.Show("fewefef");*/
            }

            for (int i = 0; i < magTxt.Count; i++)
            {
                string duzeltilmistext = " ";
                string[] kelimeler = TextAyristir(magTxt[i]);
             /* for(int j=0; j<kelimeler.Length; j++)
                {
                 kelimeler[j]=TakilarinaAyir(kelimeler[j],magTxt1);
                  duzeltilmistext += kelimeler[j]+" ";
                } */
                for (int j = 0; j < kelimeler.Length; j++)
                {
                    duzeltilmistext += kelimeler[j] + "_";
                }
                magTxt1.Add(duzeltilmistext);//noktalama işaretlerinden arındırılmış textler
            }
          

            for (int i = 0; i < sagTxt.Count; i++)
            {
                string duzeltilmistext = " ";
                string[] kelimeler = TextAyristir(sagTxt[i]);
               /* for(int j=0; j<kelimeler.Length; j++)
                {
                 kelimeler[j]=TakilarinaAyir(kelimeler[j],sagTxt1);
                 duzeltilmistext += kelimeler[j]+" ";
                } */
                for (int j = 0; j < kelimeler.Length; j++)
                {
                    duzeltilmistext += kelimeler[j] + "_";
                }
                sagTxt1.Add(duzeltilmistext);
            }
            for (int i = 0; i < siyTxt.Count; i++)
            {
                string duzeltilmistext = " ";
                string[] kelimeler = TextAyristir(siyTxt[i]);
                /* for(int j=0; j<kelimeler.Length; j++)
                {
                     kelimeler[j]=TakilarinaAyir(kelimeler[j],magTxt1);
                      duzeltilmistext += kelimeler[j]+" ";
                } */
                for (int j = 0; j < kelimeler.Length; j++)
                {
                    duzeltilmistext += kelimeler[j] + "_";
                }
                siyTxt1.Add(duzeltilmistext);
            }
            for (int i = 0; i < sprTxt.Count; i++)
            {
                string duzeltilmistext = " ";
                string[] kelimeler = TextAyristir(sprTxt[i]);
                /* for(int j=0; j<kelimeler.Length; j++)
                   {
                     kelimeler[j]=TakilarinaAyir(kelimeler[j],magTxt1);
                       duzeltilmistext += kelimeler[j]+" ";
                   } */
                for (int j = 0; j < kelimeler.Length; j++)
                {
                    duzeltilmistext += kelimeler[j] + "_";
                }
                sprTxt1.Add(duzeltilmistext);
            }
        }
        private string[] TextAyristir(string text)
        {
            /*richTextBox1.Text = text;
            MessageBox.Show("merhaba");*/
            text = text.Replace(".", " ");
            text = text.Replace("!", " ");
            text = text.Replace("?", " ");
            text = text.Replace(",", " ");
            text = text.Replace("'", " ");
            text = text.Replace("-", " ");
            text = text.Replace("~", " ");
            text = text.Replace("[", " ");
            text = text.Replace("]", " ");
            text = text.Replace(":", " ");
            text = text.Replace('"', ' ');
            text = text.Replace(":)", " ");
            text = text.Replace(":D", " ");
            text = text.Replace(":", " ");
            text = text.Replace(":(", " ");
            text = text.Replace(":/", " ");
            text = text.Replace(":\\", " ");
            text = text.Replace(":|", " ");
            text = text.Replace("(", " ");
            text = text.Replace(")", " ");
            text = text.Replace("\n", " ");
            text = text.Replace("  ", " ");
            text = text.Replace("   ", " ");
            text = text.Replace("    ", " ");
            text = text.ToLower();
            text = text.Trim();
            
            string[] kelimeler = text.Split(' ');

            return kelimeler;

        }
        ///çekim eklerinin çıkarılması
        private string TakilarinaAyir(string yenikelime, List<string> turtxt)
        {
            Zemberek zmbrk = new Zemberek(new TurkiyeTurkcesi());
            Kelime[] cozumler = zmbrk.kelimeCozumle(yenikelime);
            Kelime klm1 = new Kelime();

            try
            {
                klm1 = cozumler[0];
            }
            catch (Exception)
            {
                return yenikelime;
            }
            net.zemberek.yapi.ek.Ek[] ekler = klm1.ekDizisi();
            IList<net.zemberek.yapi.ek.Ek> yeniekler = klm1.ekler();
            int j = 0;
            for (int i = 0; i < ekler.Length; i++)
            {
                Boolean c = true;
                if ((ekler[i].ToString().Contains("ISIM_DONUSUM_LES"))
                    || (ekler[i].ToString().Contains("ISIM_BULUNMA_LI"))
                    || (ekler[i].ToString().Contains("ISIM_ILGI_CI"))
                    || (ekler[i].ToString().Contains("ISIM_YOKLUK_SIZ")))
                    c = false;
                if (c)
                {
                    yeniekler.Remove(ekler[i]);
                }
                else
                {
                    j++;
                }
            }
            string sonkelime = "";
            if (j > 0)
            {
                sonkelime = zmbrk.kelimeUret(klm1.kok(), yeniekler);
            }
            else
            {
                sonkelime = klm1.kok().icerik();
            }
            return sonkelime;
        }


        private void Ayristir()
        {         
               string text = "";
                string ikililer = "";
                int sayac = 0;

                for (int i = 0; i < ekoTxt1.Count; i++)
                {
                    text = ekoTxt1[i];
                  
                    for (int j = 0; j < text.Length - 2; j++)
                    {
                        ikililer += text.Substring(j, 2) + "|"; //iki gram ayrıştırma,ayrışan heceler düz çizgi ile ikililer textine eklenir
                    richTextBox1.Text = ikililer;
                    MessageBox.Show("frfwrf");
                        sayac++;
                    }
                    ekoikili.Add(ikililer); //her bir txt listeye eklenir

                
                    text = "";
                    ikililer = "";

                }
           // richTextBox1.Text = ekoikili[0];
                Karakter(ekoikili, sayac);
                sayac = 0;

                for (int i = 0; i < magTxt1.Count; i++)
                {
                    text = magTxt1[i];
                 
                    for (int j = 0; j < text.Length - 2; j++)
                    {
                        ikililer += text.Substring(j, 2) + "|";
                        sayac++;
                    }
                    magikili.Add(ikililer);
                    text = "";
                    ikililer = "";
                }
                Karakter(magikili, sayac);
                sayac = 0;

                for (int i = 0; i < sagTxt1.Count; i++)
                {
                    text = sagTxt1[i];
                  
                    for (int j = 0; j < text.Length - 2; j++)
                    {
                        ikililer += text.Substring(j, 2) + "|";
                        sayac++;
                    }
                    sagikili.Add(ikililer);
                    text = "";
                    ikililer = "";
                }
                Karakter(sagikili, sayac);
                sayac = 0;

                for (int i = 0; i < siyTxt1.Count; i++)
                {
                    text = siyTxt1[i];
              
                    for (int j = 0; j < text.Length - 2; j++)
                    {
                        ikililer += text.Substring(j, 2) + "|";
                        sayac++;
                    }
                    siyikili.Add(ikililer);
                    text = "";
                    ikililer = "";
                }
                Karakter(siyikili, sayac);
                sayac = 0;

                for (int i = 0; i < sprTxt1.Count; i++)
                {
                    text = sprTxt1[i];
               
                    for (int j = 0; j < text.Length - 2; j++)
                    {
                        ikililer += text.Substring(j, 2) + "|";
                        sayac++;
                    }
                    sprikili.Add(ikililer);
                    text = "";
                    ikililer = "";
                }
                Karakter(sprikili, sayac);

        }
   
        Dictionary<string, int> eko = new Dictionary<string, int>();
        Dictionary<string, int> mag = new Dictionary<string, int>();
        Dictionary<string, int> sag = new Dictionary<string, int>();
        Dictionary<string, int> siy = new Dictionary<string, int>();
        Dictionary<string, int> spr = new Dictionary<string, int>();
        Dictionary<string, int> binary = new Dictionary<string, int>();
        private void Karakter(List<string> ikiliTur, int sayac)
        {
            string text = "";
            string[] ikili = new string[sayac];

            for (int i = 0; i < ikiliTur.Count; i++)
            {
                text = ikiliTur[i];
                ikili = text.Split('|'); //gelen hece listesini ayırır ve diziye atar
                Hesapla(ikili, i, ikiliTur);
                text = "";
            }

            /*  foreach (KeyValuePair<string,int> veri in eko)
                  richTextBox1.Text+="hece: "+veri.Key+" sayi: "+ veri.Value+"\n";*/
        }
        private void Hesapla(string[] ikili, int index, List<string> tur)
        {

            int sayac = 0;
            for (int i = 0; i < ikili.Length; i++)
            {
                for (int j = 0; j < ikili.Length; j++)
                {
                    if (ikili[i] == ikili[j]) //ikili sayılarını bulmak için kontrol
                    {
                        sayac++;  //her bir ikili için tüm ikilileri tarar varsa sayac artar
                    }
                }
                if (i == 0) //ilk ikili için 
                {

                    if (tur == ekoikili)
                    {
                        binary.Add(ikili[i] + "/" + "e" + "/" + index, sayac); //binary dictionarysına her ikilinin sayısını ekler
                    }
                    else if (tur == magikili)
                    {
                        int index1 = (index + uzunluk);
                       
                        binary.Add(ikili[i] + "/" + "m" + "/" + index1, sayac);
                    }
                    else if (tur == sagikili)
                    {
                        int index1 = (index + 2 * uzunluk);
                        binary.Add(ikili[i] + "/" + "sa" + "/" + index1, sayac);
                    }
                    else if (tur == siyikili)
                    {
                        int index1 = (index + 3 * uzunluk);
                        binary.Add(ikili[i] + "/" + "si" + "/" + index1, sayac);
                    }
                    else if (tur == sprikili)
                    {
                         int index1 = (index + 4*uzunluk);
                        binary.Add(ikili[i] + "/" + "sp" + "/" + index1, sayac);
                    }
                }
                else
                {
                    if (tur == ekoikili)
                    {
                        if (!binary.ContainsKey(ikili[i] + "/" + "e" + "/" + index))
                            binary.Add(ikili[i] + "/" + "e" + "/" + index, sayac);

                    }
                    else if (tur == magikili)
                    {
                        int index1=index +  uzunluk;
                        if (!binary.ContainsKey(ikili[i] + "/" + "m" + "/" + index1))
                            binary.Add(ikili[i] + "/" + "m" + "/" + index1, sayac);

                    }

                    else if (tur == sagikili)
                    {
                       int index1= index +  2 * uzunluk;
                        if (!binary.ContainsKey(ikili[i] + "/" + "sa" + "/" + index1))
                            binary.Add(ikili[i] + "/" + "sa" + "/" + index1, sayac);

                    }
                    else if (tur == siyikili)
                    {
                        int index1 = index+3* uzunluk;
                        if (!binary.ContainsKey(ikili[i] + "/" + "si" + "/" + index1))
                            binary.Add(ikili[i] + "/" + "si" + "/" + index1, sayac);

                    }
                    else if (tur == sprikili)
                    {
                        int index1 =index+ 4 * uzunluk;
                        if (!binary.ContainsKey(ikili[i] + "/" + "sp" + "/" + index1))
                            binary.Add(ikili[i] + "/" + "sp" + "/" + index1, sayac);

                    }
                }
                sayac = 0;
            }
        }
        /// <summary>
        /// ////////////////////////////////
        /// </summary>
       
   
        Dictionary<string, int> egitim = new Dictionary<string, int>();   
        List<string> listbinary = new List<string>();
        List<int> listsabinary = new List<int>();
        List<string> listindxbinary = new List<string>();
        List<string> listturbinary = new List<string>();

        Dictionary<string, int> egitimThree = new Dictionary<string, int>();
        List<string> listThree = new List<string>();
        List<int> listSaThree = new List<int>();

        private void TemizleBinary()
        {
            MessageBox.Show("binary listesine ekleme başladi");                    
                string text = "";
                string[] text1 = new string[binary.Count * 3];
                foreach (KeyValuePair<string, int> value in binary)
                {
                    int sayi = 0;
                    text = value.Key;
                    text1 = text.Split('/');
                    sayi = value.Value;
                    listbinary.Add(text1[0]);
                    listsabinary.Add(sayi);
                    listindxbinary.Add(text1[2]);
             
                    listturbinary.Add(text1[1]);
                Array.Clear(text1, 0, text1.Length);
                } 
              
           MessageBox.Show("binary listesine ekleme bitti bitti");

            //////////////////////////////
            MessageBox.Show("50 den büyük Denetle Başladi");
           // MessageBox.Show(listbinary.Count.ToString());
            int sayac = 0;
            int sayac1 = 0;
            for (int i = 0; i < listbinary.Count ; i++)
            {
                string tur = listturbinary[i];
                string index = listindxbinary[i];
                sayac = listsabinary[i];
                sayac1 = listsabinary[i];
                for (int j = 0; j < listbinary.Count / 5; j++)
                {
                    if (i != j)
                    {
                        if (listbinary[i] == listbinary[j])
                        {
                            sayac += listsabinary[i];
                        }
                    }
                }

                if (sayac > 50)
                {
                    if (!egitim.ContainsKey(listbinary[i]+"/"+index ))
                        egitim.Add(listbinary[i]+"/"+index, sayac);
                }
            }
            MessageBox.Show("denetleme bitti");
            EgitimHesaplari();
            EkrandaGoster();
        }

      
        private void EkrandaGoster()
        {                        
                MessageBox.Show("yazdirmaya başla");
                foreach (KeyValuePair<string, int> vl in egitim)
                {
                    richTextBox1.Text += vl.Key + ": " + vl.Value + "  ";
                }
           
        }

        List<string> ikihece = new List<string>();
        List<string> ikiindex = new List<string>();
        List<string> ikisayi = new List<string>();
        List<string> orteko = new List<string>();
        List<string> ortmag = new List<string>();
        List<string> ortsag = new List<string>();
        List<string> ortsiy = new List<string>();
        List<string> ortspr = new List<string>();

        private void EgitimHesaplari()
        {
            MessageBox.Show("eğitim hesapları başladi");
            string text = "";
            string[] text1 = new string[4];
            foreach (KeyValuePair<string, int> vl in egitim) 
            {
                text = vl.Key;
                text1 = Text.Split('/');
                ikihece.Add(text1[0]);
             //   ikiindex.Add(text1[1]);
               // ikisayi.Add(text1[3]);

                Array.Clear(text1, 0, text1.Length);
            }

            for(int i=0;  i<ikihece.Count; i++)
            {
                int sayac1 = 0;
                int sayac2 = 0;
                int sayac3 = 0;
                int sayac4 = 0;
                int sayac5 = 0;
                bool ayristir1 = false;
                bool ayristir2 = false;
                bool ayristir3 = false;
                bool ayristir4 = false;
                bool ayristir5 = false;
                List<int> list1 = new List<int>();
                List<int> list2 = new List<int>();
                List<int> list3 = new List<int>();
                List<int> list4 = new List<int>();
                List<int> list5 = new List<int>();

                for (int j=0;j< listbinary.Count; j++)
                {                  
                    if (ikihece[i] == listbinary[j] && Convert.ToInt16(listindxbinary[j])>=oran && Convert.ToInt16(listindxbinary[j])<(oran+fark))
                    {
                        sayac1 += listsabinary[j];//eko kategorisndeki bir hece için tüm txtlerdeki sayısının toplamı
                        list1.Add(listsabinary[i]);//her txt nın sayısını tutuyor
                        ayristir1 = true;                       
                    }
                    else if (ikihece[i] == listbinary[j] && Convert.ToInt16(listindxbinary[j]) >= (2*oran+fark) && Convert.ToInt16(listindxbinary[j]) < (2*oran+2*fark))
                    {
                        sayac2 += listsabinary[j];
                        list2.Add(listsabinary[i]);
                        ayristir2 = true;
                    }
                    else  if (ikihece[i] == listbinary[j] && Convert.ToInt16(listindxbinary[j]) >= (3 * oran + 2*fark) && Convert.ToInt16(listindxbinary[j]) < (3 * oran + 3*fark))
                    {
                        sayac3 += listsabinary[j];
                        list3.Add(listsabinary[i]);
                        ayristir3 = true;
                    }
                    else if (ikihece[i] == listbinary[j] && Convert.ToInt16(listindxbinary[j]) >= (4* oran + 3 * fark) && Convert.ToInt16(listindxbinary[j]) < (4 * oran + 4* fark))
                    {
                        sayac4 += listsabinary[j];
                        list4.Add(listsabinary[i]);
                        ayristir4 = true;
                    }
                    else if (ikihece[i] == listbinary[j] && Convert.ToInt16(listindxbinary[j]) >= (5 * oran + 4 * fark) && Convert.ToInt16(listindxbinary[j]) < (5 * oran + 5 * fark))
                    {
                        sayac5 += listsabinary[j];
                        list5.Add(listsabinary[i]);
                        ayristir5 = true;
                    }

                    
                }
                    if (ayristir1)
                    {
                        double karetoplam = 0;
                        double varyans = 0;
                        double ort = sayac1 / 173;
                        for(int k=0; k<list1.Count; k++)
                        {
                           karetoplam += (ort - list1[k]) * (ort - list1[k]);                            
                        }
                        varyans = karetoplam / 173 - 1;
                        orteko.Add(ikihece[i]+"/"+ort.ToString()+"/"+varyans);
                        list1.Clear();
                    }
                    else if (ayristir2)
                    {
                        double karetoplam = 0;
                        double varyans = 0;

                        double ort = sayac2 / 173;
                        for (int k = 0; k < list2.Count; k++)
                        {
                            karetoplam += (ort - list2[k]) * (ort - list2[k]);
                        }
                        varyans = karetoplam / 173 - 1;
                        ortmag.Add(ikihece[i] + "/" + ort.ToString() + "/" + varyans);
                        list2.Clear();
                    }
                    else if (ayristir3)
                    {
                        double karetoplam = 0;
                        double varyans = 0;
                        double ort = sayac3 / 173;
                        for (int k = 0; k < list3.Count; k++)
                        {
                            karetoplam += (ort - list3[k]) * (ort - list3[k]);
                        }
                        varyans = karetoplam / 173 - 1;
                       
                        ortsag.Add(ikihece[i] + "/" + ort.ToString() + "/" + varyans);
                        list3.Clear();
                    }
                    else if (ayristir4)
                    {
                        double karetoplam = 0;
                        double varyans = 0;
                        double ort = sayac4 / 173;
                        for (int k = 0; k < list4.Count; k++)
                        {
                            karetoplam += (ort - list4[k]) * (ort - list4[k]);
                        }
                        varyans = karetoplam / 173 - 1;
                      
                        ortsiy.Add(ikihece[i] + "/" + ort.ToString() + "/" + varyans);
                        list4.Clear();
                    }
                    else if(ayristir5)
                    {
                        double karetoplam = 0;
                        double varyans = 0;
                        double ort = sayac5 / 173;
                        for (int k = 0; k < list5.Count; k++)
                        {
                            karetoplam += (ort - list5[k]) * (ort - list5[k]);
                        }
                        varyans = karetoplam / 173 - 1;                       
                        ortspr.Add(ikihece[i] + "/" + ort.ToString() + "/" + varyans);
                        list5.Clear();
                    }     
                                        
                
            }
        /*    MessageBox.Show("ekonomi: "+orteko.Count);
            for (int i = 0; i< orteko.Count/10; i++)
            {
                listBox1.Items.Add(orteko[i]);
            }
          */
            MessageBox.Show("Eğitim sonlandi");


        }
        private void UcluAyristir()
        {
            string text = "";
            string ucluler = "";
            int sayac = 0;

            int oran = pathEko.Length * 25 / 100;
            for (int i = 0; i < ekoTxt1.Count; i++)
            {
                text = ekoTxt1[i];

                for (int j = 0; j < text.Length - 3; j++)
                {
                    ucluler += text.Substring(j, 3) + "|";
                    sayac++;
                }
                ekouclu.Add(ucluler);
                text = "";
                ucluler = "";

            }
            /* for(int i=0; i<ekouclu.Count; i++)
             {
                 richTextBox1.Text = ekouclu[i];
             }
             MessageBox.Show("selam");*/

            KarakterThree(ekouclu, sayac);
            sayac = 0;

            for (int i = 0; i < magTxt1.Count; i++)
            {
                text = magTxt1[i];

                for (int j = 0; j < text.Length - 3; j++)
                {
                    ucluler += text.Substring(j, 3) + "|";
                    sayac++;
                }
                maguclu.Add(ucluler);
                text = "";
                ucluler = "";
            }
            KarakterThree(maguclu, sayac);
            sayac = 0;

            for (int i = 0; i < sagTxt1.Count; i++)
            {
                text = sagTxt1[i];

                for (int j = 0; j < text.Length - 3; j++)
                {
                    ucluler += text.Substring(j, 3) + "|";
                    sayac++;
                }
                saguclu.Add(ucluler);
                text = "";
                ucluler = "";
            }
            KarakterThree(saguclu, sayac);
            sayac = 0;

            for (int i = 0; i < siyTxt1.Count; i++)
            {
                text = siyTxt1[i];

                for (int j = 0; j < text.Length - 3; j++)
                {
                    ucluler += text.Substring(j, 3) + "|";
                    sayac++;
                }
                siyuclu.Add(ucluler);
                text = "";
                ucluler = "";
            }
            KarakterThree(siyuclu, sayac);
            sayac = 0;

            for (int i = 0; i < sprTxt1.Count; i++)
            {
                text = sprTxt1[i];

                for (int j = 0; j < text.Length - 3; j++)
                {
                    ucluler += text.Substring(j, 3) + "|";
                    sayac++;
                }
                spruclu.Add(ucluler);
                text = "";
                ucluler = "";
            }
            KarakterThree(spruclu, sayac);
        }

        Dictionary<string, int> ekothree = new Dictionary<string, int>();
        Dictionary<string, int> magthree = new Dictionary<string, int>();
        Dictionary<string, int> sagthree = new Dictionary<string, int>();
        Dictionary<string, int> siythree = new Dictionary<string, int>();
        Dictionary<string, int> sprthree = new Dictionary<string, int>();
        Dictionary<string, int> dicthree = new Dictionary<string, int>();
        private void KarakterThree(List<string> threeTur, int sayac)
        {
            string text = "";
            string[] three = new string[sayac];

            for (int i = 0; i < threeTur.Count; i++)
            {
                text = threeTur[i];
                three = text.Split('|');
                HesaplaThree(three, i, threeTur);
                text = "";
            }

            /*  foreach (KeyValuePair<string,int> veri in eko)
                  richTextBox1.Text+="hece: "+veri.Key+" sayi: "+ veri.Value+"\n";*/
        }

        private void HesaplaThree(string[] three, int index, List<string> tur)
        {

            int sayac = 0;
            for (int i = 0; i < three.Length; i++)
            {
                for (int j = 0; j < three.Length; j++)
                {
                    if (three[i] == three[j])
                    {
                        sayac++;
                    }
                }
                if (i == 0)
                {

                    if (tur == ekouclu)
                    {

                        dicthree.Add(three[i] + "/" + "e" + "/" + index, sayac);
                    }
                    else if (tur == maguclu)
                    {
                        dicthree.Add(three[i] + "/" + "m" + "/" + index, sayac);
                    }
                    else if (tur == saguclu)
                    {
                        dicthree.Add(three[i] + "/" + "sa" + "/" + index, sayac);
                    }
                    else if (tur == siyuclu)
                    {
                        dicthree.Add(three[i] + "/" + "si" + "/" + index, sayac);
                    }
                    else if (tur == spruclu)
                    {
                        dicthree.Add(three[i] + "/" + "sp" + "/" + index, sayac);
                    }
                }
                else
                {
                    if (tur == ekouclu)
                    {
                        if (!dicthree.ContainsKey(three[i] + "/" + "e" + "/" + index))
                            dicthree.Add(three[i] + "/" + "e" + "/" + index, sayac);

                    }
                    else if (tur == maguclu)
                    {
                        if (!dicthree.ContainsKey(three[i] + "/" + "m" + "/" + index))
                            dicthree.Add(three[i] + "/" + "m" + "/" + index, sayac);

                    }

                    else if (tur == saguclu)
                    {
                        if (!dicthree.ContainsKey(three[i] + "/" + "sa" + "/" + index))
                            dicthree.Add(three[i] + "/" + "sa" + "/" + index, sayac);

                    }
                    else if (tur == siyuclu)
                    {
                        if (!dicthree.ContainsKey(three[i] + "/" + "si" + "/" + index))
                            dicthree.Add(three[i] + "/" + "si" + "/" + index, sayac);

                    }
                    else if (tur == spruclu)
                    {
                        if (!dicthree.ContainsKey(three[i] + "/" + "sp" + "/" + index))
                            dicthree.Add(three[i] + "/" + "sp" + "/" + index, sayac);

                    }
                }
                sayac = 0;
            }
        }
        private void TemizleThree()
        {
            MessageBox.Show("binary listesine ekleme başladi");
            string text = "";
            string[] text1 = new string[dicthree.Count * 3];
            foreach (KeyValuePair<string, int> value in dicthree)
            {
                int sayi = 0;
                text = value.Key;
                text1 = text.Split('/');
                sayi = value.Value;
                listThree.Add(text1[0]);
                listSaThree.Add(sayi);
                Array.Clear(text1, 0, text1.Length);
            }
            MessageBox.Show("binary listesine ekleme bitti bitti");

            //////////////////////////////
            MessageBox.Show("50 den büyük Denetle Başladi");
            MessageBox.Show((listThree.Count / 5).ToString());
            int sayac = 0;
            for (int i = 0; i < listThree.Count / 5; i++)
            {
                sayac = listSaThree[i];
                for (int j = 0; j < listThree.Count / 5; j++)
                {
                    if (i != j)
                    {
                        if (listThree[i] == listThree[j])
                        {
                            sayac += listSaThree[i];
                        }
                    }
                }

                if (sayac > 50)
                {
                    if (!egitimThree.ContainsKey(listThree[i]))
                        egitimThree.Add(listThree[i], sayac);
                }
            }
            MessageBox.Show("denetleme bitti");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

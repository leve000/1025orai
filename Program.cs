using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyurcsaklj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Kérlek, add meg az első személyazonosító jel első 10 számjegyét: ");
            string szemelyi1 = Console.ReadLine();
            Console.Write("Kérlek, add meg a második személyazonosító jel első 10 számjegyét: ");
            string szemelyi2 = Console.ReadLine();

            NemetMegjelenit(szemelyi1);
            NemetMegjelenit(szemelyi2);

           
            int szuletesiSorszam1 = int.Parse(szemelyi1.Substring(7, 3));
            int szuletesiSorszam2 = int.Parse(szemelyi2.Substring(7, 3));
            Console.WriteLine($"Az első személy születési sorszáma: {szuletesiSorszam1}");
            Console.WriteLine($"A második személy születési sorszáma: {szuletesiSorszam2}");

        
            SzuletesnapokSzama(szemelyi1);
            SzuletesnapokSzama(szemelyi2);

            IdosebbSzemely(szemelyi1, szemelyi2);

            
            EvKulonbseg(szemelyi1, szemelyi2);

           
            idkiszam(szemelyi2);
        }

        static void NemetMegjelenit(string szemelyi)
        {
            int nemKód = int.Parse(szemelyi.Substring(0, 1));
            string nem = nemKód % 2 == 0 ? "nő" : "férfi";
            Console.WriteLine($"A személy neme: {nem}");
        }

        static void SzuletesnapokSzama(string szemelyi)
        {
            int szuletesiEv = int.Parse(szemelyi.Substring(1, 2));
            szuletesiEv += szuletesiEv < 97 ? 2000 : 1900; 
            int aktualisEv = DateTime.Now.Year;
            int szuletesnapokSzama = aktualisEv - szuletesiEv;

            Console.WriteLine($"A személy {szuletesnapokSzama} születésnapját ünnepli ebben az évben.");
        }

        static void IdosebbSzemely(string szemelyi1, string szemelyi2)
        {
            int szuletesiDatum1 = int.Parse(szemelyi1.Substring(1, 7));
            int szuletesiDatum2 = int.Parse(szemelyi2.Substring(1, 7));

            if (szuletesiDatum1 < szuletesiDatum2)
                Console.WriteLine("Az első személy idősebb.");
            else if (szuletesiDatum1 > szuletesiDatum2)
                Console.WriteLine("A második személy idősebb.");
            else
            {
                int sorszam1 = int.Parse(szemelyi1.Substring(8, 3));
                int sorszam2 = int.Parse(szemelyi2.Substring(8, 3));
                if (sorszam1 < sorszam2)
                    Console.WriteLine("Az első személy idősebb a születési sorszám alapján.");
                else if (sorszam1 > sorszam2)
                    Console.WriteLine("A második személy idősebb a születési sorszám alapján.");
                else
                    Console.WriteLine("A két személy ugyanakkor született.");
            }
        }

        static void EvKulonbseg(string szemelyi1, string szemelyi2)
        {
            int szuletesiEv1 = int.Parse(szemelyi1.Substring(1, 2));
            int szuletesiEv2 = int.Parse(szemelyi2.Substring(1, 2));
            szuletesiEv1 += szuletesiEv1 < 97 ? 2000 : 1900;
            szuletesiEv2 += szuletesiEv2 < 97 ? 2000 : 1900;

            int evKülönbség = Math.Abs(szuletesiEv1 - szuletesiEv2);
            Console.WriteLine($"A születési évek közötti különbség: {evKülönbség} év.");
        }

        static void idkiszam(string szemelyi)
        {
            if (szemelyi.Length < 10)
            {
                Console.WriteLine("Hibás személyazonosító jel. Kérlek, add meg az első 10 számjegyet.");
                return;
            }

            int osszeg = 0;
            for (int i = 0; i < 10; i++)
            {
                osszeg += int.Parse(szemelyi[i].ToString()) * (10 - i);
            }

            int ellenorzoSzam = osszeg % 11;
            if (ellenorzoSzam == 10)
            {
                Console.WriteLine("Hibás a születési sorszám!");
            }
            else
            {
                string teljesSzemelyi = szemelyi + ellenorzoSzam;
                Console.WriteLine($"A teljes személyazonosító jel: {teljesSzemelyi}");
            }
        }
    }
}


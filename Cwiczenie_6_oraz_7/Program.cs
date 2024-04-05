using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenie_6_oraz_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                string adresZrudlowy = "C:\\aaMag\\OdcinekSerialu.mkv";
                string adresDocelowy = "C:\\aaMag\\OdcinekSerialu_kopia.mkv";

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                using (FileStream sourceFileStream = new FileStream(adresZrudlowy, FileMode.Open, FileAccess.Read))
                    {
                        using (FileStream destinationFileStream = new FileStream(adresDocelowy, FileMode.Create, FileAccess.Write))
                        {
                            byte[] buffer = new byte[4096];

                            int bytesRead;
                            while ((bytesRead = sourceFileStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                destinationFileStream.Write(buffer, 0, bytesRead);
                            }

                            Console.WriteLine("Kopiowanie zakończone pomyślnie.");
                        }
                    }

                stopwatch.Stop();
                Console.WriteLine($"Czas kopiowania: {stopwatch.ElapsedMilliseconds} ms");
                // w moim przypadku kopiowanie pliku o wielkości 1 982 143 kb trwało 4745 ms

                Console.ReadKey();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAnonymousMethods
{
    //delegaten kan pege på en metode som returnerer en int og som har en int parameter
    delegate int delInt1par(int x);
    


    class AnonymousMethod
    {
        delegate bool delBool1par(int x);
        delegate int delInt2par(int x, int y);

        static void Main(string[] args)
        {

            //kalder metoden kvadrat med værdien 2 (OBS: se metoden kvadrat længere nede i koden)
            Console.WriteLine($"Kvadrat : {kvadrat(2)}");

            //delegaten delKvadrat peger på metoden kvadrat 
            delInt1par delKvadrat = kvadrat;

            //kalder metoden kvadrat gennem delegaten delKvadrat
            Console.WriteLine($"delKvadrat : {delKvadrat(2)}"); 

            //anonym metode som gør det samme som kvadrat metoden 
            //og som tildeles delegaten delKvadratAnonym
            delInt1par delKvadratAnonym = delegate(int x)
            {
                return x*x;
            };
            Console.WriteLine("delkvadrat : " + delKvadratAnonym (2));

            //anonym metode skrevet via Lamda syntax og som tildeles delegaten
            //delKvadratLamda
            delInt1par delKvadratLamda = x => x*x;
            Console.WriteLine($"delKvadrat lamda : {delKvadratLamda(2)}" );

            //Istedet for at bruge min egen delegate delInt1par kan jeg bruge
            //en forud defineret delegate Func, så derfor skal jeg bruge den.
            Func<int, int> funcDelegate = x => x * x;
            Console.WriteLine($"funcDelegate: {funcDelegate(2)}");


            //Her skal du selv arbejde med delegates, anonyme metoder og Lamda udtryk

            //Opgave 1: 
            // Test dine kald til metoder og delegates vha. Console.Writeline
            //-kod en delegate som kan pege på metoden "gtrThan100" :   private static bool gtrThan100(int x) 
            //-brug denne delegate og få den til at pege på metoden gtrThan100
            //-brug delegaten til at kode en anonym metode som gør det samme som metoden gtrThan100
            //-brug delegaten til at kode et lambda expression som gør det samme som  gtrThan100
            //-hvilken predefineret delagate kan du bruge istedet for din egen delegate -prøv at bruge den med et Lamda expression

            delBool1par delGtrThan100 = gtrThan100;
            Console.WriteLine("99 larger than 100?: "+ delGtrThan100(99));

            delBool1par delGtrThan100Annonymous = delegate (int x)
            {
                return x > 100;
            };
            Console.WriteLine("99 larger than 100? (annonym): " + delGtrThan100Annonymous(99));

            delBool1par delGtrThan100Lamda = x => x > 100;
            Console.WriteLine("99 larger than 100? (lamda): " + delGtrThan100Lamda(99));

            Func<int, bool> funcGtrThan100 = x => x > 100;
            Console.WriteLine("99 larger than 100? (func): " + funcGtrThan100(99));



            //Opgave2:
            //gør det samme som ovenstående opgave , nu bare med metoden "gange":  private static int gange(int x, int y)


            delInt2par delGange = gange;
            Console.WriteLine("6*5 = "+delGange(6,5));

            delInt2par delGangeAno = delegate (int x, int y)
            {
                return x * y;
            };
            Console.WriteLine("Ano: "+delGangeAno(6,5));

            delInt2par delGangeLamda = (x1, y1) => x1 * y1;
            Console.WriteLine("Lamda: "+delGangeLamda(6,5));

            Func<int,int,int> funcGange = (x1, y1) => x1 * y1;
            Console.WriteLine("Func: "+funcGange(6,5));


            Console.ReadLine();
        }


        /// <summary>
        /// Giver kvadratet på et tal
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static int kvadrat(int x)
        {
            return x * x;
        }

        /// <summary>
        /// tester for om x er større end 100
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static bool gtrThan100(int x)
        {
            return x > 100;
        }

        /// <summary>
        /// ganger x og y sammen
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static int gange(int x, int y)
        {
            return x*y;

        }


    }
}

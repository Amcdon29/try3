using System;
using System.Numerics;
namespace Coding_lab_2
{
    class Programk
    {
        static void Main(string[] args)
        {
            string NS = "11929413484016950905552721133125564964460656966152763801206748195494305685115033380631595703771562029730500011862877084668996911289221224545711806057499598951780042105263427376322274266393116193517839570773505632231596681121927337473973220312512599061231322250945506260066557538238517575390621262940383913963";
            string PS = "10933766183632575817611517034730668287155799984632223454138745671121273456287670008290843302875521274970245314593222946129064538358581018615539828479146469";
            string QS = "10910616967349110231723734078614922645337060882141748968209834225138976011179993394299810159736904468554021708289824396553412180514827996444845438176099727";
            BigInteger n = BigInteger.Parse(NS);
            BigInteger p = BigInteger.Parse(PS);
            BigInteger q = BigInteger.Parse(QS);
            BigInteger m = (p - 1) * (q - 1);
            BigInteger EX = 345;
            BigInteger into = (EX * EX) % m;
            Console.WriteLine(into);
            string e;
            BigInteger E;
            Console.WriteLine("Enter value for E here: ");
            e = Console.ReadLine();
            E = BigInteger.Parse(e);
            Console.WriteLine("You entered " + E + " for E");
            BigInteger x = m % E;
            if (x > 0)
            {
                for (BigInteger i = 1; i <= 20; i++)
                {
                    BigInteger Big = (1 + (i * m));
                    BigInteger remainder = Big % E;
                    if (remainder == 0)
                    {
                        Console.WriteLine("Available K ");
                        Console.WriteLine(i);
                    }
                }
                Console.WriteLine("Choose a value for K");
                string Kvalue = Console.ReadLine();
                BigInteger K = BigInteger.Parse(Kvalue);
                BigInteger D = (1 + (K * m) / E);
                Console.WriteLine("The value for D is " + D);
                Console.WriteLine("Public Key is " + (E, n));
                Console.WriteLine("Private Key is " + (D, n));
            }
            else
            {
                Console.WriteLine("E is not coprime of M try again");
            }
        }

        public static readonly BigInteger p = 987654321123456;
        public static readonly BigInteger q = 1302498943;
        public static readonly BigInteger m = p * q;

        public static BigInteger next(BigInteger prev)
        {
            return (prev * prev) % m;
        }

        public static int parity(BigInteger n)
        {
            BigInteger q = n;
            BigInteger count = 0;
            while (q != BigInteger.Zero)
            {
                count += q & BigInteger.One;
                q >>= 1;
            }
            return ((count & BigInteger.One) != BigInteger.Zero) ? 1 : 0; // even parity
        }



        static void Main1(string[] args)
        {
            BigInteger seed = 654321789;
            BigInteger seed2 = 1234654987;

            BigInteger xprev1 = seed2;

            BigInteger xprev = seed;
            for (int k = 0; k != 2; ++k)
            {
                BigInteger xnext = next(xprev);
                int bit = parity(xnext); // extract random bit from generated BBS number using parity,
                                         // or just int bit = LSB(xnext);

                xprev = xnext;

                BigInteger xnext1 = next(xprev1);


                xprev1 = xnext1;

            }
            Console.WriteLine(xprev);
            Console.WriteLine(xprev1);


        }

    }
}
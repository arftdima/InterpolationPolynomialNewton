using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ3_InterpolationPolynomialNewton
{
    class Program { 
    
        static Double SinPI(Double X) 
            => Math.Sin(Math.PI * X);

        static void Main(string[] args)
        {
            Int32 length = 1000;
            Int32 amt = 2*length + 1;
            Double temp = 0.5;
            Double point1 = 0.25;
            Double point2 = 500.25;


            Double[] x = new Double[amt];
            Double[] y = new Double[amt];
            x[0] = y[0] = 0;
            for(var i = 1; i < amt; ++i)
            {
                x[i] = x[i - 1] + temp;
                y[i] = SinPI(x[i]);
            }


            //Console.WriteLine($"SinPI(0.25)={SinPI(0.25)} \nNewton(0.25)={NewtonWiki(0.25, amt, x, y)}");
            //Console.WriteLine($"SinPI(5000.25)={SinPI(point2)} \nNewton(5000.25)={NewtonWiki(point2, amt, x, y)}");     
            Console.WriteLine($"y = x^3 \nideal: \n 2^3 = {8}\n (3.1)^3 = {Math.Pow(3.1, 3.0)} \n" +
                                        $"Newton: \n 2^3 = {Newton(2,5,new Double[] { 0,1,2,3,4}, new Double[] { 0,1,8,27,64})}\n (3.1)^3 = {Newton(3.1, 5, new Double[] { 0, 1, 2, 3, 4 }, new Double[] { 0, 1, 8, 27, 64 })}");

            Console.WriteLine(Newton(0.25, amt, x,y));
        }

        static Double Newton(Double X, Int32 n, Double[] x, Double[] y)
        {
            Double result = y[0];
            
            for (var i = 1; i < n; ++i)             //пройтись по всем узлам многочлена
            {
                var node = 0.0;
                for (var j = 0; j <= i; ++j)        //f[x_0,…,x_n ]
                {
                    var denominator = 1.0;
                    for (var k = 0; k <= i; ++k)
                    {
                        if (k != j)
                            denominator *= (x[j] - x[k]);
                    }
                    node += y[j] / denominator;
                }
                for (var k = 0; k < i; ++k)         //(x-x_0 )…(x-x_(i-1) )
                    node *= (X - x[k]);

                result += node;
            }
            return result;
        }


        
    }
}

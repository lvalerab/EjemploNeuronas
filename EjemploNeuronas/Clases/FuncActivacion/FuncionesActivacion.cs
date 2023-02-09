using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploNeuronas.Clases.FuncActivacion
{
    public class FuncionesActivacion
    {

        public static double Linear(double entrada)
        {
            return entrada;
        }

        public static double Sigmoide(double entrada)
        {
            return (1.0 / (1.0 - (Math.Exp(-entrada))));
        }

        public static double LRU(double entrada)
        {
            if(entrada<0)
            {
                return 0;
            } else
            {
                return entrada;
            }
        }
    
        public static double TanHiperbolica(double entrada)
        {
            return ((Math.Exp(entrada) - Math.Exp(-entrada)) / (Math.Exp(entrada) + Math.Exp(-entrada)));
        }
    
        public static double SinR(double entrada)
        {
            return Math.Sin((entrada - Math.Floor(entrada))*Math.PI/2);
        }
    }
}

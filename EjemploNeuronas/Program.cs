using EjemploNeuronas.Clases;
using EjemploNeuronas.Clases.Capas;
using EjemploNeuronas.Clases.FuncActivacion;
using EjemploNeuronas.Clases.Neuronas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EjemploNeuronas
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!");

            Neurona a = new Neurona(3);
            a.FuncionActivacion = FuncionesActivacion.TanHiperbolica;
            a.Sesgo = -2;
            Entrenador<double[]> entrenador = new Entrenador<double[]>(a, 0.25);
            entrenador.Entrenar(new double[] { 1, 2, 3 }, 6);
            entrenador.Entrenar(new double[] { 2, 2, 2 }, 3);
            entrenador.Entrenar(new double[] { 0, 12, -6 }, 12);
            entrenador.Entrenar(new double[] { 4, -5, 7 }, 24);

            ConvulocionalNeurona cn = new ConvulocionalNeurona(3);
            cn.FuncionActivacion = FuncionesActivacion.Sigmoide;
            cn.Sesgo = -2;

            Entrenador<double[,]> ecn = new Entrenador<double[,]>(cn, 0.25);
            ecn.Entrenar(new double[3, 3] { {1,0,0 },
                                           { 0,1,0 },
                                           { 0,0,1 } },1);

            ecn.Entrenar(new double[3, 3] { {1,2,3 },
                                           { 2,1,2 },
                                           { 3,2,1 } }, 1);

            ecn.Entrenar(new double[3, 3] { {0,-2,-3 },
                                           { 2,0,-2 },
                                           { 3,2,0 } }, 0);

            ecn.Entrenar(new double[3, 3] { {0,0,0 },
                                           { 0,0,0 },
                                           { 0,0,0 } }, 0);

            a.Entradas = new double[] { 1, 2, 3 };
            a.CalcularSalida();
            Console.WriteLine("Salida {0}", a.Salida);

            a.Entradas = new double[] { 4, 6.2, -9 };
            a.CalcularSalida();
            Console.WriteLine("Salida {0}", a.Salida);


            cn.Entradas = new double[3, 3] { {1,0,0 },
                                           { 0,1,0 },
                                           { 0,0,1 } };

            cn.CalcularSalida();
            Console.WriteLine("Salida {0}", cn.Salida);

            cn.Entradas = new double[3, 3] { {1,0,0 },
                                           { 0,0,0 },
                                           { 0,0,1 } };

            cn.CalcularSalida();
            Console.WriteLine("Salida {0}", cn.Salida);

            */

            Console.WriteLine("Donde esta el fichero de datos (formato json)");
            string rutaJson=Console.ReadLine();
            JsonDocument jdoc = null;
            try
            {
                StreamReader sr = new StreamReader(rutaJson, true);
                string contenido = sr.ReadToEnd();
                sr.Close();
                jdoc = JsonDocument.Parse(contenido);
            } catch(Exception err)
            {
                Console.WriteLine("Ha ocurrido un error al leer el fichero, causa: " + err.Message);
            }

            List<Dto.MovimientoClima> movimientos = jdoc.Deserialize<List<Dto.MovimientoClima>>();

            foreach(Dto.MovimientoClima movimiento in movimientos)
            {
                Console.WriteLine("{0}\t{0}\t{0}\t", movimiento.CFecha.ToString(), movimiento.tmin, movimiento.tmax);
            }

            Console.WriteLine("Se han volcado todos los datos, ¿Entrenar la neurona?");
            bool Entrenar = Console.ReadLine().ToUpper().Equals("S");
            Neurona a = new Neurona(2);
            a.FuncionActivacion = FuncionesActivacion.Linear;
            a.Sesgo = 0;
            Entrenador<double[]> entrenador = new Entrenador<double[]>(a, 0.01);
            Console.WriteLine("Kernel antes de entrenar");
            for(int i=0;i<a.Kernel.Length;i++)
            {
                Console.Write("{0}=>{1}", i, a.Kernel[i]);
            }
            Console.ReadLine();
            foreach (Dto.MovimientoClima mov in movimientos)
            {
                double minima = mov.tminima ?? 0;
                double maxima = mov.tmaxima ?? 0;
                double media = mov.tmedia ?? 0;
                //entrenador.Entrenar(new double[] {minima, maxima, (mov.CFecha??DateTime.Now).Month },minima);
                entrenador.Entrenar(new double[] { minima, maxima }, media);
                Console.WriteLine("min {0}, max {1}, mes {2} => media {3}", minima, maxima, (mov.CFecha ?? DateTime.Now).Month, media);
            }
            Console.WriteLine("Kernel despues de entrenar");
            for (int i = 0; i < a.Kernel.Length; i++)
            {
                Console.Write("{0}=>{1}", i, a.Kernel[i]);
            }
            Console.ReadLine();
            Console.WriteLine("Neurona entrenada");
            bool salir = false;
            while(!salir)
            {
                try { 
                    Console.WriteLine("Temperatura minima: ");
                    string lectura = Console.ReadLine();
                    Console.WriteLine("Temperatura máxima: ");
                    string maxima = Console.ReadLine();
                    //Console.WriteLine("Mes");
                    //string mes = Console.ReadLine();
                    a.Entradas = new double[] { double.Parse(lectura), double.Parse(maxima)};
                    a.CalcularSalida();
                    Console.WriteLine("Temperatura media predicha: {0}", a.Salida);
                } catch(Exception err)
                {
                    Console.WriteLine("Error " + err.Message);
                }
                salir = Console.ReadLine().ToUpper().Contains("S");
                Console.Clear();
            }
        }
    }
}

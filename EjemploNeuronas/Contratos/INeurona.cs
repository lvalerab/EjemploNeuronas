using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploNeuronas.Contratos
{
    public delegate double FuncionActivacion(double entrada);
    public interface INeurona<E,K,S>
    { 
        public S Salidas {get; set; }
        public K Kernel { get; set; }
        public E Entradas { get; set; }
        public double Salida { get; set; }
        public double? Sesgo { get; set; }
        public void CalcularSalida();
        public void Entrenar(double error, double TasaAprendizaje);
        public FuncionActivacion FuncionActivacion { get; set; }
    }
}

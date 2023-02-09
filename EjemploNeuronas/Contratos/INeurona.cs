using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploNeuronas.Contratos
{
    public delegate double FuncionActivacion(double entrada);
    public interface INeurona<T>
    {
        public T Kernel { get; set; }
        public T Entradas { get; set; }
        public double Salida { get; set; }
        public double? Sesgo { get; set; }
        public void CalcularSalida();
        public void Entrenar(double error, double TasaAprendizaje);
        public FuncionActivacion FuncionActivacion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Practica_Empresa
{
    public class Registrar_Empresa
    {
        static IEmpresasRepositorio empresasRepositorio = new EmpresasRepositorio();


        public void RegistroEmpresas()
        {
            char Continuar = 'Z';
            while (Continuar != 'M')
            {
                Console.Clear();

                Console.WriteLine("Escribir el nombre de la empresa: ");
                string nombre = Console.ReadLine();

                Console.WriteLine("Escribir el nombre del representante: ");
                string representante = Console.ReadLine();

                Console.WriteLine("Escribir el RNC: ");
                string rnc = Console.ReadLine();

                Console.WriteLine("Escribir la direccion: ");
                string direccion = Console.ReadLine();


                var resultado = empresasRepositorio.Create(new Info() { Nombre = nombre, Representante = representante, RNC = rnc, Direccion = direccion });

                Console.WriteLine(resultado.Message);

                Console.WriteLine("");
                Console.WriteLine("C - Registrar otra Empresa");
                Console.WriteLine("M - Volver al Menu");
                Console.Write("Opcion: ");
                Continuar = Console.ReadLine().ToUpper()[0];
            }

        }
    }
}

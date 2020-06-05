using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Practica_Empresa
{
    public class Buscar_RNC
    {
        static IEmpresasRepositorio empresasRepositorio = new EmpresasRepositorio();


        public  void BuscarRNC()
        {

            //string rncEmpresa;
            char Continuar = 'Z';
            while (Continuar != 'M')
            {
                Console.Clear();

                Console.WriteLine("Escriba el RNC de la empresa a buscar: ");

                string rncEmpresa = Console.ReadLine();



                var rncEmpresas = empresasRepositorio.FindByRNC(rncEmpresa);

                if (!rncEmpresas.Result)
                {
                    Console.WriteLine(rncEmpresas.Message);
                }
                else
                {
                    DataTable dataEmpresa = (DataTable)rncEmpresas.Data;

                    foreach (DataRow empr in dataEmpresa.Rows)
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"RNC: {empr["RNC"]}");
                        Console.WriteLine($"Empresa: {empr["Nombre"]}");
                        Console.WriteLine($"Representante: {empr["Representante"]}");
                        Console.WriteLine("");
                    }
                }

                Console.WriteLine("S - Buscar otra Empresa por RNC");
                Console.WriteLine("M - Volver al Menu");
                Console.Write("Opcion: ");
                Continuar = Console.ReadLine().ToUpper()[0];

            }
        }
    }
}

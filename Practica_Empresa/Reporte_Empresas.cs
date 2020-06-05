using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Practica_Empresa
{
    public class Reporte_Empresas
    {
        static IEmpresasRepositorio empresasRepositorio = new EmpresasRepositorio();


        public  void ReporteEmpresas()
        {
            char Continuar = 'Z';
            while (Continuar != 'M')
            {
                Console.Clear();

                OperationResult empresas = empresasRepositorio.GetAll();

                if (!empresas.Result)
                {
                    Console.WriteLine(empresas.Message);
                }
                else
                {
                    DataTable dataEmpresas = (DataTable)empresas.Data;

                    foreach (DataRow empr in dataEmpresas.Rows)
                    {
                        Console.WriteLine($"RNC: {empr["RNC"]}");
                        Console.WriteLine($"Empresa: {empr["Nombre"]}");
                        Console.WriteLine($"Representante: {empr["Representante"]}");
                        Console.WriteLine("");
                    }
                }

                Console.WriteLine("R - Hacer reporte de las Empresas otra vez");
                Console.WriteLine("M - Volver al Menu");
                Console.Write("Opcion: ");
                Continuar = Console.ReadLine().ToUpper()[0];
            }


        }
    }
}

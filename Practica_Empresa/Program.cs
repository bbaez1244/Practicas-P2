using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Practica_Empresa
{
    class Program
    {
        static IEmpresasRepositorio empresasRepositorio = new EmpresasRepositorio();


        public static void Main(string[] args)
        {
           

            string opcion = null;
            do
            {
                Console.Clear();

                Console.WriteLine("Sistema de Registro de Empresas");
                Console.WriteLine("");

                Console.WriteLine("C - Registrar Empresa");
                Console.WriteLine("R - Reporte de las Empresas");
                Console.WriteLine("S - Buscar Empresa por RNC");
                Console.WriteLine("U - Actualizar Datos de Empresa");
                Console.WriteLine("D - Borrar Empresa");
                Console.WriteLine("E - Salir");
                Console.WriteLine("");
                Console.Write("Opcion: ");
                opcion = Console.ReadLine();

                if (opcion.ToUpper() == "C")
                {
                    Registrar_Empresa registrarempresa = new Registrar_Empresa();
                    registrarempresa.RegistroEmpresas();
                }
                if (opcion.ToUpper() == "R")
                {
                    Reporte_Empresas registrarempresa = new Reporte_Empresas();
                    registrarempresa.ReporteEmpresas();
                }
                if (opcion.ToUpper() == "S")
                {
                    Buscar_RNC registrarempresa = new Buscar_RNC();
                    registrarempresa.BuscarRNC();
                }
                if (opcion.ToUpper() == "U")
                {
                    Actualizar_Empresa registrarempresa = new Actualizar_Empresa();
                    registrarempresa.ActualizarEmpresa();
                }
                if (opcion.ToUpper() == "D")
                {
                    Eliminar_Empresa registrarempresa = new Eliminar_Empresa();
                    registrarempresa.EliminarEmpresa();
                }
            } while (opcion.ToUpper() != "E");
        }



            
    }
}

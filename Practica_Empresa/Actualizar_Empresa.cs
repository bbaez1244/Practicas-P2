using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Practica_Empresa
{
    public class Actualizar_Empresa
    {
        static IEmpresasRepositorio empresasRepositorio = new EmpresasRepositorio();


        public  void ActualizarEmpresa()
        {
            char Continuar = 'Z';
            while (Continuar != 'M')
            {
                Console.Clear();

                Console.WriteLine("RNC a modificar: ");
                string rncEmpresa = Console.ReadLine();

                OperationResult empresa = empresasRepositorio.FindByRNC(rncEmpresa);

                if (!empresa.Result)
                {
                    Console.WriteLine(empresa.Message);
                }
                else
                {
                    DataTable dataEmpresa = (DataTable)empresa.Data;

                    foreach (DataRow empr in dataEmpresa.Rows)
                    {
                        Console.WriteLine($"RNC: {empr["RNC"]}");
                        Console.WriteLine($"Empresa: {empr["Nombre"]}");
                        Console.WriteLine($"Representante: {empr["Representante"]}");
                        Console.WriteLine("");
                    }

                    Console.Write("Nueva Direccion: ");
                    var Direccion_nueva = Console.ReadLine();
                    Console.Write("Nuevo Representante: ");
                    var Representante_nuevo = Console.ReadLine();

                    var actualizar = empresasRepositorio.Update(new Info() { Direccion = Direccion_nueva, Representante = Representante_nuevo }, rncEmpresa);
                    Console.WriteLine(actualizar.Message);

                    Console.WriteLine("");
                    Console.WriteLine("U - Actualizar Datos de otra Empresa");
                    Console.WriteLine("M - Volver al Menu");
                    Console.Write("Opcion: ");
                    Continuar = Console.ReadLine().ToUpper()[0];
                }

            }
        }
    }
}

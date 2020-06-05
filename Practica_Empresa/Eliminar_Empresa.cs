using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Practica_Empresa
{
    public class Eliminar_Empresa
    {
        static IEmpresasRepositorio empresasRepositorio = new EmpresasRepositorio();


        public  void EliminarEmpresa()
        {
            char Continuar = 'Z';
            while (Continuar != 'M')
            {
                Console.Clear();

                Console.WriteLine("RNC a eliminar: ");
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

                    Console.Write("Esta seguro que desea borra esta empresa? S/N: ");
                    var confirmar = Console.ReadLine();

                    if (confirmar.ToUpper() == "S")
                    {
                        var delete = empresasRepositorio.SoftDelete(rncEmpresa);
                        Console.WriteLine(delete.Message);
                    }
                }


                Console.WriteLine("");
                Console.WriteLine("D - Eliminar otra Empresa");
                Console.WriteLine("M - Volver al Menu");
                Console.Write("Opcion: ");
                Continuar = Console.ReadLine().ToUpper()[0];

            }

        }
    }
}

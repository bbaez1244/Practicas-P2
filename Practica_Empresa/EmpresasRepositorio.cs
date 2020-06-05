using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Practica_Empresa
{
    class EmpresasRepositorio : IEmpresasRepositorio
    {
        string connect = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
        public OperationResult Create(Info empresa)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = $"INSERT INTO empresas (Nombre, Representante, RNC, Direccion, Borrado) VALUES ('{empresa.Nombre}', '{empresa.Representante}', '{empresa.RNC}', '{empresa.Direccion}', 0)";
                    cmd.Connection = conn;

                    conn.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return new OperationResult() { Result = true, Message = "Empresa creada!" };
                    }
                    catch (Exception ex)
                    {
                        return new OperationResult(false, $"Se ha producido un error, {ex.Message}");
                    }
                }
            }

        }

        public OperationResult GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT RNC, Nombre, Representante FROM empresas WHERE borrado = 0", conn))
                {
                    DataTable data = new DataTable();
                    SqlDataAdapter dataA = new SqlDataAdapter(cmd);

                    conn.Open();

                    try
                    {
                        dataA.Fill(data);

                        if (data.Rows.Count > 0)
                        {
                            return new OperationResult() { Result = true, Data = data };
                        }

                        return new OperationResult() { Result = false, Message = "No hay empresas registradas." };
                    }
                    catch (Exception ex)
                    {
                        return new OperationResult() { Result = false, Message = $"Ha ocurrido un error. {ex.Message}" };
                    }

                }


            }
        }

        public OperationResult FindByRNC(string rnc)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT RNC, Nombre, Representante FROM empresas WHERE RNC = '{rnc}' AND borrado = 0" , conn))
                {
                    DataTable data = new DataTable();

                    conn.Open();

                    try
                    {
                        SqlDataReader dataR = cmd.ExecuteReader();
                        data.Load(dataR);

                        if (data.Rows.Count > 0)
                        {
                            return new OperationResult() { Result = true, Data = data };
                        }

                        return new OperationResult() { Result = false, Message = $"No hay empresas registradas con el RNC '{rnc}'." };
                    }
                    catch (Exception ex)
                    {
                        return new OperationResult() { Result = false, Message = $"Ha ocurrido un error. {ex.Message}" };
                    }

                }
            }


        }

        public OperationResult Update(Info Aempresa, string rnc)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                using (SqlCommand cmd = new SqlCommand($"UPDATE empresas SET Direccion = '{Aempresa.Direccion}', Representante = '{Aempresa.Representante}' WHERE RNC = '{rnc}' AND Borrado=0", conn))
                {
                    

                    conn.Open();

                    try
                    {
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            return new OperationResult(false, $"No se encontro empresa con RNC '{rnc}'.");
                        }
                        return new OperationResult() { Result = true, Message = "Empresa actualizada con éxito" };
                    }
                    catch (Exception ex)
                    {
                        return new OperationResult(false, $"Ha ocurrido un error. {ex.Message}");
                    }
                }
            }
        }

        public OperationResult SoftDelete(string rnc)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                using (SqlCommand cmd = new SqlCommand($"UPDATE empresas SET Borrado = 1 WHERE RNC = '{rnc}'", conn))
                {
                    

                    conn.Open();

                    try
                    {
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            return new OperationResult(false, $"No se encontro empresa con RNC '{rnc}'.");
                        }
                        return new OperationResult() { Result = true, Message = "Empresa Eliminada Satisfactoriamente" };
                    }
                    catch (Exception ex)
                    {
                        return new OperationResult(false, $"Ha ocurrido un error. {ex.Message}");
                    }
                }
            }
        }
    }
}
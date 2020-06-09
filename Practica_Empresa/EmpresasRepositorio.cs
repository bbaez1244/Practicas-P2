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
                using (SqlCommand cmd = new SqlCommand("CreateEmpresa", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Nombre", empresa.Nombre);
                    cmd.Parameters.AddWithValue("Representante", empresa.Representante);
                    cmd.Parameters.AddWithValue("RNC", empresa.RNC);
                    cmd.Parameters.AddWithValue("Direccion", empresa.Direccion);
                    
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
                using (SqlCommand cmd = new SqlCommand("GetAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
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
                using (SqlCommand cmd = new SqlCommand("FindByRNC" , conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("RNC", rnc);
                    
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
                using (SqlCommand cmd = new SqlCommand("UpdateEmpresa", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Direccion", Aempresa.Direccion);
                    cmd.Parameters.AddWithValue("Representante", Aempresa.Representante);
                    cmd.Parameters.AddWithValue("RNC", rnc);



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
                using (SqlCommand cmd = new SqlCommand("SoftDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("RNC", rnc);
                    

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
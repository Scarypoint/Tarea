﻿using Calificaciones.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calificaciones
{
    namespace Calificaciones
    {
<<<<<<< HEAD
        class Central
        {
            // Cadena de conexión a SQL Server
            static string constrg = "Server=localhost\\SQLEXPRESS;Database=BDCALIFICACIONES;User Id=Carlos;Password=77777;TrustServerCertificate=True;";

            // Método para registrar un alumno
            public static void RegistrarAlumno(Alumno alumno)
=======
        static string constrg = "Data Source=DESKTOP-9LEERSH\\PROGRAMMING;" +
            "Initial Catalog=Calificaciones;User ID=sa;Password=123456;TrustServerCertificate=True";
        //"Data Source=DESKTOP-9LEERSH\\PROGRAMMING;Initial Catalog=unidep;User ID=sa;Password=123456;TrustServerCertificate=True");

        public static Response RegistrarAlumno(Alumno alumno)
        {
            Response response = new Response();
            //codigo para registrar alumno
            SqlConnection conn = new SqlConnection(constrg);
            SqlCommand comm = new SqlCommand("insert into Alumnos (nombre,apellidos,matricula)values(@Nombre,@Apellidos,@Matricula) ", conn);
            comm.Parameters.AddWithValue("@Nombre", alumno.Nombre);
            comm.Parameters.AddWithValue("@Apellidos", alumno.Apellidos);
            comm.Parameters.AddWithValue("@Matricula", alumno.Matricula);
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                response.Codigo = 1;
                response.Mensaje = "Alumno regitrado correctamente";
            }
            catch (Exception ex)
            {
                response.Codigo = 2;
                response.Mensaje = "Ocurrio un error, el alumno no pudo ser registrado";
                Logger.Log(ex.Message, "RegistrarAlumno","Central");
            }
            finally
>>>>>>> e57e9dabfd7f494b8950681b6935c585e4ebc511
            {
                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(alumno.Nombre) ||
                    string.IsNullOrWhiteSpace(alumno.Apellidos) ||
                    string.IsNullOrWhiteSpace(alumno.Matricula))
                {
                    MessageBox.Show("Todos los campos son obligatorios. Completa toda la información.", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Código para registrar alumno en la base de datos
                using (SqlConnection conn = new SqlConnection(constrg))
                {
                    SqlCommand comm = new SqlCommand("INSERT INTO tablita2 (Nombre, Apellidos, Matricula) VALUES (@Nombre, @Apellidos, @Matricula)", conn);
                    comm.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                    comm.Parameters.AddWithValue("@Apellidos", alumno.Apellidos);
                    comm.Parameters.AddWithValue("@Matricula", alumno.Matricula);

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();

                        // Mostrar un MessageBox al registrar correctamente
                        MessageBox.Show("Alumno registrado exitosamente.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Mostrar mensaje de error en un MessageBox
                        MessageBox.Show($"Error al registrar el alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Método para cargar los alumnos en un DataTable desde la base de datos
            public static DataTable CargarAlumnos()
            {
                DataTable tablita2 = new DataTable();
                using (SqlConnection conn = new SqlConnection(constrg))
                {
                    SqlCommand comm = new SqlCommand("SELECT * FROM tablita2", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(comm);

                    try
                    {
                        conn.Open();
                        adapter.Fill(tablita2);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar los alumnos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return tablita2;
            }

            public static void RegistrarMateria(Materia materia)
            {
                // Cadena de conexión a la base de datos
                string connectionString = "Server=localhost\\SQLEXPRESS;Database=BDCALIFICACIONES;User Id=Carlos;Password=77777;TrustServerCertificate=True;";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Materias (Nombre, Codigo) VALUES (@txtnombre, @txtcodigo)";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@txtnombre", materia.Nombre);
                        cmd.Parameters.AddWithValue("@txtcodigo", materia.Codigo);

                        try
                        {
                            conexion.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Materia registrada con éxito.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al registrar la materia: " + ex.Message);
                        }
                    }
                }
            }

            public static DataTable CargarMaterias()
            {
                DataTable Materias = new DataTable();
                using (SqlConnection conn = new SqlConnection(constrg))
                {
                    SqlCommand comm = new SqlCommand("SELECT * FROM Materias", conn);  // Asegúrate de que la tabla 'Materias' existe
                    SqlDataAdapter adapter = new SqlDataAdapter(comm);

                    try
                    {
                        conn.Open();
                        adapter.Fill(Materias);  // Llenar el DataTable con los resultados
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar las materias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return Materias;
            }
            return response;
        }
<<<<<<< HEAD
=======
        public static DataTable CaragarAlumnos()
        {
            DataTable dtalumnos = new DataTable();
            SqlConnection conn = new SqlConnection(constrg);
            SqlCommand comm = new SqlCommand("select * from alumnos", conn);
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(dtalumnos);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message, "CaragarAlumnos", "Central");
            }
            finally
            {
                conn.Close();
            }
            return dtalumnos;
        }

        //se define el parametro com objeto para evitar el agregar mas campos si se requieren despues
        public static void RegistarMateria(Materia materia)
        {
            //codigp para registrar materia
        }
        public static DataTable CaragarMaterias()
        {
            DataTable dtmaterias = new DataTable();
            //codigo para obtener lista de materias
            return dtmaterias;
        }

>>>>>>> e57e9dabfd7f494b8950681b6935c585e4ebc511
    }
}

            //public static DataTable CargarCalificaciones()
   
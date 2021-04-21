using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EjemploArchivoDelimitado
{
    internal static class ManejoArchivosProyPersonales
    {
        private static string ArchivoProyectos = AppDomain.CurrentDomain.BaseDirectory + "\\proyPersonales.txt";
        private const int CANT_ATRIBUTOS_PROYECTO = 9; //puede q sean 10 contando el id de los hijos
        public static void GuardarObjetoEnArchivoDelimitado(Personal unProyecto, string delimitador)
        {
            try
            {

                //El constructor de StreamWriter recibe el nombre del archivo y true si se desean
                //agregar registros, false si se va a sobrescribir el archivo.
                using (StreamWriter sw = new StreamWriter("proyPersonales.txt", true))
                {
                    sw.WriteLine(unProyecto.Id + delimitador
                        + unProyecto.Titulo + delimitador
                        + unProyecto.Descripcion + delimitador
                        + unProyecto.MontoSolicitado + delimitador
                        + unProyecto.CantCuotas + delimitador
                        + unProyecto.Imagen + delimitador
                        + unProyecto.Fecha.Date + delimitador
                        + unProyecto.SolicitanteCi + delimitador
                        + unProyecto.ExpProy);
                }
            }
            catch (FileNotFoundException) { throw; }
            catch (PathTooLongException) { throw; }
            catch (InvalidDataException) { throw; }
            catch (DirectoryNotFoundException) { throw; }
            catch (DriveNotFoundException) { throw; }
            catch (Exception) { throw; }
        }
        public static void Eliminar(string clave, string delimitador)
        {
            StreamReader sr = null;
            int i = 0;
            string textoOrig = "";
            System.Text.StringBuilder textoNuevo = new System.Text.StringBuilder();
            using (sr = new StreamReader(ArchivoProyectos))
            {
                textoOrig = sr.ReadToEnd();
            }
            if (textoOrig != null)
            {
                string[] vectorLineas = textoOrig.Split(System.Environment.NewLine.ToCharArray(),
                    StringSplitOptions.RemoveEmptyEntries);
                foreach (var s in vectorLineas)
                {
                    string[] v2 = s.Split(delimitador.ToCharArray());
                    if (v2[0] != clave)
                        textoNuevo.AppendLine(s);
                }
            }
            File.WriteAllText(ArchivoProyectos, textoNuevo.ToString());
        }
        private static Personal ObtenerDesdeString(string dato, string delimitador)
        {
            string[] vecDatos = dato.Split(delimitador.ToCharArray());
            if (vecDatos.Length == CANT_ATRIBUTOS_PROYECTO) //Verificar que la línea está ok
            {
                return new Personal
                {
                    Id = Convert.ToInt32(vecDatos[0]),
                    Titulo = vecDatos[1],
                    Descripcion = vecDatos[2],
                    MontoSolicitado = Convert.ToInt32(vecDatos[3]),
                    CantCuotas = Convert.ToInt32(vecDatos[4]),
                    Imagen = vecDatos[5],
                    Fecha = DateTime.Parse(vecDatos[6]),
                    SolicitanteCi = vecDatos[7],
                    ExpProy = vecDatos[8]
                };
            }
            else
                return null;
        }


        public static object Insertar(Personal unProyecto)
        {
            if (unProyecto != null && ManejoArchivosProyPersonales.Leer(unProyecto.Titulo) == null)
            {
                ManejoArchivosProyPersonales.GuardarObjetoEnArchivoDelimitado(unProyecto, "|");
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Personal Leer(string clave)
        {
            StreamReader sr = null;

            using (sr = new StreamReader(ArchivoProyectos))
            {
                string linea = sr.ReadLine();
                while (linea != null)
                {
                    Personal unProyecto = ManejoArchivosProyPersonales.ObtenerDesdeString(linea, "|");
                    if (unProyecto != null)
                    {
                        if (unProyecto.Titulo.Equals(clave, StringComparison.CurrentCultureIgnoreCase))
                        {
                            return unProyecto;
                        }
                    }
                    linea = sr.ReadLine();

                }
            }
            return null;

        }

        public static List<Personal> ObtenerTodos()
        {
            List<Personal> retorno = new List<Personal>();
            using (StreamReader sr = File.OpenText(ArchivoProyectos))
            {
                string linea = sr.ReadLine();
                while ((linea != null))
                {
                    if (linea.IndexOf("|") > 0)
                    {
                        retorno.Add(ObtenerDesdeString(linea, "|"));
                    }
                    linea = sr.ReadLine();
                }

            }
            return retorno;

        }
    }
}




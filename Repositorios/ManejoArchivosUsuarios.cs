using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EjemploArchivoDelimitado
{
    internal static class ManejoArchivosUsuarios
    {
        private static string ArchivoSolicitantes = AppDomain.CurrentDomain.BaseDirectory + "\\solicitantes.txt";
        private const int CANT_ATRIBUTOS_SOLICITANTE = 7;
        public static void GuardarObjetoEnArchivoDelimitado(Solicitante unSolicitante, string delimitador)
        {
            try
            {

                //El constructor de StreamWriter recibe el nombre del archivo y true si se desean
                //agregar registros, false si se va a sobrescribir el archivo.
                using (StreamWriter sw = new StreamWriter("solicitantes.txt", true))
                {
                    sw.WriteLine(unSolicitante.Ci + delimitador
                        + unSolicitante.Password + delimitador
                        + unSolicitante.Nombre + delimitador
                        + unSolicitante.TipoUsuario + delimitador
                        + unSolicitante.Apellido + delimitador
                        + unSolicitante.FechaNac.Date + delimitador
                        + unSolicitante.Celular);
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
            using (sr = new StreamReader(ArchivoSolicitantes))
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
            File.WriteAllText(ArchivoSolicitantes, textoNuevo.ToString());
        }
        private static Solicitante ObtenerDesdeString(string dato, string delimitador)
        {
            string[] vecDatos = dato.Split(delimitador.ToCharArray());
            if (vecDatos.Length == CANT_ATRIBUTOS_SOLICITANTE) //Verificar que la línea está ok
            {
                return new Solicitante
                {
                    Ci = vecDatos[0],
                    Password = vecDatos[1],
                    TipoUsuario = vecDatos[2],
                    Nombre = vecDatos[3],
                    Apellido = vecDatos[4],
                    FechaNac = DateTime.Parse(vecDatos[5]),
                    Celular = vecDatos[6]
                };
            }
            else
                return null; 
        }


        public static object Insertar(Solicitante unSolicitante)
        {
            if (unSolicitante != null && ManejoArchivosUsuarios.Leer(unSolicitante.Nombre) == null)
            {
                ManejoArchivosUsuarios.GuardarObjetoEnArchivoDelimitado(unSolicitante, "|");
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Solicitante Leer(string clave)
        {
            StreamReader sr = null;

            using (sr = new StreamReader(ArchivoSolicitantes))
            {
                string linea = sr.ReadLine();
                while (linea != null)
                {
                    Solicitante unSolicitante = ManejoArchivosUsuarios.ObtenerDesdeString(linea, "|");
                    if (unSolicitante != null)
                    {
                        if (unSolicitante.Nombre.Equals(clave, StringComparison.CurrentCultureIgnoreCase))
                        {
                            return unSolicitante;
                        }
                    }
                    linea = sr.ReadLine();

                }
            }
            return null;

        }

        public static List<Solicitante> ObtenerTodos()
        {
            List<Solicitante> retorno = new List<Solicitante>();
            using (StreamReader sr = File.OpenText(ArchivoSolicitantes))
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




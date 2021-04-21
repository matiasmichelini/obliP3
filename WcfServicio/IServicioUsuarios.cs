using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioUsuarios
    {


        [OperationContract]
        List<DtoSolicitante> AgregarSolicitantes();
        [OperationContract]
        List<DtoPersonal> AgregarPersonales();
        [OperationContract]
        List<DtoCooperativo> AgregarCooperativos();
        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class DtoSolicitante
    {
       
        [DataMember]
        public string Ci { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string TipoUsuario { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellido { get; set; }
        [DataMember]
        public DateTime FechaNac { get; set; }
        [DataMember]
        public string Celular { get; set; }


    }
    [DataContract]
    public class DtoPersonal
    {

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Titulo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public int MontoSolicitado { get; set; }
        [DataMember]
        public int CantCuotas { get; set; }
        [DataMember]
        public string Imagen { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public string SolicitanteCi { get; set; }
        [DataMember]
        public string ExpProy { get; set; }

    }
    [DataContract]
    public class DtoCooperativo
    {

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Titulo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public int MontoSolicitado { get; set; }
        [DataMember]
        public int CantCuotas { get; set; }
        [DataMember]
        public string Imagen { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public string SolicitanteCi { get; set; }
        [DataMember]
        public int Integrantes { get; set; }

    }
}

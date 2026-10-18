using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.bo
{
    [Serializable]
    [DataContract]
    public class EmpleadoBO
    {
        [DataMember]
        public int codigo { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string apepaterno { get; set; }
        [DataMember]
        public string apematerno { get; set; }
        [DataMember]
        public string documento { get; set; }
        [DataMember]
        public string direccion { get; set; }
        [DataMember]
        public DateTime fecha { get; set; }
        [DataMember]
        public string nacionalidad { get; set; }
        [DataMember]
        public string telefono { get; set; }
        [DataMember]
        public string celular { get; set; }
        [DataMember]
        public string correo { get; set; }
        [DataMember]
        public string usuario { get; set; }
        [DataMember]
        public string clave { get; set; }
        [DataMember]
        public bool estado { get; set; }
        [DataMember]
        public DistritoBO distrito { get; set; }
        [DataMember]
        public RolBO rol { get; set; }
        [DataMember]
        public TipoDocumentoBO tipoDocumento { get; set; }
        [DataMember]
        public SexoBO sexo { get; set; }
        [DataMember]
        public EstadoCivilBO estadoCivil { get; set; }
    }
}

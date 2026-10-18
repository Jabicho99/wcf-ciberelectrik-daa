using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.bo
{
    //[Serializable] -> convierte a la clase en serializable
    [Serializable]
    //[DataContract] -> contrato de datos para WCF y usa serializacion basada en XML o JSON
    [DataContract]
    public class CategoriaBO
    {
        //[DataMember] -> marca las propiedades o campos que seran serializados y enviados
        [DataMember]
        public int codigo { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public bool estado { get; set; }
    }
}

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
    public class MarcaBO
    {
        [DataMember]
        public int codigo { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public bool estado { get; set; }
    }
}

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
    public class ProductoBO
    {
        [DataMember]
        public int codigo { get; set; }
        public string nombre { get; set; }
        [DataMember]
        public string descripcion { get; set; }
        [DataMember]
        public decimal precio { get; set; }
        [DataMember]
        public int cantidad { get; set; }
        [DataMember]
        public DateTime fechaingreso { get; set; }
        [DataMember]
        public bool estado { get; set; }
        [DataMember]
        public MarcaBO marca { get; set; }
        [DataMember]
        public CategoriaBO categoria { get; set; }
    }
}

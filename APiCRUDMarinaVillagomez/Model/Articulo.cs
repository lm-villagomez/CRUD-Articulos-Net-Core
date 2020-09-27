using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APiCRUDMarinaVillagomez.Model
{
    public class Articulo
    {
        public int idArticulo { get; set; }
        public string descripcion { get; set; }
        public string nombreFabricante { get; set; }
        public decimal precio { get; set; }
        public string unidadMedida { get; set; }
         
    }
}

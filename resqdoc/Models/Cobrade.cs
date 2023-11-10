 using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace resqdoc.Models
{
    public class Cobrade : BaseEntity
    {
        public int Cod { get; set; }
        public string Descricao { get; set; }
    }
}

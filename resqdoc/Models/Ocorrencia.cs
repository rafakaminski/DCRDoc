using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using resqdoc.Enums;
using resqdoc.Models;


namespace ResqDoc.Models
{
    public class Ocorrencia : BaseEntity
    {
        public string Titulo { get; set; }    
        public GravidadeEnum Gravidade { get; set; }         
        public string Data { get; set; }
        public int Cobrade { get; set; }
    }
}
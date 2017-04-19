using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PermisC
{
    public class Adresse_Metadata
    {
        [MaxLength(5)]
        [RegularExpression(@"[0-9]{5}", ErrorMessage = "le code postal n'est pas valide")]
        public string codePostal { get; set; }
    }
}
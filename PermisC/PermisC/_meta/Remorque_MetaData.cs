using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PermisC
{
    public class Remorque_Metadata
    {
        [MaxLength(9)]
        [MinLength(9)]
        [RegularExpression(@"[A-Z]{2}-[0-9]{3}-[A-Z]{2}", ErrorMessage = "La plaque d'immatriculation doit etre de la forme 'AA-111-AA'")]
        public string Immatriculation { get; set; }
    }
}
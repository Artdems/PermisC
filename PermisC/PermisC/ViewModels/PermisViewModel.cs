using PermisC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermisC.ViewModels
{
    class Permis
    {
        public string poidTotal { get; set; }
        double poid;
        double poidRemorque;
        public string essTotal { get; set; }
        int ess;
        public string permis { get; set; }
        public string formation { get; set; }

        public Permis(Tracteur trac = null, Remorque rem = null)
        {
            if ( rem == null)
            {
                poid = double.Parse(trac.PoidTracteur);
                ess = int.Parse(trac.Essieux);
                poidRemorque = 0;
            }
            else
            {
                poid = double.Parse(trac.PoidTracteur)+double.Parse(rem.PoidRemorque);
                ess = int.Parse(trac.Essieux)+int.Parse(rem.Essieux);
                poidRemorque = double.Parse(rem.PoidRemorque);
            }

            poidTotal = poid.ToString();
            essTotal = ess.ToString();

            if (ess == 2 && (poid) < 3500)
            {
                if (poidRemorque <= 750)
                {
                    permis = "Premis B";
                    formation = "Aucune";
                }
                else if (poidRemorque > 750)
                {
                    permis = "Premis BE";
                    formation = "Aucune";
                }

            }
            else if (ess == 2 && poid > 3500 && poid <= 7500)
            {
                if (poidRemorque <= 750)
                {
                    permis = "Premis C1";
                    formation = "FCOS requi de moins de 5 ans";
                }
                else if (poidRemorque > 750)
                {
                    permis = "Premis C1E";
                    formation = "FCOS requi de moins de 5 ans";
                }


            }
            else if ((ess == 2 && poid <= 19000) || (ess == 3 && poid <= 26000) || (ess == 4 && poid <= 36000) || (ess >= 5 && poid <= 44000))
            {
                if (poidRemorque <= 750)
                {
                    permis = "Premis C";
                    formation = "Aucune";
                }
                else if (poidRemorque > 750)
                {
                    permis = "Premis CE";
                    formation = "Aucune";
                }
                if (poid > 3500)
                {
                    formation = "FCOS requi de moins de 5 ans";
                }

            }
            else if (ess >= 5 && poid <= 48000)
            {
                permis = "Convoit exeptionnel de Catégorie 1";
                formation = "Permis CE et FCOS requi de moins de 5 ans";
            }
            else if (ess >= 5 && poid <= 72000)
            {
                permis = "Convoit exeptionnel de Catégorie 2";
                formation = "Permis CE et FCOS requi de moins de 5 ans";
            }
            else
            {
                permis = "Convoit exeptionnel de Catégorie 3";
                formation = "Permis CE et FCOS requi de moins de 5 ans";
            }
        }
    }
}

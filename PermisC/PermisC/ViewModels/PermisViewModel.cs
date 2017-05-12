using PermisC.Models;

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
        public string attention { get; set; }

        //Affiche les condition requise pour conduire le tracteur et la remorque séléctionné si il y en a une
        public Permis(Tracteur trac, Remorque rem = null)
        {
            if (rem == null)
            {
                poid = double.Parse(trac.PoidTracteur);
                ess = int.Parse(trac.Essieux);
                poidRemorque = 0;
            }
            else
            {
                poid = double.Parse(trac.PoidTracteur) + double.Parse(rem.PoidRemorque);
                ess = int.Parse(trac.Essieux) + int.Parse(rem.Essieux);
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
                    formation = "FCOS requis de moins de 5 ans";
                }
                else if (poidRemorque > 750)
                {
                    permis = "Premis C1E";
                    formation = "FCOS requis de moins de 5 ans";
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
                    formation = "FCOS requis de moins de 5 ans";
                }

            }
            else if (ess >= 5 && poid <= 48000)
            {
                permis = "Permis CE";
                formation = "FCOS requis de moins de 5 ans";
                attention = "Convoi exceptionnel de Catégorie 1";
            }
            else if (ess >= 5 && poid <= 72000)
            {
                permis = "Permis CE";
                formation = "FCOS requis de moins de 5 ans";
                attention = "Convoi exceptionnel de Catégorie 2\n1 voiture Pilote peut être requise";
            }
            else
            {
                permis = "Permis CE";
                formation = "FCOS requis de moins de 5 ans";
                attention = "Convoi exceptionnel de Catégorie 3\nDeux voiture de protection obligatoire";
            }
        }
    }
}

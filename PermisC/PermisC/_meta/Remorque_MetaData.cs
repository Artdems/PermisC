using PermisC.Models;
using PermisC.Data;

using System.Text.RegularExpressions;

namespace PermisC
{
    public class Remorque_Metadata
    {
        public string Remorque(Remorque item, string erreur, CamionDatabase database)
        {

            var RegImmat = Regex.IsMatch(item.Immatriculation, "[A-Z]{2}[-][0-9]{3}[-][A-Z]{2}");
            int Num;
            var RegPoid = int.TryParse(item.PoidRemorque, out Num);
            if (RegImmat)
            {
                item.Immatriculation = item.Immatriculation.ToUpper();

                if (RegPoid)
                {
                    var RegNull = int.Parse(item.PoidRemorque);
                    if (RegNull != 0)
                    {
                        Remorque existant = null;
                        if ((existant = database.GetRemorqueImmat(item.Immatriculation)) == null)
                        {
                            database.AddRemorque(item);

                        }
                        else
                        {
                            erreur = "-Cette imatriculation a deja été enregistré";
                        }
                    }
                    else
                    {
                        erreur = "-Le poid de la remorque ne peut pas etre null";
                    }
                }
                else
                {
                    erreur = "-Le poid de la remorque ne peut pas etre null";
                }
            }
            else if (RegPoid)
            {
                var RegNull = int.Parse(item.PoidRemorque);
                if (RegNull != 0)
                {
                    erreur = "-L'immatriculation doit etre de la frome 'AA-666-BB'";
                }
                else
                {
                    erreur = "-L'immatriculation doit etre de la frome 'AA-666-BB'\n-Le poid de la remorque ne peut pas etre null";
                }
            }
            else
            {
                erreur = "-L'immatriculation doit etre de la frome 'AA-666-BB'\n-Le poid de la remorque ne peut pas etre null";
            }

            return erreur;
        }
    }
}
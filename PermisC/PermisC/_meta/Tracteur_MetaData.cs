using System.Text.RegularExpressions;

using PermisC.Models;
using PermisC.Data;


namespace PermisC._meta
{
    public class Tracteur_Metadata
    {

        public string Tracteur(Tracteur item, string erreur, CamionDatabase database)
        {

            var RegImmat = Regex.IsMatch(item.Immatriculation, "[a-zA-Z]{2}[-][0-9]{3}[-][a-zA-Z]{2}");
            int Num;
            var RegPoid = int.TryParse(item.PoidTracteur, out Num);
            if (RegImmat)
            {
                item.Immatriculation = item.Immatriculation.ToUpper();
                
                if (RegPoid)
                {
                    var RegNull = int.Parse(item.PoidTracteur);
                    if (RegNull != 0)
                    {
                        Tracteur existant = null;
                        if ((existant = database.GetTracteurImmat(item.Immatriculation)) == null)
                        {
                            database.AddTracteur(item);

                        }
                        else
                        {
                            erreur = "-Cette imatriculation a deja été enregistré";
                        }
                    }
                    else
                    {
                        erreur = "-Le poid du tracteur ne peut pas etre null";
                    }
                }
                else
                {
                    erreur = "-Le poid du tracteur ne peut pas etre null";
                }
            }
            else if (RegPoid)
            {
                var RegNull = int.Parse(item.PoidTracteur);
                if (RegNull != 0)
                {
                    erreur = "-L'immatriculation doit etre de la frome 'AA-666-BB'";
                }
                else
                {
                    erreur = "-L'immatriculation doit etre de la frome 'AA-666-BB'\n-Le poid du tracteur ne peut pas etre null";
                }
            }
            else
            {
                erreur = "-L'immatriculation doit etre de la frome 'AA-666-BB'\n-Le poid du tracteur ne peut pas etre null";
            }

            return erreur;
        }
    }
}
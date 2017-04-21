using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

using PermisC.Models;
using PermisC.Data;


namespace PermisC._meta
{
    public class Tracteur_Metadata
    {

        public string Tracteur(Tracteur item, string erreur, CamionDatabase database)
        {

            var RegImmat = Regex.IsMatch(item.Immatriculation, "[A-Z]{2}[-][0-9]{3}[-][A-Z]{2}");
            if (RegImmat)
            {

                int Num;
                var RegPoid = int.TryParse(item.PoidTracteur, out Num);
                if (RegPoid)
                {
                    Tracteur existant = null;
                    if ((existant = database.GetTracteurImmat(item.Immatriculation)) == null)
                    {
                        database.AddTracteur(item);

                    }
                    else
                    {
                        erreur = "Cette imatriculation a deja été enregistré";
                    }
                }
                else
                {
                    erreur = "Le poid du tracteur doit etre un chiffre";
                }
            }
            else
            {
                erreur = "L'immatriculation doit etre de la frome 'AA-666-BB'";
            }

            return erreur;
        }
    }
}
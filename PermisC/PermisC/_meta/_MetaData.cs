using System.Text.RegularExpressions;

using PermisC.Models;
using PermisC.Data;

namespace PermisC._meta
{
    public class _Metadata
    {
        private string immat;
        private string poid;
        public string meta(string erreur, CamionDatabase database, Remorque rem, Tracteur trac)
        {
            if(rem == null)
            {
                immat = trac.Immatriculation;
                poid = trac.PoidTracteur;
            }
            else
            {
                immat = rem.Immatriculation;
                poid = rem.PoidRemorque;
            }

            var RegImmat = Regex.IsMatch(immat, "[a-zA-Z]{2}[-][0-9]{3}[-][a-zA-Z]{2}");
            int Num;
            var RegPoid = int.TryParse(poid, out Num);
            if (RegImmat)
            {
                if (rem == null)
                {
                    trac.Immatriculation = immat.ToUpper();
                }
                else
                {
                    rem.Immatriculation = immat.ToUpper();
                }

                if (RegPoid)
                {
                    var RegNull = int.Parse(poid);
                    if (RegNull != 0)
                    {
                        Remorque existant = null;
                        if ((existant = database.GetRemorqueImmat(immat)) == null)
                        {
                            
                            if (rem == null)
                            {
                                database.AddTracteur(trac);
                            }
                            else
                            {
                                database.AddRemorque(rem);
                            }

                        }
                        else
                        {
                            erreur = "-Cette immatriculation a déjà été enregistré";
                        }
                    }
                    else
                    {
                        erreur = "-Le poid ne peut pas etre null";
                    }
                }
                else
                {
                    erreur = "-Le poid ne peut pas etre null";
                }
            }
            else if (RegPoid)
            {
                var RegNull = int.Parse(poid);
                if (RegNull != 0)
                {
                    erreur = "-L'immatriculation doit être de la frome 'AA-666-BB'";
                }
                else
                {
                    erreur = "-L'immatriculation doit être de la frome 'AA-666-BB'\n-Le poid ne peut pas être null";
                }
            }
            else
            {
                erreur = "-L'immatriculation doit être de la frome 'AA-666-BB'\n-Le poid ne peut pas être null";
            }

            return erreur;
        }
    }
}
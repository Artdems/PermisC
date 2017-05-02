using System;

using Xamarin.Forms;

namespace PermisC.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {

        public Command verifier { get; set; }
        public Command moins { get; set; }
        public Command plus { get; set; }

        public AboutViewModel()
        {
            Title = "Véhicule non répértorier";

            verifier = new Command(() => Verif());
            moins = new Command(() => Moins());
            plus = new Command(() => Plus());

        }

        private string poidTrac = "";
        public string PoidTrac
        {
            get { return poidTrac; }
            set
            {
                poidTrac = value;
            }
        }

        private string poidRem = "";
        public string PoidRem
        {
            get { return poidRem; }
            set
            {
                poidRem = value;
            }
        }

        private string nbEss = "2";
        public string NbEss
        {
            get { return nbEss; }
            set
            {
                nbEss = value;
                OnPropertyChanged();
            }
        }

        private string result = "";
        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged();
            }
        }
        private string fcos = "";
        public string FCOS
        {
            get { return fcos; }
            set
            {
                fcos = value;
                OnPropertyChanged();
            }
        }
        string couleur = "Black";
        public string Couleur
        {
            get { return couleur; }
            set
            {
                couleur = value;
                OnPropertyChanged();
            }
        }
        void Verif()
        {
            int Num;
            Boolean RegRem = int.TryParse(PoidRem, out Num);
            Boolean RegTrac = int.TryParse(PoidTrac, out Num);
            Boolean RegEss = int.TryParse(NbEss, out Num);

            if (RegRem && RegTrac && RegEss)
            {
                int poidRemorque, poidtracteur, essieux;
                poidRemorque = int.Parse(PoidRem);
                poidtracteur = int.Parse(PoidTrac);
                essieux = int.Parse(NbEss);

                if (poidRemorque < 0)
                {
                    Couleur = "Red";
                    Result = "Veuillez rentrer le poid de la remorque. Entré 0 si il n'y a pas de remorque";
                    FCOS = "";
                }
                else if (poidtracteur <= 0)
                {
                    Couleur = "Red";
                    Result = "Le poid du tracteur ne peut pas etre null";
                    FCOS = "";
                }
                else if (essieux == 2 && (poidRemorque + poidtracteur) < 3500)
                {
                    if (poidRemorque <= 750)
                    {
                        Result = "Premis B";
                        FCOS = "";
                    }
                    else if (poidRemorque > 750)
                    {
                        Result = "Premis BE";
                        FCOS = "";
                    }
                    Couleur = "Black";

                }
                else if (essieux == 2 && (poidRemorque + poidtracteur) > 3500 && (poidRemorque + poidtracteur) <= 7500)
                {
                    if (poidRemorque <= 750)
                    {
                        Result = "Premis C1";
                        FCOS = "FCOS requi de moins de 5 ans";
                    }
                    else if (poidRemorque > 750)
                    {
                        Result = "Premis C1E";
                        FCOS = "FCOS requi de moins de 5 ans";
                    }
                    Couleur = "Black";


                }
                else if ((essieux == 2 && (poidRemorque + poidtracteur) <= 19000) || (essieux == 3 && (poidRemorque + poidtracteur) <= 26000) || (essieux == 4 && (poidRemorque + poidtracteur) <= 36000) || (essieux >= 5 && (poidRemorque + poidtracteur) <= 44000))
                {
                    if (poidRemorque <= 750)
                    {
                        Result = "Premis C";
                        FCOS = " ";
                    }
                    else if (poidRemorque > 750)
                    {
                        Result = "Premis CE";
                        FCOS = " ";
                    }
                    if ((poidRemorque + poidtracteur) > 3500)
                    {
                        FCOS = "FCOS requi de moins de 5 ans";
                    }
                    Couleur = "Black";

                }
                else if (essieux >= 5 && (poidRemorque + poidtracteur) <= 48000)
                {
                    Result = "Convoit exeptionnel de Catégorie 1";
                    FCOS = "Permis CE et FCOS requi de moins de 5 ans";
                    Couleur = "Black";
                }
                else if (essieux >= 5 && (poidRemorque + poidtracteur) <= 72000)
                {
                    Result = "Convoit exeptionnel de Catégorie 2";
                    FCOS = "Permis CE et FCOS requi de moins de 5 ans";
                    Couleur = "Black";
                }
                else
                {
                    Result = "Convoit exeptionnel de Catégorie 3";
                    FCOS = "Permis CE et FCOS requi de moins de 5 ans";
                    Couleur = "Black";
                }
            }
            else
            {
                Couleur = "Red";
                Result = "Les poids rentré doive etre des chiffre";
                FCOS = "";
            }
        }

        void Moins()
        {
            int essieux;
            essieux = int.Parse(NbEss);
            if (essieux > 2)
            {
                essieux--;
            }
            NbEss = essieux.ToString();

        }
        void Plus()
        {
            int essieux;
            essieux = int.Parse(NbEss);
            essieux++;
            NbEss = essieux.ToString();

        }

    }
}

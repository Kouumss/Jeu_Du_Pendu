using System;
using System.Data;
using System.Linq.Expressions;
using AsciiArt;

class Program
{
    static void Afficher_Mot(string mot, List<char> lettres)
    {   

       for(int i = 0; i < mot.Length; i++)
        {
            if (lettres.Contains(mot[i]))

            {
                Console.Write(mot[i]);
            }
            else
            {
                Console.Write(" - ");
            }
            
        }
        Console.WriteLine();
    }

    static string[] ChargerLesMots( string fichier)
    {
        try
        {
            return File.ReadAllLines(fichier);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Erreur de lecture du fichier " + fichier + " (" + ex.Message + ")." );
            Console.WriteLine();
        }

        return null;
    }

    static bool Verifier_reponse(string mot, string reponse)
    {   
        if (mot == reponse)
        {
            return true;
        }
        return false;
    }

    static char Demander_Lettre()
    {   
       
        Console.WriteLine("Entrez une lettre : ");

        string reponse = Console.ReadLine();

        if (reponse.Length == 1)
        {
            reponse = reponse.ToUpper();
            return reponse[0];
        }

        Console.WriteLine("Erreur : Vous devez entrez une seule lettre !");
        return Demander_Lettre();
    }
    static void Deviner_Mot(string mot)
    {
        var lettreDevinee = new List<char>();
        var liste_lettre_fausse = new List<char>();

        string bonneReponse = string.Empty;
        const int VIE = 6;
        int vie = VIE;

        while (vie > 0)
        {   

            Console.WriteLine($"Vie restante : {vie}");

            Console.WriteLine(Ascii.PENDU[VIE - vie]);

            if(liste_lettre_fausse.Count > 0 )
            {
                Console.Write("Lettre eronnées : " + String.Join(", ", liste_lettre_fausse)); 

            }

            Console.WriteLine();
            Console.WriteLine();

            Afficher_Mot(mot, lettreDevinee);

            Console.WriteLine();
            Console.WriteLine();


            var lettre = Demander_Lettre();

            Console.WriteLine();
            Console.WriteLine();

            Console.Clear();
            

            if (mot.Contains(lettre))
            {
                Console.WriteLine("Cool ! Cette lettre est dans le mot. ");
                Console.WriteLine();


                lettreDevinee.Add(lettre);
                bonneReponse += lettre;
            }
            else
            {
                Console.WriteLine("Hélas! Cette lettre n'est pas dans le mot..");
                Console.WriteLine();

                if (!liste_lettre_fausse.Contains(lettre))
                {

                    liste_lettre_fausse.Add(lettre);
                    vie--;
                }
                else
                {
                    Console.WriteLine("Vous avez déjà essayé cette lettre !");
                }
                
                
            }


            bool verification = Verifier_reponse(mot, bonneReponse);

            if(verification == true)
            {
                Console.Clear();
                Console.Write($"Vous avez gagné ! Le mot à deviner était {mot} !");
                break;
            }


        }

        if (vie == 0)
        {
            Console.Clear();
            Console.WriteLine(Ascii.PENDU[VIE - vie]);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write($"Oh Zut ! Il vous reste {vie} vies. Vous avez été pendu !");
            Console.WriteLine();
            Console.WriteLine();
        }

    }

    static void Main(string[] args)
    {
        var mots = ChargerLesMots("mots.txt");

        if(mots == null ||mots.Length == 0)
        {
            Console.WriteLine("La liste de mots est vide.") ;
        }
        else
        {
            Deviner_Mot(mots[0].Trim());
        }

        
    }
}
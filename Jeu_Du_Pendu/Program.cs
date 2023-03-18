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
                Console.Write("- ");
            }
            
        }
        Console.WriteLine();
    }

    static bool verifier_reponse(string mot, string reponse)
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
        int index = 0;

        string bonneReponse = string.Empty;
        int vie = 6;

        while (vie > 0)
        {   

            Console.WriteLine($"Vie restante : {vie}");

            Console.WriteLine(Ascii.PENDU[index]);

            Console.WriteLine();

            Console.Write("Lettre eronnées : " + String.Join(", ", liste_lettre_fausse));

       
            Console.WriteLine();
            Console.WriteLine();

            Afficher_Mot(mot, lettreDevinee);
            Console.WriteLine();
            

            var lettre = Demander_Lettre();

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
                liste_lettre_fausse.Add(lettre);
                
                vie--;
                index++;
            }
            bool verification = verifier_reponse(mot, bonneReponse);

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
            Console.Write($"Oh Zut ! Il vous reste {vie} vies. Vous avez perdu !");
        }

    }

    static void Main(string[] args)
    {
        string mot = "KOUMEIL";
        Deviner_Mot(mot);
    }
}
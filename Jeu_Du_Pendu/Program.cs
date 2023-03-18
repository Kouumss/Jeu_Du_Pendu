using System;
using System.Data;
using System.Linq.Expressions;

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
                Console.Write("-");
            }
            
        }
        Console.WriteLine();
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
        string bonneReponse = string.Empty;
        int vie = 6;

        while (vie > 0)
        {
            Afficher_Mot(mot, lettreDevinee);
            var lettre = Demander_Lettre();
            
            Console.Clear();
            Console.WriteLine($"Vie restante : {vie}");

            if (mot.Contains(lettre))
            {
                Console.WriteLine("Cette lettre est dans le mot");
                
                lettreDevinee.Add(lettre);
                bonneReponse += lettre;
            }
            else
            {
                Console.WriteLine("Cette lettre n'est pas dans le mot");
                vie--;
            }

            if (mot == bonneReponse)
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
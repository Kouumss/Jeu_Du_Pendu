using System;
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
        

    }

    static void Main(string[] args)
    {
        var lettre = Demander_Lettre();
         Afficher_Mot("KOUMEIL", new List<char> {lettre} );
    }
}
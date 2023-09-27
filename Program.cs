using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TD0___Fatih_BOZLAK
{
    class Program
    {
        static bool isInt(string value)
        {
            int result = 0;
            return int.TryParse(value, out result);
        }

        static bool isFloat(string value)
        {
            float result = 0;
            return float.TryParse(value, out result);
        }

        static bool isDouble(string value)
        {
            double result = 0;
            return double.TryParse(value, out result);
        }

        static bool isNumeric(string value)
        {
            if (isInt(value) || isFloat(value) || isDouble(value))
                return true;

            return false;
        }

        static string formatterPrenomNom(string prenom, string nom)
        {
            return char.ToUpper(prenom[0]) + prenom.Substring(1) + " " + nom.ToUpper();
        }

        static float calculerImc(int taille, float poids)
        {
            float tailleFloat = taille / 100.0f;

            return poids / (tailleFloat * tailleFloat);
        }

        static void commenterImc(float imc)
        {
            const string ANOREXIE = "Attention à l’anorexie !";
            const string MAIGRICHON = "Vous êtes un peu maigrichon !";
            const string CORPULENCE_NORMAL = "Vous êtes de corpulence normale !";
            const string SURPOIDS = "Vous êtes en surpoids !";
            const string OBESITE_MODEREE = "Obésité modérée !";
            const string OBESITE_SEVERE = "Obésité sévère !";
            const string OBESITE_MORBIDE = "Obésité morbide !";

            if (imc < 16.5)
                Console.WriteLine(ANOREXIE);
            else if (imc >= 16.5 && imc < 18.5)
                Console.WriteLine(MAIGRICHON);
            else if (imc >= 18.5 && imc < 25)
                Console.WriteLine(CORPULENCE_NORMAL);
            else if (imc >= 25 && imc < 30)
                Console.WriteLine(SURPOIDS);
            else if (imc >= 30 && imc < 35)
                Console.WriteLine(OBESITE_MODEREE);
            else if (imc >= 35 && imc < 40)
                Console.WriteLine(OBESITE_SEVERE);
            else
                Console.WriteLine(OBESITE_MORBIDE);
        }

        static void letsGo()
        {
            string buffer = string.Empty;
            string nom = string.Empty;
            string prenom = string.Empty;

            int taille = 0;
            int age = 0;
            int nbCheveux = 0;

            float poids = 0.0f;
            float imc = 0.0f;

            Console.WriteLine("Bienvenue sur mon programme, jeune étranger imberbe");

            do
            {
                Console.Write("Quel est ton nom jeune chenapan : ");
                nom = Console.ReadLine();
            } while (isNumeric(nom));

            do
            {
                Console.Write("Petite frappe, ta oublié de me donner ton prénom : ");
                prenom = Console.ReadLine();
            } while (isNumeric(prenom));

            Console.WriteLine(formatterPrenomNom(prenom, nom));

            while (true)
            {
                Console.Write("Votre traille (en cm) : ");
                buffer = Console.ReadLine();

                if (isInt(buffer))
                {
                    taille = int.Parse(buffer);
                    break;
                }
            }

            while (true)
            {
                Console.Write("Votre poids (en kg, utiliser la virgule pour la partie décimal) : ");
                buffer = Console.ReadLine();

                if (isFloat(buffer) || isDouble(buffer))
                {
                    poids = float.Parse(buffer);
                    break;
                }
            }

            while (true)
            {
                Console.Write("Votre âge (en année) : ");
                buffer = Console.ReadLine();

                if (isInt(buffer))
                {
                    age = int.Parse(buffer);
                    break;
                }
            }

            if (age < 18)
                Console.WriteLine("Heeeeeeeeeeee le bébé !");


            imc = calculerImc(185, 90.0f);
            Console.WriteLine("Vous avez un IMC de " + imc.ToString("0.0"));
            commenterImc(imc);

            while (true)
            {
                Console.WriteLine("Combien de cheveux tu as sur la tête ?");
                buffer = Console.ReadLine();

                if (isInt(buffer))
                {
                    nbCheveux = int.Parse(buffer);
                    if (nbCheveux >= 100_000 && nbCheveux <= 150_000)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Tu es sur du nombre de cheveux que tu possèdes ?!");
                        continue;
                    }
                }

                Console.WriteLine("Tu sais ce qu'un nombre ?!");
            }

            Console.WriteLine(nbCheveux);
        }

        static void afficheMenu()
        {
            Console.WriteLine("Qu'est-ce que tu veux faire maintenant ? ");

            Console.WriteLine("\t1 - Quitter le magnifique programme");
            Console.WriteLine("\t2 - Recommencer");
            Console.WriteLine("\t3 - Compter jusqu'à 10");
            Console.WriteLine("\t4 - Téléphonner à Tata Jacqueline");

            Console.Write("Ton choix de looser : ");
        }

        static int getMenuChoix()
        {
            string buffer;
            int choix;
            do
            {
                afficheMenu();
                buffer = Console.ReadLine();
                if (!isInt(buffer))
                {
                    Console.WriteLine("Tu comprends ma question ?!");
                    continue;
                }

                choix = int.Parse(buffer);
                if (choix >= 1 && choix <= 4)
                    return choix;

                Console.WriteLine("Est-ce que tu sais lire ?");
            } while (true);
        }

        static void byeBye()
        {
            Console.WriteLine("Je vais attendre 3 secondes et te remercier d'avoir utiliser mon super programme...");

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine(i + " secondes");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Bye bye !");
        }

        static void compterJusqua10()
        {
            Console.WriteLine("Je suis tellement puissant pour compter jusqu'à 10...");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }

        static void reponseTata()
        {
            Console.WriteLine(@"Bip 🎵

""Salut à toi, cher appelant ! Ici, la fabuleuse et inimitable tata Jacqueline. 
Je suis actuellement en mission secrète pour retrouver la chaussette perdue au dernier lavage ou peut-être en train de donner une masterclass sur l'art de faire des crêpes ultra épaisses. 
Si tu as besoin de ma légendaire recette de quiche ou si tu veux simplement papoter de la dernière série que j'ai 'accidentellement' visionnée en une nuit (chut, ne le dis à personne !), laisse-moi un message. J'y répondrai... si j'arrive à retrouver ce bouton 'rappeler'. À bientôt, et n'oublie pas : la vie est trop courte pour manger de mauvais gâteaux !""

Bip 🎵");
        }

        public static void Main(string[] args)
        {
            while (true)
            {
                letsGo();

                switch (getMenuChoix())
                {
                    case 1:
                        byeBye();
                        return;
                    case 2:
                        continue;
                    case 3:
                        compterJusqua10();
                        byeBye();
                        return;
                    case 4:
                        reponseTata();
                        byeBye();
                        return;
                }
            }
        }
    }
}
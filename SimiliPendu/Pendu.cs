using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace ProjetJeuPOO.SimiliPendu
{
    class Pendu : IPendu
    {
        public Pendu() { }

        private Joueur joueur = new Joueur();
        private Joueur ordi = new Joueur();

        private ListeDeMots listeDeMot;
        private List<string> letterGuessed = new List<string>();

        private List<string> charGuessed = new List<string>();
        private string randomWord;

        List<char> correctChar = new List<char>();
        List<char> incorrectChar = new List<char>();

        List<char> found = new List<char>();

        List<string> motCompletTrouve = new List<string>();

        public StringBuilder displayToPlayer;


        public void Jouer()
        {
            listeDeMot = new ListeDeMots();
            listeDeMot.ListeDeMot = new List<string> { "canada", "bleu", "bosnie", "bizarre", "impossible", "jeune", "rouge", "banana", "abdominale", "bonne", "important" };
            Console.WriteLine();

            joueur.Jouer();
            ordi.SetName("Croupier");

            Console.WriteLine();
            randomWord = listeDeMot.GetRandomMot();

            //si le mot a 10 letres et plus afficher 
            if (randomWord.Length >= 10)
            {
                AvoirUnIndice(randomWord);
                Play();
            }
            else
            {
                Play();
            }

        }

        private void OrdiTurn()
        {
            charGuessed.Clear();
            found.Clear();
            motCompletTrouve.Clear();

            while (ordi.NbpointOrdi < 3 && joueur.NbpointJoueur < 3)
            {
                int live = 5;
                bool win = false;

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Vous avez   {0} essais ", live);

                Console.ResetColor();

                displayToPlayer = new StringBuilder(randomWord.Length);
                for (int i = 0; i < randomWord.Length; i++)
                {
                    displayToPlayer.Append('_');
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------------------------------------------------------");
                Console.ResetColor();
                //démasque la lettre devinée
                Console.Write("Mot a Trouve [" + displayToPlayer.Length + "] Lettres  ");
                Console.ForegroundColor = ConsoleColor.Green;
                // affiche chaque caractère et lui donne un espace
                for (int i = 0; i < displayToPlayer.Length; i++)
                {
                    Console.Write("  " + displayToPlayer[i]);
                }
                Console.ResetColor();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------------------------------------------------------");
                Console.ResetColor();



                while (!win && live > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    //string choix = RandomString(1);
                    //Console.WriteLine(choix);
                    string choix = GenerateRandomAlphanumericString(1);



                    if (charGuessed.Contains(choix))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Vous avez entré la lettre [{0}] deja", choix);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Essayez une lettre différent");
                        live -= 1;
                        Console.WriteLine("Il vous reste  {0} essais", live);
                    }

                    //si mot trouvé
                    charGuessed.Add(choix);
                    if (IsWordForOrdiAlgo(randomWord, charGuessed))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(randomWord);
                        Console.WriteLine("Toutes mes félicitations  Vous avez trouve le mot");
                        ordi.NbpointJoueur++;
                        ordi.VoirScoreOrdi();

                        win = true;
                        break;
                    }
                    //si une lettre a ete trouve 
                    else if (randomWord.Contains(choix))
                    {

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Bravo vous avez trouve une lettre");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string letters = IsletterForOrdiAlgo(randomWord, charGuessed);
                        Console.Write(letters);
                    }
                    //quand  mauvaise lettre a ete  entré 
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Desole le lettre n'est pas dans le mot");
                        live -= 1;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Il vous reste  {0} essais", live);

                    }
                    Console.WriteLine();
                    //Affiche le mot secrete  
                    if (live.Equals(0))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Game over \nLe mot secret est [ {0} ]", randomWord);
                        Console.ResetColor();
                        randomWord = listeDeMot.GetRandomMot();
                        Play();
                        break;
                    }
                }

            }
        }
        public void PlayAgain()
        {
            bool playGame = false;
            while (!playGame)
            {
                Console.WriteLine("");
                Console.Write("Voulez-vous jouer encore (Oui/Non) ? ");
                string response = Console.ReadLine().ToString().ToUpper();
                if (response == "Oui" || response == "O")
                {
                    playGame = true;
                    Play();
                }
                if (response == "Non" || response == "N")
                {
                    playGame = false;
                    Controller start = new Controller();
                    start.Menu();
                }
                else
                {
                    Console.WriteLine("Tapez Oui ou Non!");
                }
            }
        }
        public bool IsWord(string secreword, List<string> letterGuessed)
        {
            bool word = false;
            //loop through secretword
            for (int i = 0; i < secreword.Length; i++)
            {
                //initialize c with the index of secretword[i]
                string c = Convert.ToString(secreword[i]);
                //check if c is in list of letters Guess
                if (letterGuessed.Contains(c))
                {
                    word = true;
                }
                /*if c is not in the letters guessed then we dont have the
                * we dont have the full word*/
                else
                {
                    //change the value of word to false and return false
                    return word = false;
                }
            }
            return word;
        }

        public void Play()
        {
            motCompletTrouve.Clear();
            letterGuessed.Clear();
            int live = 5;
            bool win = false;

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Vous avez   {0} essais ", live);

            Console.ResetColor();

            displayToPlayer = new StringBuilder(randomWord.Length);
            for (int i = 0; i < randomWord.Length; i++)
            {
                displayToPlayer.Append('_');
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------");
            Console.ResetColor();
            //unmask the letter guessed
            Console.Write("Mot a Trouve [" + displayToPlayer.Length + "] Lettres  ");
            Console.ForegroundColor = ConsoleColor.Green;
            //displays each character and gives it an space
            for (int i = 0; i < displayToPlayer.Length; i++)
            {
                Console.Write("  " + displayToPlayer[i]);
            }
            Console.ResetColor();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("le mot c'est  " + randomWord.ToUpper());
            Console.ResetColor();
            Console.WriteLine();
            while (!win && live > 0)
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Ce quoi votre choix: ");
                string choix = Console.ReadLine().ToLower();
                //if letterGuessed contains input
                //validates if the input is OK

                if (Validate(choix))
                {
                    if (letterGuessed.Contains(choix))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Vous avez entré la lettre [{0}] deja", choix);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Essayez une lettre différent");
                        live -= 1;
                        Console.WriteLine("Il vous reste  {0} essais", live);
                    }
                    //if word found
                    letterGuessed.Add(choix);
                    if (IsWord(randomWord, letterGuessed) || choix.Equals(randomWord))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(randomWord);
                        Console.WriteLine("Toutes mes félicitations  Vous avez trouve le mot");
                        joueur.NbpointJoueur++;
                        joueur.VoirScore();
                        motCompletTrouve.Add(randomWord);

                        win = true;
                        break;
                    }
                    //si une lettre a ete trouve 
                    else if (randomWord.Contains(choix))
                    {

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Bravo vous avez trouve une lettre");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string letters = Isletter(randomWord, letterGuessed);
                        Console.Write(letters);
                    }
                    //quand  mauvaise lettre a ete  entré 
                    else
                    {
                        // si la longueur  choix ecrit  est supérieure à 1, alors c'est un mot
                        if (choix.Length > 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("" + choix + " C'est pas une lettre criss");
                            Console.ResetColor();
                            live -= 1;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Il vous reste  {0} essais", live);
                            Console.ResetColor();
                        }
                        //quand  mauvaise lettre a ete  entré
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Desole le lettre n'est pas dans le mot");
                            live -= 1;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Il vous reste  {0} essais", live);

                        }
                    }
                    Console.WriteLine();
                    //Afficher  secret word  si user a pas trouve 
                    if (live.Equals(0))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Game over \nLe mot secret est [ {0} ]", randomWord);
                        Console.ResetColor();
                        randomWord = listeDeMot.GetRandomMot();
                        joueur.VoirScore();
                        OrdiTurn();
                        break;
                    }
                }
                //Si user entre des chifres show error 
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Uniquement les caractères a-z, A-Z");
                    live -= 1;
                    Console.WriteLine("Tu as perdu un vie pour rien  lol");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Il vous reste  {0} essais", live);
                    Console.ResetColor();

                }
            }
            AfficherGagnant();
            randomWord = listeDeMot.GetRandomMot();
            OrdiTurn();
        }
        public void AfficherGagnant()
        {

            if (joueur.NbpointJoueur.Equals(3))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("       Bravo    " + joueur.GetName + " Tu as gaganer le turnois");
                Console.WriteLine("---------------------------------------------------------------------");
                System.Threading.Thread.Sleep(1000);
                joueur.NbpointJoueur = 0;
                randomWord = listeDeMot.GetRandomMot();
                PlayAgain();

                Console.ResetColor();
            }
            if (ordi.NbpointOrdi.Equals(3))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("       Bravo   Ordi  Tu as gaganer le turnois");
                Console.WriteLine("---------------------------------------------------------------------");
                System.Threading.Thread.Sleep(1000);
                randomWord = listeDeMot.GetRandomMot();
                Console.ResetColor();

            }

        }
        public bool Validate(string input)
        {
            if (input != "")
            //vérifie si la mot  ne contient que des caractères
            {
                return input.All(Char.IsLetter);
            }
            else
            {
                //return false if not characters
                return false;
            }
        }
        public void AvoirUnIndice(string str)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Le mot a devinner contient plus de 10 lettres");
            Console.WriteLine("Vous avez  doit a un indice:");
            Console.ResetColor();
            Random random = new Random();
            int valeur = random.Next(2, 5);

            List<int> liste = GetListeNumber(str, valeur);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Le mot contient les lettres suivants: ");
            Console.ResetColor();

            foreach (int i in liste)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.Write($"\t{str.ToCharArray()[i]}");
                Console.ResetColor();

            }
            Console.WriteLine();
        }
        public List<int> GetListeNumber(string str, int number)
        {
            Random random = new Random();
            List<int> liste = new List<int>();

            while (number >= 1)
            {
                int valeur = random.Next(0, str.Length);
                if (!liste.Contains(valeur))
                {
                    liste.Add(valeur);
                }
                number--;
            }
            return liste;
        }
        public string Isletter(string secretword, List<string> letterDevine)
        {
            string correctletters = "";
            //parcourir le mot secret
            for (int i = 0; i < secretword.Length; i++)
            {
                string leChar = Convert.ToString(secretword[i]);
                //si le letre contine dans le mot 
                if (letterDevine.Contains(leChar))
                {
                    //ajoute la lettre si il a trouve 
                    correctletters += leChar;
                }
                else
                {
                    // else afficher  (__) si le lettre n est pas trouve
                    correctletters += "_ ";
                }
            }
            // return la lettre 
            return correctletters;
        }
        //Fonction  parcourir le mot pour  Algorithme pour le ordi 
        public string IsletterForOrdiAlgo(string secretword, List<string> letterDevine)
        {
            string correctletters = "";
            //parcourir le mot secret
            for (int i = 0; i < secretword.Length; i++)
            {
                string leChar = Convert.ToString(secretword[i]);
                //si le letre contine dans le mot 
                if (letterDevine.Contains(leChar))
                {
                    //ajoute la lettre si il a trouve 
                    correctletters += leChar;
                }
                else
                {
                    // else afficher  (__) si le lettre n est pas trouve 
                    correctletters += "_ ";
                }
            }
            // return la lettre 
            return correctletters;
        }
        public bool IsWordForOrdiAlgo(string secreword, List<string> letterDevine)
        {
            bool isWord = false;
            //parcourir le mot secret
            for (int i = 0; i < secreword.Length; i++)
            {
                string leChar = Convert.ToString(secreword[i]);
                //vérifie si leChar est dans la liste de lettres
                if (letterDevine.Contains(leChar))
                {
                    /* Nous avons  le mot complet  retunr true */
                    isWord = true;
                }
                /*si leChar  n'est pas dans les lettres devinées alors 
                 n'avons pas le mot complet*/
                else
                {
                    //changer la valeur de isWord en false et renvoyer false
                    return isWord = false;
                }
            }
            //Return troue ou false;
            return isWord;
        }
        public string GenerateRandomAlphanumericString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";

            Random random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, length)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());

            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(randomString);
            return randomString;
        }
    }
}

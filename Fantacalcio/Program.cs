using System;
using System.IO;

namespace Fantacalcio
{

    //Classe Fantallenatore
    class Fantaallenatore
    {
        //creatore file per fantaallenatori
        private static string mainPath = Environment.CurrentDirectory;
        //attributi

        string fantaallenatore;
        string[] squadraf1 =new string[11];
        string[] squadraf2 = new string[11];
        string calciatore;
        string squadra;
        int punteggiog;//punteggio del giocatore
        double punteggiof;//punteggio del fantaallenatore
        

        //giocatori
        int turno;
        int tmp;

        string n = "";
        string r = "";
        string s = "";

        //malus e bonus
        int gol;
        int assist;
        double giallo;
        int rosso;
        int rigoresegnato;
        int rigorepreso;
        int portiereimbattuto;
        int golpreso;
        int autorete;
        int rigoresbagliato;
        int rigoreparato;

        //costruttore
        public Fantaallenatore()
        {
            //iniziallizzo variabili
            punteggiog = 0;
            punteggiof = 0;
            //inizializzo i bonus/malus
            gol = 3;
            assist = 1;
            giallo = -0.5;
            rosso = -1;
            rigoresegnato = 2;
            rigorepreso = -1;
            rigoresbagliato = -3;
            autorete = -2;
            golpreso = -1;
            rigoreparato = 3;
            portiereimbattuto = 1;
            turno = 0;
            tmp = 0;

        }

        //metodi

        //metodo che fa inserire il nome del gicoatore e ne crea il file
        public string setFantaallenatore()
        {
            
                fantaallenatore = Console.ReadLine();
                using (StreamWriter a = File.CreateText($"{mainPath}\\squadre\\{fantaallenatore}")) { }
                return fantaallenatore;
           
            
        }

        //Metodo che calcola il punteggio di ogni giornata con bonus e malus compresi 
        public double calcoloPunti(double media,int assists,int autogol,int rigorisbagliati,int rigoripresi,int golpresi,int portierimbattuti,int golf,double gialli,int rossi,int rigore,int rigoriparati)//metodo che calcola media con bonus e malus
        {
            golf = golf*gol;
            assists = assists * assist;
            gialli = gialli*giallo;
            rossi = rossi*rosso;
            rigore = rigore*rigoresegnato;
            rigorisbagliati = rigorisbagliati * rigoresbagliato;
            autogol = autogol * autorete;
            rigoriparati = rigoriparati * rigoreparato;
            golpresi = golpresi * golpreso;
            rigoripresi = rigoripresi * rigorepreso;
            portierimbattuti = portierimbattuti * portiereimbattuto;
            media = media+golf+gialli+rossi+rigore+rigoriparati+portierimbattuti+golpresi+rigorisbagliati+autogol+rigoripresi;
            punteggiof = media;
            return punteggiof;
        }

        public string[] ricordaNome(string[] playersName)//ottiene i nomi dei FantaAllenatori
        {
            playersName = Directory.GetFileSystemEntries(mainPath + "\\squadre");//ottiene i percorsi relativi dei file contenuti nel percorso assoluto 
            for (int i = 0; i < playersName.Length; i++)
            {
                string[] str = playersName[i].Split("squadre\\");//divide l'array in due elementi, 1 è "Squadre\\" il secondo è il nome del file e il suo tipo
                string[] str2 = str[1].Split(".txt");//divido di nuovo l'array, dove il primo elemento è il nome del file, il secondo è il tipo ".txt" del file
                playersName[i] = str2[0];//assegno all'elemento della posizione in quel momento dell'array il valore dle nome del giocatore
            }
            return playersName;//ritorna il contenuto dell'array
        }

        //questo metodo serve a ritornare il nome scelto dal giocatore per salvarlo nel Main
        public string settaNome()
        {
            return fantaallenatore;
        }

        //questo metodo serve a capire di chi è il turno 
        public bool setTurno()
        {
            if (turno == 0)
            {
                turno++;
                return true;

            }
            else
            {
                turno--;
                return false;
                
            }
            
        }


    }


    //Classe calciatore
    class Calciatore
    {
        private static string mainPath = Environment.CurrentDirectory;
        //attributi
        string nome;
        string squadra;
        string ruolo;

        //creatore
        public Calciatore(string n,string s,string r)
        {
            this.nome = n;
            this.squadra = s;
            this.ruolo = r;
        }

        //progetti futuri

       /* public string[] prendiSquadra(ref string[] nomiFantaAllenatori)//ottiene i nomi dei calciatori di ogni giocatore
        {
            string[] squadre = new string[nomiFantaAllenatori.Length];//crea un'array per salvare la squadra dei giocatori
            for (int i = 0; i < nomiFantaAllenatori.Length; i++)//itera per tutti i fantaallenatori
            {
                string[] tmp = File.ReadAllLines(mainPath + $"\\Squadre\\{nomiFantaAllenatori[i]}.txt");//prende in input la squadra del singolo giocatore
                squadre[i] = tmp[0];//salva il primo elemento, il primo calciatore del fantaallenatori
                for (int j = 1; j < tmp.Length; j++)//itera per tutta la squadra
                    squadre[i] += $"|{tmp[j]}";//aggiunge il calciatore alla singola stringa, separandolo con una virgola, dal precedente
            }
            return squadre;//ritorna l'array delle squadre
        }*/



    }

    //Class Programm
    class Program
    {
        private static string mainPath = Environment.CurrentDirectory;
        static void Main(string[] args)
        {

            

            //creo i nomi dei giocatori
            string allenatore1="";
            string allenatore2="";
            //creo le stringhe utili a richiamare la classe calciatore
            string n, s, r;
            n = "";
            s = "";
            r = "";
            //creo un istanza della classe Fantaallenatore per il primo giocatore
            Fantaallenatore f = new Fantaallenatore();
            //creo un istanza della classe Fantaallenatore per il secondo giocatore
            Fantaallenatore d = new Fantaallenatore();
            //creo un istanza della classe Calciatore
            Calciatore c = new Calciatore(n,s,r);
           
            //variabile utile per il ciclo while
            int t=0;

            while (t==0)
             {
                //Il giocatore ora dovrà scegliere cosa fare attraverso un apposito menù
                Console.WriteLine("Digita 1 se vuoi creare nuova partita,");
                Console.WriteLine("Digita 2 se vuoi entrare in partita già esistente,");
                Console.WriteLine("Digita 3 se vuoi eliminare una partita già esistente.");
                //l'utente sceglie cosa vuole fare digitando il tasto che corrisponde alla sua scelta
                int decisione=Convert.ToInt32(Console.ReadLine());



                if (decisione == 1)
                {
                    if (!Directory.Exists(mainPath + "\\squadre"))//se non esiste alcuna cartella la prima volta che viene aperto il programma la creo
                    {
                       
                        for (int i = 0; i == 0; i++)
                        {
                            DirectoryInfo creaCartella = Directory.CreateDirectory(mainPath + "\\squadre");

                            Console.WriteLine("Inserisci nome del fantallenatore1");
                            f.setFantaallenatore();//crea il file col nome del giocatore
                            allenatore1 = f.settaNome();
                      
                            Console.WriteLine("Inserisci nome del fantallenatore2");
                            d.setFantaallenatore();
                            allenatore2 = d.settaNome();

                            if (allenatore2 == allenatore1)
                            {
                                Console.WriteLine("Mi spiace ma questo nome è già in uso al momento");
                                Directory.Delete(mainPath + "\\squadre", true);
                                i--;
                            }
                            else//se va tutto bene
                            {
                                Console.WriteLine("Ottimo i nomi sono stati inseriti in modo a dir poco perfecto");
                            }
                        }
                        
                        
                    }
                    else//se esiste già la cartella non può essere creata
                    {
                        Console.WriteLine("Non puoi sono stati già creati!");
                    }

                }
                else
                {
                    if (decisione == 2)
                    {
                        if (Directory.Exists(mainPath + "\\squadre"))//se la cartella esiste
                        {
                            Console.WriteLine("Ottimo puoi continuare la tua partita");
                            string[] nomi = new string[0];//creo array per i nomi
                            nomi = f.ricordaNome(nomi);//ritrovo i nomi dei giocatori
                            allenatore1 = nomi[0];
                            allenatore2 = nomi[1];
                            t++;
                        }
                        else//se la cartella non esiste
                        {
                            Console.WriteLine("Mi spiace doverti avvertire che la partita da lei cercata al momento non è raggiungibile, riprova più tardi dopo averla creata grazie");
                        }
                    }
                    else
                    {
                        if (decisione == 3)
                        {
                            string elimina = "";
                            if (Directory.Exists(mainPath +"\\squadre"))//se la cartella esiste
                            {


                                //creo un ciclo che controlli la scelta del giocatore se vuole eliminare o meno il file
                                for (int i = 0; i == 0; i++)
                                {
                                    Console.WriteLine("Sei sicuro di voler eliminare la partita esistemnte?Digita si o no");
                                    elimina = Console.ReadLine();


                                    if (elimina == "si")
                                    {
                                        Directory.Delete(mainPath + "\\squadre", true);

                                    }
                                    else if (elimina == "no")
                                    {
                                        t = 0;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Mi spiace non ho capito la tua scelta");
                                        i--;
                                    }

                                }
                            }
                            else//se la cartella non esiste
                            {
                                Console.WriteLine("Mi spiace ma non esistono file da eliminare");
                            }
                        }
                        else
                        {
                            Console.WriteLine("La tua scelta non corrisponde a nessuna possibilità");
                        }
                    }
                }
            }

            //ASTA

            //Variabili utili per l'asta
            int creditiG1=500;
            int creditiG2 = 500;
            int propostaG1;
            int propostaG2;
            int ideaG1=0;
            int ideaG2=0;
            string rispostaG1;
            string rispostaG2;
            string nomecG1;
            string squadracG1;
            string ruolocG1;
            string nomecG2;
            string squadracG2;
            string ruolocG2;
            //progetti futuri
            string [] formazioneG1= new string[3];
            string[] formazioneG2 = new string[3];


            for (int v = 0; v == 0; v++)
            {
                Console.WriteLine("Inizia l'asta!!!!!!!!");
                Console.WriteLine("Adesso dovrete proporre i vostri calciatori");

                //INIZIA ASTA che chiede nome squadra e ruolo di ogni calciatore
                for (int i = 1; i <= 2; i++)
                {
                    if (creditiG1 == 0 || creditiG2 == 0)
                    {
                        Console.WriteLine("Mi sipace ma l'asta va ricominciata non ci sono abbastanza crediti per continuare");
                        v--;
                    }
                    else
                    {
                        if (f.setTurno() == true)//Turno del giocatore 1
                        {
                            for(int b = 0; b == 0; b++)
                            {
                                Console.WriteLine(allenatore1 + " tocca a te!!!!");

                                Console.WriteLine("Inserisci nome");
                                
                                nomecG1 = Console.ReadLine();

                                Console.WriteLine("Inserisci squadra");
                                
                                squadracG1 = Console.ReadLine();
                                Console.WriteLine("Inserisci ruolo");
                                
                                ruolocG1 = Console.ReadLine();
                               

                                Console.WriteLine("Quanti crediti proponi per queso giocatore?");//il giocatore propone una cifra iniziale
                                propostaG1 =int.Parse(Console.ReadLine());
                                if (propostaG1 > creditiG1)//cifra che viene controllata
                                {
                                    Console.WriteLine("non puoi fare questa proposta");
                                    b--;
                                }
                                else
                                {
                                    ideaG1 = 0;
                                    ideaG1 = ideaG1 + propostaG1;
                                    for (int g = 0; g == 0; g++)
                                    {
                                       
                                        Console.WriteLine(allenatore2 + " vuoi inserire una controfferta? si/no");//Permetto la possibilità di controbattere
                                        rispostaG2 = Console.ReadLine();
                                        if (rispostaG2 == "si")
                                        {
                                            Console.WriteLine("Inserisci la tua proposta");
                                            propostaG2 = 0;
                                            propostaG2 = int.Parse(Console.ReadLine());
                                            if (propostaG2 > creditiG2||propostaG2<=ideaG1)//se la proposta del giocatore supera il suo badget o la proposta dell'avversario non vale
                                            {
                                                Console.WriteLine("Non puoi proporre questo prezzo o perchè supera il tuo badget o perchè non supera l'offerta del tuo avversario");
                                                g--;
                                            }
                                            else
                                            {
                                                ideaG2 = 0;
                                                ideaG2 = ideaG2 + propostaG2;
                                                for(int p = 0; p == 0; p++)
                                                {
                                                    Console.WriteLine(allenatore1+" vuoi ribattere? si/no");
                                                    rispostaG1 = Console.ReadLine();
                                                    if (rispostaG1 == "si")
                                                    {
                                                        Console.WriteLine("Inserisci la tua controribattuta");
                                                        propostaG1 = 0;
                                                        propostaG1 = int.Parse(Console.ReadLine());

                                                        if (propostaG1 > creditiG1||propostaG1<=ideaG2)//se la proposta del giocatore supera il suo badget o la proposta dell'avversario non vale
                                                        {
                                                            Console.WriteLine("Non puoi proporre questo prezzo o perchè supera il tuo badget o perchè non supera l'offerta del tuo avversario");
                                                            p--;
                                                        }
                                                        else
                                                        {
                                                            ideaG1 = 0;
                                                            ideaG1 = ideaG1 + propostaG1;
                                                            g--;//In modo da creare un loop per le ribattute
                                                        }
                                                    }else if (rispostaG1 == "no")
                                                    {
                                                        Console.WriteLine("Va bene il giocatore verrà assegnato a " + allenatore2);
                                                        creditiG2 = creditiG2 - ideaG2;
                                                        
                                                        //assegnazione calciatore
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Puoi ripetere?");
                                                        p--;
                                                    }
                                                }
                                            }

                                        }
                                        else if(rispostaG2=="no")
                                        {
                                            Console.WriteLine("Ottimo il giocatore verrà assegnato a " + allenatore1);
                                            creditiG1 = creditiG1 - ideaG1;//scalo i crediti del giocatore
                                            
                                            //Assegnazione giocatore
                                        }
                                        else 
                                        {
                                            Console.WriteLine("Non ho capito puoi ripetere?");
                                            g--;
                                        }

                                    }
                                }

                            }
                           


                        }
                        else//turno del giocatore 2
                        {
                            for(int b = 0; b == 0; b++) { 
                            Console.WriteLine(allenatore2 + "tocca a te!!!!");

                            Console.WriteLine("Inserisci nome");
                            nomecG2 = Console.ReadLine();
                            

                            Console.WriteLine("Inserisci squadra");
                            squadracG2 = Console.ReadLine();
                            

                            Console.WriteLine("Inserisci ruolo");
                            ruolocG2 = Console.ReadLine();



                                Console.WriteLine("Quanti crediti proponi per queso giocatore?");//il giocatore propone una cifra iniziale
                                propostaG2 = int.Parse(Console.ReadLine());
                                if (propostaG2 > creditiG2)//cifra che viene controllata
                                {
                                    Console.WriteLine("non puoi fare questa proposta");
                                    b--;
                                }
                                else
                                {
                                    ideaG2 = 0;
                                    ideaG2 = ideaG2 + propostaG2;
                                    for (int g = 0; g == 0; g++)
                                    {

                                        Console.WriteLine(allenatore2 + " vuoi inserire una controfferta? si/no");//Permetto la possibilità di controbattere
                                        rispostaG1 = Console.ReadLine();
                                        if (rispostaG1 == "si")
                                        {
                                            Console.WriteLine("Inserisci la tua proposta");
                                            propostaG1 = 0;
                                            propostaG1 = int.Parse(Console.ReadLine());
                                            if (propostaG1 > creditiG1 || propostaG1 <= ideaG2)//se la proposta del giocatore supera il suo badget o la proposta dell'avversario non vale
                                            {
                                                Console.WriteLine("Non puoi proporre questo prezzo o perchè supera il tuo badget o perchè non supera l'offerta del tuo avversario");
                                                g--;
                                            }
                                            else
                                            {
                                                ideaG1 = 0;
                                                ideaG1 = ideaG2 + propostaG2;
                                                for (int p = 0; p == 0; p++)
                                                {
                                                    Console.WriteLine(allenatore1 + " vuoi ribattere? si/no");
                                                    rispostaG2 = Console.ReadLine();
                                                    if (rispostaG2 == "si")
                                                    {
                                                        Console.WriteLine("Inserisci la tua controribattuta");
                                                        propostaG2 = 0;
                                                        propostaG2 = int.Parse(Console.ReadLine());

                                                        if (propostaG2 > creditiG2 || propostaG2 <= ideaG1)//se la proposta del giocatore supera il suo badget o la proposta dell'avversario non vale
                                                        {
                                                            Console.WriteLine("Non puoi proporre questo prezzo o perchè supera il tuo badget o perchè non supera l'offerta del tuo avversario");
                                                            p--;
                                                        }
                                                        else
                                                        {
                                                            ideaG2 = 0;
                                                            ideaG2 = ideaG2 + propostaG2;
                                                            g--;//In modo da creare un loop per le ribattute
                                                        }
                                                    }
                                                    else if (rispostaG2 == "no")
                                                    {
                                                        Console.WriteLine("Va bene il giocatore verrà assegnato a " + allenatore1);
                                                        creditiG1 = creditiG1 - ideaG1;

                                                        //assegnazione calciatore
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Puoi ripetere?");
                                                        p--;
                                                    }
                                                }
                                            }

                                        }
                                        else if (rispostaG1 == "no")
                                        {
                                            Console.WriteLine("Ottimo il giocatore verrà assegnato a " + allenatore2);
                                            creditiG2 = creditiG2 - ideaG2;//scalo i crediti del giocatore

                                            //Assegnazione giocatore
                                        }
                                        else
                                        {
                                            Console.WriteLine("Non ho capito puoi ripetere?");
                                            g--;
                                        }

                                    }
                                }

                            }

                        }
                    }



                }
            }




            //INIZIA IL CAMPIONATO

            //punti dei giocatori
            double punti =0;
            double punti1=0;


            //Varaibili primo fantaallenatore
            double mediac;
            double medias=0;
            int gol;
            int assists;
            int golpresi;
            double gialli;
            int rossi;
            int rigore;
            int rigoriparati;
            int rigoripresi;
            int rigorisbagliati;
            int autogol;
            int portiereimbattuto=0;

            //variabili secondo fantaallenatore
            double mediac1 ;
            double medias1 = 0;
            int gol1 ;
            int assists1;
            int golpresi1;
            double gialli1 ;
            int rossi1 ;
            int rigore1 ;
            int rigoriparati1 ;
            int rigoripresi1;
            int rigorisbagliati1;
            int autogol1;
            int portiereimbattuto1=0;


            Console.WriteLine("Bene ora che le squadre sono al completo può avere inizio il fantacalcio");
            Console.WriteLine("Il campionato è formato da 10 giornate e la prima parte adesso");

            //CICLO CHE GESTISCE IL CAMPIONATO
            for(int i = 1; i <= 1; i++)//campionato da 10 giornate
            {
                //primo
                Console.WriteLine(allenatore1 + "Inserisci i dati della tua squadra relativi alla {0} giornata",i);//il fantaallenatore inserirà tutti i dati riguardanti bonus e malus
                for (int p = 1; p <= 2; p++)//ciclo che calcola la media della squadra in base alle medie dei singoli calciatori
                {
                    Console.WriteLine("Inserisci la media del {0} calciatore", p);

                    mediac = Convert.ToDouble(Console.ReadLine());

                    medias = medias + mediac;

                }
                //GESTIONE BONUS
                Console.WriteLine("Inserisci i gol fatti dai tuoi giocatori");
                gol = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Inserisci il numero assist fatti dai tuoi giocatori  ");
                assists = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Inserisci i gialli presi dai tuoi giocatori");
                gialli = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Inserisci i rossi presi dai tuoi giocatori");
                rossi = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Inserisci i rigori segnati");
                rigore = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Inserisci il numero di rigori sbagliati dalla tua squadra ");
                rigorisbagliati = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Inserisci il numero di autogol fatti  ");
                autogol = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Inserisci i rigori parati ");
                rigoriparati = Convert.ToInt32(Console.ReadLine());
                 for(int v = 0; v == 0; v++)
                 {
                     Console.WriteLine("Il tuo portiere è imbattuto? ");
                     string risposta = Console.ReadLine();
                     if (risposta == "si")
                     {
                         portiereimbattuto = 1;
                     }
                     else if (risposta == "no")
                     {
                         portiereimbattuto = 0;
                     }
                     else
                     {
                         Console.WriteLine("Non ho capito potresti ripetere?");
                         v--;
                     }
                 }
                if (portiereimbattuto == 1)
                {
                    golpresi = 0;
                    rigoripresi = 0;
                    medias = f.calcoloPunti(medias, assists, autogol, rigorisbagliati, rigoripresi, golpresi, portiereimbattuto, gol, gialli, rossi, rigore, rigoriparati);
                    punti = punti + medias;
                }
                else
                {
                    Console.WriteLine("Inserisci i gol presi dal portiere ");
                    golpresi = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Inserisci il numero di rigori non parati dal portiere ");
                    rigoripresi = Convert.ToInt32(Console.ReadLine());

                    medias = f.calcoloPunti(medias, assists, autogol, rigorisbagliati, rigoripresi, golpresi, portiereimbattuto, gol, gialli, rossi, rigore, rigoriparati);
                    punti = punti + medias;
                }
               

                //secondo
                Console.WriteLine(allenatore2 + "Inserisci i dati della tua squadra relativi alla {0} giornata", i);//il fantaallenatore inserirà tutti i dati riguardanti bonus e malus
                for (int p = 1; p <= 2; p++)//ciclo che calcola la media della squadra in base alle medie dei singoli calciatori
                {
                    Console.WriteLine("Inserisci la media del {0} calciatore", p);

                    mediac1 = Convert.ToDouble(Console.ReadLine());

                    medias1 = medias1 + mediac1;

                }
                //GESTIONE BONUS
                Console.WriteLine("Inserisci i gol fatti ");
                gol1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Inserisci il numero di assist fatti dai tuoi giocatori");
                assists1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Inserisci i gialli presi dai tuoi giocatori");
                gialli1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Inserisci i rossi presi dai tuoi giocatori");
                rossi1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Inserisci i rigori segnati");
                rigore1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Inserisci i rigori parati ");
                Console.WriteLine("Inserisci il numero di rigori sbagliati ");
                rigorisbagliati1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Inserisci il numero di autogol fatti  ");
                autogol1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Inserisci i rigori parati dal tuo portiere");
                rigoriparati1 = Convert.ToInt32(Console.ReadLine());
                for (int v = 0; v == 0; v++)//ciclo che controlla se il tuo portiere è imbattuto
                {
                    Console.WriteLine("Il tuo portiere è imbattuto? ");
                    string risposta = Console.ReadLine();
                    if (risposta == "si")
                    {
                        portiereimbattuto1 = 1;
                    }
                    else if (risposta == "no")
                    {
                        portiereimbattuto1 = 0;
                    }
                    else
                    {
                        Console.WriteLine("Non ho capito potresti ripetere?");
                        v--;
                    }
                }
                if (portiereimbattuto == 1)//se il tuo portiere è imbattuto non chiedera alcune informazioni
                {
                    golpresi1 = 0;
                    rigoripresi1 = 0;
                    medias1 = d.calcoloPunti(medias1, assists1, autogol1, rigorisbagliati1, rigoripresi1, golpresi1, portiereimbattuto1, gol1, gialli1, rossi1, rigore1, rigoriparati1);
                    punti1 = punti1 + medias1;
                }
                else//altrimenti chiederà tutto
                {
                    Console.WriteLine("Inserisci il numero di gol presi dal portiere ");
                    golpresi1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Inserisci il numero di rigori non parati dal portiere ");
                    rigoripresi1 = Convert.ToInt32(Console.ReadLine());
                    medias1 = d.calcoloPunti(medias1, assists1, autogol1, rigorisbagliati1, rigoripresi1, golpresi1, portiereimbattuto1, gol1, gialli1, rossi1, rigore1, rigoriparati1);
                    punti1 = punti1 + medias1;
                }
                
            }


            //DECRETO VINCITORE
            Console.WriteLine("Il vincitore di questo fantacalcio è.....");
            if (punti < punti1)
            {
                Console.WriteLine(allenatore2+"con {0} punti",punti1);
            }else if (punti > punti1)
            {
                Console.WriteLine(allenatore1 + "con {0} punti", punti);
            }
            else
            {
                Console.WriteLine("Nessuno perhè si tratta di un pareggio, il campionato è finito: {0} a {1} punti.COMPLIMENTI AD ENTRAMBI I GIOCATORI",punti,punti1);
            }

            Console.ReadKey();//a fine Main per la lettura 
        }
        
    }

}
using System;

	namespace Hotel{
		
		class MiniHotel{
			
			public static void Main(string[] args){
				int[] hotel = null;
				
				hotel = initProgramme();
			}
			
			static int[] initProgramme(){
				int taille = 0;
				int[] hotel = null;
				
				taille = TailleHotel();
				hotel = OccupationChambres(taille);
				return hotel;
			}
			
			static int TailleHotel(){
				int taille = 0;
				
				Console.Write("Quelle est la taille de l'hotel (en nombre de chambres) ? : ");
				taille = int.Parse(Console.ReadLine());
				
				return taille;
			}
			
			static int[] OccupationChambres(int taille){
				int[] hotel = new int[taille];
				Random random = new Random();
				
				for(int i = 0; i <= hotel.Length-1; i++){
					hotel[i] = random.Next(0,2);
				}
				
				Menu(hotel);
				return hotel;
			}
			
			static void EtatHotel(int[] hotel){				
				for(int i = 0; i <= hotel.Length-1; i++){
					Console.WriteLine($"Chambre n° {i+1} : {hotel[i]}");
				}
			}
			
			static void EtatDesLieux(int[] hotel){
				int chambresVides = 0;
				int chambresOccupees = 0;
				
				for(int i = 0; i <= hotel.Length-1; i++){
					if (hotel[i] == 0)
					{
						chambresVides = chambresVides+1;
					}
				}
				
				for(int i = 0; i <= hotel.Length-1; i++){
					if (hotel[i] == 1)
					{
						chambresOccupees = chambresOccupees+1;
					}
				}
				
				Console.WriteLine("\n\n Nous disposons à l'instant de : \n");
				Console.WriteLine($" {chambresOccupees} chambres occupées.");
				Console.WriteLine($" {chambresVides} chambres vides. \n");
			}
			
			static void PremiereOccurrence(int[] hotel){
				for(int i = 0; i <= hotel.Length-1; i++){
					if (hotel[i] == 0)
					{
						Console.WriteLine("\n La première chambre vide est la chambre n° " + (i+1) + "\n");
						break;
					}
				}
			}
			
			static void DerniereOccurrence(int[] hotel){
				for (int i = hotel.Length; i >= 0; i--)
				{
					if (hotel[i-1] == 0)
					{
						Console.WriteLine("\n La dernière chambre vide est la chambre n° " + (i) + "\n");
						break;
					}
				}
			}
			
			static bool Identification(){
				bool login = false;
				string username = "Ced";
				string utilisateur;
				string password = "Ric";
				string motDePasse;
				
				Console.Write(" Username : ");
				utilisateur = Console.ReadLine();
				
				Console.Write(" Password : ");
				Console.ForegroundColor = Console.BackgroundColor;
				motDePasse = Console.ReadLine();
				Console.ResetColor();
				
				if(utilisateur.Equals(username) && motDePasse.Equals(password)){
					login = true;
				} else{
					Console.WriteLine("Wrong username and or password");
					Console.WriteLine("Try again!!!");
					Identification();
				}
				return login;
			}
			
			static void Reservation(int[] hotel){
				Identification();
				
				for(int i = 0; i <= hotel.Length-1; i++){
					if (hotel[i] == 0)
					{
						hotel[i] = 1;
						Console.WriteLine("\n Bienvenue dans notre Etablissement!!! Nous vous souhaitons la bienvenue et vous attribuons la chambre n° " + (i+1) + "\n");
						break;
					}
				}
			}
			
			static void Liberation(int[] hotel){
				Identification();
				
				for (int i = hotel.Length-1; i >= 0; i--)
				{
					if (hotel[i] == 1)
					{
						hotel[i] = 0;
						Console.WriteLine("\n L'Hotel CEDRIC ELONG espère que votre séjour a été agréable et espère vous revoir très bientôt!!! \n");
						Console.WriteLine("\n La chambre n° " + (i+1) + " s'est libérée. \n");
						break;
					}
				}
			}
			
			static void Quitter(){
				Console.WriteLine("\n A Bientôt!!!\n");
					return;
			}
			
			static int Menu(int[] hotel){
				int monChoix = 0;
				
				Console.WriteLine("\n < MENU >");
				Console.WriteLine("\n Saisir : \n");
				Console.WriteLine(" 1 pour afficher l'état de l'Hotel");
				Console.WriteLine(" 2 pour afficher l'état des lieux");
				Console.WriteLine(" 3 pour afficher le numéro de la première chambre vide");
				Console.WriteLine(" 4 pour afficher le numéro de la dernière chambre vide");
				Console.WriteLine(" 5 pour effectuer une réservation");
				Console.WriteLine(" 6 pour libérer une chambre");
				Console.WriteLine(" 7 pour quitter notre application \n");
				Console.WriteLine(" </ MENU > \n");
				
				Console.Write("\n Je fais mon choix : ");
				monChoix = int.Parse(Console.ReadLine());
				Choix(monChoix, hotel);
				
				return monChoix;
			}
			
			static void Choix(int monChoix, int[] hotel){
				Console.Clear();
				Console.WriteLine("\n *** HOTEL CEDRIC ELONG ***");
				
				if(monChoix.Equals(7)){
					Quitter();
				}
				
				if(monChoix.Equals(1)){
					EtatHotel(hotel);
					Menu(hotel);
				}
				
				if(monChoix.Equals(2)){
					EtatDesLieux(hotel);
					Menu(hotel);
				}
				
				if(monChoix.Equals(3)){
					PremiereOccurrence(hotel);
					Menu(hotel);
				}
				
				if(monChoix.Equals(4)){
					DerniereOccurrence(hotel);
					Menu(hotel);
				}
				
				if(monChoix.Equals(5)){
					Reservation(hotel);
					Menu(hotel);
				}
				
				if(monChoix.Equals(6)){
					Liberation(hotel);
					Menu(hotel);
				}
			}
		}
	}

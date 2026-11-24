/* Main class for launching the game */
using trash;

class Game {
  static World world = new World();
  static Player player = new Player();
  static Context context = new Context(world.GetEntry());
  
  static void Main (string[] args) {
      
      Console.WriteLine("Du tager afsted på en vigtig mission! Skraldemonstrenes grotte skal tømmes, og kun du kan gøre det.");
      Console.WriteLine("Menneskeheden har negliceret affaldssorteringen, og nu er affaldet begyndt at vågne op af ren hævntørst!");
      Console.WriteLine("Inde i grotten åbner jorden sig under dig - en fælde! Du falder og falder og falder... Nu er der kun en vej ud: igennem!");
      Console.WriteLine("SORTÉR MONSTRENE MED DE RIGTIGE VÅBEN. SKRIV 'hjælp' FOR KOMMANDOER");
      Console.WriteLine("\nGå videre med: gå <udgang>");
      Console.WriteLine("\nAngrib med: angrib <monsterdel-nr> <våben-nr>");
    
    context.GetCurrent().Welcome();

    context.GetInventory().PrintInventory();         // Vis inventory til start
    
    while (!context.IsDone()) {
      Console.Write("\n> ");
      string? line = Console.ReadLine();
      if (line==null) continue;
      
      // parse line
      string[] elements = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
      string command = (elements.Count() > 0) ? elements[0] : "";
      string[] parameters = GetParameters(elements);
      
      switch (command) {
        case "afslut":
        case "farvel":
            Console.WriteLine("\nSpillet er ovre! Vi håber du vil spille videre en anden gang.");
            Console.WriteLine($"Du endte med {player.GetDeathCounter()} antal døde. ");
            context.MakeDone();
            break;
      
        case "gå":
            if (parameters.Length != 2) 
            {
                Console.WriteLine("\nJeg ved ikke hvor det er 🤔"); 
                break;                                   // ÆNDRET: var "return;"
            }
            context.Transition($"{parameters[0]} {parameters[1]}");
                break;
      
        case "saml":
          if (parameters[0] == "op")
          {
            context.PickUp();
            context.GetCurrent().ShowExits();
            break;
          }
          else
          {
              Console.WriteLine($"Jeg forstår ikke {parameters[0]}");
          }
          break;
          
        case "angrib":                               // NY
          context.Attack(parameters);
          break;
      
        case "inventar":                            // NY
          context.GetInventory().PrintInventory();
          break;
      
        case "hjælp":
          Console.WriteLine(" - afslut/farvel                Forlad programmet");
          Console.WriteLine(" - gå <udgang>                  Følg udgang");
          Console.WriteLine(" - saml op                      Saml genstanden op");        // NY
          Console.WriteLine(" - angrib <del-nr> <våben-nr>   Angrib monsterets dele med et bestemt våben");   // NY
          Console.WriteLine(" - inventar                     Se dine våben");                   // NY
          Console.WriteLine(" - hjælp                        Afspil en hjælpebesked");
          break;
      
        default:
          Console.WriteLine("\nUpsi, jeg forstår ikke '"+command+"' 😕");
          break;
      }
    }
  }
  
    private static string[] GetParameters (string[] input) 
    {
        if (input.Count() == 0)
        {
            return new string[0];
        }
        string[] output = new string[input.Length-1];
    
        for (int i=0 ; i<output.Length ; i++) 
        {
            output[i] = input[i+1];
        }
        return output;
    }
}

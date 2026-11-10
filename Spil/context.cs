class Context
{
    // ---------- Felter: det Context husker under hele spillet ----------
    Space current;                              // Det rum spilleren står i lige nu
    Player player = new Player();               // Spilleren (liv og dødstæller). Oprettes med det samme
    Inventory inventory = new Inventory();      // Spillerens våben. Oprettes tomt
    bool done = false;                          // false = spillet kører. true = spillet er slut

    // ---------- Constructor: kaldes én gang, når spillet starter (new Context(...)) ----------
    public Context(Space node)                                // node = startrummet, som Game sender ind
    {
        current = node;                                       // Husk startrummet som "nuværende rum"
        inventory.AddWeapon(new Weapon("Metalbat", "metal")); // Spilleren starter med et våben
    }

    // ---------- Getters: lader andre klasser læse felterne uden at ændre dem ----------
    public Space GetCurrent() { return current; }
    public Inventory GetInventory() { return inventory; }

    // ---------- Gå videre til et andet rum ("go door") ----------
    public void Transition(string direction)
    {
        Space? next = current.FollowEdge(direction);   // Slå retningen op. Giver null, hvis den ikke findes
        if (next == null)                              // Findes udgangen ikke?
        {
            Console.WriteLine("Du går i ring og leder efter '" + direction + "' 😩");
            return;                                    // return = stop metoden her, intet mere sker
        }
        if (current.HasLivingMonster())                // Regel 1: monsteret skal være besejret
        {
            Console.WriteLine("Monsteret blokerer vejen! Besejr det først.");
            return;
        }
        if (current.HasAvailableLoot())                // Regel 2: tingene skal samles op først
        {
            Console.WriteLine("Du skal samle tingene op, før du går videre ('samle op').");
            return;
        }
        // Når vi når hertil, er begge regler overholdt, så vi må gå videre
        current.Goodbye();     // Giv det gamle rum chancen for at "rydde op"
        current = next;        // Skift til det nye rum
        current.Welcome();     // Vis det nye rum for spilleren
    }

    // ---------- Saml loot op ("pickup") ----------
    public void PickUp()
    {
        List<Item> items = current.TakeLoot();   // Hent alt loot og tøm rummet. Tom liste, hvis monsteret lever
        if (items.Count == 0)                    // Count = antal elementer i listen
        {
            Console.WriteLine("\nDer er intet at samle op.");
            return;
        }
        foreach (Item item in items)             // Gennemgå hver ting i listen, én ad gangen
            item.PickUp(player, inventory);      // Hver ting ved selv, hvad der skal ske (våben → inventory, liv → +1 HP)

        Console.WriteLine("\nDit inventory:");
        inventory.PrintInventory();              // Vis spillerens våben efter opsamling
        Console.WriteLine("\nDu kan nu gå videre.");
    }

    // ---------- Angrib ("attack 1 2" = del nr. 1 med våben nr. 2) ----------
    public void Attack(string[] parameters)
    {
        Monster? monster = current.GetMonster();   // Hent rummets monster (kan være null)
        if (!current.HasLivingMonster() || monster == null)   // ! = "ikke". Intet levende monster = intet at angribe
        {
            Console.WriteLine("\nDer er intet monster at angribe her.");
            return;
        }

        // Tjek at kommandoen er skrevet rigtigt:
        // 1) præcis 2 parametre, og 2) begge kan laves om til tal.
        // int.TryParse(tekst, out tal): prøver at omdanne tekst til tal. Giver true/false og crasher ikke ved bogstaver.
        // "out int partNo" opretter variablen partNo og fylder den med tallet, hvis det lykkes
        if (parameters.Length != 2
            || !int.TryParse(parameters[0], out int partNo)
            || !int.TryParse(parameters[1], out int weaponNo))
        {
            Console.WriteLine("\nBrug: angrib <del-nr> <våben-nr>");
            return;
        }

        MonsterPart? part = monster.GetPart(partNo);        // Find monsterdelen ud fra nummeret (null hvis ugyldigt)
        Weapon? weapon = inventory.GetWeapon(weaponNo);     // Find våbnet ud fra nummeret (null hvis ugyldigt)
        if (part == null || weapon == null)                 // Et af numrene var forkert
        {
            Console.WriteLine("\nUgyldigt valg af del eller våben.");
            return;
        }

        if (weapon.Attack(part))                            // Rigtigt materiale? (true = delen er besejret)
        {
            if (monster.IsDefeated())                       // Var det den sidste del på monsteret?
            {
                Console.WriteLine("\nMonster besejret! Godt arbejde.");
                if (current.IsFinal())                      // Er det sidste rum? Så er spillet vundet
                {
                    Console.WriteLine("\nDu har sorteret skraldets verden. Du har vundet! 🎉");
                    done = true;                            // Game's løkke stopper, når IsDone() giver true
                }
                else
                {
                    current.PrintLoot();                    // Ellers: vis nu det loot, monsteret tabte
                }
            }
        }
        else                                                // Forkert materiale
        {
            player.LoseLife();                              // Mist ét liv
            Console.WriteLine($"\nForkert våben! Liv tilbage: {player.GetHealthPoints()}");
            if (player.IsDead()) RestartLevel();            // Ingen liv tilbage? Genstart leveled
        }
    }

    // ---------- Genstart det nuværende level efter døden (private = kun brugt inde i Context) ----------
    private void RestartLevel()
    {
        player.Respawn();                    // Fyld liv op til 3 og tæl dødstælleren op
        current.GetMonster()?.Reset();       // ?. = kun kald Reset(), hvis monsteret ikke er null. Gør alle dele levende igen
        Console.WriteLine($"\nDu døde. Dødsfald i alt: {player.GetDeathCounter()}");
        current.Welcome();                   // Vis rummet igen, som da du kom ind
    }

    // ---------- Afslut spillet ("exit") ----------
    public void MakeDone() { done = true; }      // Sæt flaget, så spil-løkken stopper
    public bool IsDone() { return done; }        // Game spørger her, om løkken skal fortsætte
}
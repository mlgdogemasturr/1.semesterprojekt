/* World class for modeling the entire in-game world
 */
namespace trash;

class World
{
    Space entry;   // Feltet gemmer startrummet

    public World()
    {
        // ---------- Opret de 8 rum (hvert rum er et level) ----------
        Space level1 = new Space("Level 1");
        Space level2 = new Space("Level 2");
        Space level3 = new Space("Level 3");
        Space level4 = new Space("Level 4");
        Space level5 = new Space("Level 5");
        Space level6 = new Space("Level 6");
        Space level7 = new Space("Level 7");
        Space level8 = new Space("Level 8");

        // ---------- Level 1: KonservesMonsteret -> Glass Cannon ----------
        Monster metalMonster = new Monster("KonservesMonsteret");
        metalMonster.AddMonsterPart(new MonsterPart("Krop", "metal"));
        level1.SetMonster(metalMonster);
        level1.AddLoot(new Weapon("Glas Kanon", "glas"));

        // ---------- Level 2: DrikkeUheldet (glas + glas + glas) -> madaffaldsvåben ----------
        Monster glasMonster = new Monster("DrikkeUheldet");
        glasMonster.AddMonsterPart(new MonsterPart("Stort glasskår", "glas"));
        glasMonster.AddMonsterPart(new MonsterPart("Lille glasskår", "glas"));
        glasMonster.AddMonsterPart(new MonsterPart("Mini  glasskår", "glas"));
        level2.SetMonster(glasMonster);
        level2.AddLoot(new Weapon("Madgaffel", "mad"));

        // ---------- Level 3: Cocio (glas + metal) -> restaffaldsvåben ----------
        Monster cocio = new Monster("CocioBæstet");
        cocio.AddMonsterPart(new MonsterPart("Låg", "metal"));
        cocio.AddMonsterPart(new MonsterPart("Flaske", "glas"));
        level3.SetMonster(cocio);
        level3.AddLoot(new Weapon("Restaffaldsøkse", "rest"));

        // ---------- Level 4: BananKongen (mad) -> Papsværd ----------
        Monster bananaKing = new Monster("BananKongen");
        bananaKing.AddMonsterPart(new MonsterPart("Bananskræl", "mad"));
        level4.SetMonster(bananaKing);
        level4.AddLoot(new Weapon("Papsværdet", "pap"));

        // ---------- Level 5: Pizzabakke (rest + mad + metal) -> +1 liv ----------
        Monster pizza = new Monster("HangoverUdyret");
        pizza.AddMonsterPart(new MonsterPart("Pizzabakke", "rest"));
        pizza.AddMonsterPart(new MonsterPart("Skorperester", "mad"));
        pizza.AddMonsterPart(new MonsterPart("Tom dåse fra Tyskland", "metal"));
        level5.SetMonster(pizza);
        level5.AddLoot(new HealthPickup());          // Belønning er et ekstra liv i stedet for et våben

        // ---------- Level 6: Avocadobakke (pap + mad) -> PlastMaSværd ----------
        Monster avocado = new Monster("AvocadoRidderen");
        avocado.AddMonsterPart(new MonsterPart("Rustning: Bakke", "pap"));
        avocado.AddMonsterPart(new MonsterPart("Krop: Avocadoskrald", "mad
        avocado.AddMonsterPart(new MonsterPart("Krop: Avocadosten", "mad"));
        level6.SetMonster(avocado);
        level6.AddLoot(new Weapon("PLASTmaSværdet", "plast"));

        // ---------- Level 7: Smørbakke (pap + plast + rest) -> +1 liv ----------
        Monster smør = new Monster("SmørbakkeMonstromet"); //evt. gør det til Lurpak el. andet for at specificere 
        smør.AddMonsterPart(new MonsterPart("Bund", "pap"));
        smør.AddMonsterPart(new MonsterPart("Låg", "plast"));
        smør.AddMonsterPart(new MonsterPart("Resten af bakken", "rest"));
        level7.SetMonster(smør);
        level7.AddLoot(new HealthPickup());

        // ---------- Level 8: Julegave-monsteret (rest + pap + plast) -> spillet er vundet ----------
        Monster gave = new Monster("Den Afskyelige Julegave");
        gave.AddMonsterPart(new MonsterPart("Gavepapir", "rest"));
        gave.AddMonsterPart(new MonsterPart("Skoæske", "pap"));
        gave.AddMonsterPart(new MonsterPart("Boblefolie", "plast"));
        level8.SetMonster(gave);
        // Ingen loot og ingen udgange: Space.IsFinal() er true, så Context afslutter spillet ved sejr

        // ---------- Forbind rummene i rækkefølge ----------
        level1.AddEdge("gennem.dør", level2);
        level2.AddEdge("under.vandfaldet", level3);
        level3.AddEdge("gennem.hul", level4);
        level4.AddEdge("op.af.mineskakten", level5);
        level5.AddEdge("gennem.lem", level6);
        level6.AddEdge("mod.nord", level7);
        level7.AddEdge("mod.lyset", level8);

        this.entry = level1;   // Spilleren starter ved level 1
    }

    public Space GetEntry() { return entry; }
}
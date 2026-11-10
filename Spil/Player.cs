class Player
{
    private const byte MaxHealth = 3;            // const = fast værdi, kan ikke ændres. Max liv
    private byte healthPoints = MaxHealth;       // Nuværende liv, starter på max
    private int deathCounter = 0;                // Hvor mange gange spilleren er død

    public byte GetHealthPoints() { return healthPoints; }   // Getter: liv
    public int GetDeathCounter() { return deathCounter; }    // Getter: dødstæller

    // Spilleren mister ét liv
    public void LoseLife()
    {
        if (healthPoints > 0) healthPoints--;   // Tjek først, så byte ikke går under 0
    }

    public bool IsDead() { return healthPoints == 0; }   // Død hvis liv er 0

    // Genopliv spilleren
    public void Respawn()
    {
        deathCounter++;              // Tæl en død op
        healthPoints = MaxHealth;    // Fyld liv op igen
    }

    // Saml et ekstra liv op (kan ikke overstige max)
    public void PickUpHP()
    {
        if (healthPoints < MaxHealth) healthPoints++;
        else Console.WriteLine("\nDu har ikke mistet et liv. Godt arbejde!");
    }
}
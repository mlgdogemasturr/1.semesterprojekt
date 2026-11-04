class Level 
{
    private Byte levelCounter;

    public Level(byte levelCounter) 
    {
        this.levelCounter = levelCounter;
    }

    public void NextLevel () 
    {
        levelCounter++;
    }

    public bool CompleteLevel () 
    {
        return monster.MonsterDefeat(); //Hvis monsteret er defeat er level complete
    }

    public void RestartLevel (Player player) 
    {
        if (player.PlayerDeath()) // Hvis player er død, skal monsteret spawn og player skal respawn med full hp
        {
            monster.SpawnMonster();
            player.PlayerRespawn();
        }
    }
}
Lav liste med alle monstre 
Construct alle weapons
PlayerSpawn

Velkommen til skraldets verden!

Du er nå på level 0. 
Du ser en genstand på jorden. Vil du samle den op? (ja/nej)
Nej: ”Er du sikker?”
Ja: (Våben) tilføjet til inventory. 
PrintInventory
Vil du fortsætte? (ja/nej)
Nej: er du sikker?
Ja: du går igennem døren
Du er nu på level 1.
Du ser (affaldsmonster) nærme sig!
if (MonsterPartCount>1 || MonsterCount > 1)
    Hvilken del af monsteret vil du angribe?
    PrintMonsterParts
    ReadLine (1-MonsterPart.Count)
else
{
    skipper kode for at vælge monsterpart
}
Hvilket våben vil du benytte?
PrintInventory
ReadLine (1-weapons.count)
Attack (checker om weaponmaterial==monsterpartmaterial) 
    True -> Defeat()
        if MonsterPart.Count <= 0
            MonsterDefeat()
            print Monster besejret! Godt arbejde.
            print Du ser en genstand på jorden. Vil du samle det op? (ja/nej)
                ja -> (våben) tilføjet til inventory.
                        print inventory
                nej -> er du sikker?
                    Vil du fortsætte? (ja/nej)
                    Nej: er du sikker?
                    Ja: du går igennem døren
                    Du er nu på level 2. (fortsætter som før)
    False -> LoseLife ()
        HealthPoints--
        if HealthPoints <= 0
        {
        PlayerDeath() 
            deathcounter++
            RestartLevel()
                PlayerRespawn()
                    SetFullHP()
                SpawnMonster()
                    monsteret skal spawne fra start med alle dets dele
                    print DeahtCount
                    gå til linje 11 (du er nu på level (x))
        }
        else
        {
            HealthPoints--;
            print Healthpoints
            break/continue...?
        }

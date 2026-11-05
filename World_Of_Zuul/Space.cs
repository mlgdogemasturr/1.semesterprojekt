/* Space class for modeling spaces (rooms, caves, ...)
 */

class Space : Node {
  public Space (String name) : base(name)
  {
  }
  
  public void Welcome () {
    Console.WriteLine("You are now at level "+name); //levelcounter
    Console.WriteLine("Du ser "+affaldsmonster+" nærme sig!"); //affaldsmonster er placeholder  
    Console.WriteLine("Hvilket våben vil du benytte?");
    Inventory.PrintInventory();
    
    Monster.PrintMonster();
    HashSet<string> exits = edges.Keys.ToHashSet(); //
    Console.WriteLine("Current exits are:");
    foreach (String exit in exits) {
      Console.WriteLine(" - "+exit);
    }
  }
  
  public void Goodbye () {
  }
  
  public override Space FollowEdge (string direction) {
    return (Space) (base.FollowEdge(direction));
  }
}

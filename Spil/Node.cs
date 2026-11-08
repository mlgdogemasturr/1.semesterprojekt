class Node
{
    protected string name;   // protected: synligt i Node og klasser, der arver fra Node (fx Space)
    protected Dictionary<string, Node> edges = new Dictionary<string, Node>();  // Retning → næste rum

    public Node(string name) { this.name = name; }

    public String GetName() { return name; }

    // Opretter en forbindelse, fx AddEdge("door", level1)
    public void AddEdge(string name, Node node) { edges.Add(name, node); }

    // Følger en forbindelse. NYT: returnerer null i stedet for at crashe, hvis retningen ikke findes
    public virtual Node? FollowEdge(string direction)
    {
        // TryGetValue slår op i dictionary'en. Giver true og leverer værdien i "next", hvis nøglen findes
        return edges.TryGetValue(direction, out Node? next) ? next : null;
    }
}
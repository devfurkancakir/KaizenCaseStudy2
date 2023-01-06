namespace KaizenCaseStudy2.Models;

public class Receipt
{
    public List<Item> Items { get; set; }
}

public class BoundingPoly
{
    public List<Vertex> vertices { get; set; }
}

public class Item
{
    //public string locale { get; set; }
    public string description { get; set; }
    public BoundingPoly boundingPoly { get; set; }
}

public class Vertex
{
    public int x { get; set; }
    public int y { get; set; }
}
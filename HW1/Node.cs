namespace HW1;

public class Node
{
    public Node leftNode { get; set; }
    public Node rightNode { get; set; }
    public int content { get; set; }
    public Node(int newContent){
        content = newContent;
        leftNode = null;
        rightNode = null;
    }

    public void PrintNode()
    {
        Console.Write(content + " ");
    }
}
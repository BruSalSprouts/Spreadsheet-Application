namespace HW1;

public class BST
{
    public Node root { get; set; }

    public BST(){
        root = null;
    }
    
    public void Insert(int value)
    {
        root = InsertHelp(root, value);
    }

    private Node InsertHelp(Node branch, int value)
    {
        if (branch == null)
        {
            branch = new Node(value);
            return branch;
        }
        if (value < branch.content)
        {
            branch.leftNode = InsertHelp(branch.leftNode, value);
        }
        else if (value > branch.content)
        {
            branch.rightNode = InsertHelp(branch.rightNode, value);
        }
        return branch;
    }
	
}
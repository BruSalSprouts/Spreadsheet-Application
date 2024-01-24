namespace HW1;

public class BST
{
    public Node root { get; set; }

    public BST(){ //Default constructor
        root = null;
    }
    
    public void Insert(int value) //Insert item to the BST
    {
        root = InsertHelp(root, value);
    }

    private Node InsertHelp(Node branch, int value) //Insert item to the BST Helper
    {
        if (branch == null)
        { //Insert item where there is none
            branch = new Node(value);
            return branch;
        }
        if (value < branch.content)
        { //Insert item into the left side
            branch.leftNode = InsertHelp(branch.leftNode, value);
        }
        else if (value > branch.content)
        { //Insert item into the right side
            branch.rightNode = InsertHelp(branch.rightNode, value);
        }
        return branch;
    }

    public void DisplayInOrder()
    {
        if (root == null)
        {
            Console.WriteLine("Nothing has been inserted yet!");
        }
        else
        {
            if (root.leftNode != null) // Check left side
            { //Stuff exists, call the display helper, then exit
                DisplayInOrderHelper(root.leftNode);
            }
            //Print out the contents of the root
            root.printNode();
            
            if (root.rightNode != null)// Check right side
            { //Stuff exists, call the display helper, then exit
                DisplayInOrderHelper(root.rightNode);
            } 
        }
    }

    private void DisplayInOrderHelper(Node branch)
    {
        if (branch == null)
        {
            Console.WriteLine("Error! Empty Node");
        }
        else
        {
            if (branch.leftNode != null) // Check left side
            { //Stuff exists, call the display helper, then exit
                DisplayInOrderHelper(branch.leftNode);
            }
            //Print out the contents of the root
            branch.printNode();
            
            if (branch.rightNode != null)// Check right side
            { //Stuff exists, call the display helper, then exit
                DisplayInOrderHelper(branch.rightNode);
            } 
        }
    }
}
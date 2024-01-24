namespace HW1;

public class BST
{
    public Node root { get; set; }

    public BST(){ //Default constructor
        root = null;
    }
    // Insert Functions
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
    // Display Functions
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
    // Counting Functions
    public int NumItems()
    {
        if (root == null)
        { //No items at all
            return 0;
        }
        return NumItemsHelper(root);
    }

    private int NumItemsHelper(Node branch)
    { //Recursive function that returns the number of nodes in a branch
        if (branch == null)
        { //If the branch is empty, return such
            return 0;
        }
        int left = NumItemsHelper(branch.leftNode); // Gets number of nodes from left part of branch
        int right = NumItemsHelper(branch.rightNode); // Gets number of nodes from right part of branch
        return 1 + left + right; //Always returns number of nodes returned + 1, ensuring there's something in here
    }
    // Level-related functions
    public int GetLevels()
    {
        return getLevelsHelper(root, 1);
    }

    private int getLevelsHelper(Node branch, int level)
    {
        if (branch == null)
        { // Negative value for later max comparison
            return -1;
        }

        int leftLevels = getLevelsHelper(branch.leftNode, level); //Store max height of left side
        int rightLevels = getLevelsHelper(branch.rightNode, level); //Store max height of right side;

        return Math.Max(leftLevels, rightLevels) + 1; //Returns highest height of tree and returns it
    }
}
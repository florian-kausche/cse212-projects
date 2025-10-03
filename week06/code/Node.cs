public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // If value already exists, don't insert it
        if (value == Data)
            return;

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // If we found the value
        if (value == Data)
            return true;

        // Search left subtree if value is less than current
        if (value < Data && Left != null)
            return Left.Contains(value);

        // Search right subtree if value is greater than current
        if (value > Data && Right != null)
            return Right.Contains(value);

        // Value not found
        return false;
    }

    public int GetHeight()
    {
        // Get heights of left and right subtrees
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        // Return 1 (for current node) plus the maximum of left and right heights
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
using System;

/// <summary>
/// Generic node class for linked list implementation
/// Contains data of type T and reference to next node
/// </summary>
public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

/// <summary>
/// Stack implementation using a singly linked list
/// Follows Last-In-First-Out (LIFO) principle
/// All operations are O(1) time complexity
/// </summary>
public class LinkedListStack<T>
{
    private Node<T> top;    // Points to the top element of the stack
    private int count;      // Keeps track of number of elements

    public LinkedListStack()
    {
        top = null;
        count = 0;
    }

    /// <summary>
    /// Push Operation - O(1)
    /// 1. Creates new node with data
    /// 2. Points new node to current top
    /// 3. Updates top to new node
    /// Example: top->[A]->[B] becomes top->[X]->[A]->[B]
    /// </summary>
    public void Push(T item)
    {
        Node<T> newNode = new Node<T>(item);
        newNode.Next = top;
        top = newNode;
        count++;
    }

    /// <summary>
    /// Pop Operation - O(1)
    /// 1. Checks if stack is empty
    /// 2. Gets top element's data
    /// 3. Moves top pointer to next node
    /// Example: top->[X]->[A]->[B] becomes top->[A]->[B]
    /// </summary>
    public T Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty");

        T data = top.Data;
        top = top.Next;
        count--;
        return data;
    }

    /// <summary>
    /// GetTop Operation - O(1)
    /// Simply returns the data at the top node
    /// No traversal needed, direct access via top pointer
    /// </summary>
    public T GetTop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty");
        return top.Data;
    }

    /// <summary>
    /// IsEmpty Operation - O(1)
    /// Checks if stack has any elements by examining top pointer
    /// </summary>
    public bool IsEmpty()
    {
        return top == null;
    }
}

/// <summary>
/// Queue implementation using a singly linked list
/// Follows First-In-First-Out (FIFO) principle
/// All operations are O(1) time complexity
/// Uses both front and rear pointers for efficient operations
/// </summary>
public class LinkedListQueue<T>
{
    private Node<T> front;  // Points to first element (for dequeue)
    private Node<T> rear;   // Points to last element (for enqueue)
    private int count;      // Keeps track of number of elements

    public LinkedListQueue()
    {
        front = null;
        rear = null;
        count = 0;
    }

    /// <summary>
    /// Enqueue Operation - O(1)
    /// 1. Creates new node
    /// 2. If queue empty, both front and rear point to new node
    /// 3. Otherwise, adds to rear and updates rear pointer
    /// Example: [A]->[B]->rear becomes [A]->[B]->[X]->rear
    /// </summary>
    public void Enqueue(T item)
    {
        Node<T> newNode = new Node<T>(item);
        
        if (IsEmpty())
        {
            front = newNode;
            rear = newNode;
        }
        else
        {
            rear.Next = newNode;
            rear = newNode;
        }
        count++;
    }

    /// <summary>
    /// Dequeue Operation - O(1)
    /// 1. Checks if queue is empty
    /// 2. Gets front element's data
    /// 3. Moves front pointer to next node
    /// 4. Updates rear to null if queue becomes empty
    /// Example: front->[A]->[B]->[C] becomes front->[B]->[C]
    /// </summary>
    public T Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");

        T data = front.Data;
        front = front.Next;
        count--;

        if (front == null)
            rear = null;

        return data;
    }

    /// <summary>
    /// Size Operation - O(1)
    /// Returns current number of elements
    /// Maintained by count variable
    /// </summary>
    public int Size()
    {
        return count;
    }

    /// <summary>
    /// IsEmpty Operation - O(1)
    /// Checks if queue has any elements by examining front pointer
    /// </summary>
    public bool IsEmpty()
    {
        return front == null;
    }
}


/*
STACK IMPLEMENTATION USING LINKED LIST
===================================

A stack follows Last-In-First-Out (LIFO) principle and can be efficiently
implemented using a singly linked list. Here's how each operation works:

1. Push Operation (O(1))
   - Create a new node with the data
   - Set the new node's next pointer to current top
   - Update top to point to new node
   - Increment count
   Example:
   Initial: top -> [A] -> [B] -> [C]
   Push(X): top -> [X] -> [A] -> [B] -> [C]

2. Pop Operation (O(1))
   - Check if stack is empty
   - Store top node's data
   - Update top to point to next node
   - Decrement count
   - Return stored data
   Example:
   Before: top -> [X] -> [A] -> [B] -> [C]
   After:  top -> [A] -> [B] -> [C]

3. GetTop Operation (O(1))
   - Simply return the data in the top node
   - No traversal needed

4. IsEmpty Operation (O(1))
   - Check if top is null
   - Return true if null, false otherwise

QUEUE IMPLEMENTATION USING LINKED LIST
===================================

A queue follows First-In-First-Out (FIFO) principle and can be efficiently
implemented using a singly linked list with both front and rear pointers:

1. Enqueue Operation (O(1))
   - Create new node with data
   - If queue is empty, set both front and rear to new node
   - Otherwise:
     * Set rear's next to new node
     * Update rear to new node
   - Increment count
   Example:
   Initial: front -> [A] -> [B] -> [C] <- rear
   Enqueue(X): front -> [A] -> [B] -> [C] -> [X] <- rear

2. Dequeue Operation (O(1))
   - Check if queue is empty
   - Store front node's data
   - Update front to next node
   - If front becomes null, set rear to null too
   - Decrement count
   - Return stored data
   Example:
   Before: front -> [A] -> [B] -> [C] <- rear
   After:  front -> [B] -> [C] <- rear

3. Size Operation (O(1))
   - Maintain a count variable
   - Return current count

4. IsEmpty Operation (O(1))
   - Check if front is null
   - Return true if null, false otherwise

Note: Both implementations maintain O(1) time complexity for all operations
by keeping track of the necessary pointers (top for stack, front and rear
for queue) and a count variable.
*/
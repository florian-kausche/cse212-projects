/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        _queue.Insert(0, person); // Add to the back of the queue
    }

    public Person Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        int lastIndex = _queue.Count - 1;
        var person = _queue[lastIndex]; // Get from the front of the queue
        _queue.RemoveAt(lastIndex); // Remove from the front
        return person;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public Person Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }
        return _queue[0];
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}
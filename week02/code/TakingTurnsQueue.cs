public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }
        else
        {
            Person person = _people.Dequeue();
            if (person.Turns > 0) // Only if they have finite turns
            {
                person.Turns -= 1; // Decrease turns
                if (person.Turns >= 0) // Enqueue again if they still have turns left
                {
                    _people.Enqueue(person);
                }
            }
            return person;
        }
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}

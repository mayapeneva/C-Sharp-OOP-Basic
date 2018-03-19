using System.Collections.Generic;

public class StackOfStrings
{
    private List<string> data;

    public StackOfStrings()
    {
        this.data = new List<string>();
    }

    public void Push(string item)
    {
        this.data.Add(item);
    }

    public string Pop()
    {
        var result = this.data[this.data.Count - 1];
        this.data.RemoveAt(this.data.Count - 1);
        return result;
    }

    public string Peek()
    {
        return this.data[this.data.Count - 1];
    }

    public bool IsEmpty()
    {
        if (this.data.Count > 0)
        {
            return true;
        }

        return false;
    }
}
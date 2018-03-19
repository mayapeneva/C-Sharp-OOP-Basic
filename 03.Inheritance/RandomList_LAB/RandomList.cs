using System;
using System.Collections;

public class RandomList : ArrayList
{
    private Random random;
    private ArrayList list;

    public RandomList()
    {
        this.random = new Random();
        this.list = new ArrayList();
    }

    public object RandomString()
    {
        var str = this.list[this.random.Next(0, this.list.Count - 1)];
        this.list.Remove(str);
        return str;
    }
}
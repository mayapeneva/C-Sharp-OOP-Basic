public class StartUp
{
    static void Main(string[] args)
    {
        var stringStack = new StackOfStrings();
        var item = "item";
        stringStack.Push(item);
        stringStack.Pop();
        stringStack.Peek();
        stringStack.IsEmpty();
    }
}
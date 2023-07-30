namespace Assignment.Question1.Solution1;

public sealed class GenericList<T>
{
    private readonly IOutput _output;

    public GenericList(IOutput output)
    {
        _output = output;
    }

    public void DoSomething(T item)
    {
        _output.Write($"{(item is null ? "NULL" : item.ToString())}{Environment.NewLine}");
    }
}
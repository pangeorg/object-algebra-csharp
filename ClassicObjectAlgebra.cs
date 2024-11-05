
// instead of returning an expression 'Exp'
// we make the interface generic over E.
// This makes it an algebra over E.
// E is the OperationType so to say and
// _t is the concrete type of the value we want to operate on
// e.g. int, f64...
// E thus could be a printer, an evaluator, an image drawer or whatever...
//
// We need to extend the interface defined here if 
// we want to add more operations like Mul
// This will be a bit hard however as C# only 'supports'
// single inheritance. So to add new capabilities you still need
// to modify the interface here. Extension methods on Interfaces
// are implementations and do not count onto the interface.
// Only possibility is to create an interface for each individual 
// capability, e.g. IExpAlgLiteral<E>, IExpAlgAdd<E>, ...

// 'Classic' Version
public interface ExpAlg<E>
{
    E Literal(int value);
    E Add(E lhs, E rhs);
}

public interface IPrint
{
    string Print();
}

public struct PrintLiteral : IPrint
{
    private readonly int _value;

    public PrintLiteral(int value)
    {
        _value = value;
    }

    public string Print()
    {
        return _value.ToString();
    }
}

public struct PrintAdd : IPrint
{
    private readonly IPrint _lhs;
    private readonly IPrint _rhs;

    public PrintAdd(IPrint lhs, IPrint rhs)
    {
        _lhs = lhs;
        _rhs = rhs;
    }

    public string Print()
    {
        return _lhs.Print() + " + " + _rhs.Print();
    }
}


class PrintExp : ExpAlg<IPrint>
{
    public IPrint Add(IPrint lhs, IPrint rhs)
    {
        return new PrintAdd(lhs, rhs);
    }

    public IPrint Literal(int value)
    {
        return new PrintLiteral(value);
    }
}

// instead of returning an expression 'Exp'
// we make the interface generic over E.
// This makes it an algebra over E.
// E is the OperationType so to say and
// _t is the concrete type of the value we want to operate on
// e.g. int, f64...
// E thus could be a printer, an evaluator, an image drawer or whatever...

public interface ExpAlgT<E, _t>
{
    E Literal(_t value);
    E Binary(E lhs, E rhs, Func<_t, _t> op);
    E Ternary(E lhs, E mid, E rhs, Func<_t, _t, _t> op);
}

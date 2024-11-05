
// ---------- Top level stmts

E MakeExp<E>(ExpAlg<E> a)
{
    return a.Add(a.Literal(1), a.Literal(2));
}

var printExp = MakeExp(new PrintExp());
Console.WriteLine(printExp.Print());


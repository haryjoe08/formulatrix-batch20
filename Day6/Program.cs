class Program
{
    static void Main(string[] args)
    {
        FooBarJazz.Foo(21);
        FooBarJazz.Foo(35);
        FooBarJazz.Foo(105);
    }
}

class FooBarJazz
{
    public static void Foo(int x)
    {
        string result = "";

        if (x % 3 == 0)
        {
            result += "foo";
        }

        if (x % 5 == 0)
        {
            result += "bar";
        }

        if (x % 7 == 0)
        {
            result += "jazz";
        }

        // if x is does not matching any of 3 conditions above
        if (result == "")
        {
            result = x.ToString();
        }

        Console.WriteLine(result);
    }
}
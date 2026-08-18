class Program
{
    static void Main(string[] args)
    {
        FooBarJazz.Foo(36);
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

        if (x % 4 == 0)
        {
            result += "baz";
        }

        if (x % 5 == 0)
        {
            result += "bar";
        }

        if (x % 7 == 0)
        {
            result += "jazz";
        }

        if (x % 9 == 0)
        {
            result += "huzz";
        }

        // if x is does not matching any divisor
        if (result == "")
        {
            result = x.ToString();
        }

        Console.WriteLine(result);
    }
}
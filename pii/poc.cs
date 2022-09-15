using System;


// ------
// Two "Phantom Types"
//
// - Never instantiated
// - Used only by the compiler ("type-level")
//
public sealed class PII
{
    // cannot be constructed
    private PII() {}
}

public sealed class NonPII
{
    // cannot be constructed
    private NonPII() {}
}


// ------
// String wrapper
// - The "Phantom Types" will be used in <T>
//
public sealed class PString<T>
{
    public PString(string s)
    {
        S = s;
    }

    // Auto-implemented readonly property:
    public string S { get; }

    // Method that overrides the base class (System.Object) implementation.
    public override string ToString()
    {
        return S;
    }
}



public class HelloWorld
{
    public static void Main(string[] args)
    {
        var normal = new PString<NonPII>("hello world!");
        var pii    = new PString<PII>("S3(73T");


        // --------------
        // won't compile:

        //pii    = normal;
        //normal = pii;


        // --------------
        // won't compile:

        //everyoneSees(pii);
        //verySecretStuff(normal);


        // --------------
        // will compile
        everyoneSees(normal);
        verySecretStuff(pii);

        worksForBoth(normal);
        worksForBoth(pii);
    }


    public static void everyoneSees(PString<NonPII> data)
    {
        Console.WriteLine ("-------");
        Console.WriteLine ("Everyone can see this string = {0}", data);

    }


    public static void verySecretStuff(PString<PII> data)
    {
        Console.WriteLine ("-------");
        Console.WriteLine ("Top secret string = {0}", data);
    }


    public static void worksForBoth<T>(PString<T> data)
    {
        Console.WriteLine ("-------");
        Console.WriteLine ("Works for both PII and Non-PII = {0}", data);
    }
}

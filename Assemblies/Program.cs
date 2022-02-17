using System;
using System.Reflection;

class AssemblyStudy
{
    #region ClassDefinition

    #region PublicProperties
    public string DummyMessage { get; private set; }
    #endregion

    #region PrivateData
    private int age;
    private Random random;
    #endregion

    #region Ctor
    public AssemblyStudy(string message)
    {
        random = new Random();
        DummyMessage = message;
        age = random.Next(10, 23);
    }
    #endregion

    #region PublicMethods
    public int ComputeAgeDifference(int age)
    {
        return Math.Abs(age - this.age);
    }
    #endregion

    #endregion

    #region TestCode
    /// <summary>
    /// Main method: just get some information from the current assembly
    /// </summary>
    /// <param name="args">command line arguments</param>
    public static void Main(string[] args)
    {
        #region AnalyzeCurrentAssembly
        Assembly asm = typeof(AssemblyStudy).Assembly;
        Console.WriteLine("Full Name: {0}", asm.FullName);
        Console.WriteLine("Assembly Location: {0}", asm.Location);
        Console.WriteLine("Security Level: {0}", asm.SecurityRuleSet);
        Console.WriteLine("Host Context: {0}", asm.HostContext);
        Console.WriteLine("Entry Point: {0}", asm.EntryPoint); //should be null for dlls
        Console.WriteLine("Defined Types:");
        foreach (TypeInfo element in asm.DefinedTypes)
        {
            Console.WriteLine("\t->{0}", element.Name);
        }
        Console.WriteLine(asm.PermissionSet);
        Console.WriteLine("Modules:");
        foreach(var module in asm.Modules)
        {
            Console.WriteLine("\t->{0}", module);
        }
        #endregion
        #region AnalyzeLibraryAssembly
        Assembly libAsm = typeof(TestLibraryAssemblyEntryPoint.AssemblyEntryPoint).Assembly;
        if(libAsm.EntryPoint == null)
        {
            Console.WriteLine("No entry point for DLL!");
        }
        #endregion
    }
    #endregion
}
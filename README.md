# PA_Prefab_Constructor

HOW TO USE
------------------------------------

LOADING THE FILE INTO THE OBJECT.
>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

using PA_PLUGIN;

public class Program
{
    static void Main()
    {
        Prefab pre = Prefab.Load("FILENAME LOCATION"); // Loading the lsb file
        Console.WriteLine(pre); // Converts Object to JSON
    }
}

SAVING THE OBJECT TO A FILE
>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

Using PA_PLUGIN;

public class Program
{
    static void Main()
    {
        Prefab pre = Prefab.Load("FILENAME LOCATION"); // Get a PreExisting File to use for saving.
        
        pre.Save("<Location of New File>"); //Saves a new File.
        pre.SaveAs("<Location Of Existing File>"); // Overwrites the File.
    }
}
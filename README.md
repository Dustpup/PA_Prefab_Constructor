# PA_Prefab_Constructor

HOW TO USE
------------------------------------

LOADING THE FILE INTO THE OBJECT.
>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

```C#
using PA_PLUGIN;

public class Program
{
    static void Main()
    {
        Prefab pre = Prefab.Load("FILENAME LOCATION"); // Loading the lsb file (( Must Include Extension ))
        Console.WriteLine(pre); // Converts Object to JSON
    }
}
```

SAVING THE OBJECT TO A FILE
>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

```C#
Using PA_PLUGIN;

public class Program
{
    static void Main()
    {
        Prefab pre = Prefab.Load("FILENAME LOCATION"); // Get a PreExisting File to use for saving. (( Must Include Extension ))
        
        //((Must Include File Extension))
        pre.Save("<Location of New File>"); //Saves a new File. 
        
        //((Must Include File Extension))
        pre.SaveAs("<Location Of Existing File>"); // Overwrites the File. 
    }
}
```

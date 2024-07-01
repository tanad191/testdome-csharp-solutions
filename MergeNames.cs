using System;
using System.Collections;
using System.Linq;

//Problem: https://www.testdome.com/questions/c-sharp/merge-names/96048

public class MergeNames
{
    public static string[] UniqueNames(string[] names1, string[] names2)
    {
        ArrayList uniqueList = new ArrayList();
        
        for (int i = 0; i < names1.Length; i++) {
            if (!uniqueList.Contains(names1[i])) { uniqueList.Add(names1[i]); }
        }
        
        for (int j = 0; j < names2.Length; j++) {
            if (!uniqueList.Contains(names2[j])) { uniqueList.Add(names2[j]); }
        }
        
        return (string[])uniqueList.ToArray(typeof(string));
    }
    
    public static void Main(string[] args)
    {
        string[] names1 = new string[] {"Ava", "Emma", "Olivia"};
        string[] names2 = new string[] {"Olivia", "Sophia", "Emma"};
        Console.WriteLine(string.Join(", ", MergeNames.UniqueNames(names1, names2))); // should print Ava, Emma, Olivia, Sophia
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAndHashTable
{
    internal class HashTable
    {
        // Create a Hashtable
        Hashtable userInfo = new Hashtable();

        // Adding different types of keys and values
        userInfo.Add("username", "Alice");         // string key, string value
        userInfo.Add("userId", 123);                // string key, int value
        userInfo.Add("isActive", true);             // string key, bool value
        userInfo.Add("age", 25);                    // string key, int value

        // Accessing values
        Console.WriteLine("Username: " + userInfo["username"]);  // Alice
        Console.WriteLine("User ID: " + userInfo["userId"]);     // 123
        Console.WriteLine("Is Active: " + userInfo["isActive"]);  // True
        Console.WriteLine("Age: " + userInfo["age"]);             // 25

        // Removing a user attribute
        userInfo.Remove("age");
        Console.WriteLine("After removing age:");

        // Iterating through the hashtable
        foreach (DictionaryEntry entry in userInfo)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
            
        }
    }
}

using System.Collections;

namespace DictionaryAndHashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Using Dictionary
            Dictionary<int, string> studentRecords = new Dictionary<int, string>();
           

            // Adding records
            studentRecords.Add(101, "Alice");
            studentRecords.Add(102, "Bob");

            string studentName1 = studentRecords[101]; 
            string studentName2 = studentRecords[102]; 


            // Accessing a record
            Console.WriteLine("Student ID 101: " + studentRecords[101]);

            // Removing a record
            studentRecords.Remove(102);


            foreach (KeyValuePair<int, string> record in studentRecords)
            {
                Console.WriteLine($"ID: {record.Key}, Name: {record.Value}");
            }











            // Using  Hashtable
            Hashtable userInfo = new Hashtable();
             
             // Adding different types of keys and values
             userInfo.Add("username", "Alice");         
             userInfo.Add("userId", 123);                
             userInfo.Add("isActive", true);             
             userInfo.Add("age", 25);

            int userId = (int)userInfo["userId"];  
            bool isActive =(bool)userInfo["isActive"]; 
            int age = (int)userInfo["age"];

            // Accessing values
            Console.WriteLine("Username: " + userInfo["username"]);  
             Console.WriteLine("User ID: " + userInfo["userId"]);     
             Console.WriteLine("Is Active: " + userInfo["isActive"]);  
             Console.WriteLine("Age: " + userInfo["age"]);            
             
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
}

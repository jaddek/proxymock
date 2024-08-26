// using System.IO;  // include the System.IO namespace
// Console.WriteLine("adad");

// List<int> l = new([1, 2, 3, 5]);

// foreach (int i in l)
// {
//     Console.WriteLine(i);
// }



// string writeText = "Hello World!";  // Create a text string
// File.WriteAllText("filename.txt", writeText);  // Create a file and write the content of writeText to it

// string readText = File.ReadAllText("filename.txt");  // Read the contents of the file
// Console.WriteLine(readText);  // Output the content


StringBuilder sb = new StringBuilder("ABC", 50);

// Append three characters (D, E, and F) to the end of the StringBuilder.
sb.Append(new char[] { 'D', 'E', 'F' });

// Append a format string to the end of the StringBuilder.
sb.AppendFormat("GHI{0}{1}", 'J', 'k');

// Display the number of characters in the StringBuilder and its string.
Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());

// Insert a string at the beginning of the StringBuilder.
sb.Insert(0, "Alphabet: ");

// Replace all lowercase k's with uppercase K's.
sb.Replace('k', 'K');

// Display the number of characters in the StringBuilder and its string.
Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());
// See https://aka.ms/new-console-template for more information

using (var sw = new StreamReader("../../../input.txt"))
{
	var data = sw.ReadToEnd();
	Console.WriteLine(data);
}

Console.WriteLine("Hello, World!");
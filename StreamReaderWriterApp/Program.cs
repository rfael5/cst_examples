using (StreamWriter writer = File.CreateText("reminder.txt"))
{
    writer.WriteLine("Don't forget Mother's day this year");
    writer.WriteLine("Don't forget Father's day this year");
    writer.WriteLine("Don't forget these numbers: ");
    for(var x = 0; x <= 10; x++)
    {
        writer.Write($"{x}, ");
    }
}

using (StreamReader reader = File.OpenText("reminder.txt"))
{
    string input = null;
    while((input = reader.ReadLine()) != null)
    {
        Console.WriteLine(input);
    }
}
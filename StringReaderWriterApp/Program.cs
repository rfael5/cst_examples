using System.Text;

StringBuilder sb;
using(var writer = new StringWriter())
{
    writer.Write("Don't forget Mother's Day this year!");
    sb = writer.GetStringBuilder();
    sb.Insert(0, "Hey!! ");
    using(var reader = new StringReader(sb.ToString()))
    {
        string input = null;
        while((input = reader.ReadLine()) != null)
        {
            Console.WriteLine(input);
        }        
    }
}

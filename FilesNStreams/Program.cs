using System.Xml;

string xmlContent = "<message><text>Hello</text><recipient>world</recipient></message>";

var xmlReader = XmlReader.Create(new StringReader(xmlContent));

JsonExamples.TestSerializer();

// while(xmlReader.Read())
// {
//     if(xmlReader.NodeType == XmlNodeType.Text)
//     {
//         Console.WriteLine(xmlReader.Value);
//     }
// }

// using var fr = new StreamReader(@"C:\Users\serverteste\Desktop\MEDIAS.txt");
// Console.WriteLine(fr.ReadToEnd());

// using var fw = new StreamWriter(@"C:\Users\serverteste\Desktop\MEDIAS.txt", true);
// fw.WriteLine("TESTE");
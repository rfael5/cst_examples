FileInfo file = new FileInfo("binFile.dat");

using(BinaryWriter bw = new BinaryWriter(file.OpenWrite()))
{
    Console.WriteLine("Content {0}", bw.BaseStream);

    var aDouble = 2.5;
    var aInt = 5;
    var aString = "abc";

    bw.Write(aDouble);
    bw.Write(aInt);
    bw.Write(aString);
}

using(BinaryReader br = new BinaryReader(file.OpenRead()))
{
    Console.WriteLine(br.ReadDouble());
    Console.WriteLine(br.ReadInt32());
    Console.WriteLine(br.ReadString());
}
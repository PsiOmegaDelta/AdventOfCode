using System.Text;

const string input = "bgvyzdsv";
Console.WriteLine("2015 - Day 4");
Console.WriteLine("Part One: " + Enumerable.Range(0, int.MaxValue).Select(x => (Answer: x, MD5: CreateMD5(input + x))).First(x => x.MD5.StartsWith("00000")).Answer);
Console.WriteLine("Part Two: " + Enumerable.Range(0, int.MaxValue).Select(x => (Answer: x, MD5: CreateMD5(input + x))).First(x => x.MD5.StartsWith("000000")).Answer);

static string CreateMD5(string input)
{
    using System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
    byte[] inputBytes = Encoding.ASCII.GetBytes(input);
    byte[] hashBytes = md5.ComputeHash(inputBytes);

    var sb = new StringBuilder();
    for (int i = 0; i < hashBytes.Length; i++)
    {
        sb.Append(hashBytes[i].ToString("X2"));
    }

    return sb.ToString();
}

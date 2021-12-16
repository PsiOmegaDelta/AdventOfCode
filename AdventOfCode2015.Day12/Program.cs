using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

Console.WriteLine("2015 - Day 12");
const string inputPath = "Day12Input.txt";

var numberRegex = new Regex(@"(-{0,1}\d+)", RegexOptions.Compiled);
Console.WriteLine("Part One: " + File.ReadLines(inputPath).SelectMany(x => numberRegex.Matches(x).Select(x => int.Parse(x.Value))).Sum());
Console.WriteLine("Part Two: " + ProcessNode(JsonNode.Parse(File.ReadAllText(inputPath))));

static int ProcessNode(JsonNode? node)
{
    if (node is JsonArray array)
    {
        return ProcessArray(array);
    }
    else if (node is JsonObject jobject)
    {
        return ProcessObject(jobject);
    }
    else if (node is JsonValue jvalue)
    {
        return ProcessValue(jvalue);
    }

    throw new ArgumentException(null, nameof(node));
}

static int ProcessArray(JsonArray array)
{
    return array.Sum(x => ProcessNode(x));
}

static int ProcessValue(JsonValue value)
{
    return int.TryParse(value.ToString(), out var number) ? number : 0;
}

static int ProcessObject(JsonObject jobject)
{
    foreach (var (_, node) in jobject)
    {
        if (node is not JsonValue value)
        {
            continue;
        }

        if (value.ToString() == "red")
        {
            return 0;
        }
    }

    return jobject.Sum(property => ProcessNode(property.Value));
}

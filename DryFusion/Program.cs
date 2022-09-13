using System.Text;

var file = @"weather.dat";
Console.WriteLine(File.Exists(file)
    ? $"The day with the minimum span is day {GetMinSpan(File.ReadLines(file, Encoding.UTF8).Skip(2).Take(30), 1, 2, 0)}"
    : "{file} doesn't exist.");

file = @"football.dat";
Console.WriteLine(File.Exists(file)
    ? $"The team with the minimum span is {GetMinSpan(File.ReadLines(file, Encoding.UTF8).Skip(1).Where(x => !x.Contains("---")), 6, 8, 1)}"
    : "{file} doesn't exist.");

static (int, string) GetSpanValue(IReadOnlyList<string> line, int maxIndex, int minIndex, int valueIndex) =>
    (Math.Abs(int.Parse(line[maxIndex][..2]) - int.Parse(line[minIndex][..2])), line[valueIndex]);

string GetMinSpan(IEnumerable<string> inputFileData, int maxIndex, int minIndex, int valueIndex) =>
    inputFileData.Select(line =>
        GetSpanValue(line.Split(' ', StringSplitOptions.RemoveEmptyEntries), maxIndex, minIndex, valueIndex)).MinBy(t => t.Item1).Item2;
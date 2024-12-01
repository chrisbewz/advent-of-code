using DayOne;
using DayOne.Helpers;

string[] contents = IoHelpers.ReadInput(@"Shared/Assets/2024/day_1_1.txt");

#region Part One

IList<InputEntry> readEntries = contents.AsEnumerable()
                                        .Select(s => s.Split("   "))
                                        .Select(splitted => (List<int>)[int.Parse(splitted[0]), int.Parse(splitted[1])])
                                        .Select(splitted => new InputEntry(splitted.First(),splitted.Last()))
                                        .ToList();

List<int> leftOrdered = readEntries.Select(entry => entry.Left).OrderBy(e => e).ToList();
List<int> rightOrdered = readEntries.Select(entry => entry.Right).OrderBy(e => e).ToList();

List<InputEntry> inputEntriesOrdered = leftOrdered.Zip(rightOrdered, (left, right) => new InputEntry(left,right))
                                                  .ToList();
int totalDistance = inputEntriesOrdered.Aggregate(0, (current, entry) => current + Math.Abs(entry.Left - entry.Right));
#endregion

#region Part Two
        
IEnumerable<IGrouping<int, int>> grouped = rightOrdered.GroupBy(@gp => @gp).ToList();

int totalSimilarity = inputEntriesOrdered.Select(entry =>
{
    int similarity = 0;
            
    if(!grouped.Any(gp => gp.Key == entry.Left))
        return similarity;
            
    int gpCount = grouped.First(g => g.Key == entry.Left).Count();
            
    similarity = entry.Left * gpCount;
    return similarity;
}).Sum();

#endregion
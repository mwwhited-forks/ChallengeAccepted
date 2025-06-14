namespace ProcedualGeneration.Map.Cli;

internal class Program
{
    static void Main(string[] args)
    {
        var graph = GetGraph();

        var seed = 0;
        var before = Console.BackgroundColor;

        do
        {
            Console.Clear();
            Console.BackgroundColor = before;
            Console.WriteLine(seed);
            Console.WriteLine(new string('-', Console.WindowWidth));

            var rand = new Random(seed);

            var map = new NodeItem[Math.Max(Console.WindowWidth-1, 0), Math.Max(Console.WindowHeight-3, 0)];
            var width = map.GetLength(0);
            var height = map.GetLength(1);


            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var kernel = new NodeItem[]{
                    map[(x + width - 1) % width, (y + height - 1) % height],
                    map[(x + width + 0) % width, (y + height - 1) % height],
                    map[(x + width + 1) % width, (y + height - 1) % height],
                    map[(x + width - 1) % width, (y + height + 0) % height],
                    map[(x + width + 0) % width, (y + height + 0) % height],
                    map[(x + width + 1) % width, (y + height + 0) % height],
                    map[(x + width - 1) % width, (y + height + 1) % height],
                    map[(x + width + 0) % width, (y + height + 1) % height],
                    map[(x + width + 1) % width, (y + height + 1) % height],
                }.Where(i => i != null).ToArray();
                    if (kernel.Length == 0) kernel = [graph];
                    var values = kernel.SelectMany(i => i.Items).ToArray();
                    var total = values.Sum(i => i.Value);
                    var target = rand.NextSingle() * total;
                    var result = values.Last().Key;
                    foreach (var item in values)
                    {
                        target -= item.Value;
                        if (target < 0)
                        {
                            result = item.Key;
                            break;
                        }
                    }

                    map[x, y] = result;
                    Console.BackgroundColor = result.Name[0] switch
                    {
                        'l' => ConsoleColor.DarkGreen,
                        'b' => ConsoleColor.Blue,
                        'w' => ConsoleColor.DarkBlue,
                        'r' => ConsoleColor.DarkGray,
                        'c' => ConsoleColor.Gray,
                        'h' => ConsoleColor.Green,
                    };
                    Console.Write(' '); // result.Name[0]
                }
                Console.WriteLine(); 
            }
            seed++;
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
        Console.BackgroundColor = before;
    }

    public static NodeItem GetGraph()
    {
        var start = new NodeItem() { Name = "start" };
        var land = new NodeItem() { Name = "land" };
        var beach = new NodeItem() { Name = "beach" };
        var water = new NodeItem() { Name = "water" };
        var road = new NodeItem() { Name = "road" };
        var cliff = new NodeItem() { Name = "cliff" };
        var hill = new NodeItem() { Name = "hill" };

        start.Items.Add(land, 1.00f);
        start.Items.Add(beach, 1.00f);
        start.Items.Add(water, 1.00f);
        start.Items.Add(road, 0.25f);
        start.Items.Add(cliff, 0.25f);
        start.Items.Add(hill, 1.00f);

        land.Items.Add(land, 0.80f);
        land.Items.Add(beach, 0.15f);
        land.Items.Add(water, 0.05f);
        land.Items.Add(road, 0.35f);
        land.Items.Add(cliff, 0.35f);
        land.Items.Add(hill, 0.35f);

        beach.Items.Add(land, 0.15f);
        beach.Items.Add(beach, 0.10f);
        beach.Items.Add(water, 0.50f);

        water.Items.Add(beach, 0.15f);
        water.Items.Add(land, 0.15f);
        water.Items.Add(water, 0.75f);

        road.Items.Add(hill, 0.15f);
        road.Items.Add(land, 0.15f);
        road.Items.Add(road, 0.75f);

        cliff.Items.Add(hill, 0.50f);
        cliff.Items.Add(land, 0.50f);

        hill.Items.Add(hill, 0.50f);
        hill.Items.Add(land, 0.85f);

        return start;
    }
}

public record NodeItem
{
    public string Name { get; init; }
    public Dictionary<NodeItem, float> Items { get; } = [];

    public override string ToString() => $"{Name}";
}
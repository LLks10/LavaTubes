var field = Field.CreateFromFile("../../../input.txt");

int count = 0;

for(int y = 0; y < field.Height; y++)
{
	for(int x = 0; x < field.Height; x++)
	{
		char curr = field[x, y];
		if (curr < field.GetBounded(x + 1, y) &&
			curr < field.GetBounded(x - 1, y) &&
			curr < field.GetBounded(x, y + 1) &&
			curr < field.GetBounded(x, y - 1))
		{
			count += curr.GetValue() + 1;
		}
	}
}

Console.WriteLine(count);

class Field
{
	const char BOUNDARY = (char)('9' + 1);
	private IReadOnlyList<char> field;

	private Field(List<char> field, int width)
	{
		this.field = field;
		Width = width;
		Height = field.Count/width;
	}

	public int Width { get; init; }
	public int Height { get; init; }

	public static Field CreateFromFile(string filename)
	{
		using var sr = new StreamReader(filename);

		var field = new List<char>();
		var line = sr.ReadLine();
		if (line is null)
			return new Field(field, 0);

		int width = line.Length;

		while(line is not null)
		{ 
			field.AddRange(line); 
			line = sr.ReadLine();
		}

		return new Field(field, width);
	}

	public char this[int x, int y] => field[x + y * Width];

	public bool InBounds(int x, int y) => 
		x >= 0 && y >= 0 && x < Width && y < Height;

	public char GetBounded(int x, int y)
	{
		if (!InBounds(x, y))
			return BOUNDARY;

		return this[x, y];
	}
}

static class CharExtensions
{
	public static int GetValue(this char c) => c - '0';
}

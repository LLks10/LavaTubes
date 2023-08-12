namespace LavaTubes;

sealed class Field
{
	const char BOUNDARY = (char)('9' + 1);
	private readonly List<char> field;

	private Field(List<char> field, int width)
	{
		this.field = field;
		Width = width;
		Height = field.Count / width;
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

		while (line is not null)
		{
			field.AddRange(line);
			line = sr.ReadLine();
		}

		return new Field(field, width);
	}

	public char this[int x, int y]
	{
		get => field [x + y * Width];
		set => field[x + y * Width] = value;
	} 

	public bool InBounds(int x, int y) =>
		x >= 0 && y >= 0 && x < Width && y < Height;

	public char GetBounded(int x, int y)
	{
		if (InBounds(x, y))
			return this[x, y];

		return BOUNDARY;
	}
}
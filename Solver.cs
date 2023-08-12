namespace LavaTubes;

class PartASolver
{
	public static int CalculateRiskLevel(in Field field)
	{
		int count = 0;

		for (int y = 0; y < field.Height; y++)
			for (int x = 0; x < field.Height; x++)
			{
				char curr = field[x, y];
				if (curr < field.GetBounded(x + 1, y) &&
					curr < field.GetBounded(x - 1, y) &&
					curr < field.GetBounded(x, y + 1) &&
					curr < field.GetBounded(x, y - 1))
				{
					count += curr - '0' + 1;
					
					x++; // Two adjacent lowpoints is impossible
				}
			}

		return count;
	}
}

class PartBSolver
{
	const char WALL = '9';

	Field field;
	int smallestSize = 0;
	int smallestIdx = 0;
	int[] basinSizes = new int[3];

	private PartBSolver(Field field)
	{
		this.field = field;
	}

	public static (int, int, int) GetThreeBiggestBasinSizes(Field field) => new PartBSolver(field).Solve();

	private (int, int, int) Solve()
	{
		for (int y = 0; y < field.Height; y++)
			for (int x = 0; x < field.Width; x++)
			{
				if (field[x, y] == WALL)
					continue;

				int basinSize = FillBasin(x, y);
				InsertBasin(basinSize);

				x++; // Two adjacent basins is impossible
			}

		return (basinSizes[0], basinSizes[1], basinSizes[2]);
	}

	private int FillBasin(int x, int y)
	{
		field[x, y] = WALL;
		int size = 1;

		if (field.InBounds(x + 1, y) && field[x + 1, y] != WALL)
			size += FillBasin(x + 1, y);

		if (field.InBounds(x - 1, y) && field[x - 1, y] != WALL)
			size += FillBasin(x - 1, y);

		if (field.InBounds(x, y + 1) && field[x, y + 1] != WALL)
			size += FillBasin(x, y + 1);

		if (field.InBounds(x, y - 1) && field[x, y - 1] != WALL)
			size += FillBasin(x, y - 1);

		return size;
	}

	private void InsertBasin(int size)
	{
		if (size < smallestSize)
			return;

		basinSizes[smallestIdx] = size;

		// Calculate new smallest basin
		smallestSize = int.MaxValue;

		for (int i = 0; i < basinSizes.Length; i++)
			if (basinSizes[i] < smallestSize)
			{
				smallestSize = basinSizes[i];
				smallestIdx = i;
			}
	}
}
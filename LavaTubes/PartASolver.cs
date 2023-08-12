namespace LavaTubes;

static internal class PartASolver
{
	public static int CalculateRiskLevel(in Field field)
	{
		int count = 0;

		for (int y = 0; y < field.Height; y++)
			for (int x = 0; x < field.Width; x++)
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
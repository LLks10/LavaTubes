using System.Globalization;

namespace LavaTubes;

sealed class Solver
{
	public static int CalculateRiskLevel(Field field)
	{
		int count = 0;

		for (int y = 0; y < field.Height; y++)
		{
			for (int x = 0; x < field.Height; x++)
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

		return count;
	}
}

static class CharExtensions
{
	public static int GetValue(this char c) => c - '0';
}

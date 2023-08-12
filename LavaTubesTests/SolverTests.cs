using FluentAssertions;
using LavaTubes;

namespace LavaTubesTests;

public class SolverTests
{
	const string filePrefix = "../../../SolverTestCases/";

	[Theory]
	[InlineData("empty_risk0_basin0.txt", 0)]
	[InlineData("line_risk6_basin27.txt", 6)]
	[InlineData("square_risk18_basin80.txt", 18)]
	public void CalculateRiskLevel_ShouldReturnCorrectRisklevel(string filename, int expectedRisklevel)
	{
		var field = Field.CreateFromFile(filePrefix + filename);

		int riskLevel = PartASolver.CalculateRiskLevel(field);

		riskLevel.Should().Be(expectedRisklevel);
	}

	[Theory]
	[InlineData("empty_risk0_basin0.txt", 0)]
	[InlineData("line_risk6_basin27.txt", 27)]
	[InlineData("square_risk18_basin80.txt", 80)]
	public void GetThreeBiggestBasinSizes_ShouldReturnCorrectBasinSizes(string filename, int expectedBasinSize)
	{
		var field = Field.CreateFromFile(filePrefix + filename);

		(int, int, int) basinSizes = PartBSolver.GetThreeBiggestBasinSizes(field);

		int basinSize = basinSizes.Item1 * basinSizes.Item2 * basinSizes.Item3;

		basinSize.Should().Be(expectedBasinSize);
	}
}
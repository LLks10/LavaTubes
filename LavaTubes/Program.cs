using LavaTubes;

var field = Field.CreateFromFile("../../../input.txt");

int riskLevelSum = PartASolver.CalculateRiskLevel(field);

var basinSizes = PartBSolver.GetThreeBiggestBasinSizes(field);

Console.WriteLine($"Risk level: {riskLevelSum}");
Console.WriteLine($"Basin size: {basinSizes.Item1 * basinSizes.Item2 * basinSizes.Item3}");
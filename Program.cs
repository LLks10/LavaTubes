using LavaTubes;

var field = Field.CreateFromFile("../../../input.txt");

int riskLevelSum = Solver.CalculateRiskLevel(field);

Console.WriteLine($"Risk level: {riskLevelSum}");
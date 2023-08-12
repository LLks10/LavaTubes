using FluentAssertions;
using LavaTubes;

namespace LavaTubesTests;

public class FieldTests
{
	const string TestFieldFile = "../../../testField.txt";

	[Fact]
	public void CreateFromFile_ShouldParseFileCorrectly()
	{
		var field = Field.CreateFromFile(TestFieldFile);

		field[0, 0].Should().Be('1');
		field[1, 0].Should().Be('2');
		field[0, 1].Should().Be('3');
		field[1, 1].Should().Be('4');
		field[0, 2].Should().Be('5');
		field[1, 2].Should().Be('6');
	}

	[Fact]
	public void GetBounded_ShouldReturnSentinalValue_WhenOutOfBounds()
	{
		var field = Field.CreateFromFile(TestFieldFile);

		field.GetBounded(2, 0).Should().BeGreaterThan('9');
	}

	[Fact]
	public void GetBounded_ShouldReturnValue_WhenInOfBounds()
	{
		var field = Field.CreateFromFile(TestFieldFile);

		field.GetBounded(0, 0).Should().Be('1');
	}

	[Fact]
	public void InBounds_ShouldReturnTrue_WhenInBounds()
	{
		var field = Field.CreateFromFile(TestFieldFile);

		field.InBounds(0, 0).Should().BeTrue();
	}

	[Fact]
	public void InBounds_ShouldReturnFalse_WhenOutOfBounds()
	{
		var field = Field.CreateFromFile(TestFieldFile);

		field.InBounds(0, 4).Should().BeFalse();
	}

	[Fact]
	public void WidthHeight_ShouldEqualDimensionsOfField()
	{
		var field = Field.CreateFromFile(TestFieldFile);

		field.Width.Should().Be(2);
		field.Height.Should().Be(3);
	}

	[Fact]
	public void Setter_ShouldChangeValueOfField()
	{
		var field = Field.CreateFromFile(TestFieldFile);

		const char a = 'a';
		field[0, 0] = a;

		field[0, 0].Should().Be(a);
	}
}
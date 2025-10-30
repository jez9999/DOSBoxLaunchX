using System.Linq;
using NUnit.Framework;
using AwesomeAssertions;
using DOSBoxLaunchX.Logic.DosboxParsing;

namespace DOSBoxLaunchX.Tests.TestDosboxConfFile;

[TestFixture]
public class Comment_and_malformed_line_tests {
	[Test]
	public void Lines_starting_with_hash_are_comment_lines() {
		// Arrange
		string text = "# this is a comment";

		// Act
		var file = DosboxConfFile.FromText(text);
		var line = file.Lines[0];

		// Assert
		line.Should().BeOfType<CommentLine>().Which.Should().BeEquivalentTo(new {
			Comment = " this is a comment",
			RawText = "# this is a comment"
		});
	}

	[Test]
	public void Lines_starting_with_semicolon_are_not_comments() {
		// Arrange
		string text = "; this should not be a comment";

		// Act
		var file = DosboxConfFile.FromText(text);
		var line = file.Lines[0];

		// Assert
		line.Should().NotBeOfType<CommentLine>();
		line.RawText.Should().Be("; this should not be a comment");
	}

	[Test]
	public void Blank_lines_are_interpreted_correctly() {
		// Arrange
		string text = "\n   \n";

		// Act
		var file = DosboxConfFile.FromText(text);
		var lines = file.Lines.ToList();

		// Assert
		lines.Should().HaveCount(3);
		lines.All(l => l is CommentLine).Should().BeTrue();
		lines.Should().BeEquivalentTo([
			new { Comment = string.Empty, RawText = string.Empty },
			new { Comment = string.Empty, RawText = "   " },
			new { Comment = string.Empty, RawText = string.Empty }
		], options => options.WithStrictOrdering());
	}

	[Test]
	public void Malformed_section_header_without_closing_bracket_is_malformed_line() {
		// Arrange
		string text = "[abc";

		// Act
		var file = DosboxConfFile.FromText(text);
		var line = file.Lines[0];

		// Assert
		line.Should().BeOfType<MalformedLine>().Which.RawText.Should().Be("[abc");
	}

	[Test]
	public void Comment_with_leading_whitespace_is_detected() {
		// Arrange
		string text = "   # spaced comment";

		// Act
		var file = DosboxConfFile.FromText(text);
		var line = file.Lines[0];

		// Assert
		line.Should().BeOfType<CommentLine>().Which.Should().BeEquivalentTo(new {
			Comment = " spaced comment",
			RawText = "   # spaced comment"
		});
	}
}

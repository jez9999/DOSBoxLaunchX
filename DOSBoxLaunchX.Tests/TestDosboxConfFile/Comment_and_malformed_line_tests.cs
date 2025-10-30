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
		line.Should().BeOfType<CommentLine>();
		line.As<CommentLine>().Comment.Should().Be(" this is a comment");
		line.As<CommentLine>().RawText.Should().Be("# this is a comment");
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
		lines.Count.Should().Be(3);
		lines[0].Should().BeOfType<CommentLine>();
		lines[1].Should().BeOfType<CommentLine>();
		lines[2].Should().BeOfType<CommentLine>();
		lines[0].RawText.Should().Be(string.Empty);
		lines[1].RawText.Should().Be("   ");
		lines[2].RawText.Should().Be(string.Empty);
	}

	[Test]
	public void Malformed_section_header_without_closing_bracket_is_malformed_line() {
		// Arrange
		string text = "[abc";

		// Act
		var file = DosboxConfFile.FromText(text);
		var line = file.Lines[0];

		// Assert
		line.Should().BeOfType<MalformedLine>();
		line.As<MalformedLine>().RawText.Should().Be("[abc");
	}

	[Test]
	public void Comment_with_leading_whitespace_is_detected() {
		// Arrange
		string text = "   # spaced comment";

		// Act
		var file = DosboxConfFile.FromText(text);
		var line = file.Lines[0];

		// Assert
		line.Should().BeOfType<CommentLine>();
		line.As<CommentLine>().Comment.Should().Be(" spaced comment");
		line.As<CommentLine>().RawText.Should().Be("   # spaced comment");
	}
}

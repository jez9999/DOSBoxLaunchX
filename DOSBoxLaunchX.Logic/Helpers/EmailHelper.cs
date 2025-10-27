namespace DOSBoxLaunchX.Logic.Helpers;

public class EmailHelper {
	/// <summary>
	/// Checks whether the provided e-mail address is in a valid format (as specified by RFC 822).
	/// </summary>
	/// <param name="emailAddress">The e-mail address to check.</param>
	/// <returns>True if valid, otherwise false.</returns>
	public static bool EmailIsValid(string emailAddress) {
		// Code by Jeremy Morton, 2010-09-30
		// Last update: 2015-11-01

		// If this e-mail address validity check fails, an error message should be given, along the lines of:
		// "Invalid e-mail address format (must be similar to user@domain.com)"
		string reEmailAddressPattern = @"
			^			# RFC 822 says e-mail addys consist of any CHAR except specials, SPACE and CTLs.
						# We also have the @ and . to seperate user or hostnames.
						# CHAR is ASCII 0-127(0x00-7F).  SPACE is ASCII 32(0x20).
						# CTLs are ASCII 0-31(0x00-1F) and 127(0x7F).  Specials are ( ) < > @ , ; : \ "" . [ ]
						# ASCII 127(0x7F) is a DEL control character - prudent to disallow this in an e-mail address.
			[^\x7F\x80-\xFF\x00-\x20\(\)\<\>\@\,\;\:\\\""\[\]]+
						# ^ Username... even '(.)@host.com' is ok.
			\@
						# ^ @
			[^\x7F\x80-\xFF\x00-\x20\(\)\<\>\@\,\;\:\\\""\[\]\.]+
						# ^ Host part 1 (no dots yet): 'blah@(host).com.com'.
			\.
						# ^ .
			[^\x7F\x80-\xFF\x00-\x20\(\)\<\>\@\,\;\:\\\""\[\]\.]+
			[^\x7F\x80-\xFF\x00-\x20\(\)\<\>\@\,\;\:\\\""\[\]]*
						# ^ Host part 2 (remaining dots allowed): 'blah@host.(com.com)'.
			$
		";

		Regex reEmailAddress = new(reEmailAddressPattern, RegexOptions.IgnorePatternWhitespace);

		// Maximum length of an e-mail address is 254 characters owing to path length limitation of 256 minus the two chevron parentheses; see:
		// RFC 821: 4.1.2. COMMAND SYNTAX
		// Note that the "a-d-l" (at-domain-list) syntax as part of the path is obsolete and should just be left out, leaving the path as <user@domain>
		return emailAddress != null && emailAddress.Length <= 254 && reEmailAddress.IsMatch(emailAddress);
	}
}

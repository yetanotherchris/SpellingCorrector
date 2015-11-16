using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SpellingCorrector.Tests
{
    public class SpellingTests
    {
	    private string _dictionary;

		[TestFixtureSetUp]
	    public void TestFixtureSetUp()
	    {
			// Note: tests are dependent on the words in this dictionary file
			// that Peter Norvig originally provided as a proof of concept, it 
			// is not meant to be used a proper dictionary as it's just a Sherlock Holmes book.
			_dictionary = File.ReadAllText("big.txt");
		}

		[Test]
		[TestCase("speling", "spelling")]
		[TestCase("acess", "access")]
		[TestCase("supposidly", "supposedly")]
		public void should_correct_single_words(string mispelled, string expected)
		{
			// Arrange
			var spelling = new Spelling(_dictionary);

			// Act
			string actual = spelling.Correct(mispelled);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		[TestCase("I HAVEE Gowt thisse WrnG", "i have got this wrong")]
		public void should_lower_case_sentence_correction(string mispelled, string expected)
		{
			// Arrange
			string dictionary = File.ReadAllText("big.txt");
			var spelling = new Spelling(dictionary);

			// Act
			string actual = spelling.CorrectSentence(mispelled);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		[TestCase("I havve wrtten somm woordz wwrong", "i have written some words wrong")]
		public void should_correct_sentences(string mispelled, string expected)
		{
			// Arrange
			string dictionary = File.ReadAllText("big.txt");
			var spelling = new Spelling(dictionary);

			// Act
			string actual = spelling.CorrectSentence(mispelled);

			// Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
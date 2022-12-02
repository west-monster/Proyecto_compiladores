using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Text.RegularExpressions;

public class TunedLSys : MonoBehaviour
{
	public TunedRule[] rules;
	public string rootSentence;
	[Range(0, 10)]
	public int iterationLimit = 1;

	private TunedRule[] CreationArray(Dictionary<string, string> ParsedText)
    {
		List<TunedRule> TempCreate = new List<TunedRule>();
		if (ParsedText["Begin"] == "AUTODUNE")
        {
            switch (ParsedText["Difficult"])
            {
				case "Easy":
					Debug.Log("EnterEASY");
					rootSentence = "A";
					iterationLimit = 3;
					TunedRule a = new TunedRule("A", new string[] { "[A+B]-A" , "[A-]" });
					TunedRule b = new TunedRule("B", new string[] { "--A" , "[B--]B" });
					rules = new TunedRule[] { a , b };
					break;

				case "Medium":
					Debug.Log("EnterMEDIUM");
					rootSentence = "A";
					iterationLimit = 4;
					TunedRule c = new TunedRule("A", new string[] { "[[A+B]-A]", "[BA]-A" });
					TunedRule d = new TunedRule("B", new string[] { "[-A]+A" });
					rules = new TunedRule[] { c, d };
					break;

				case "Hard":
					Debug.Log("EnterHARD");
					rootSentence = "[F]--F";
					iterationLimit = 4;
					TunedRule e = new TunedRule("F", new string[] { "[+FF]F" , "[-F]F[+F]" });
					rules = new TunedRule[] { e };
					break;

				default:
					Debug.Log("Unknown difficuly for dungeon, type help for help");
					break;
			}

			
			return rules;
        }
        else
        {
			foreach (var entry in ParsedText)
			{

				if (new Regex(@"rule[0-9]+").IsMatch(entry.Key))
				{
					string[] TypeSeparator = (entry.Value).Split(':');
					string[] RuleSeparator = (TypeSeparator[1]).Split(',');

					TempCreate.Add(new TunedRule(TypeSeparator[0], RuleSeparator));
				}

			}
			iterationLimit = int.Parse(ParsedText["Generations"]);
			rootSentence = ParsedText["Axiom"];
			rules = TempCreate.ToArray();
			return rules;
		}
		
    }

	private void Start()
	{
		//TunedRule a = new TunedRule("F", new string[] { "[+FF]F-" });
		//TunedRule b = new TunedRule("B", new string[] { "A" });

		//rules = new TunedRule[] { a };
	
        try
        {
			rules = CreationArray(MainMenu.ParsingText);
			Debug.Log(GenerateSentence());
			DebugConsole.currentText = "Correct";
		}
        catch
        {
            try {
				if (MainMenu.ParsingText.Count < 1)
				{
					DebugConsole.currentText = "Unknown";
				}
			}
            catch
            {

            }

		}


		
	}

	public string GenerateSentence(string word = null)
	{
		if (word == null)
		{
			word = rootSentence;
		}
		return GrowRecursive(word);
	}

	private string GrowRecursive(string word, int iterationIndex = 0)
	{
		//Debug.Log(string.Format("The current word is {0} .",word)); 

		if (iterationIndex >= iterationLimit)
		{
			return word;
		}
		StringBuilder newWord = new StringBuilder();

		foreach (var c in word)
		{
			newWord.Append(c);
			ProcessRulesRecursivelly(newWord, c, iterationIndex);
		}

		return newWord.ToString();
	}

	private void ProcessRulesRecursivelly(StringBuilder newWord, char c, int iterationIndex)
	{
		foreach (var rule in rules)
		{
			if (rule.letter == c.ToString())
			{

				newWord.Append(GrowRecursive(rule.GetResult(), iterationIndex + 1));

			}

		}
	}
}

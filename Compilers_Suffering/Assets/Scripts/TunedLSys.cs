using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class TunedLSys : MonoBehaviour
{
	public Rule[] rules;
	public string rootSentence;
	[Range(0, 10)]
	public int iterationLimit = 1;

	private void Start()
	{
		Debug.Log(GenerateSentence());
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
		Debug.Log(string.Format("The current word is {0} .",word)); 

		if (iterationIndex >= iterationLimit)
		{
			return word;
		}
		StringBuilder newWord = new StringBuilder();

		foreach (var c in word)
		{
			//newWord.Append(c);
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

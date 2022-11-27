using System.Text;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class LsystemGenv2 : MonoBehaviour
{
	RuleV2 myrule = new RuleV2();
	public string rootSentence;
	[Range(0, 10)]
	public int iterationLimit = 1;

	public bool randomIgnoreRuleModifier = true;
	[Range(0, 1)]
	public float chanceToIgnoreRule = 0.3f;

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
		
			if (myrule.letter == c.ToString())
			{

				newWord.Append(GrowRecursive(myrule.GetResult(), iterationIndex + 1));

			}


	}
}


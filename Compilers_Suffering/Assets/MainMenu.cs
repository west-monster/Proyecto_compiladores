using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;


public class MainMenu : MonoBehaviour
{
    public GameObject inputxd;
	public static Dictionary<string,string> ParsingText;
    public void Generate()
    {
		
		string Godmode = inputxd.GetComponent<InputField>().text;

		var text = Godmode; //asignación
		//var text = System.IO.File.ReadAllText("b.txt");
		Debug.Log(text);
		var stream = CharStreams.fromString(text);
		var lexer = new DUNLexer(stream);
		var tokens = new CommonTokenStream(lexer);
		var parser = new DUNParser(tokens) { BuildParseTree = true };

		var parseTree = parser.file();
		var listener = new TestListener();
		ParseTreeWalker.Default.Walk(listener, parseTree);
		var myDictionary = listener.getter();

		foreach (var entry in myDictionary)
		{
			// do something with entry.Value or entry.Key
			Debug.Log("Hola : " + entry.Value);
		}

		ParsingText = myDictionary;

		SceneManager.LoadScene(2);
	}

}


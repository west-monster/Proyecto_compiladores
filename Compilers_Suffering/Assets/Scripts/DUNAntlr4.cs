using UnityEngine;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Collections;
using System.Collections;
using System.Collections.Generic;



public class DUNAntlr4 : MonoBehaviour
{
	public string Name = "world";


	void Start()
	{

		//var text = "Hello9=991 \n hello8=9"; //asignación
		var text = System.IO.File.ReadAllText("b.txt");
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
			Debug.Log("Hola : " +  entry.Key);
		}

	}

}

public sealed class TestListener : DUNBaseListener
{
		
	public Dictionary<string, string> assigments = new Dictionary<string, string>();



	public override void EnterAssignment(DUNParser.AssignmentContext context)
		{
		// Error handling omitted for brevity.
		// Debug.Log("ADD ELEMENT");
		// Debug.Log(context);
		//var identifier = context.Identifier().GetText();
		//var value = (context.Number().GetText());
		//var beg = context.Begin().GetText();
		var dune = context.Begin().GetText();
		var axiom = context.Axiom().GetText();
		var gen = context.Gen().GetText();
		for (int i = 0; i < context.Rol().Length; i++)
        {
			string name = "rule" + i;
			assigments.Add(name, context.Rol(i).GetText());
		}
		assigments.Add("Begin", dune);
		assigments.Add("Generations", gen);
		assigments.Add("Axiom", axiom);


	}

	public Dictionary<string, string> getter()
    {
		return assigments; 
    }

}





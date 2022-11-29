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
	}

	public sealed class TestListener : DUNBaseListener
	{
		public Dictionary<string, int> Assigments = new Dictionary<string, int>();


		public override void EnterAssignment(DUNParser.AssignmentContext context)
		{
			// Error handling omitted for brevity.
			Debug.Log("ADD ELEMENT");
			Debug.Log(context);
			var identifier = context.Identifier().GetText();
			var value = int.Parse(context.Number().GetText());
			Debug.Log(identifier);
			Debug.Log(value);

			Assigments.Add(identifier, value);
			Debug.Log(Assigments.Keys);
		}

	}


}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Hello.g4 by ANTLR 4.11.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.11.1")]
[System.CLSCompliant(false)]
public partial class HelloParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, ID=2, WS=3;
	public const int
		RULE_r = 0;
	public static readonly string[] ruleNames = {
		"r"
	};

	private static readonly string[] _LiteralNames = {
		null, "'hello'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, "ID", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Hello.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static HelloParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public HelloParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public HelloParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class RContext : ParserRuleContext {
		public IToken _ID;
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(HelloParser.ID, 0); }
		public RContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_r; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IHelloListener typedListener = listener as IHelloListener;
			if (typedListener != null) typedListener.EnterR(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IHelloListener typedListener = listener as IHelloListener;
			if (typedListener != null) typedListener.ExitR(this);
		}
	}

	[RuleVersion(0)]
	public RContext r() {
		RContext _localctx = new RContext(Context, State);
		EnterRule(_localctx, 0, RULE_r);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 2;
			Match(T__0);
			State = 3;
			_localctx._ID = Match(ID);
			 UnityEngine.Debug.Log("Antlr say: Hello, " + (_localctx._ID!=null?_localctx._ID.Text:null)); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static int[] _serializedATN = {
		4,1,3,7,2,0,7,0,1,0,1,0,1,0,1,0,1,0,0,0,1,0,0,0,5,0,2,1,0,0,0,2,3,5,1,
		0,0,3,4,5,2,0,0,4,5,6,0,-1,0,5,1,1,0,0,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;


public class DebugConsole : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    public static bool showConsole = false;
    public static string currentText;
    string input;
    Vector2 scroll;

    [SerializeField]
    private InputActionReference DevC;

    private bool chr = false;

    public void Toggle()
    {
        showConsole = !showConsole;
        input = "";
    }

    public void ODevConsole()
    {
        if (showConsole)
        {
            HandleInput();
            input = "";
        }
    }

    private void OnEnable()
    {
        DevC.action.performed += test;
    }

    private void OnDisable()
    {
        DevC.action.performed -= test;
    }


    private void test(InputAction.CallbackContext obj)
    {
        ODevConsole();
    }
    private void OnGUI()
    {
        GUI.contentColor = Color.white;
        if (!showConsole) { return; }

        float y = 0f;

        GUI.Box(new Rect(0, y, Screen.width, 100), "");
        
        Rect viewport = new Rect(0, 0, Screen.width - 30, 20 * 1);

        scroll = GUI.BeginScrollView(new Rect(0, y + 5f, Screen.width, 90), scroll, viewport);

        string label;

        switch (currentText)
        {
            case "Help":
                label = "Use AUTODUNE (Difficult) for starters";
                break;
            case "Correct":
                label = "Generating...";
                break;
            case "Exiting":
                label = "Exiting...";
                break;
            case "Error":
                label = "Syntax Error";
                break;
            default:
                label = "Unknown command";
                break;
        }
        

        Rect labelRect = new Rect(5, 10, viewport.width - 100, 20);
        GUI.Label(labelRect, label);

        GUI.EndScrollView();

        y += 100;

        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color( 0, 0, 0, 0);
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);

       

    }
    private void Awake()
    {
        cam1.SetActive(!chr);
        cam2.SetActive(chr);
    }

    private void HandleInput()
    {
        //string Godmode = input.GetComponent<InputField>().text;

        var text = input; //asignación
                            //var text = System.IO.File.ReadAllText("b.txt");
        Debug.Log(text);
        if (text == "DUNE Help")
        {
            currentText = "Help";
        }
        else if (text == "DUNE Exit")
        {
            currentText = "Exiting";
            Application.Quit();
        }
        else if (text == "DUNE View")
        {
            Debug.Log("ESTA VAINA ENTRA ACA");
            chr = !chr;
            cam1.SetActive(!chr);
            cam2.SetActive(chr);
        }
        else
        {
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

            MainMenu.ParsingText = myDictionary;

            SceneManager.LoadScene(2);
        }
    }
}

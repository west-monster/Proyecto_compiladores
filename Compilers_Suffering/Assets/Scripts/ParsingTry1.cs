using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ParsingTry1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] str = {"makedun a", "makedun [A] gen 4", "makedun [A][A] gen 13"};

        foreach (string s in str)
        {
            bool prin = Gen(s) ? true : false;
            Debug.Log(prin);
        }

    }

    public static bool Gen(string Gen)
    {
        string strRegex = @"(makedun )(\[[A-Z]\])*( gen [0-9]+)";


        Regex re = new Regex(strRegex);

        if (re.IsMatch(Gen))
            return (true);
        else
            return (false);
    }

}

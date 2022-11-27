using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleV2
{
    public string letter;
    [SerializeField]
    private string[] results = null;

    public RuleV2()
    {
        this.letter = "F";
    }

    public string GetResult()
    {
        return results[0];
    }
}
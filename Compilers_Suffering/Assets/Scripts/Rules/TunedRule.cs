using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunedRule : MonoBehaviour
{
    public string letter;
    [SerializeField]
    private string[] results = null;

    public TunedRule(string axiom, string[] Rules)
    {
        letter = axiom;
        results = Rules;
    }

    public string GetResult()
    {
        return results[0];
    }
}

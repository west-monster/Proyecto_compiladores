using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunedRule : MonoBehaviour
{
    public string letter;
    [SerializeField]
    private string[] results = null;
    [SerializeField]
    private bool randomResult = true;
    public TunedRule(string axiom, string[] Rules)
    {
        letter = axiom;
        results = Rules;
    }

    public string GetResult()
    {
        if (randomResult)
        {
            int randomIndex = UnityEngine.Random.Range(0, results.Length);
            return results[randomIndex];
        }
        return results[0];
    }
}

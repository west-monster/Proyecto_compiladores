using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ProceduralDunge/Rule")]
public class Rule : ScriptableObject
{
    public string letter;
    [SerializeField]
    private string[] results = null;
    [SerializeField]
    private bool randRes = false;

    public string GetResult()
    {   
        if (randRes)
        {
            int randomIdx = Random.Range(0, results.Length);
            return results[randomIdx];
        }
        return results[0];
    }
}

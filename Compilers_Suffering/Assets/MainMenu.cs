using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public static string[] ParsingText = { "yuju", "yuju2" };
    public void Generate()
    {
        SceneManager.LoadScene(1);
    }
}

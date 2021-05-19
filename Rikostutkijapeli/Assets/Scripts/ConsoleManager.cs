using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConsoleManager : MonoBehaviour
{
    public TMP_InputField consoleInput;
    public Console consoleScript;

    private ConsoleFunctions functions;

    private void Start()
    {
        functions = GetComponent<ConsoleFunctions>();
        Debug.Log("Kirjoita (help) nähdäksesi komennot");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Command(consoleInput.text);
            consoleInput.text = "";
            consoleInput.Select();
            consoleInput.ActivateInputField();
        }
    }

    void Command(string cmd)
    {
        if (cmd == "help")
        {
            Debug.Log("Komennot:");
            Debug.Log("help");
            Debug.Log("loadscene (numero)");
            Debug.Log("close");
            Debug.Log("clear");
            Debug.Log("reload");
            Debug.Log("debugcam");
        }



        if (cmd == "close")
        {
            PlayerPrefs.SetInt("ConsoleEnabled", 0);

            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;

            #else
		    Application.Quit();

            #endif
        }



        if (cmd == "debugcam")
        {
            Debug.Log("Debugcam");
        }



        if (cmd == "clear")
        {
            consoleScript.Clear();
        }



        if (cmd == "reload")
        {
            functions.LoadScene(functions.currentScene);
        }



        if (cmd == "loadscene 0")
        {
            functions.LoadScene(0);
        }
        if (cmd == "loadscene 1")
        {
            functions.LoadScene(1);
        }
        if (cmd == "loadscene 2")
        {
            functions.LoadScene(2);
        }
    }
}

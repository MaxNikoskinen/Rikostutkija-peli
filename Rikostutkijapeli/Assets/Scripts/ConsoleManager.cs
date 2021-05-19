using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConsoleManager : MonoBehaviour
{
    public TMP_InputField consoleInput;
    public Console consoleScript;

    private ConsoleFunctions functions;
    private int amount = 0;
    private int amount2 = 0;
    private int amount3 = 0;

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
        if(cmd == "")
        {
            amount++;

            if(amount >= 25)
            {
                if(amount <= 25)
                {
                    Debug.Log("lopeta, ei ole hauskaa");
                }
                
                amount2++;
            }
            if(amount2 >= 25)
            {
                if (amount2 <= 25)
                {
                    Debug.Log("jos jatkat, niin suljen pelin");
                }
                amount3++;
            }
            if(amount3 >= 25)
            {
                PlayerPrefs.SetInt("ConsoleEnabled", 0);

                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;

                #else
		        Application.Quit();

                #endif
            }
        }


        else if (cmd == "help" || cmd == "HELP")
        {
            Debug.Log("Komennot:");
            Debug.Log("help");
            Debug.Log("loadscene (numero)");
            Debug.Log("close");
            Debug.Log("clear");
            Debug.Log("reload");
            Debug.Log("debugcam");
        }



        else if (cmd == "close" || cmd == "CLOSE")
        {
            PlayerPrefs.SetInt("ConsoleEnabled", 0);

            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;

            #else
		    Application.Quit();

            #endif
        }



        else if (cmd == "debugcam" || cmd == "DEBUGCAM")
        {
            Debug.Log("Debugcam");
        }



        else if (cmd == "clear" || cmd == "CLEAR")
        {
            consoleScript.Clear();
        }



        else if (cmd == "reload" || cmd == "RELOAD")
        {
            functions.LoadScene(functions.currentScene);
        }



        else if (cmd == "loadscene 0" || cmd == "LOADSCENE 0")
        {
            functions.LoadScene(0);
        }
        else if (cmd == "loadscene 1" || cmd == "LOADSCENE 1")
        {
            functions.LoadScene(1);
        }
        else if (cmd == "loadscene 2" || cmd == "LOADSCENE 2")
        {
            functions.LoadScene(2);
        }


        else
        {
            Debug.Log("<color=yellow>Komento (" + cmd + ") on virheellinen</color>");
        }
    }
}

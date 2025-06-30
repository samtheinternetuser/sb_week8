using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{


    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
        ColorPicker.SelectColor(MainManager.Instance.unitColour);
    }
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        MainManager.Instance.unitColour = color;
    }


    public void SaveColorClicked()
    {
        MainManager.Instance.saveColour();
    
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadColorClicked()
    {
        MainManager.Instance.loadColour();
        ColorPicker.SelectColor(MainManager.Instance.unitColour);
    }



    public void Exit()
    {
        MainManager.Instance.saveColour();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private string[] _scenesNamesToLoad;

    void Start()
    {
        for (int i = 0; i < _scenesNamesToLoad.Length; i++)
        {
            SceneManager.LoadScene(_scenesNamesToLoad[i], LoadSceneMode.Additive);
        }
        
        this.ExecuteAfterDelay(0.3f, () =>
        {
            Debug.Log("Test");
        });
    }
}

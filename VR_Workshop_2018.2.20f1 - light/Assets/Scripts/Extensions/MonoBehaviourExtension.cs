using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
/// <author>Théo Farnole 8)</author>
public static class MonoBehaviourExtension
{
    public static void ExecuteAfterDelay(this MonoBehaviour monoBehaviour, float delay, Action task)
    {
        monoBehaviour.StartCoroutine(DelayCoroutine(delay, task));
    }

    static IEnumerator DelayCoroutine(float delay, Action task)
    {
        yield return new WaitForSeconds(delay);
        task();
    }
}

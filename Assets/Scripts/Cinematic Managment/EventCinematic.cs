using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventCinematic : MonoBehaviour
{
    public void LoadingSceneCinematic(int _newScene)
    {
        SceneManager.LoadScene(_newScene);
        // Transitiontuto();
    }

    // IEnumerator Transitiontuto()
    // {

    // }
}

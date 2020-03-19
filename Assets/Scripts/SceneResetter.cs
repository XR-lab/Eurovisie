using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SceneResetter : MonoBehaviour
{
    [SerializeField] private int sceneIndexToLoad = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ResetScene();
        }
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(sceneIndexToLoad);
    }
}

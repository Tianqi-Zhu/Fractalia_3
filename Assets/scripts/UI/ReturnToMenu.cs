using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    {
        SceneManager.LoadScene(11);
        Destroy(GameObject.FindWithTag("PersistentManager"));
    }
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using NUnit.Framework;

public class SceneChange : MonoBehaviour,ActionBase
{
    [SerializeField] string sceneName;  
    public void Action()
    {
        Debug.Log("SceneChange");
        SceneManager.LoadScene(sceneName);
    }
}

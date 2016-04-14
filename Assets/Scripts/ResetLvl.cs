using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResetLvl : MonoBehaviour {
    public void Reset()
    {
        //Application.LoadLevel(0);
        SceneManager.LoadScene(0);
    }
}

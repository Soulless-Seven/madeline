using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchMadeline : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Madeline")
            SceneManager.LoadScene("PrototypeFailed");
    }
}

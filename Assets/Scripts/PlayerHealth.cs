using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int lives;

    void Awake() {
      //  DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if (gameObject.transform.position.y < -6)
        {
            Die();
        }
    }
    public void Die()
    {
     SceneManager.LoadScene("Game");
    }
}
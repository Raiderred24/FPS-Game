using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinVolume : MonoBehaviour
{
    [SerializeField] GameObject m_target;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject LevelController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == m_target)
        {
            Time.timeScale = 0f;
            winScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            LevelController.GetComponent<Level01Controller>().winGame();
            this.GetComponent<AudioSource>().Play();

        }
    }
}

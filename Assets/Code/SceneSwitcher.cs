using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    public int nextSceneNum;
    public bool destroyPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            SceneManager.LoadScene(nextSceneNum);
            if (destroyPlayer)
            {
                Destroy(other.gameObject);
            }
        }
    }
}

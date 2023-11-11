using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Barrel : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ship")
        {
            //ServiceLocator.GetService<ScoreManager>().IncreaseScore(10);
            Destroy(this);
        }
    }
}

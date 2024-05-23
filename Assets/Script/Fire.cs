using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public static bool flag;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("パーティクル当たってる？");
            flag = true;
        }
    }
}

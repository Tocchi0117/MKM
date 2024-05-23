using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public bool ans;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (ans)
            {
                Debug.Log("ê≥â");
                Sound_SE.playsound(0,2);
            }
            else
            {
                Debug.Log("ïsê≥â");
                Sound_SE.playsound(0, 3);
            }
        }
    }
}

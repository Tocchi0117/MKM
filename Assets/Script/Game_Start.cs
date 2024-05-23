using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Start : MonoBehaviour
{
    public GameObject fire;

    Vector3 posi;

    // Start is called before the first frame update
    void Start()
    {
        posi = fire.transform.position;
        fire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("joystick button 2") && Input.GetKey("joystick button 4") && Input.GetKey("joystick button 5") && Input.GetKey("joystick button 6"))
        {
            fire.SetActive(false);
            this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            FireMove.flag = false;
            fire.transform.position = posi;
            Debug.Log("çƒäJ");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fire.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            Sound_SE.playsound(0,0);
        }
    }
}

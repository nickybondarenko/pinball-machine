using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerScript : MonoBehaviour
{
    float power;
    float minPower = 0f;
    public float maxPower = 100f;
    public Slider powerSlider;
    List<Rigidbody> ballList;
    bool ballReady;

    // Start is called before the first frame update
    void Start()
    {
        powerSlider.minValue = 0f;

        powerSlider.maxValue = maxPower;
        ballList = new List<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (ballReady) {
            powerSlider.gameObject.SetActive(true);
        } else {
            powerSlider.gameObject.SetActive(false);
        }

        powerSlider.value = power;   

        //If the ball has entered the trigger and the player hit space, count force and when the player releases space, add force
        if (ballList.Count > 0) {
            //Debug.Log("Found the ball, ready to shoot");
            ballReady = true;
            if (Input.GetKey(KeyCode.Space)) { 
                if (power <= maxPower) {
                    power += 50 * Time.deltaTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space)) { 
                foreach (Rigidbody r in ballList) {
                    r.AddForce(power * Vector3.forward);
                    }
            }
        } 
        //Otehrwise, the ball isn't ready and can't be moved
        else 
        {
            ballReady = false;
            power = 0f;
         }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            ballList.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ballList.Remove(other.gameObject.GetComponent<Rigidbody>());
            power = 0f;
        }
    }


}

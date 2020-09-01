using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRock : MonoBehaviour
{
    [SerializeField] private GameObject rock;
    [SerializeField] private int rockForce;
    private Transform mainCamObject;
    private Transform rockSpawnPos;
    Vector3 rockOffset = new Vector3(0,1,1);

    // Awake is called once before Start
    void Awake()
    {
        GetComponent<ThirdPersonController>().OnPunchAnimation+= shootRock;
        //finds the child object without needing serializefield. 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rockSpawnPos = transform.Find("Main Camera").Find("rockSpawnPosition");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction*100, Color.red);
    }

    private void shootRock(object sender, EventArgs e)
    {
        int pLayer = 1 << 9;
        pLayer= ~pLayer;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, pLayer))
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
            Debug.Log("Yeet the rock");
            GameObject shot = GameObject.Instantiate(rock, rockSpawnPos.position, Quaternion.identity);
            //shot.GetComponent<Rigidbody>().AddForceAtPosition((hit.point - rockSpawnPos.position)*rockForce*Time.deltaTime, shot.GetComponent<Rigidbody>().centerOfMass, ForceMode.VelocityChange);
            shot.GetComponent<Rigidbody>().AddForce((hit.point - rockSpawnPos.position)*rockForce*Time.deltaTime);
        }
        else
        {
            Debug.Log("False");
        }
    }
}

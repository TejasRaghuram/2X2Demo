using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCube : MonoBehaviour
{
    public GameObject[] pieces;
    public GameObject turning;
    bool isTurning;
    public int rotateSpeed;
    float rotateProgress;
    Vector3 rotateAngle;
    Vector3 overshoot;
    // Start is called before the first frame update
    void Start()
    {
        rotateAngle = Vector3.zero;
        overshoot = Vector3.zero;
        isTurning = false;
        rotateProgress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTurning)
        {
            turning.transform.Rotate(rotateAngle.x * Time.deltaTime, rotateAngle.y * Time.deltaTime, rotateAngle.z * Time.deltaTime, Space.World);
            rotateProgress += rotateSpeed * Time.deltaTime;
            if(rotateProgress > 90)
            {
                float reverse = rotateProgress - 90;
                turning.transform.Rotate(overshoot.x * reverse, overshoot.y * reverse, overshoot.z * reverse, Space.World);
                rotateProgress = 0;
                isTurning = false;
                for(int i = 0; i < 8; i++)
                {
                    pieces[i].transform.SetParent(transform, true);
                }
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.U))
            {
                isTurning = true;
                for(int i = 0; i < 8; i++)
                {
                    if(pieces[i].transform.position.y > -1)
                    {
                        pieces[i].transform.SetParent(turning.transform, true);
                    }
                }
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    rotateAngle = new Vector3(0, -rotateSpeed, 0);
                    overshoot = new Vector3(0, 1, 0);
                }
                else 
                {
                    rotateAngle = new Vector3(0, rotateSpeed, 0);
                    overshoot = new Vector3(0, -1, 0);
                }
            }
            if(Input.GetKeyDown(KeyCode.D))
            {
                isTurning = true;
                for(int i = 0; i < 8; i++)
                {
                    if(pieces[i].transform.position.y < -1)
                    {
                        pieces[i].transform.SetParent(turning.transform, true);
                    }
                }
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    rotateAngle = new Vector3(0, rotateSpeed, 0);
                    overshoot = new Vector3(0, -1, 0);
                }
                else 
                {
                    rotateAngle = new Vector3(0, -rotateSpeed, 0);
                    overshoot = new Vector3(0, 1, 0);
                }
            }
            if(Input.GetKeyDown(KeyCode.F))
            {
                isTurning = true;
                for(int i = 0; i < 8; i++)
                {
                    if(pieces[i].transform.position.z < -1)
                    {
                        pieces[i].transform.SetParent(turning.transform, true);
                    }
                }
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    rotateAngle = new Vector3(0, 0, rotateSpeed);
                    overshoot = new Vector3(0, 0, -1);
                }
                else 
                {
                    rotateAngle = new Vector3(0, 0, -rotateSpeed);
                    overshoot = new Vector3(0, 0, 1);
                }
            }
            if(Input.GetKeyDown(KeyCode.B))
            {
                isTurning = true;
                for(int i = 0; i < 8; i++)
                {
                    if(pieces[i].transform.position.z > -1)
                    {
                        pieces[i].transform.SetParent(turning.transform, true);
                    }
                }
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    rotateAngle = new Vector3(0, 0, -rotateSpeed);
                    overshoot = new Vector3(0, 0, 1);
                }
                else 
                {
                    rotateAngle = new Vector3(0, 0, rotateSpeed);
                    overshoot = new Vector3(0, 0, -1);
                }
            }
            if(Input.GetKeyDown(KeyCode.L))
            {
                isTurning = true;
                for(int i = 0; i < 8; i++)
                {
                    if(pieces[i].transform.position.x < 1)
                    {
                        pieces[i].transform.SetParent(turning.transform, true);
                    }
                }
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    rotateAngle = new Vector3(rotateSpeed, 0, 0);
                    overshoot = new Vector3(-1, 0, 0);
                }
                else 
                {
                    rotateAngle = new Vector3(-rotateSpeed, 0, 0);
                    overshoot = new Vector3(1, 0, 0);
                }
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                isTurning = true;
                for(int i = 0; i < 8; i++)
                {
                    if(pieces[i].transform.position.x > 1)
                    {
                        pieces[i].transform.SetParent(turning.transform, true);
                    }
                }
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    rotateAngle = new Vector3(-rotateSpeed, 0, 0);
                    overshoot = new Vector3(1, 0, 0);
                }
                else 
                {
                    rotateAngle = new Vector3(rotateSpeed, 0, 0);
                    overshoot = new Vector3(-1, 0, 0);
                }
            }
        }
    }
}

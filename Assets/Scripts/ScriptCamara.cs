using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCamara : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Target;
    private Vector3 TargetPos;
    //private float Adelante;

    public float cammov;
    public PlayerMovement player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TargetPos=transform.position=new Vector3(Target.transform.position.x,Target.transform.position.y+2,transform.position.z);

        

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    private Transform NPCPos;
    public Movement movementScript;
    public float NPCDistance;
    
    void Start()
    {
        NPCPos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        NPCDistance = Vector3.Distance(NPCPos.position, movementScript.playerPos.position);

        if(NPCDistance <=3)
        {
            Vector3 lookDirection = movementScript.playerPos.position - NPCPos.position;
            lookDirection.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            Quaternion desiredRotation= Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
            NPCPos.rotation = Quaternion.Slerp(NPCPos.rotation, desiredRotation, 5 * Time.deltaTime);
        }

    }
}

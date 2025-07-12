using Unity.VisualScripting;
using UnityEngine;

public class BoulderTrap : MonoBehaviour
{
    [SerializeField] GameObject boulder;
    [SerializeField] GameObject boulderSpawnPoint;
    [SerializeField] GameObject boulderEndPoint;
    [SerializeField] float moveSpeed;
    [SerializeField] bool hasCollided = false; 

    private void Update()
    {
        if(hasCollided)//if collision happens, move boulder to its end point
        {
            boulder.transform.position = Vector3.MoveTowards(boulder.transform.position, boulderEndPoint.transform.position, moveSpeed);
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
         

        if(other.CompareTag("Player"))//trap triggers
        {
            Debug.Log("trap has triggered");
            hasCollided = true;//confirm that triggered has been hit
        }
    }

}

using UnityEngine;

public class BoulderDamagesPlayer : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)//if boulder hits player, do damage
    {
        if(other.CompareTag("Player"))
        {
            //put player damage code here @Corbin?


            Debug.Log("Player Has Been Hit"); 
        }
    }

}

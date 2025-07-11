using UnityEngine;

public class SwordAnimation : MonoBehaviour
{
    public void showSword()
    {
        GetComponent<MeshRenderer>().enabled = true;
    }

    public void hideSword()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}

using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public GameObject lookcamera;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - lookcamera.transform.position);  
    }
}

using UnityEngine;

public class UI_Chase : MonoBehaviour
{

    public GameObject target;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}

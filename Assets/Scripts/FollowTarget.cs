using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    Vector3 offset = new Vector3(0, 0, -10);
    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (target == null)
        {
            Debug.Log("Sem target nesse código");
            Destroy(this);
        }    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}

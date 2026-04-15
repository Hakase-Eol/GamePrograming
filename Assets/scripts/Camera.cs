using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform target;
    public float smoothspeed = 5f;
    public Vector3 offset = new Vector3(0f, 0f, 10f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothspeed * Time.deltaTime);
            transform.position = smoothPosition;
        }
    }
}

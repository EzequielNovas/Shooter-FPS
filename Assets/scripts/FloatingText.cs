using UnityEngine;
public class FloatingText : MonoBehaviour
{
    public Camera camera;
    public Vector3 offset = new Vector3(0, 1, 0);
    public float timeOfLife = 1f;
    void Start()
    {
        camera = GameObject.Find("FirstPersonCharacter").GetComponent<Camera>();
        Destroy(gameObject, timeOfLife);
        transform.localPosition += offset;
    }
    void Update() => transform.LookAt(transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
}

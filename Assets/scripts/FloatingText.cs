using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
   public Camera camera;
    public float TiempoDeVida = 1f;
    public Vector3 offset = new Vector3(0, 1, 0);
    void Start()
    {
        camera = GameObject.Find("FirstPersonCharacter").GetComponent<Camera>();
        Destroy(gameObject, TiempoDeVida);
        transform.localPosition += offset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
    }
}

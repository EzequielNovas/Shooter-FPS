using UnityEngine;
public class weaponSwing : MonoBehaviour
{
    private Vector3 initPos;
    public float amount;
    public float amountMax;
    public float time;
    public bool sways;
    void Start() => initPos = transform.localPosition;
    void Update()
    {
     sways = true;
     float movX = Input.GetAxis("Mouse X") * amount;
     float movY = Input.GetAxis("Mouse Y") * amount;
     movX       = Mathf.Clamp(movX, -amountMax, amountMax);
     movY       = Mathf.Clamp(movY, -amountMax, amountMax);

    Vector3 PosFinalMov = new Vector3(movX, movY, 0);


     if (Input.GetMouseButton(1))
        sways = false;

     if (sways == true)
        transform.localPosition = Vector3.Lerp(transform.localPosition, PosFinalMov + initPos, time * Time.deltaTime);
    }
}
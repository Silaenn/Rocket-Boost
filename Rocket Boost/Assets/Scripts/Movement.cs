using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] float thrustStrength;

    Rigidbody rb;
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable() {
        thrust.Enable();
    }

    private void FixedUpdate() {
        if(thrust.IsPressed()){
           rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        }
    }
}

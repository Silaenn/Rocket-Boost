using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    // PARAMETERS  -  for tuning , typically set in the editor

    // CAHCE  -  eg. rederences for readability or speed

    // STATE  -  private instances (member) variables

    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength = 100f;
    [SerializeField] float rotationStrength = 100f;

    Rigidbody rb;
    AudioSource audioSource;
    private void Start() {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() {
        thrust.Enable();
        rotation.Enable();
    } 

    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
            if(!audioSource.isPlaying){
            audioSource.Play();
            }
        } else {
            audioSource.Stop();
        }
    }

    private void ProcessRotation()
    {
        float rotationInput =  rotation.ReadValue<float>();
        if(rotationInput < 0)
        {
            ApplayRotation(rotationStrength);
        }
        else if(rotationInput > 0){
            ApplayRotation(-rotationStrength);
        }
    }

    private void ApplayRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}

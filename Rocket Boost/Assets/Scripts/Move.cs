using UnityEngine;

public class TestDeleteMe : MonoBehaviour
{
    [SerializeField] float movementSped = 3f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * movementSped * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * movementSped * Time.deltaTime;

        transform.Translate(horizontal, 0f, vertical);
    }
}

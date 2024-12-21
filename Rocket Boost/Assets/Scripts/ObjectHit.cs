using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
       Debug.Log("Sesuatu mengenaiku");
       GetComponent<MeshRenderer>().material.color = Color.yellow;
    }
}

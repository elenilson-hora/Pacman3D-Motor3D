using UnityEngine;

public class PickUpController : MonoBehaviour
{
    // 10° metodo do MonoBehaviour
    private void Update()
    {
        transform.Rotate(new Vector3(15f, 30f, 0f) * Time.deltaTime);
    }
}

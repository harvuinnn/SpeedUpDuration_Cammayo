using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCRIPT : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float speedBoost = 3f;
    public float rotationSpeed = 150f;
    public float speedDuration = 5f;

    private float originalSpeed = 5f;

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * moveSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            StartCoroutine(BoostSpeed());
            Destroy(other.gameObject);
        }
    }

    IEnumerator BoostSpeed()
    {
        moveSpeed += speedBoost;

        yield return new WaitForSeconds(speedDuration);
        moveSpeed = originalSpeed;
    }
}
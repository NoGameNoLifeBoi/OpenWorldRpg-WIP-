using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerControl : MonoBehaviour
{
    private float horizontalMovement;
    private float verticalMovement;
    [SerializeField] private float speed;

    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * verticalMovement * Time.fixedDeltaTime * speed);
        transform.Translate(Vector3.right * horizontalMovement * Time.fixedDeltaTime * speed);
    }
}

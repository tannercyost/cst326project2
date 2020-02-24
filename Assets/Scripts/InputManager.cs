using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Animator myAnimator;

    [SerializeField] private Transform myTransform;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private float speedAmplifier = 1;

    [SerializeField] private float jumpAmplifier = 1;
    [SerializeField] private bool isGrounded = false;

    private float lastYposition = 0;
    // Start is called before the first frame update
    enum StateVariables
    {
        forwardMovement
    }

    void FixedUpdate()
    {
        float forward = Input.GetAxis("Horizontal");
        float y = (forward < 0) ? -90 : 90;
        Vector3 newRotation = new Vector3(0, y, 0);
        myTransform.eulerAngles = newRotation;

        isGrounded = lastYposition == myTransform.position.y;

        myAnimator.SetFloat(StateVariables.forwardMovement.ToString(), Mathf.Abs(forward));

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * jumpAmplifier;
        }

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, forward * speedAmplifier);

        lastYposition = myTransform.position.y;
    }


}

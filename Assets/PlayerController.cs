using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;

    public Camera camera;
    public CharacterController characterController;
    private Vector2 m_Input;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

	void FixedUpdate () {
        float speed;
        GetInput(out speed);
        Vector3 desiredMove = camera.transform.forward * m_Input.y + camera.transform.right * m_Input.x;
        characterController.Move(desiredMove);
	}

    private void GetInput(out float speed)
    {
            // Read input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        speed = moveSpeed;

        m_Input = new Vector2(horizontal, vertical);

        // normalize input if it exceeds 1 in combined length:
        if (m_Input.sqrMagnitude > 1)
        {
            m_Input.Normalize();
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerMovement : MonoBehaviour
{
	[Range(0.2f, 2f)]
	public float moveSpeedModifier = 0.5f;

	public bool blockMovementX = false, blockMovementY = false;

	bool moveAllowed = true;

	Rigidbody2D rb;

	float dirX, dirY;

	void Start()
	{
		moveAllowed = true;
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		dirX = Input.acceleration.x * moveSpeedModifier * (blockMovementX ? 0 : 1);
		dirY = Input.acceleration.y * moveSpeedModifier * (blockMovementY ? 0 : 1);
	}

	void FixedUpdate()
	{
		if (moveAllowed)
		{
			rb.velocity = new Vector2(rb.velocity.x + dirX, rb.velocity.y + dirY);
		}
	}

	public void SetMoveAllowed(bool _moveAllowed)
    {
		moveAllowed = _moveAllowed;
		if (!moveAllowed)
        {
			rb.velocity = new Vector2(0, 0);
        }
    }
}

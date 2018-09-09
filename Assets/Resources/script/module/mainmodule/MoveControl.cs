using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour {

	private Animator masterAnim = null;
	private enum Direct {
		idle = -1,
		down,
		left,
		right,
		up
	}
	private Direct direction;
	void Awake()
	{
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveBegin()
	{
		if (masterAnim == null)
		{
			masterAnim = Player.heroAnimator;	
		}
		masterAnim.speed = 1;
		direction = Direct.idle;
	}

	public void Move(Vector2 delta)
	{
		if (delta.x >= 0.5f)
		{
			masterAnim.CrossFade("right", 0);
			direction = Direct.right;
		}
		else if(delta.x < -0.5f)
		{
			masterAnim.CrossFade("left", 0);	
			direction = Direct.left;
		}
		else if(delta.y < 0)
		{
			masterAnim.CrossFade("down", 0);	
			direction = Direct.down;
		}
		else if(delta.y > 0)
		{
			masterAnim.CrossFade("up", 0);	
			direction = Direct.up;
		}
		// Debug.Log("move" + delta);

	}

	public void MoveEnd()
	{
		float dir = (float)direction;
		masterAnim.CrossFade("idle", 0, -1, dir / 4.0f);
		masterAnim.speed = 0;
		direction = Direct.idle;

		// Debug.Log("move" + dir+ "," + (dir / 4.0f));
	}
}

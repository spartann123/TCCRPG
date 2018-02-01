﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is an abstract class that all characters needs to inherit from
/// </summary>
public abstract class Character : MonoBehaviour
{

	[SerializeField]
	private float speed;

	private Animator animator;

	protected Vector2 direction;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator> ();
	}

	protected virtual void Update ()
	{
		Move ();
	}

	public void Move ()
	{
		transform.Translate (direction * speed * Time.deltaTime);
		if (direction.x != 0 || direction.y != 0) {
			AnimateMovement (direction);
		} else {
			animator.SetLayerWeight (1, 0);
		}
	}

	public void AnimateMovement (Vector2 direction)
	{
		animator.SetLayerWeight (1, 1);

		animator.SetFloat ("x", direction.x);
		animator.SetFloat ("y", direction.y);
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
	public static GameObject hero;
	public static Animator heroAnimator;
	public static void SetHero(GameObject go)
	{
		hero = go;
		heroAnimator = hero.GetComponent<Animator>();
		heroAnimator.CrossFade("idle", 0, -1, 0);
		heroAnimator.speed = 0;
		hero.GetComponent<CharacterController>().isTrigger = false;
	}
}

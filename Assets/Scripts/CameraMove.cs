using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
	//public Player Player;
	[SerializeField] private float Smoothing;
	private Vector3 Velocity = Vector3.zero;

	private void Start() 
	{
		//GameManager.Instance.OnPlayerSpawn += UpdatePlayer;
	}

	//private IEnumerator Start() {
	//	yield return null;
	//	if (Player == null) {
	//		Player = GameManager.Instance.getPlayer();
	//	}
	//}

	/*private void UpdatePlayer() {
		Player = GameManager.Instance.getPlayer();
	}*/

	private void FixedUpdate() {
		if (GameManager.Instance.getPlayer() != null) {
			//if (Player.IsPlayerAlive()) 
			{
				//Debug.Log("coucou");
				Vector3 targetPosition = new Vector3(GameManager.Instance.getPlayer().transform.position.x, GameManager.Instance.getPlayer().transform.position.y, transform.position.z);
				transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref Velocity, Smoothing);
			}
		}
	}
}

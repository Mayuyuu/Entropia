using UnityEngine;

public class GameManager : MonoBehaviour {

	//----------------Player related-------------------------- 
	[SerializeField] private GameObject PrefabPlayer;
	private Player player;
	// ----------------Delegates pour la mort du player-------------------------- 
	public delegate void PlayerDeath();
	public PlayerDeath OnPlayerDeath;
	// ----------------Delegates pour le spawn du player-------------------------- 
	public delegate void SpawnPlayer();

	public SpawnPlayer OnPlayerSpawn;

	/*-------------VARIABLES PLAYER-------------*/
	[SerializeField] private float Speed = 10f; // Vitesse du player
	[SerializeField] private float Smoothing = 0.2f; // Valeur de smoothing acc�l�ration au d�part et ralentissement lors de l'arr�t du joueur
	[SerializeField] private bool isJumping;
	[SerializeField] public bool isGrounded;

	public static GameManager Instance;

	private void Awake() {
		if(Instance == null) {
			Instance = this;
		}
		else {
			Debug.LogWarning("Second instance of GameManager created.Automatic self - destruct triggered.");
			Destroy(this.gameObject);
		}

		SpawningPlayer();
	}


	private void OnDestroy() {
		if (Instance == this) {
			Instance = null;
		}
	}

	#region Player
	/*-------------GETTERS & SETTERS PLAYER-------------*/
	public bool getIsJumping() {
		return isJumping;
	}

	public void setIsJumping(bool isJumping) {
		this.isJumping = isJumping;
	}

	public bool getIsGrounded() {
		return isGrounded;
	}

	public void setIsGrounded(bool isGrounded) {
		this.isGrounded = isGrounded;
	}

	public float getSpeed() {
		return Speed;
	}

	public void setSpeed(float SpeedPlayer) {
		Speed = SpeedPlayer;
	}

	public float getSmoothing() {
		return Smoothing;
	}

	public void setSmoothing(float SmoothingWalk) {
		Smoothing = SmoothingWalk;
	}


	#endregion

	public void SpawningPlayer() {
		player = Instantiate(PrefabPlayer).GetComponent<Player>();
		OnPlayerSpawn?.Invoke();
	}

	public Player getPlayer() {
		return player;
	}

	public void PlayerIsDead() {
		OnPlayerDeath?.Invoke();
	}



}

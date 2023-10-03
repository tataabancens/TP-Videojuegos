using UnityEngine;

public class Actor : MonoBehaviour, IDamageable
{
	#region IDAMAGEABLE_PROPERTIES
	public int MaxLife => stats.MaxLife;

	public int Life => _life;
	#endregion

	#region PRIVATE_PROPERTIES
	public EntitieStats Stats => stats;
	[SerializeField] protected EntitieStats stats;
	[SerializeField] private int _life;
	#endregion

	#region UNITY_METHODS
	protected void Start()
	{
		_life = MaxLife;
	}
	#endregion

	#region IDAMAGEABLE_METHODS
	public void Die() {
		if (name.Equals("Character")) EventsManager.instance.EventGameOver(false);
		else Destroy(gameObject);
		Debug.Log($"{name} Died");
	}

	public void TakeDamage(int damage) {
		_life -= damage;
		Debug.Log($"{name} Hit -> Life: {_life}");
		if (_life < 0) Die();
	}
	#endregion
}

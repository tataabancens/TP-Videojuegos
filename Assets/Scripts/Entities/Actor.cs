using UnityEngine;

public class Actor : MonoBehaviour, IDamageable
{
	#region IDAMAGEABLE_PROPERTIES
	public int MaxLife => _maxLife;

	public int Life => _life;
	#endregion

	#region PRIVATE_PROPERTIES
	[SerializeField] private int _maxLife = 100;
	[SerializeField] private int _life;
	#endregion

	#region UNITY_METHODS
	protected void Start()
	{
		_life = _maxLife;
	}
	#endregion

	#region IDAMAGEABLE_METHODS
	public void Die() {
		Debug.Log($"{name} Died");
	}

	public void TakeDamage(int damage) {
		_life -= damage;
		Debug.Log($"{name} Hit -> Life: {_life}");
		if (_life < 0) Die();
	}
	#endregion
}

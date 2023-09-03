using UnityEngine;

namespace Entities
{
	public class BasicBullet : MonoBehaviour, IBullet
	{
    
		[SerializeField] private int _damage = 10;
		[SerializeField] private float _lifetime = 3f;
		[SerializeField] private float _speed = 3f;


		// Start is called before the first frame update
		void Start()
		{
        
		}

		// Update is called once per frame
		void Update()
		{
			Travel();

			_lifetime -= Time.deltaTime;
			if (_lifetime < 0) Die();
		}

		private void OnDestroy() {
			Debug.Log("Bullet has died");
		}

		public void Init() {

		}

		private void CollisionDetection() {

		}

		public int Damage => _damage;
		public float Lifetime => _lifetime;
		public float Speed => _speed;

		#region IBULLET_METHODS
		public void Die() => Destroy(gameObject);
		public void Travel() => transform.position += Vector3.forward * Time.deltaTime * _speed;
		#endregion
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
	int Damage {
		get;
	}

	float Lifetime {
		get;
	}

	float Speed {
		get;
	}

	void Travel();
	void Die();
}

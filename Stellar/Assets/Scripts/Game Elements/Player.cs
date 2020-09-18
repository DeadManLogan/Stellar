using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stellar{
	public class Player : MonoBehaviour,Damageable{
		public PlayerHolder holder;

		public void Damage(int v){
			holder.Damage(v);
		}
	}
}
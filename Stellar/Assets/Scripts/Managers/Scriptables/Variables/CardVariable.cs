using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Stellar{
	[CreateAssetMenu(menuName = "Variables/Card variable")]
	public class CardVariable : ScriptableObject
	{
		public CardInstance value;

		public void Set(CardInstance v){
			value = v;
		}
	}
}

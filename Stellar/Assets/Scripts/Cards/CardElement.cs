using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Stellar{
	[CreateAssetMenu(menuName = "Cards/CardElement")]
	public class CardElement : ScriptableObject{
		public CardElement[] beats;

		public bool Counters(CardElement other){
			if(beats.Contains(other)){
				return true;
			}
			else{
				return false;
			}
		}
	}	
}


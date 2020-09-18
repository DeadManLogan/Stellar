using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stellar.GameElements{

	[CreateAssetMenu(menuName = "Game Elements/Card On Play")]
	public class OnPlayCard : GE_Logic
	{
		public override void OnClick(CardInstance instance){
			Debug.Log("this card is on my board");
		}
		public override void OnHighlight(CardInstance instance){

		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Stellar{
	[CreateAssetMenu(menuName = "Actions/Player Actions/Reset Flat Foot")]
	public class ResetFlatFootedCards : PlayerAction
	{
		public override void Execute(PlayerHolder player){
			foreach(CardInstance c in player.downCards){
				if(c.state==CardInstance.State.Flatfooted){
					c.state=CardInstance.State.Idle;
				}
			}
		}
	}
}

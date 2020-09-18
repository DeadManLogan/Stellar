using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Stellar{

	[CreateAssetMenu(menuName = "Holders/Card Holder")]
	public class CardHolders : ScriptableObject
	{
		public SO.TransformVariable handGrid;
		public SO.TransformVariable downGrid;

		[System.NonSerialized]
		public PlayerHolder playerHolder;

		public void LoadPlayer(PlayerHolder p,PlayerStatsUI statsUI){
			if(p == null){
				return;
			}
			playerHolder = p;

			foreach(CardInstance c in p.downCards){
				if (c == null){
					continue;
				}
				Settings.SetParentForCard(c.viz.gameObject.transform, downGrid.value.transform);
			}

			foreach(CardInstance c in p.handCards){
				if (c.viz != null){
					Settings.SetParentForCard(c.viz.gameObject.transform, handGrid.value.transform);
				}	
			}



			p.statsUI = statsUI;
			p.LoadPlayerOnStatsUI();
		}
	}
}

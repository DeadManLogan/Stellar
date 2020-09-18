using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;


namespace Stellar{
	[CreateAssetMenu(menuName = "Actions/Player Actions/Sync Levels")]
	public class SyncLevels : PlayerAction
	{
		public GameEvent enemyEnable2;
		public GameEvent enemyEnable3;
		public GameEvent enemyDisable2;
		public GameEvent enemyDisable3;
		
		public override void Execute(PlayerHolder player){
			PlayerHolder current = Settings.gameManager.currentPlayer;
			PlayerHolder enemy = Settings.gameManager.GetEnemyOf(current);



			if(current.playerLevel==1){
				current.statsUI.level2.gameObject.SetActive(false);
				current.statsUI.level3.gameObject.SetActive(false);
			}

			else if(current.playerLevel==2){
				current.statsUI.level2.gameObject.SetActive(true);
				current.statsUI.level3.gameObject.SetActive(false);
			}
			else if(current.playerLevel==3){
				current.statsUI.level3.gameObject.SetActive(true);
			}

			if(enemy.playerLevel==1){
				enemyDisable2.Raise();
				enemyDisable3.Raise();
			}

			else if(enemy.playerLevel==2){
				enemyEnable2.Raise();
				enemyDisable3.Raise();
			}
			else if(enemy.playerLevel==3){
				enemyEnable3.Raise();
			}
			foreach(CardInstance c in player.downCards){
				c.state=CardInstance.State.Idle;
			}
		}
	}
}

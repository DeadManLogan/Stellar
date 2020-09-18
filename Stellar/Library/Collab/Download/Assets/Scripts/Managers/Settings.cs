using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;




namespace Stellar{
	public static class Settings {

		public static GameManager gameManager;
		private static ResourcesManager _resourcesManager;

		public static ResourcesManager GetResourcesManager(){
			if(_resourcesManager==null){
				_resourcesManager = Resources.Load("ResourcesManager") as ResourcesManager;
				_resourcesManager.Init();			
			}
			return _resourcesManager;
		}

		public static List<RaycastResult> GetUIObjs(){
			PointerEventData pointerData = new PointerEventData(EventSystem.current){
				position = Input.mousePosition
			};

			List<RaycastResult> results = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerData, results);
			return results;
		}

		public static void DropCreatureCard(Transform c, Transform p , CardInstance cardInst){
			cardInst.state = CardInstance.State.Flatfooted;
			//Execute card special abilities here.
			SetParentForCard(c,p);
			gameManager.currentPlayer.DropCard(cardInst);
		}

		public static void SetParentForCard(Transform c, Transform p){
			c.SetParent(p);
			c.localPosition = Vector3.zero;
			c.localEulerAngles = Vector3.zero;
			c.localScale = Vector3.one;
		}
	}
}

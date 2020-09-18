using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Superclass for all kinds of events a player might cause.
namespace Stellar.GameStates{

	public abstract class Action : ScriptableObject{
		public abstract void Execute(float d);
	}

}

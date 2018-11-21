using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour {
		List<DamageBlock> observers = new List<DamageBlock>();

		public void ToggleColliders(bool enable) {
			foreach (var observer in observers) {
				observer.ToggleCollider(enable);
			}
		}

		public void AddToObserver(DamageBlock observer) {
			observers.Add(observer);
		}
}

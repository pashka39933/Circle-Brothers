using UnityEngine;
using System.Collections;

public class global : MonoBehaviour {

	public static Vector3 rot; // level change rotation memory
	public static bool rdyToChangeLvl = false; // help flag to change lvl
	public static int currentLevel; // current lvl number

	public static int lastLevelLoaded = 0;
	public static int maxLevel = 16;
}

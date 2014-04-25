using UnityEngine;
using System.Collections;

public class TileChain : MonoBehaviour {
	public GameObject[] followingTiles;
	public int[] weightings;
	public int startY;
	public int endY;

	public GameObject GetNextTile () {

		string ws = "";
		float totalWeighting = 0.0f;
		foreach (int w in weightings) {
			totalWeighting += w;
			ws += w + ",";
		}
		float weight = Random.Range (0.0f, totalWeighting);
		
		int c = -1;
		totalWeighting = 0;
		do {
			totalWeighting += weightings[++c];
		} while (weight > totalWeighting);

		return followingTiles [c];
	}
}

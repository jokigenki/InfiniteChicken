using UnityEngine;
using System.Collections;

public class TileRandomiser : MonoBehaviour {

	public Sprite[] tiles;
	void Start () {

		if (tiles != null && tiles.Length > 0) {
			SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();

			Sprite tile = tiles [Random.Range (0, tiles.Length)];
			renderer.sprite = tile;
		}
	}
}

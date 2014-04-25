using UnityEngine;
using System.Collections;

public class GroundSpawner : MonoBehaviour {

	public GameObject startTile;
	public float xSpeed = 0;
	public int preGenerate = 32;
	private GameObject currentTile;
	private TileChain currentChain;
	private float lastXPosition;
	private Vector3 xTransformer;
	private Vector3 yTransformer;

	// TODO: create a pool for the tiles, and recycle them beyond a certain number (based on screen width)
	void Start () {
		lastXPosition = gameObject.transform.position.x;
		lastXPosition = ((int)lastXPosition / 16) * 16;
		xTransformer = new Vector3 ();
		yTransformer = new Vector3 (0, 16, 0);
		currentTile = startTile;
		currentChain = currentTile.GetComponent<TileChain> ();

		xTransformer.x = 16;
		for (int i = 0; i < preGenerate; i++) {
			generate();
		}
	}
	
	void Update () {
		xTransformer.x = xSpeed * Time.deltaTime;
		generate ();
	}

	void generate () {
		gameObject.transform.Translate (xTransformer);
		float currentXPosition = gameObject.transform.position.x;
		float xOffset = currentXPosition - lastXPosition;
		while (xOffset >= 16) {
				// place current tile and move to next x position
				Vector3 position = new Vector3 (lastXPosition + 16, transform.position.y, transform.position.z);
				Instantiate (currentTile, position, Quaternion.identity);
				xOffset -= 16;
	
				GameObject nextTile = currentChain.GetNextTile ();
				TileChain nextChain = nextTile.GetComponent<TileChain> ();
	
				// check if spawner should move up or down
				int yChange = 0;
	
				if (currentChain.endY > nextChain.startY) {
						yChange = 16;
				} else if (currentChain.endY < nextChain.startY) {
						yChange = -16;
				}
	
				yTransformer.y = yChange;
				gameObject.transform.Translate (yTransformer);
	
				currentTile = nextTile;
				currentChain = nextChain;

			lastXPosition = position.x;
		}
	}
}

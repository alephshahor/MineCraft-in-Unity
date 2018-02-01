using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBlock : Block {

	public AirBlock(Vector3 posicion) : base (posicion){}

	public override Tile getTile (Direction direction){
		Tile tile = new Tile();
		switch(direction){

			default:
					tile.positionX = 3;
					tile.positionY = 3;
					break;

		}

			return tile;
	}
}

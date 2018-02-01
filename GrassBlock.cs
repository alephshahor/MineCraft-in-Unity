using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBlock : Block {

		public GrassBlock(Vector3 posicion) : base (posicion){}
		public GrassBlock() : base (){}

		public override Tile getTile (Direction direction){
			Tile tile = new Tile();
			switch(direction){

				case Direction.Up:
						 tile.positionX = 2;
						 tile.positionY = 0;
						 break;

			  case Direction.Down:
						tile.positionX = 1;
						tile.positionY = 0;
						break;

				default:
						tile.positionX = 3;
						tile.positionY = 0;
						break;

			}

				return tile;
		}

}

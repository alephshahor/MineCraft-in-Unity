using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block{

	public Mesh 							blockMesh;
	public List<Vector3> 	    blockVertices;
	public List<int> 					blockTriangles;
	//Vector2[]					blockUvs;
	public List<Vector2>			blockUvs;
	public Vector3  				  blockPosition;
	public float							tileSize = 0.25f; // Because our tile is 4 in the X axis per 4 in the Y axis.
																		 // So if we want to introduce coordinates from 0 - 3 to make it
																		 // easier for us, we need to make that conversion

	public struct Tile{
		public int positionX;
		public int positionY;
	};

	public Block(Vector3 blockPosition){
		//blockMesh = GetComponent<MeshFilter>().mesh;
		blockVertices  = new List<Vector3>();
		blockTriangles = new List<int>();
		blockUvs 			 = new List<Vector2>();
		this.blockPosition = blockPosition;
		createBlock(blockPosition);
		createTexture();
		//createMesh();
	}

	public Block(){
		//blockMesh = GetComponent<MeshFilter>().mesh;
		blockVertices  = new List<Vector3>();
		blockTriangles = new List<int>();
		blockUvs 			 = new List<Vector2>();
	}

/*
	public void Awake(){
		blockMesh = GetComponent<MeshFilter>().mesh;
	}*/

/*
	public void Start(){
		createBlock(new Vector3(1,1,1));
		createTexture();
		//createMesh();
	}*/

/*
	public void createMesh(){

	 	blockMesh.Clear();
		blockMesh.vertices 	= blockVertices.ToArray();
		blockMesh.triangles = blockTriangles.ToArray();
		blockMesh.uv 				= blockUvs.ToArray();
		blockMesh.RecalculateNormals();

	}*/

	// This function needs to be overrided in other Block types.
	// So you actually change the Tile return depending of the
	// face direction.
	public virtual Tile getTile(Direction direction){
				 Tile tile = new Tile();
				 tile.positionX = 3;
				 tile.positionY = 0;
				 return tile;
	}

	public void createFaceTexture(Direction direction){

				 Tile faceTile = getTile(direction);

				 int posX = faceTile.positionX;
				 int posY = faceTile.positionY;

				 blockUvs.Add(new Vector2((tileSize * posX), (tileSize * posY) + tileSize));
				 blockUvs.Add(new Vector2((tileSize * posX), (tileSize * posY)));
				 blockUvs.Add(new Vector2((tileSize * posX) + tileSize, (tileSize * posY)));
				 blockUvs.Add(new Vector2((tileSize * posX) + tileSize, (tileSize * posY) + tileSize));
	}

	public void createTexture(){


				createFaceTexture(Direction.South);
				createFaceTexture(Direction.North);
				createFaceTexture(Direction.Up);
				createFaceTexture(Direction.Down);
				createFaceTexture(Direction.West);
			  createFaceTexture(Direction.East);

	}

	public void createBlock(Vector3 blockPosition){

			 createEastFace(blockPosition);
			 createWestFace(blockPosition);

			 createUpFace(blockPosition);
			 createDownFace(blockPosition);

			 createNorthFace(blockPosition);
			 createSouthFace(blockPosition);

	}

	public void createEastFace(Vector3 blockPosition){
				blockVertices.Add(new Vector3( 1,   1,  1 ) + blockPosition);
				blockVertices.Add(new Vector3( 1,   -1,  1 ) + blockPosition);
				blockVertices.Add(new Vector3( -1,   -1,  1 ) + blockPosition);
				blockVertices.Add(new Vector3( -1,   1,  1 ) + blockPosition);
				//createTriangles();
	}

	public void createWestFace(Vector3 blockPosition){

				blockVertices.Add(new Vector3( -1,   1,  -1 ) + blockPosition);
				blockVertices.Add(new Vector3( -1,   -1,  -1 ) + blockPosition);
				blockVertices.Add(new Vector3( 1,   -1,  -1 ) + blockPosition);
				blockVertices.Add(new Vector3( 1,   1,  -1 ) + blockPosition);

				//createTriangles();
	}

	public void createUpFace(Vector3 blockPosition){

				blockVertices.Add(new Vector3( -1,   1,  1 ) + blockPosition);
				blockVertices.Add(new Vector3( -1,   1,  -1 ) + blockPosition);
				blockVertices.Add(new Vector3( 1,   1,  -1 ) + blockPosition);
				blockVertices.Add(new Vector3( 1,   1,  1 ) + blockPosition);

				//createTriangles();
	}

	public void createDownFace(Vector3 blockPosition){

				blockVertices.Add(new Vector3( -1,   -1,  1 ) + blockPosition);
				blockVertices.Add(new Vector3( 1,   -1,  1 ) + blockPosition);
				blockVertices.Add(new Vector3( 1,  -1,  -1 ) + blockPosition);
				blockVertices.Add(new Vector3( -1,   -1,  -1 ) + blockPosition);

				//createTriangles();
	}

	public void createNorthFace(Vector3 blockPosition){

				blockVertices.Add(new Vector3( 1,   1,  -1 ) + blockPosition);
				blockVertices.Add(new Vector3( 1,   -1,  -1 ) + blockPosition);
				blockVertices.Add(new Vector3( 1,   -1,  1 ) + blockPosition);
				blockVertices.Add(new Vector3( 1,   1,  1 ) + blockPosition);

				//createTriangles();
	}

	public void createSouthFace(Vector3 blockPosition){

				blockVertices.Add(new Vector3( -1,   1,  1 ) + blockPosition);
				blockVertices.Add(new Vector3( -1,   -1,  1 ) + blockPosition);
				blockVertices.Add(new Vector3( -1,   -1,  -1 ) + blockPosition);
				blockVertices.Add(new Vector3( -1,   1,  -1 ) + blockPosition);

				//createTriangles();
	}

/*
	public void createTriangles(){

			int numberVertices = blockVertices.Count;

			blockTriangles.Add(numberVertices - 4);
			blockTriangles.Add(numberVertices - 1);
			blockTriangles.Add(numberVertices - 2);

			blockTriangles.Add(numberVertices - 4);
			blockTriangles.Add(numberVertices - 2);
			blockTriangles.Add(numberVertices - 3);
	}

	public void drawBlock(){
		   blockMesh.Clear();
			 blockMesh.vertices = blockVertices.ToArray();
			 blockMesh.triangles = blockTriangles.ToArray();
			 blockMesh.RecalculateNormals();
	}*/


	public enum Direction{
				North,
				South,
				East,
				West,
				Up,
				Down
	};



}

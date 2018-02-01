using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour{

	Mesh 							blockMesh;
	List<Vector3> 	  blockVertices;
	List<int> 				blockTriangles;
	//Vector2[]					uvS;
	List<Vector2>			uvS;
	Vector3  				  blockPosition;
	public float			tileSize = 0.25f; // Because our tile is 4 in the X axis per 4 in the Y axis.
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
		uvS 					 = new List<Vector2>();
		this.blockPosition = blockPosition;
		createBlock(blockPosition);
		createTexture();
		createMesh();
	}

	public Block(){
		//blockMesh = GetComponent<MeshFilter>().mesh;
		blockVertices  = new List<Vector3>();
		blockTriangles = new List<int>();
		uvS 					 = new List<Vector2>();
	}

	public void Awake(){
		blockMesh = GetComponent<MeshFilter>().mesh;
	}

	public void Start(){
		createBlock(new Vector3(1,1,1));
		createTexture();
		createMesh();
	}

	void createMesh(){
		blockMesh.Clear();
		blockMesh.vertices 	= blockVertices.ToArray();
		blockMesh.triangles = blockTriangles.ToArray();
		blockMesh.uv 				= uvS.ToArray();
		blockMesh.RecalculateNormals();

	}

	// This function needs to be overrided in other Block types
	// So you actually change the Tile return depending of the
	// face direction.
	public Tile getTile(Direction direction){
				 Tile tile = new Tile();
				 tile.positionX = 3;
				 tile.positionY = 0;
				 return tile;
	}

	public void createFaceTexture(Direction direction){

				 Tile faceTile = getTile(direction);

				 int posX = faceTile.positionX;
				 int posY = faceTile.positionY;

				 print("posX -> ");
				 print(posX);

				 uvS.Add(new Vector2((tileSize * posX), (tileSize * posY) + tileSize));
				 uvS.Add(new Vector2((tileSize * posX), (tileSize * posY)));
				 uvS.Add(new Vector2((tileSize * posX) + tileSize, (tileSize * posY)));
				 uvS.Add(new Vector2((tileSize * posX) + tileSize, (tileSize * posY) + tileSize));


	}

	public void createTexture(){

				 createFaceTexture(Direction.North);
				 createFaceTexture(Direction.South);

				 createFaceTexture(Direction.East);
				 createFaceTexture(Direction.West);

				 createFaceTexture(Direction.Up);
				 createFaceTexture(Direction.Down);
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
				blockVertices.Add(new Vector3( blockPosition.z,   blockPosition.y,  blockPosition.x));
				blockVertices.Add(new Vector3( blockPosition.z,   -blockPosition.y,  blockPosition.x));
				blockVertices.Add(new Vector3( -blockPosition.z,   -blockPosition.y,  blockPosition.x));
				blockVertices.Add(new Vector3( -blockPosition.z,   blockPosition.y,  blockPosition.x));
				createTriangles();
	}

	public void createWestFace(Vector3 blockPosition){

				blockVertices.Add(new Vector3( -blockPosition.z,   blockPosition.y,  -blockPosition.x));
				blockVertices.Add(new Vector3( -blockPosition.z,   -blockPosition.y,  -blockPosition.x));
				blockVertices.Add(new Vector3( blockPosition.z,   -blockPosition.y,  -blockPosition.x));
				blockVertices.Add(new Vector3( blockPosition.z,   blockPosition.y,  -blockPosition.x));

				createTriangles();
	}

	public void createUpFace(Vector3 blockPosition){

				blockVertices.Add(new Vector3( -blockPosition.z,   blockPosition.y,  blockPosition.x));
				blockVertices.Add(new Vector3( -blockPosition.z,   blockPosition.y,  -blockPosition.x));
				blockVertices.Add(new Vector3( blockPosition.z,   blockPosition.y,  -blockPosition.x));
				blockVertices.Add(new Vector3( blockPosition.z,   blockPosition.y,  blockPosition.x));

				createTriangles();
	}

	public void createDownFace(Vector3 blockPosition){

				blockVertices.Add(new Vector3( -blockPosition.z,   -blockPosition.y,  blockPosition.x));
				blockVertices.Add(new Vector3( blockPosition.z,   -blockPosition.y,  blockPosition.x));
				blockVertices.Add(new Vector3( blockPosition.z,  -blockPosition.y,  -blockPosition.x));
				blockVertices.Add(new Vector3( -blockPosition.z,   -blockPosition.y,  -blockPosition.x));

				createTriangles();
	}

	public void createNorthFace(Vector3 blockPosition){

				blockVertices.Add(new Vector3( blockPosition.z,   blockPosition.y,  -blockPosition.x));
				blockVertices.Add(new Vector3( blockPosition.z,   -blockPosition.y,  -blockPosition.x));
				blockVertices.Add(new Vector3( blockPosition.z,   -blockPosition.y,  blockPosition.x));
				blockVertices.Add(new Vector3( blockPosition.z,   blockPosition.y,  blockPosition.x));

				createTriangles();
	}

	public void createSouthFace(Vector3 blockPosition){

				blockVertices.Add(new Vector3( -blockPosition.z,   blockPosition.y,  blockPosition.x));
				blockVertices.Add(new Vector3( -blockPosition.z,   -blockPosition.y,  blockPosition.x));
				blockVertices.Add(new Vector3( -blockPosition.z,   -blockPosition.y,  -blockPosition.x));
				blockVertices.Add(new Vector3( -blockPosition.z,   blockPosition.y,  -blockPosition.x));

				createTriangles();
	}

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
	}


	public enum Direction{
				North,
				South,
				East,
				West,
				Up,
				Down
	};



}

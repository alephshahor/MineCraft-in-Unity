using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {

  Mesh mallaChunk;
  public List<Vector3> chunkVertices = new List<Vector3>();
  public List<int>		chunkTriangles = new List<int>();
  public List<Vector2> chunkUvs			 = new List<Vector2>();
  public int chunkSize = 2;

	// Use this for initialization

	void Awake(){
			mallaChunk = GetComponent<MeshFilter>().mesh;
	}

	void Start () {
       createChunk(chunkSize);
       createChunkMesh();

	}

  public void createChunk(int chunkSize){

        for (int xAxis = 0; xAxis < chunkSize; xAxis++){
          for (int yAxis = 0; yAxis < chunkSize; yAxis++){
            for (int zAxis = 0; zAxis < chunkSize; zAxis++){
                  Block newBlock = new GrassBlock(new Vector3(xAxis, yAxis, zAxis));
                  chunkVertices.AddRange(newBlock.blockVertices);
                  chunkUvs.AddRange(newBlock.blockUvs);
            }
          }
        }

        for (int numberVertices = 4; numberVertices < chunkVertices.Count; numberVertices += 4){

           chunkTriangles.Add(numberVertices - 4);
           chunkTriangles.Add(numberVertices - 1);
           chunkTriangles.Add(numberVertices - 2);

           chunkTriangles.Add(numberVertices - 4);
           chunkTriangles.Add(numberVertices - 2);
           chunkTriangles.Add(numberVertices - 3);

        }

  }

  public void createChunkMesh(){

          mallaChunk.Clear();
          mallaChunk.vertices  = chunkVertices.ToArray();
          mallaChunk.triangles = chunkTriangles.ToArray();
          mallaChunk.uv				 = chunkUvs.ToArray();
          mallaChunk.RecalculateNormals();


}

  // This method doesn't work, and I haven't figure out why.
  // It creates the Block but with weird dimensions and if I try to create more than
  // one, the blocks merges and creates more of them, all of them with oversized
  // non cubic shape.
  // It's strange because I'm actually doing the same in createChunk() and it works
  // perfect.

  public void replaceBlock(Vector3 blockPosition){

    Block vlock = new GrassBlock(blockPosition);
    chunkVertices.AddRange(vlock.blockVertices);
    chunkUvs.AddRange(vlock.blockUvs);

         int numberVertices = chunkVertices.Count;

          for (int i = 6; i > 0 ; i -- ){
          chunkTriangles.Add(numberVertices - (4*i) );   // 0 3 2 - 0 2 1
          chunkTriangles.Add(numberVertices - (4*i) + 3);
          chunkTriangles.Add(numberVertices - (4*i) + 2);

          chunkTriangles.Add(numberVertices - (4*i) );
          chunkTriangles.Add(numberVertices - (4*i) + 2);
          chunkTriangles.Add(numberVertices - (4*i) + 1);
        }



  }

// Not being used yet
  public enum typeOfBlock{
         Grass,
         Sky
  };


}

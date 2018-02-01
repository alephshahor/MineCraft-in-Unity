using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

	public Dictionary <Vector3, Chunk> conjuntoChunks = new Dictionary <Vector3, Chunk>();
	public int tamanioChunk = 4;
	List<Vector3> verticesWorld = new List<Vector3>();
	List<int>		triangulosWorld = new List<int>();
	Mesh mallaWorld;

	void Awake(){
			mallaWorld = GetComponent<MeshFilter>().mesh;
	}

	void Start(){
			crearChunks();
			setBloque(new Vector3(4,0,32));
			crearMalla();
			dibujarWorld();
	}

	/* El problema de este método es que World no puede trabajar directamente
		con cada bloque, porque está formando por un conjunto de Chunks */
	void setBloque(Vector3 posicionBloque){

			int ejeX = (int)posicionBloque.x / tamanioChunk;
			int ejeY = (int)posicionBloque.y / tamanioChunk;
			int ejeZ = (int)posicionBloque.z / tamanioChunk;

			Vector3 newKey = new Vector3 ( ejeX * tamanioChunk, ejeY * tamanioChunk, ejeZ * tamanioChunk );

		if (conjuntoChunks.ContainsKey (newKey)){
					//conjuntoChunks[newKey];
					print("Hay un chunk que lo contiene");
				}else{
					print("No hay chunk que lo contenga");
					Chunk nuevoChunk = new Chunk(newKey, tamanioChunk);
					conjuntoChunks.Add(newKey, nuevoChunk);
				}

	}

	void crearChunks(){

				 for (int indice = -tamanioChunk ; indice < tamanioChunk; indice++){
					 Chunk nuevoChunk = new Chunk(new Vector3(0, 0, tamanioChunk * indice), tamanioChunk);
					 conjuntoChunks.Add(new Vector3(0,0,tamanioChunk * indice), nuevoChunk);
				 }
	}

	void crearMalla(){

				foreach( KeyValuePair<Vector3,Chunk> entrada in conjuntoChunks){
								 List<Vector3> verticesChunk = entrada.Value.verticesChunk;
								 verticesWorld.AddRange(verticesChunk);

							 			}

				for (int numeroVertices = 4; numeroVertices <= verticesWorld.Count; numeroVertices += 4){
									triangulosWorld.Add(numeroVertices - 4);
									triangulosWorld.Add(numeroVertices - 3);
									triangulosWorld.Add(numeroVertices - 2);

									triangulosWorld.Add(numeroVertices - 4);
									triangulosWorld.Add(numeroVertices - 2);
									triangulosWorld.Add(numeroVertices - 1);
								}
							}

		void dibujarWorld(){
			mallaWorld.Clear();
			mallaWorld.vertices 	= verticesWorld.ToArray();
			mallaWorld.triangles = triangulosWorld.ToArray();
			mallaWorld.RecalculateNormals();
		}

						}

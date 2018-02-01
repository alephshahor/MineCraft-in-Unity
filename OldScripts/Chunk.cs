using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk {

	private int chunkSize;
	public List<Vector3>  verticesChunk;
	public List<int>			triangulosChunk;
	public Vector3 posicionChunk;
//  public Mesh mallaChunk;

	public Dictionary <Vector3, Bloque> conjuntoBloques;

/* Métodos para probar Chunk de manera ajena a World,
	es necesario convertirla en una clase heredada de MonoBehaviour

	void Awake(){
		mallaChunk = GetComponent<MeshFilter>().mesh;
	}

	void Start(){
		crearChunk(new Vector3(0,0,0));
		crearMalla();
		//unSoloBloque();
		dibujarChunk();
	}*/

	public Chunk(Vector3 posicionChunk, int chunkSize){
			verticesChunk   = new List<Vector3>();
			triangulosChunk = new List<int>();
			conjuntoBloques = new Dictionary<Vector3, Bloque>();
			this.chunkSize  = chunkSize;
			this.posicionChunk 	= posicionChunk;
			crearChunk(posicionChunk);
		}

		Chunk(){
				verticesChunk   = new List<Vector3>();
				triangulosChunk = new List<int>();
				conjuntoBloques = new Dictionary<Vector3, Bloque>();
			}

		public void crearChunk(Vector3 posicion){

				for (int ejeX = 0; ejeX < chunkSize - 1; ejeX++){
					for (int ejeY = 0; ejeY < chunkSize - 1; ejeY++){
						for (int ejeZ = 0; ejeZ < chunkSize - 1; ejeZ++){

								Vector3 posicionActual = new Vector3(ejeX, ejeY, ejeZ) + posicion;
								Bloque nuevoBloque = crearBloque(posicionActual);
								conjuntoBloques.Add(posicionActual, nuevoBloque	);
						}
					}
				}
								crearVerticesChunk();
		}

		public Bloque crearBloque(Vector3 posicion){
					Bloque bloque = new Bloque(posicion);
					return bloque;
		}



		public void crearVerticesChunk(){

			foreach( KeyValuePair<Vector3,Bloque> entrada in conjuntoBloques){
							List<Vector3> verticesBloque = entrada.Value.verticesBloque;
							verticesChunk.AddRange(verticesBloque);
						}

					// Creación de los tríangulos necesaria si se quiere comprobar
					// que Chunk funciona correctamente de manera ajena a World

						/*for (int numeroVertices = 4; numeroVertices <= verticesChunk.Count; numeroVertices += 4){
							triangulosChunk.Add(numeroVertices - 4);
							triangulosChunk.Add(numeroVertices - 3);
							triangulosChunk.Add(numeroVertices - 2);

							triangulosChunk.Add(numeroVertices - 4);
							triangulosChunk.Add(numeroVertices - 2);
							triangulosChunk.Add(numeroVertices - 1);
						}*/


		}

/* Método para establecer los atributos de la malla si se quiere utilizar Chunk de manera separada a World
		public void dibujarChunk(){
			mallaChunk.Clear();
			mallaChunk.vertices = verticesChunk.ToArray();
			mallaChunk.triangles = triangulosChunk.ToArray();
			mallaChunk.RecalculateNormals();
		}
*/




}

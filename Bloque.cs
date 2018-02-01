using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque {


		public Vector3 posicionBloque;
		public List<Vector3> verticesBloque;

		// Constructor por defecto
		public Bloque(Vector3 posicion){
			verticesBloque = new List<Vector3>();
			triangulosBloque = new List<int>();
			posicionBloque = posicion;
			crearBloque(posicion);
		}

		// Método que crea los vértices de un Bloque.
		public void crearBloque (Vector3 posicion){

				crearCara(Direccion.Este,   posicion);
				crearCara(Direccion.Norte,  posicion);
				crearCara(Direccion.Oeste,  posicion);
				crearCara(Direccion.Sur,    posicion);
				crearCara(Direccion.Arriba, posicion);
				crearCara(Direccion.Abajo,  posicion);

			}


		// Método que inserta los vértices de cada cara en la lista 'verticesBloque'
		public void crearCara (Direccion direccion, Vector3 desplazamiento){

					verticesBloque.AddRange(getVerticesCara(direccion, desplazamiento));

		}

		// Método que devuelve los vértices de cada cara según su dirección y desplazamiento
		// respecto al origen.

		public Vector3[] getVerticesCara(Direccion direccion, Vector3 posicion)
		{
			// Vector que contiene los 4 vértices de una cara
			Vector3[] verticesCara = new Vector3[4];
			for (int cara = 0; cara < verticesCara.Length; cara++){
				verticesCara[cara] = vertices_Bloque[carasBloque[(int)direccion][cara]] + posicion ;
			}

			return verticesCara;
		}

		// Array que contiene los ocho vértices de un cubo en el origen.
		public Vector3[] vertices_Bloque = {

			new Vector3	( 1,  1,  1), // 0
			new Vector3	(-1,  1,  1), // 1
			new Vector3	(-1, -1,  1), // 2
			new Vector3	( 1, -1,  1), // 3

			new Vector3	(-1,  1, -1), // 4
			new Vector3	( 1,  1, -1), // 5
			new Vector3	( 1, -1, -1), // 6
			new Vector3	(-1, -1, -1) //  7
		};

		/* Array que contiene el índice de los cuatro vértices que conforman cada
			una de las caras, correspondiendo este índice a cada uno de los vectores3
			de vertices_Bloque.

			Por ejemplo, la cara Norte se crearía a partir de los vértices en
			vertices_Bloque cuyos índices son 5, 0, 3 y 6 */

		public int [][] carasBloque = {

			new int [] {0, 1, 2, 3}, // Este
			new int [] {5, 0, 3, 6}, // Norte
			new int [] {4, 5, 6, 7}, // Oeste

			new int [] {4, 7, 2, 1}, // Sur
			new int [] {6, 3, 2, 7}, // Abajo
			new int [] {1, 0, 5, 4}	 // Arriba
		};

		public enum Direccion{
					Este,
					Norte,
					Oeste,
					Sur,
					Abajo,
					Arriba
			};

}

#region Header

using UnityEngine;    // Use the Methods and Variables located in the default UnityEngine.dll.
using UnityEngine.UI; // Use the Methods and Variables located in the default UnityEngine.UI.dll.

#endregion Header

/**
 * Component Model HexGrid for use in HexGrid Methods.
 * 
 * Copyright (C) 2016  Copyright (C) 2016  Biophase Games
 * 
 * @category Biophase
 * @package Biophase.HexGrid
 * @subpackage HexGrid
 * @copyright Copyright (C) 2016  Biophase Games
 * @license www.gnu.org/licenses/gpl.html
 * @version 0.0.1Alpha
 * @link https://github.com/BiophaseGames/HexGrid
 * @since 2017-01-20
 */

/**
 * Monobehaviour Model HexGrid for use in HexGrid Methods
 */
[AddComponentMenu("Biophase/Hexagonal/Grid")] // Add Component to Biophase Hexagonal Component List.
public class HexGrid : MonoBehaviour
{
	#region Public Variables

	public int width = 6; // Define width of grid. Default is 6.
	public int height = 6; // Define height of grid. Default is 6.

	public HexCell cellPrefab; // Define cell prefab.

	public bool showLabels; // Define whether or not to show position labels.

	public Text cellLabelPrefab; // Define cell labels.

	#endregion Public Variables

	#region Private Variables

	private HexCell[] cells; // Array of all cells in grid.

	private Canvas gridCanvas; // Define Label Canvas.

	private HexMesh hexMesh; // Define the Hex Mesh to use in grid.

	#endregion Private Variables

	#region Private Methods

	/**
	 * Method Name: Awake()
	 * Method Parameters: []
	 * Method Purpose: Assign gridCanvas, hexMesh and cells. Create cells according to size
	 */
	private void Awake()
	{
		gridCanvas = GetComponentInChildren<Canvas> (); // Assign value to gridCanvas.
		hexMesh = GetComponentInChildren<HexMesh> (); // Assign value to hexMesh.

		cells = new HexCell[height * width]; // Define length of cells array.

		for (int z = 0, i = 0; z < height; z++) { // Starting with 0 while z is less than the height of the grid do the following adding 1 to z with each pass.
			for (int x = 0; x < width; x++) { // Starting with 0 while x is less than the width of the grid do the following adding 1 to x with each pass.
				CreateCell (x, z, i++); // Create a cell at position x,z and add 1 to i with each pass.
			}
		}
	}

	/**
	 * Method Name: Start()
	 * Method Parameters: []
	 * Method Purpose: Create Mesh for cells
	 */
	private void Start()
	{
		hexMesh.Triangulate (cells); // Create the Mesh for MeshFilter from the list of cells.
	}

	/**
	 * Method Name: CreateCell()
	 * Method Parameters: [int x, int z, int i]
	 * Method Purpose: Create Cells at x and z coordinates and add to index at i
	 */
	private void CreateCell(int x, int z, int i)
	{
		Vector3 position; // Create cell position.

		position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f); // Define x-axis of position, using formula (x + (z * ((1/2) - (z/2)))).
		position.y = 0f; // Define y-axis of position. with value 0.
		position.z = z * (HexMetrics.outerRadius * 1.5f); // Define z-axis of position, using formula (z * (outerRadius * 1.5)).

		HexCell cell = cells [i] = Instantiate<HexCell> (cellPrefab); // Create Cell Object and add cell to the list of cells at index i.

		cell.transform.SetParent (transform, false); // Define the parent of the cell (The object holding this component).
		cell.transform.localPosition = position; // Place cell at the coordinates defined by position.

		Text label = Instantiate<Text> (cellLabelPrefab); // Create label for Cell.
		label.rectTransform.SetParent (gridCanvas.transform, false); // Define the parent of the cell (parent determined by the value assigned to gridCanvas).
		label.rectTransform.anchoredPosition = new Vector2 (position.x, position.z); // Place Label at the coordinates defined by position;
		label.text = x.ToString () + "\n" + z.ToString (); // Write to text, the value of the coordinates.
	}

	#endregion Private Methods
}

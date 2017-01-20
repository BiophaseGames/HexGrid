#region Header

using UnityEngine;

#endregion Header

/**
 * Metrics Model HexMetrics for use in HexGrid Methods.
 * 
 * Copyright (C) 2016  Copyright (C) 2016  Biophase Games
 * 
 * @category Biophase
 * @package Biophase.HexGrid
 * @subpackage HexMtrics
 * @copyright Copyright (C) 2016  Biophase Games
 * @license www.gnu.org/licenses/gpl.html
 * @version 0.0.1Alpha
 * @link https://github.com/BiophaseGames/HexGrid
 * @since 2017-01-20
 */

/**
 * Metrics Model HexMetrics for use in HexGrid Methods
 */
public static class HexMetrics
{
	#region Constants

	public const float outerRadius = 10f;  // Define the Outer Radius of the Hexagon.
	public const float innerRadius = outerRadius * 0.866025404f; // Define the Inner Radius of the Hexagon.

	#endregion Constants

	#region Statics

	public static Vector3[] corners = { new Vector3 (0f, 0f, outerRadius), new Vector3 (innerRadius, 0f, 0.5f * outerRadius), new Vector3 (innerRadius, 0f, -0.5f * outerRadius), new Vector3 (0f, 0f, -outerRadius), new Vector3 (-innerRadius, 0f, -0.5f * outerRadius), new Vector3 (-innerRadius, 0f, 0.5f * outerRadius)}; // Define the corners of the Hexagon.

	#endregion Statics
}

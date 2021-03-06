﻿// xivModdingFramework
// Copyright © 2018 Rafael Gonzalez - All Rights Reserved
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using SixLabors.ImageSharp.PixelFormats;
using System.Collections.Generic;
using SharpDX;

namespace xivModdingFramework.Models.DataContainers
{
    /// <summary>
    /// This class contains the properties for the Vertex Data
    /// </summary>
    public class VertexData
    {
        /// <summary>
        /// The vertex position data in Vector3 format (X, Y, Z)
        /// </summary>
        public List<Vector3> Positions { get; set; }

        /// <summary>
        /// The bone weight array per vertex
        /// </summary>
        /// <remarks>
        /// Each vertex can hold a maximum of 4 bone weights
        /// </remarks>
        public List<float[]> BoneWeights { get; set; }

        /// <summary>
        /// The bone index array per vertex
        /// </summary>
        /// <remarks>
        /// Each vertex can hold a maximum of 4 bone indices
        /// </remarks>
        public List<byte[]> BoneIndices { get; set; }

        /// <summary>
        /// The vertex normal data in Vector4 format (X, Y, Z, W)
        /// </summary>
        /// <remarks>
        /// The W coordinate is present but has never been noticed to be anything other than 0
        /// </remarks>
        public List<Vector3> Normals { get; set; }

        /// <summary>
        /// The vertex BiNormal data in Vector3 format (X, Y, Z)
        /// </summary>
        public List<Vector3> BiNormals { get; set; }

        /// <summary>
        /// The vertex Tangent data in Vector3 format (X, Y, Z)
        /// </summary>
        public List<Vector3> Tangents { get; set; }

        /// <summary>
        /// The vertex color data in Byte4 format (A, R, G, B)
        /// </summary>
        public List<Byte4> Colors { get; set; }

        /// <summary>
        /// The primary texture coordinates for the mesh in Vector2 format (X, Y)
        /// </summary>
        public List<Vector2> TextureCoordinates0 { get; set; }

        /// <summary>
        /// The secondary texture coordinates for the mesh in Vector2 format (X, Y)
        /// </summary>
        public List<Vector2> TextureCoordinates1 { get; set; }

        /// <summary>
        /// The index data for the mesh
        /// </summary>
        public List<int> Indices { get; set; }
    }
}
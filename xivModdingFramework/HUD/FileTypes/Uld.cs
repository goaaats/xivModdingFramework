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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using xivModdingFramework.General.Enums;
using xivModdingFramework.Helpers;
using xivModdingFramework.SqPack.FileTypes;

namespace xivModdingFramework.HUD.FileTypes
{
    /// <summary>
    ///  This class contains the methods that deal with the .uld file type 
    /// </summary>
    public class Uld
    {
        private readonly DirectoryInfo _gameDirectory;

        public Uld(DirectoryInfo gameDirectory)
        {
            _gameDirectory = gameDirectory;
        }

        /// <summary>
        /// Gets the texture paths from the uld file
        /// </summary>
        /// <returns>List of texture paths from the uld file</returns>
        public List<string> GetTexFromUld()
        {
            var hashedFolder = HashGenerator.GetHash("ui/uld");
            var index = new Index(_gameDirectory);
            var dat = new Dat(_gameDirectory);

            var uldStringList = new HashSet<string>();
            var uldOffsetList = index.GetAllFileOffsetsInFolder(hashedFolder, XivDataFile._06_Ui);

            foreach (var offset in uldOffsetList)
            {
                var uldData = dat.GetType2Data(offset, XivDataFile._06_Ui);

                using (var br = new BinaryReader(new MemoryStream(uldData)))
                {
                    var signature = br.ReadInt32();

                    if (signature != 1751411829) continue;

                    br.ReadBytes(56);

                    int pathCount = br.ReadByte();

                    br.ReadBytes(7);

                    for (var i = 0; i < pathCount; i++)
                    {
                        br.ReadBytes(4);
                        var path = Encoding.UTF8.GetString(br.ReadBytes(48)).Replace("\0", "");

                        if (path.Length <= 2 || !path.Contains("uld")) continue;

                        var uldPath = path.Substring(0, path.LastIndexOf(".", StringComparison.Ordinal) + 4);
                        uldStringList.Add(uldPath);
                    }
                }
            }

            return uldStringList.ToList();
        }
    }
}
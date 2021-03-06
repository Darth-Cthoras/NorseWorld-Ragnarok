/*
 *  "NorseWorld: Ragnarok", a roguelike game for PCs.
 *  Copyright (C) 2002-2008, 2014 by Serg V. Zhdanovskih.
 *
 *  This file is part of "NorseWorld: Ragnarok".
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections.Generic;
using System.IO;
using BSLib;
using ZRLib.Core;

namespace NWR.Core
{
    public sealed class IntList : BaseObject
    {
        private List<int> fList;

        public IntList()
        {
            fList = new List<int>();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                fList.Clear();
                fList = null;
            }
            base.Dispose(disposing);
        }

        public int Count
        {
            get {
                return fList.Count;
            }
        }

        public int this[int index]
        {
            get {
                if (index < 0 || index >= fList.Count) {
                    throw new ListException("List index out of bounds (%d)", index);
                }
                return fList[index];
            }
        }

        public int Add(int item)
        {
            int result = fList.Count;
            fList.Add(item);
            return result;
        }

        public int IndexOf(int item)
        {
            return fList.IndexOf(item);
        }

        public void LoadFromStream(BinaryReader stream, FileVersion version)
        {
            fList.Clear();

            int count = StreamUtils.ReadInt(stream);
            for (int i = 0; i < count; i++) {
                Add(StreamUtils.ReadInt(stream));
            }
        }

        public void SaveToStream(BinaryWriter stream, FileVersion version)
        {
            int count = fList.Count;
            StreamUtils.WriteInt(stream, count);
            for (int i = 0; i < count; i++) {
                StreamUtils.WriteInt(stream, fList[i]);
            }
        }
    }
}

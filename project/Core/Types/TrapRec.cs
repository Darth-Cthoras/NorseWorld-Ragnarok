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

using ZRLib.Core;

namespace NWR.Core.Types
{
    public sealed class TrapRec
    {
        public int TileID;
        public Movements EscMovements;
        public bool Disposable;
        public int EscapeMsgRS;

        public TrapRec(int tileID, Movements escMovements, bool disposable, int escapeMsg)
        {
            TileID = tileID;
            EscMovements = escMovements;
            Disposable = disposable;
            EscapeMsgRS = escapeMsg;
        }

        public TrapRec Clone()
        {
            TrapRec varCopy = new TrapRec(TileID, EscMovements, Disposable, EscapeMsgRS);
            return varCopy;
        }
    }
}
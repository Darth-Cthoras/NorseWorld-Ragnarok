/*
 *  "NorseWorld: Ragnarok", a roguelike game for PCs.
 *  Copyright (C) 2002-2008, 2014 by Serg V. Zhdanovskih (aka Alchemist).
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
package nwr.creatures.brain.goals;

import jzrlib.core.brain.BrainEntity;
import jzrlib.core.FileVersion;
import jzrlib.utils.StreamUtils;
import nwr.creatures.brain.NWGoalEntity;
import java.io.IOException;
import jzrlib.core.Rect;
import jzrlib.external.BinaryInputStream;
import jzrlib.external.BinaryOutputStream;

/**
 *
 * @author Serg V. Zhdanovskih
 */
public abstract class AreaGoal extends NWGoalEntity
{
    public Rect Area;

    public AreaGoal(BrainEntity owner)
    {
        super(owner);
    }

    @Override
    public void/*checked*/ loadFromStream(BinaryInputStream stream, FileVersion version) throws IOException
    {
        super.loadFromStream(stream, version);
        this.Area = StreamUtils.readRect(stream);
    }

    @Override
    public void/*checked*/ saveToStream(BinaryOutputStream stream, FileVersion version) throws IOException
    {
        super.saveToStream(stream, version);
        StreamUtils.writeRect(stream, this.Area);
    }
}

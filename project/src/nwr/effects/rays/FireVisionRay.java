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
package nwr.effects.rays;

import jzrlib.utils.RefObject;
import jzrlib.utils.AuxUtils;
import nwr.creatures.NWCreature;
import nwr.effects.EffectID;
import nwr.effects.EffectsFactory;
import nwr.universe.NWField;

/**
 *
 * @author Serg V. Zhdanovskih
 */
public final class FireVisionRay extends EffectRay
{
    public FireVisionRay()
    {
    }

    @Override
    public void TileProc(int aX, int aY, RefObject<Boolean> aContinue)
    {
        NWField f = this.Field;
        if (f.isBarrier(aX, aY)) {
            aContinue.argValue = false;
        } else {
            NWCreature c = (NWCreature) f.findCreature(aX, aY);
            if (c != null) {
                EffectsFactory.FireHit(EffectID.eid_FireVision, this.Creature, c, AuxUtils.getBoundedRnd(2, 40));
            }
            aContinue.argValue = (c == null);
        }
    }
}

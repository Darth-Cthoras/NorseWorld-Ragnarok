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

using BSLib;
using ZRLib.Engine;

namespace NWR.GUI.Controls
{
    public class HintWindow : BaseHintWindow
    {
        protected override void DoPaintEvent(BaseScreen screen)
        {
            ExtRect crt = ClientRect;
            screen.DrawRectangle(crt, Colors.Black, Colors.Black);
            CtlCommon.DrawCtlBorder(screen, crt);
            screen.SetTextColor(Colors.Gold, true);
            int h = screen.GetTextHeight("W");

            int num = fText.Count;
            for (int i = 0; i < num; i++) {
                screen.DrawText(crt.Left + 8, crt.Top + 8 + i * h, fText[i], 0);
            }
        }

        public HintWindow(BaseControl owner)
            : base(owner)
        {
            Font = CtlCommon.SmFont;
            Margin = 8;
        }
    }
}

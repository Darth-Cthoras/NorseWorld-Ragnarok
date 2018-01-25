/*
 *  "NorseWorld: Ragnarok", a roguelike game for PCs.
 *  Copyright (C) 2002-2008, 2014 by Serg V. Zhdanovskih (aka Alchemist).
 *
 *  this file is part of "NorseWorld: Ragnarok".
 *
 *  this program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  this program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using NWR.Game;
using NWR.GUI.Controls;
using ZRLib.Engine;

namespace NWR.GUI
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class IntroWindow : NWWindow
    {
        private readonly Marquee fMarquee;

        public IntroWindow(BaseControl owner)
            : base(owner)
        {
            Font = CtlCommon.SmFont;
            Width = 590;
            Height = 430;
            WindowStyle = new WindowStyles(WindowStyles.wsScreenCenter, WindowStyles.wsModal, WindowStyles.wsKeyPreview);
            Shifted = false;
            BackDraw = false;

            fMarquee = new Marquee(this);
            fMarquee.ActiveScroll = false;
            fMarquee.Font = CtlCommon.SmFont;
            fMarquee.Left = 10;
            fMarquee.Top = 10;
            fMarquee.Width = 570;
            fMarquee.Height = 410;
            fMarquee.Visible = true;
            fMarquee.OnMouseDown = OnMarqueeMouseDown;
            fMarquee.TextColor = BaseScreen.clGoldenrod;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                fMarquee.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void DoKeyDownEvent(KeyEventArgs eventArgs)
        {
            DoneIntro();
        }

        protected override void DoMouseDownEvent(MouseEventArgs eventArgs)
        {
            base.DoMouseDownEvent(eventArgs);
            DoneIntro();
        }

        protected override void DoShowEvent()
        {
            base.DoShowEvent();

            fMarquee.Lines.BeginUpdate();
            fMarquee.Lines.Text = GetTextFileByLang("Intro");
            fMarquee.Lines.EndUpdate();
        }

        private void DoneIntro()
        {
            Hide();
            GlobalVars.nwrWin.NewGame_Finish();
        }

        private void OnMarqueeMouseDown(object sender, MouseEventArgs eventArgs)
        {
            DoneIntro();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace InputWrapper
{
    internal struct AllInputButtons
    {
        private const Keys kA_ButtonKey = Keys.K;
        private const Keys kB_ButtonKey = Keys.L;
        private const Keys kX_ButtonKey = Keys.J;
        private const Keys kY_ButtonKey = Keys.I;
        private const Keys kBack_ButtonKey = Keys.F1;
        private const Keys kStart_ButtonKey = Keys.F2;


        private ButtonState GetState(ButtonState gameButtonState, Keys key)
        {
            if (Keyboard.GetState().IsKeyDown(key))
                return ButtonState.Pressed;

            if (GamePad.GetState(PlayerIndex.One).IsConnected)
                return gameButtonState;

            return ButtonState.Released;

        }

    }

    class InputWrapper
    {
    }


}

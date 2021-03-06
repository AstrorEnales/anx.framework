using ANX.Framework.NonXNA;
using ANX.Framework.NonXNA.InputSystem;
using ANX.Framework.NonXNA.Development;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.InputDevices.Windows.XInput
{
	[PercentageComplete(100)]
	[TestState(TestStateAttribute.TestState.Tested)]
	[Developer("AstrorEnales")]
	public class KeyboardCreator : IKeyboardCreator
	{
		public string Name
		{
			get
			{
				return "XInput.Keyboard";
			}
		}

		public int Priority
		{
			get
			{
				return 10;
			}
		}

		public IKeyboard CreateDevice()
		{
			return new Keyboard();
		}


        public string Provider
        {
            get { return "XInput"; }
        }
    }
}

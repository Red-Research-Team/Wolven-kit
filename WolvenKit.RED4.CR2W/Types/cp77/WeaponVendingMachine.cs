using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class WeaponVendingMachine : VendingMachine
	{
		private wCHandle<IWorldWidgetComponent> _bigAdScreen;

		[Ordinal(97)] 
		[RED("bigAdScreen")] 
		public wCHandle<IWorldWidgetComponent> BigAdScreen
		{
			get
			{
				if (_bigAdScreen == null)
				{
					_bigAdScreen = (wCHandle<IWorldWidgetComponent>) CR2WTypeManager.Create("whandle:IWorldWidgetComponent", "bigAdScreen", cr2w, this);
				}
				return _bigAdScreen;
			}
			set
			{
				if (_bigAdScreen == value)
				{
					return;
				}
				_bigAdScreen = value;
				PropertySet(this);
			}
		}

		public WeaponVendingMachine(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

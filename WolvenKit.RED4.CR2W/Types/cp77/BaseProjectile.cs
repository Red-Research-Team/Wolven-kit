using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class BaseProjectile : gameItemObject
	{
		private CHandle<gameprojectileComponent> _projectileComponent;
		private wCHandle<gameObject> _user;
		private wCHandle<gameObject> _projectile;
		private Vector4 _projectileSpawnPoint;
		private Vector4 _projectilePosition;
		private CFloat _initialLaunchVelocity;
		private CFloat _lifeTime;
		private CString _tweakDBPath;

		[Ordinal(43)] 
		[RED("projectileComponent")] 
		public CHandle<gameprojectileComponent> ProjectileComponent
		{
			get => GetProperty(ref _projectileComponent);
			set => SetProperty(ref _projectileComponent, value);
		}

		[Ordinal(44)] 
		[RED("user")] 
		public wCHandle<gameObject> User
		{
			get => GetProperty(ref _user);
			set => SetProperty(ref _user, value);
		}

		[Ordinal(45)] 
		[RED("projectile")] 
		public wCHandle<gameObject> Projectile
		{
			get => GetProperty(ref _projectile);
			set => SetProperty(ref _projectile, value);
		}

		[Ordinal(46)] 
		[RED("projectileSpawnPoint")] 
		public Vector4 ProjectileSpawnPoint
		{
			get => GetProperty(ref _projectileSpawnPoint);
			set => SetProperty(ref _projectileSpawnPoint, value);
		}

		[Ordinal(47)] 
		[RED("projectilePosition")] 
		public Vector4 ProjectilePosition
		{
			get => GetProperty(ref _projectilePosition);
			set => SetProperty(ref _projectilePosition, value);
		}

		[Ordinal(48)] 
		[RED("initialLaunchVelocity")] 
		public CFloat InitialLaunchVelocity
		{
			get => GetProperty(ref _initialLaunchVelocity);
			set => SetProperty(ref _initialLaunchVelocity, value);
		}

		[Ordinal(49)] 
		[RED("lifeTime")] 
		public CFloat LifeTime
		{
			get => GetProperty(ref _lifeTime);
			set => SetProperty(ref _lifeTime, value);
		}

		[Ordinal(50)] 
		[RED("tweakDBPath")] 
		public CString TweakDBPath
		{
			get => GetProperty(ref _tweakDBPath);
			set => SetProperty(ref _tweakDBPath, value);
		}

		public BaseProjectile(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

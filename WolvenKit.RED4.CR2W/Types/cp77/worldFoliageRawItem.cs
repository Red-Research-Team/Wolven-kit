using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class worldFoliageRawItem : ISerializable
	{
		private raRef<CMesh> _mesh;
		private CName _meshAppearance;
		private Vector3 _position;
		private Quaternion _rotation;
		private CFloat _scale;

		[Ordinal(0)] 
		[RED("Mesh")] 
		public raRef<CMesh> Mesh
		{
			get => GetProperty(ref _mesh);
			set => SetProperty(ref _mesh, value);
		}

		[Ordinal(1)] 
		[RED("MeshAppearance")] 
		public CName MeshAppearance
		{
			get => GetProperty(ref _meshAppearance);
			set => SetProperty(ref _meshAppearance, value);
		}

		[Ordinal(2)] 
		[RED("Position")] 
		public Vector3 Position
		{
			get => GetProperty(ref _position);
			set => SetProperty(ref _position, value);
		}

		[Ordinal(3)] 
		[RED("Rotation")] 
		public Quaternion Rotation
		{
			get => GetProperty(ref _rotation);
			set => SetProperty(ref _rotation, value);
		}

		[Ordinal(4)] 
		[RED("Scale")] 
		public CFloat Scale
		{
			get => GetProperty(ref _scale);
			set => SetProperty(ref _scale, value);
		}

		public worldFoliageRawItem(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

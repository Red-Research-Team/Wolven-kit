using System.IO;

namespace WolvenKit.Scaleform
{
    public class SofdecStream : Mpeg1Stream
    {
        #region Fields

        public const string AdxAudioExtension = ".adx";
        public const string AixAudioExtension = ".aix";
        public new const string DefaultVideoExtension = ".m2v";
        public static readonly byte[] AixSignatureBytes = new byte[] { 0x41, 0x49, 0x58, 0x46 };

        #endregion Fields

        #region Constructors

        public SofdecStream(string path) : base(path)
        {
            this.FileExtensionAudio = AdxAudioExtension;
            this.FileExtensionVideo = DefaultVideoExtension;
        }

        #endregion Constructors

        #region Methods

        protected override string GetAudioFileExtension(Stream readStream, long currentOffset)
        {
            string fileExtension;
            byte[] checkBytes;

            int headerSize = this.GetAudioPacketHeaderSize(readStream, currentOffset);
            checkBytes = ParseFile.ParseSimpleOffset(readStream, (currentOffset + 6 + headerSize), 4);

            if (ParseFile.CompareSegment(checkBytes, 0, AixSignatureBytes))
            {
                fileExtension = AixAudioExtension;
            }
            else if (checkBytes[0] == 0x80)
            {
                fileExtension = AdxAudioExtension;
            }
            else
            {
                fileExtension = ".bin";
            }

            return fileExtension;
        }

        #endregion Methods
    }
}

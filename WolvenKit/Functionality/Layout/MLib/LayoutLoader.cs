using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WolvenKit.Functionality.Layout.MLib
{
    /// <summary>
    /// Implements base methods and events for loading an AvalonDock layout
    /// in a background thread.
    /// </summary>
    internal class LayoutLoader : IDisposable
    {
        #region fields

        private SemaphoreSlim _LayoutSemaphore;
        private readonly string _layoutFileName;
        private LayoutLoaderResult _LayoutLoaded;

        #endregion fields

        #region ctors

        /// <summary>
        /// Class constructor
        /// </summary>
        public LayoutLoader(string layoutFileName)
            : this()
        {
            _layoutFileName = layoutFileName;
        }

        /// <summary>
        /// Hidden class constructor
        /// </summary>
        protected LayoutLoader()
        {
            _LayoutSemaphore = new SemaphoreSlim(1, 1);
        }

        #endregion ctors

        #region events

        /// <summary>
        /// Implements an event that is raised when the AvalonDock layout
        /// was successfully loaded.
        /// </summary>
        public EventHandler<LayoutLoadedEventArgs> LayoutLoadedEvent;

        private bool _Disposed;

        #endregion events

        #region methods

        /// <summary>
        /// Loads the AvalonDockLayout with a background task and makes the result
        /// available in a private <see cref="_LayoutLoaded"/> field.
        ///
        /// The result can later be queried with the <see cref="GetLayoutString"/> method
        /// which will eiter return the available result of connect to an eventhandler
        /// The will return the result via <see cref="LayoutLoadedEvent"/> as soon as it
        /// is available.
        /// </summary>
        public async Task LoadLayoutAsync()
        {
            try
            {
                var result = await LoadAvalonDockLayoutToStringAsync();

                await _LayoutSemaphore.WaitAsync();
                try
                {
                    _LayoutLoaded = result;

                    // Send an event if event subscriber is available
                    // if MainWindow is already successfull constructed and waiting for Xml Layout
                    LayoutLoadedEvent?.Invoke(this, new LayoutLoadedEventArgs(result));
                }
                finally
                {
                    _LayoutSemaphore.Release();
                }
            }
            catch (Exception exc)
            {
                _LayoutLoaded = new LayoutLoaderResult(null, false, exc);
            }
        }

        #region IDisposable

        /// <summary>
        /// Standard dispose method of the <seealso cref="IDisposable" /> interface.
        /// </summary>
        public void Dispose() => Dispose(true);

        /// <summary>
        /// Source: http://www.codeproject.com/Articles/15360/Implementing-IDisposable-and-the-Dispose-Pattern-P
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_Disposed == false)
            {
                if (disposing == true)
                {
                    // Dispose of the curently displayed content
                    _LayoutSemaphore.Dispose();
                }

                // There are no unmanaged resources to release, but
                // if we add them, they need to be released here.
            }

            _Disposed = true;

            //// If it is available, make the call to the
            //// base class's Dispose(Boolean) method
            ////base.Dispose(disposing);
        }

        #endregion IDisposable

        /// <summary>
        /// Loads the layout object queried via <see cref="LoadLayoutAsync"/> method or
        /// connects the caller to the eventhandler to return the result object at
        /// a later stage (if it was not available at this time).
        /// </summary>
        /// <param name="loadEventHandler"></param>
        /// <returns></returns>
        internal async Task<LayoutLoaderResult> GetLayoutString(EventHandler<LayoutLoadedEventArgs> loadEventHandler)
        {
            await _LayoutSemaphore.WaitAsync();
            try
            {
                if (_LayoutLoaded != null)
                {
                    return _LayoutLoaded;
                }
                else
                {
                    // Attach event to return result later
                    LayoutLoadedEvent += loadEventHandler;

                    return null;
                }
            }
            finally
            {
                _LayoutSemaphore.Release();
            }
        }

        /// <summary>
        /// Reads the AvalonDock layout into a string and returns it with additional
        /// information wrapped into a <see cref="LayoutLoaderResult"/>.
        /// </summary>
        /// <returns></returns>
        private async Task<LayoutLoaderResult> LoadAvalonDockLayoutToStringAsync()
        {
            var path = GetFullPathToLayout();

            if (File.Exists(path) == false)
            {
                return null;
            }

            try
            {
                var textContent = string.Empty;
                // This is the same default buffer size as StreamReader and FileStream
                var DefaultBufferSize = 4096;

                // 1. The file is to be used for asynchronous reading.
                // 2. The file is to be accessed sequentially from beginning to end.
                var DefaultOptions = FileOptions.Asynchronous | FileOptions.SequentialScan;

                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, DefaultBufferSize, DefaultOptions))
                {
                    var bom = new byte[4];
                    await stream.ReadAsync(bom, 0, 4);
                    stream.Seek(0, SeekOrigin.Begin);
                    var fileEncoding = GetEncoding(bom);

                    using var reader = new StreamReader(stream, fileEncoding);
                    textContent = await reader.ReadToEndAsync();
                }

                //Thread.Sleep(2000);
                return new LayoutLoaderResult(textContent, true, null);
            }
            catch (Exception exc)
            {
                return new LayoutLoaderResult(null, false, exc);
            }
        }

        /// <summary>
        /// Gets whether a standard layout file is available for loading.
        /// </summary>
        /// <returns></returns>
        internal bool CanLoadLayout() => System.IO.File.Exists(GetFullPathToLayout());

        /// <summary>
        /// Gets the full path to the layout file that stores the AvalonDock layout
        /// and is used to store/restore the layout of the controls.
        /// </summary>
        /// <returns></returns>
        internal string GetFullPathToLayout() => System.IO.Path.GetFullPath(_layoutFileName);

        /// <summary>
        /// Gets the encoding of a file from its first 4 bytes.
        /// </summary>
        /// <param name="bom">BOM to be translated into an <see cref="Encoding"/>.
        /// This should be at least 4 bytes long.</param>
        /// <returns>Recommended <see cref="Encoding"/> to be used to read text from this file.</returns>
        public Encoding GetEncoding(byte[] bom)
        {
            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76)
            {
#pragma warning disable 618
                return Encoding.UTF7;
            }
#pragma warning restore 618

            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf)
            {
                return Encoding.UTF8;
            }

            if (bom[0] == 0xff && bom[1] == 0xfe)
            {
                return Encoding.Unicode; //UTF-16LE
            }

            if (bom[0] == 0xfe && bom[1] == 0xff)
            {
                return Encoding.BigEndianUnicode; //UTF-16BE
            }

            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff)
            {
                return Encoding.UTF32;
            }

            return Encoding.Default;
        }

        #endregion methods
    }
}

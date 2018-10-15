namespace KattisVSIXStarter
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("362c1389-870b-4442-a8f7-b162177ef9c6")]
    public class KattisDisplayWindow : ToolWindowPane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KattisDisplayWindow"/> class.
        /// </summary>
        public KattisDisplayWindow() : base(null)
        {
            this.Caption = "KattisDisplayWindow";

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            this.Content = new KattisDisplayWindowControl();
        }
    }
}

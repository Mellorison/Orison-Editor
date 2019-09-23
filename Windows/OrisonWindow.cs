using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using OrisonEditor.LevelData;

namespace OrisonEditor.Windows
{
    public partial class OrisonWindow : Form
    {
        public enum HorizontalSnap { None, Left, Right };
        public enum VerticalSnap { None, Top, Bottom };

        private const int SNAP_RANGE = 18;

        private HorizontalSnap startHSnap;
        private VerticalSnap startVSnap;
        private HorizontalSnap hSnap;
        private VerticalSnap vSnap;

        //The window will only be visible if both of the following are true:
        private bool userVisible;       // Whether the user has specified that this window should be visible
        private bool editorVisible;     // Whether the current editor state allows this window to be visible

        public OrisonWindow()
            : this(HorizontalSnap.None, VerticalSnap.None)
        {

        }

        public OrisonWindow(HorizontalSnap startHSnap, VerticalSnap startVSnap)
        {
            this.startHSnap = startHSnap;
            this.startVSnap = startVSnap;
            InitializeComponent();

            userVisible = true;
            editorVisible = false;

            //Events
            Shown += onShown;
            Resize += enforceSnap;
            Move += checkSnap;
            Orison.MainWindow.Resize += enforceSnap;
            Orison.MainWindow.LocationChanged += enforceSnap;
            Orison.MainWindow.KeyDown += onKeyDown;
            KeyDown += onKeyDown;
            Orison.OnProjectClose += onProjectClose;
            Orison.OnLevelClosed += onLevelClose;
            Orison.OnLevelChanged += new Orison.LevelCallback(Orison_OnLevelChanged);
        }

        void Orison_OnLevelChanged(int index)
        {
            EditorVisible = ShouldBeVisible();
        }

        protected virtual void handleKeyDown(KeyEventArgs e)
        {
            //Override me!
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        public virtual bool ShouldBeVisible()
        {
            return true;
        }

        /*
         *  Visibility helpers
         */
        public bool UserVisible
        {
            get { return userVisible; }
            set
            {
                userVisible = value;
                Visible = userVisible && editorVisible;
            }
        }

        public bool EditorVisible
        {
            get { return editorVisible; }
            set
            {
                editorVisible = value;
                Visible = userVisible && editorVisible;
            }
        }

        /*
         *  Snapping to edges helpers
         */
        private void checkSnap(object sender = null, EventArgs e = null)
        {
            Rectangle r = Orison.MainWindow.EditBounds;
            Point p = Location;

            //Check for X snap
            if (Math.Abs(p.X - r.X) <= SNAP_RANGE)
            {
                hSnap = HorizontalSnap.Left;
                p.X = r.X;
            }
            else if (Math.Abs((p.X + Width) - (r.X + r.Width)) <= SNAP_RANGE)
            {
                hSnap = HorizontalSnap.Right;
                p.X = r.X + r.Width - Width;
            }
            else
                hSnap = HorizontalSnap.None;

            //Check for Y snap
            if (Math.Abs(p.Y - r.Y) <= SNAP_RANGE)
            {
                vSnap = VerticalSnap.Top;
                p.Y = r.Y;
            }
            else if (Math.Abs((p.Y + Height) - (r.Y + r.Height)) <= SNAP_RANGE)
            {
                vSnap = VerticalSnap.Bottom;
                p.Y = r.Y + r.Height - Height;
            }
            else
                vSnap = VerticalSnap.None;

            Location = p;
        }

        private void enforceSnap(object sender = null, EventArgs e = null)
        {
            Rectangle r = Orison.MainWindow.EditBounds;
            Point p = Location;

            //Check for X snap
            if (hSnap == HorizontalSnap.Left)
                p.X = r.X;
            else if (hSnap == HorizontalSnap.Right)
                p.X = r.X + r.Width - Width;

            //Check for Y snap
            if (vSnap == VerticalSnap.Top)
                p.Y = r.Y;
            else if (vSnap == VerticalSnap.Bottom)
                p.Y = r.Y + r.Height - Height;

            Location = p;
        }

        /*
         *  Events
         */
        private void onLevelClose(int index)
        {
            if (Orison.Levels.Count == 0)
                EditorVisible = false;
        }

        private void onProjectClose(Project project)
        {
            EditorVisible = false;
        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            handleKeyDown(e);
        }

        private void onShown(object sender, EventArgs e)
        {
            hSnap = startHSnap;
            vSnap = startVSnap;
            enforceSnap();
        }

        private void OrisonWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                UserVisible = false;
                Orison.MainWindow.Focus();
            }
        }
    }
}

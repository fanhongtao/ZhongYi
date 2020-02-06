using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// ԭʼ�������ԣ� https://www.cnblogs.com/ahdung/p/FloatLayerBase.html
namespace AhDung.WinForm.Controls
{
    /// <summary>
    /// ���������
    /// </summary>
    public class FloatLayerBase : Form
    {
        #region Fields & Properties

        /// <summary>
        /// �����Ϣɸѡ��
        /// </summary>
        //���ڱ�����ΪWS_CHILD�����Բ����յ��ڴ���������������Ϣ
        //����Ϣɸѡ�������þ����ñ������֪����������������������Ƿ��ڱ������������������������Ӧ����
        readonly AppMouseMessageHandler _mouseMsgFilter;

        /// <summary>
        /// ָʾ�������Ƿ���ShowDialog��
        /// </summary>
        //���ڶ��ShowDialog��ʹOnLoad/OnShown���룬�������ô˱���Թ�����ʱ�ж�
        bool _isShowDialogAgain;

        #region �߿�����ֶ�
        BorderStyle _borderType;
        Border3DStyle _border3DStyle;
        ButtonBorderStyle _borderSingleStyle;
        Color _borderColor;

        /// <summary>
        /// ��ȡ�����ñ߿�����
        /// </summary>
        [Description("��ȡ�����ñ߿����͡�")]
        [DefaultValue(BorderStyle.Fixed3D)]
        public BorderStyle BorderType
        {
            get { return _borderType; }
            set
            {
                if (_borderType == value) { return; }
                _borderType = value;
                Invalidate();
            }
        }

        /// <summary>
        /// ��ȡ��������ά�߿���ʽ
        /// </summary>
        [Description("��ȡ��������ά�߿���ʽ��")]
        [DefaultValue(Border3DStyle.RaisedInner)]
        public Border3DStyle Border3DStyle
        {
            get { return _border3DStyle; }
            set
            {
                if (_border3DStyle == value) { return; }
                _border3DStyle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// ��ȡ���������ͱ߿���ʽ
        /// </summary>
        [Description("��ȡ���������ͱ߿���ʽ��")]
        [DefaultValue(ButtonBorderStyle.Solid)]
        public ButtonBorderStyle BorderSingleStyle
        {
            get { return _borderSingleStyle; }
            set
            {
                if (_borderSingleStyle == value) { return; }
                _borderSingleStyle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// ��ȡ�����ñ߿���ɫ�������߿�����Ϊ����ʱ��Ч��
        /// </summary>
        [Description("��ȡ�����ñ߿���ɫ�������߿�����Ϊ����ʱ��Ч����")]
        [DefaultValue(typeof(Color), "DarkGray")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                if (_borderColor == value) { return; }
                _borderColor = value;
                Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// ��ȡ������ �����ܷ�����϶�
        /// <value><c>true</c> ������Ա��϶�; <c>false</c> ���岻�����϶�.</value>
        /// </summary>
        [Description("��ȡ������ �����ܷ�����϶���")]
        [DefaultValue(true)]
        public bool Movable { get; set; }

        #endregion

        protected override sealed CreateParams CreateParams
        {
            get
            {
                CreateParams prms = base.CreateParams;

                //prms.Style = 0;
                //prms.Style |= -2147483648;   //WS_POPUP
                prms.Style |= 0x40000000;      //WS_CHILD  ��Ҫ��ֻ��CHILD����Ų����������役��
                prms.Style |= 0x4000000;       //WS_CLIPSIBLINGS
                prms.Style |= 0x10000;         //WS_TABSTOP
                prms.Style &= ~0x40000;        //WS_SIZEBOX       ȥ��
                prms.Style &= ~0x800000;       //WS_BORDER        ȥ��
                prms.Style &= ~0x400000;       //WS_DLGFRAME      ȥ��
                //prms.Style &= ~0x20000;      //WS_MINIMIZEBOX   ȥ��
                //prms.Style &= ~0x10000;      //WS_MAXIMIZEBOX   ȥ��

                prms.ExStyle = 0;
                //prms.ExStyle |= 0x1;         //WS_EX_DLGMODALFRAME ����߿�
                //prms.ExStyle |= 0x8;         //WS_EX_TOPMOST
                prms.ExStyle |= 0x10000;       //WS_EX_CONTROLPARENT
                //prms.ExStyle |= 0x80;        //WS_EX_TOOLWINDOW
                //prms.ExStyle |= 0x100;       //WS_EX_WINDOWEDGE
                //prms.ExStyle |= 0x8000000;   //WS_EX_NOACTIVATE
                //prms.ExStyle |= 0x4;         //WS_EX_NOPARENTNOTIFY

                return prms;
            }
        }

        //���캯��
        public FloatLayerBase()
        {
            //��ʼ����Ϣɸѡ������Ӻ��Ƴ�����ʾ/����ʱ����
            _mouseMsgFilter = new AppMouseMessageHandler(this);

            //��ʼ����������
            InitBaseProperties();

            //��ʼ���߿����
            _borderType = BorderStyle.Fixed3D;
            _border3DStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            _borderSingleStyle = ButtonBorderStyle.Solid;
            _borderColor = Color.DarkGray;
            Movable = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            //��ֹ����
            if (_isShowDialogAgain) { return; }

            //��ü�������߿��ȣ�����ʱ�ߴ�������ʱ��ȫ�����ԭ����
            //ȷ����ControlBox��FormBorderStyle�йأ���������ϵ����
            if (!DesignMode)
            {
                Size size = SystemInformation.FrameBorderSize;
                this.Size -= size + size;//��������ClientSize�����߻���ݴ��ڷ�����µ���Size
            }
            base.OnLoad(e);
        }

        protected override void OnShown(EventArgs e)
        {
            //��ֹ����
            if (_isShowDialogAgain) { return; }

            //��OnShown��Ϊ�״�ShowDialog����
            if (Modal) { _isShowDialogAgain = true; }

            if (!DesignMode)
            {
                //�����׿ؼ�
                Control firstControl;
                if ((firstControl = GetNextControl(this, true)) != null)
                {
                    firstControl.Focus();
                }
            }
            base.OnShown(e);
        }

        protected override void WndProc(ref Message m)
        {
            //����������ΪShowDialog����ʱ�����յ�WM_SHOWWINDOWǰ��Owner�ᱻDisable
            //�������յ�����Ϣ������Enable������ȻOwner����ͱ����嶼����������Ӧ״̬
            if (m.Msg == 0x18 && m.WParam != IntPtr.Zero && m.LParam == IntPtr.Zero
                && Modal && Owner != null && !Owner.IsDisposed)
            {
                if (Owner.IsMdiChild)
                {
                    //��Owner��MDI�Ӵ���ʱ����Disable����MDI������
                    //����ParentҲ��ָ��MDI�����壬����Ļ�ΪOwner���������������Location�Ż������Owner����MDIParent
                    NativeMethods.EnableWindow(Owner.MdiParent.Handle, true);
                    NativeMethods.SetParent(this.Handle, Owner.Handle);//ֻ����API����Parent����Ϊģʽ������TopLevel��.Net�ܾ�Ϊ������������Parent
                }
                else
                {
                    NativeMethods.EnableWindow(Owner.Handle, true);
                }
            }
            base.WndProc(ref m);
        }

        //���߿�
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            if (_borderType == BorderStyle.Fixed3D)//����3D�߿�
            {
                ControlPaint.DrawBorder3D(e.Graphics, ClientRectangle, Border3DStyle);
            }
            else if (_borderType == BorderStyle.FixedSingle)//�������ͱ߿�
            {
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, BorderColor, BorderSingleStyle);
            }
        }

        //��ʾ����������Ϣɸѡ���Կ�ʼ��׽������ʱ���Ƴ�ɸѡ����֮���Բ���Dispose�����뾡���Ƴ�ɸѡ��
        protected override void OnVisibleChanged(EventArgs e)
        {
            if (!DesignMode)
            {
                if (Visible) { Application.AddMessageFilter(_mouseMsgFilter); }
                else { Application.RemoveMessageFilter(_mouseMsgFilter); }
            }
            base.OnVisibleChanged(e);
        }

        //ʵ�ִ���ͻ����϶�
        //��WndProc��ʵ��������鷳�����Էŵ�������
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (Movable) {
                //��������ͻ���ʱ�ﵽ����������һ����Ч�����Դ�ʵ�ֿͻ����϶�
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, 0xA1/*WM_NCLBUTTONDOWN*/, (IntPtr)2/*CAPTION*/, IntPtr.Zero);
            }

            base.OnMouseDown(e);
        }

        /// <summary>
        /// ��ʾΪģʽ����
        /// </summary>
        /// <param name="control">��ʾ�ڸÿؼ��·�</param>
        public DialogResult ShowDialog(Control control)
        {
            return ShowDialog(control, 0, control.Height);
        }

        /// <summary>
        /// ��ʾΪģʽ����
        /// </summary>
        /// <param name="control">������������Ŀؼ�</param>
        /// <param name="offsetX">���controlˮƽƫ��</param>
        /// <param name="offsetY">���control��ֱƫ��</param>
        public DialogResult ShowDialog(Control control, int offsetX, int offsetY)
        {
            return ShowDialog(control, new Point(offsetX, offsetY));
        }

        /// <summary>
        /// ��ʾΪģʽ����
        /// </summary>
        /// <param name="control">������������Ŀؼ�</param>
        /// <param name="offset">���controlƫ��</param>
        public DialogResult ShowDialog(Control control, Point offset)
        {
            return this.ShowDialogInternal(control, offset);
        }

        /// <summary>
        /// ��ʾΪģʽ����
        /// </summary>
        /// <param name="item">��ʾ�ڸù���������·�</param>
        public DialogResult ShowDialog(ToolStripItem item)
        {
            return ShowDialog(item, 0, item.Height);
        }

        /// <summary>
        /// ��ʾΪģʽ����
        /// </summary>
        /// <param name="item">������������Ĺ�������</param>
        /// <param name="offsetX">���itemˮƽƫ��</param>
        /// <param name="offsetY">���item��ֱƫ��</param>
        public DialogResult ShowDialog(ToolStripItem item, int offsetX, int offsetY)
        {
            return ShowDialog(item, new Point(offsetX, offsetY));
        }

        /// <summary>
        /// ��ʾΪģʽ����
        /// </summary>
        /// <param name="item">������������Ĺ�������</param>
        /// <param name="offset">���itemƫ��</param>
        public DialogResult ShowDialog(ToolStripItem item, Point offset)
        {
            return this.ShowDialogInternal(item, offset);
        }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="control">��ʾ�ڸÿؼ��·�</param>
        public void Show(Control control)
        {
            Show(control, 0, control.Height);
        }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="control">������������Ŀؼ�</param>
        /// <param name="offsetX">���controlˮƽƫ��</param>
        /// <param name="offsetY">���control��ֱƫ��</param>
        public void Show(Control control, int offsetX, int offsetY)
        {
            Show(control, new Point(offsetX, offsetY));
        }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="control">������������Ŀؼ�</param>
        /// <param name="offset">���controlƫ��</param>
        public void Show(Control control, Point offset)
        {
            this.ShowInternal(control, offset);
        }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="item">��ʾ�ڸù������·�</param>
        public void Show(ToolStripItem item)
        {
            Show(item, 0, item.Height);
        }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="item">������������Ĺ�������</param>
        /// <param name="offsetX">���itemˮƽƫ��</param>
        /// <param name="offsetY">���item��ֱƫ��</param>
        public void Show(ToolStripItem item, int offsetX, int offsetY)
        {
            Show(item, new Point(offsetX, offsetY));
        }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="item">������������Ĺ�������</param>
        /// <param name="offset">���itemƫ��</param>
        public void Show(ToolStripItem item, Point offset)
        {
            this.ShowInternal(item, offset);
        }

        /// <summary>
        /// ShowDialog�ڲ�����
        /// </summary>
        private DialogResult ShowDialogInternal(Component controlOrItem, Point offset)
        {
            //�����������������彫�п���������δHide��������ٴε�������������쳣������������
            if (this.Visible) { return System.Windows.Forms.DialogResult.None; }

            this.SetLocationAndOwner(controlOrItem, offset);
            return base.ShowDialog();
        }

        /// <summary>
        /// Show�ڲ�����
        /// </summary>
        private void ShowInternal(Component controlOrItem, Point offset)
        {
            if (this.Visible) { return; }//ԭ���ShowDialogInternal

            this.SetLocationAndOwner(controlOrItem, offset);
            base.Show();
        }

        /// <summary>
        /// �������꼰������
        /// </summary>
        /// <param name="controlOrItem">�ؼ��򹤾�����</param>
        /// <param name="offset">���ƫ��</param>
        private void SetLocationAndOwner(Component controlOrItem, Point offset)
        {
            Point pt = Point.Empty;

            if (controlOrItem is ToolStripItem)
            {
                ToolStripItem item = (ToolStripItem)controlOrItem;
                pt.Offset(item.Bounds.Location);
                controlOrItem = item.Owner;
            }

            Control c = (Control)controlOrItem;
            pt.Offset(GetControlLocationInForm(c));
            pt.Offset(offset);
            this.Location = pt;

            //����Owner������Show[Dialog](Owner)�в�ͬ����Owner��MDIChildʱ�����߻��OwnerΪMDIParent
            this.Owner = c.FindForm();
        }

        /// <summary>
        /// ��ȡ�ؼ��ڴ����е�����
        /// </summary>
        private static Point GetControlLocationInForm(Control c)
        {
            Point pt = c.Location;
            while (!((c = c.Parent) is Form))
            {
                pt.Offset(c.Location);
            }
            return pt;
        }

        #region ���ζԱ���Ӱ���ش�Ļ��෽��������

        /// <summary>
        /// ��ʼ�����ֻ�������
        /// </summary>
        private void InitBaseProperties()
        {
            base.ControlBox = false;                           //��Ҫ
            //�������SizableToolWindow����֧�ֵ�����С��ͬʱ������SystemInformation.MinWindowTrackSize������
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            base.Text = string.Empty;                          //��Ҫ
            base.HelpButton = false;
            base.Icon = null;
            base.IsMdiContainer = false;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.Manual;     //��Ҫ
            base.TopMost = false;
            base.WindowState = FormWindowState.Normal;
        }

        //����ԭ����
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("��ʹ�ñ�����أ�", true)]
        public new DialogResult ShowDialog() { throw new NotImplementedException(); }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("��ʹ�ñ�����أ�", true)]
        public new DialogResult ShowDialog(IWin32Window owner) { throw new NotImplementedException(); }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("��ʹ�ñ�����أ�", true)]
        public new void Show() { throw new NotImplementedException(); }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("��ʹ�ñ�����أ�", true)]
        public new void Show(IWin32Window owner) { throw new NotImplementedException(); }

        //����ԭ����
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("���ø����ԣ�", true)]
        public new bool ControlBox { get { return false; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("���ñ߿���ʹ��Border������ԣ�", true)]
        public new FormBorderStyle FormBorderStyle { get { return System.Windows.Forms.FormBorderStyle.SizableToolWindow; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("���ø����ԣ�", true)]
        public override sealed string Text { get { return string.Empty; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("���ø����ԣ�", true)]
        public new bool HelpButton { get { return false; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("���ø����ԣ�", true)]
        public new Image Icon { get { return null; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("���ø����ԣ�", true)]
        public new bool IsMdiContainer { get { return false; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("���ø����ԣ�", true)]
        public new bool MaximizeBox { get { return false; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("���ø����ԣ�", true)]
        public new bool MinimizeBox { get { return false; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("���ø����ԣ�", true)]
        public new bool ShowIcon { get { return false; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("���ø����ԣ�", true)]
        public new bool ShowInTaskbar { get { return false; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("���ø����ԣ�", true)]
        public new FormStartPosition StartPosition { get { return FormStartPosition.Manual; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("���ø����ԣ�", true)]
        public new bool TopMost { get { return false; } set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("���ø����ԣ�", true)]
        public new FormWindowState WindowState { get { return FormWindowState.Normal; } set { } }

        #endregion

        /// <summary>
        /// ���������Ϣɸѡ��
        /// </summary>
        private class AppMouseMessageHandler : IMessageFilter
        {
            readonly FloatLayerBase _layerForm;

            public AppMouseMessageHandler(FloatLayerBase layerForm)
            {
                _layerForm = layerForm;
            }

            public bool PreFilterMessage(ref Message m)
            {
                //����ڱ�������������꣬���ر�����
                //�����ڵ�����������������ȷǿͻ���ҲҪ�ñ�������ʧ��ȡ��0xA1��ע�ͼ���
                //�����Ǹ��������жϣ�����Ը�Ϊ���ݾ������Ҫ��������ؼ�
                //֮������API������Form.DesktopBounds����Ϊ���߲��ɿ�
                if ((m.Msg == 0x201/*|| m.Msg==0xA1*/)
                    && _layerForm.Visible && !NativeMethods.GetWindowRect(_layerForm.Handle).Contains(MousePosition))
                {
                    _layerForm.Hide();//֮���Բ�Close�ǿ���Ӧ���ɵ����߸�������
                }

                return false;
            }
        }

        /// <summary>
        /// API��װ��
        /// </summary>
        private static class NativeMethods
        {
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll")]
            public static extern bool ReleaseCapture();

            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

            [StructLayout(LayoutKind.Sequential)]
            private struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;

                public static explicit operator Rectangle(RECT rect)
                {
                    return new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);
                }
            }

            public static Rectangle GetWindowRect(IntPtr hwnd)
            {
                RECT rect;
                GetWindowRect(hwnd, out rect);
                return (Rectangle)rect;
            }

            //[DllImport("user32.dll", ExactSpelling = true)]
            //public static extern IntPtr GetAncestor(IntPtr hwnd, uint flags);
        }
    }
}
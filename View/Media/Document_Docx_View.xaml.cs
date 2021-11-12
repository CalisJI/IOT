using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using DevExpress.XtraRichEdit.API.Layout;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.Xpf.DemoBase;
using DevExpress.Xpf.RichEdit;
using DevExpress.Xpf.Utils;
using DevExpress.DemoData.Models;
using DevExpress.Web.Demos;
using Category = DevExpress.DemoData.Models.Category;
using DevExpress.Mvvm.UI;
using System.DirectoryServices.AccountManagement;
using DevExpress.XtraRichEdit;
using System.Windows.Threading;

namespace WPF_TEST.View
{
    /// <summary>
    /// Interaction logic for Document_Docx_View.xaml
    /// </summary>
    public partial class Document_Docx_View : UserControl 
    {
        static readonly DependencyProperty PageCountProperty = DependencyProperty.Register("PageCount", typeof(int), typeof(Document_Docx_View), new PropertyMetadata(1));
        static readonly DependencyProperty ActivePageNumberProperty = DependencyProperty.Register("ActivePageNumber", typeof(int), typeof(Document_Docx_View), new PropertyMetadata(1));
        static readonly DependencyProperty WordCountProperty = DependencyProperty.Register("WordCount", typeof(int), typeof(Document_Docx_View), new PropertyMetadata(0));
        private DispatcherTimer docummentStatisticsTimer;

        //static readonly DependencyProperty ActiveViewZoomProperty = DependencyProperty.Register("ActiveViewZoom", typeof(float), typeof(Document_Docx_View), new PropertyMetadata(100f, OnActiveViewZoomChanged));



        //static void OnActiveViewZoomChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        //{
        //    Document_Docx_View document_Docx_View = (Document_Docx_View)obj;
        //    document_Docx_View.RichEditControl.ActiveView.ZoomFactor = (float)e.NewValue / 100;
        //}
        public Document_Docx_View()
        {
            InitializeComponent();
            //this.docummentStatisticsTimer = new DispatcherTimer();
            //this.docummentStatisticsTimer.Tick += DocummentStatisticsTimer_Tick;
            //this.docummentStatisticsTimer.Start();
        }

        //private void DocummentStatisticsTimer_Tick(object sender, EventArgs e)
        //{
        //    this.docummentStatisticsTimer.Stop();
        //    Dispatcher.BeginInvoke(new Action(() => {
        //        StaticsticsVisitor visitor = CalculateDocumentStatistics(this.includeTextBoxes);
        //        WordCount = visitor.WordCount;
        //    }));
        //}

        private void RichEditControl_InvalidFormatException(object sender, RichEditInvalidFormatExceptionEventArgs e)
        {
            MessageBox.Show(string.Format("Không thể mở File'{0}' vì định dạng hỗ trợ không hợp lệ.\n" +
                "Xác minh rằng tệp không bị hỏng và phần mở rộng tệp phù hợp với định dạng của tệp.",richedit.DocumentSource),
                "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void RichEditControl_DocumentClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (richedit.Modified) 
            {
                string currenFileName = richedit.DocumentSource.ToString();
            }
            richedit.SaveDocument();
        }

        private void RichEditControl_VisiblePagesChanged(object sender, EventArgs e)
        {

        }

        private void RichEditControl_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void RichEditControl_ContentChanged(object sender, EventArgs e)
        {

        }

        private void RichEditControl_ZoomChanged(object sender, EventArgs e)
        {

        }
    }

    public class RichEditDemoModule : DemoModule 
    {
        static readonly DependencyPropertyKey RichEditControlPropertyKey;
        public static readonly DependencyProperty RichEditControlProperty;

        static RichEditDemoModule()
        {
            //NWindContext.Preload();
            RichEditControlPropertyKey = DependencyPropertyManager.RegisterReadOnly("RichEditControl", typeof(RichEditControl), typeof(RichEditDemoModule), new FrameworkPropertyMetadata(null));
            RichEditControlProperty = RichEditControlPropertyKey.DependencyProperty;
        }

        public RichEditControl RichEditControl
        {
            get { return (RichEditControl)GetValue(RichEditControlProperty); }
            private set { SetValue(RichEditControlPropertyKey, value); }
        }

        void OnRichEditControlLoaded(object sender, RoutedEventArgs e)
        {
            SetFocus(RichEditControl);
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            RichEditControl = Content as RichEditControl ?? LayoutTreeHelper.GetVisualChildren((DependencyObject)Content).OfType<RichEditControl>().FirstOrDefault();
            if (RichEditControl != null)
            {
                RichEditControl.Loaded += OnRichEditControlLoaded;
                new RichEditDemoExceptionsHandler(RichEditControl).Install();
                SetBehaviorOptions();
                RichEditControl.AnnotationOptions.Author = GetCurrentUserDisplayName();

            }
        }
        string GetCurrentUserDisplayName()
        {
            try
            {
                return UserPrincipal.Current.DisplayName;
            }
            catch
            {
                return null;
            }
        }
        void SetBehaviorOptions()
        {
            RichEditControl.BehaviorOptions.FontSource = DevExpress.XtraRichEdit.RichEditBaseValueSource.Document;
            RichEditControl.BehaviorOptions.ForeColorSource = DevExpress.XtraRichEdit.RichEditBaseValueSource.Document;
        }
        protected internal virtual void SetFocus(RichEditControl control)
        {
            if (control == null)
                return;
            if (control.KeyCodeConverter != null)
                control.KeyCodeConverter.Focus();
        }
        protected override void ShowPopupContent()
        {
            base.ShowPopupContent();
            if (RichEditControl != null)
                RichEditControl.ShowHoverMenu = true;
        }
        protected override void HidePopupContent()
        {
            if (RichEditControl != null)
                RichEditControl.ShowHoverMenu = false;
            base.HidePopupContent();
        }
    }
    public class RichEditDemoExceptionsHandler
    {
        readonly RichEditControl control;
        public RichEditDemoExceptionsHandler(RichEditControl control)
        {
            this.control = control;
        }
        public void Install()
        {
            if (control != null)
                control.UnhandledException += OnRichEditControlUnhandledException;
        }

        void OnRichEditControlUnhandledException(object sender, RichEditUnhandledExceptionEventArgs e)
        {
            try
            {
                if (e.Exception != null)
                    throw e.Exception;
            }
            catch (RichEditUnsupportedFormatException ex)
            {
                ShowMessage(ex.Message);
                e.Handled = true;
            }
            catch (System.Runtime.InteropServices.ExternalException ex)
            {
                ShowMessage(ex.Message);
                e.Handled = true;
            }
            catch (System.IO.IOException ex)
            {
                ShowMessage(ex.Message);
                e.Handled = true;
            }
            catch (System.InvalidOperationException ex)
            {
                if (ex.Message == DevExpress.XtraRichEdit.Localization.XtraRichEditLocalizer.GetString(DevExpress.XtraRichEdit.Localization.XtraRichEditStringId.Msg_MagicNumberNotFound) ||
                    ex.Message == DevExpress.XtraRichEdit.Localization.XtraRichEditLocalizer.GetString(DevExpress.XtraRichEdit.Localization.XtraRichEditStringId.Msg_UnsupportedDocVersion))
                {
                    ShowMessage(ex.Message);
                    e.Handled = true;
                }
                else
                    throw ex;
            }
            catch (SystemException ex)
            {
                ShowMessage(ex.Message);
                e.Handled = true;
            }
        }
        void ShowMessage(string message)
        {
            DXMessageBox.Show(message, System.Windows.Forms.Application.ProductName, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

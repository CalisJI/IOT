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
using DevExpress.Xpf.Grid;
using DevExpress.Mvvm.UI.Interactivity;

namespace WPF_TEST.View
{
    /// <summary>
    /// Interaction logic for Frame_Certification_View.xaml
    /// </summary>
    public partial class Frame_Certification_View : UserControl
    {
        public Frame_Certification_View()
        {
            InitializeComponent();
        }
    }
    public class CommitEditingOnCellValueChanged : Behavior<GridViewBase>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.CellValueChanged += AssociatedObject_CellValueChanged;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.CellValueChanged -= AssociatedObject_CellValueChanged;
        }
        void AssociatedObject_CellValueChanged(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            var view = (DataViewBase)sender;
            view.CommitEditing();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WPF_TEST.ViewModel;

namespace WPF_TEST.View
{
    /// <summary>
    /// Interaction logic for ModbusScreenView.xaml
    /// </summary>
    public partial class ModbusScreenView : UserControl
    {
        ModbusViewModel ModbusViewModel;
        DispatcherTimer rfs = new DispatcherTimer(); 
        public ModbusScreenView()
        {
            InitializeComponent();
            rfs.Interval = new TimeSpan(0, 0, 1);
            rfs.Tick += Rfs_Tick;
            rfs.Start();
           
        }

        private void Rfs_Tick(object sender, EventArgs e)
        {
            Dispatcher.CurrentDispatcher.Invoke(delegate 
            {
                PLCInfor.Items.Refresh();
            });
           
        }

        ObservableCollection<ModbusDevice> ModbusDevice = new ObservableCollection<ModbusDevice>();
        public void Edit_element()
        {
           
        }

        private void Home_button_Click(object sender, RoutedEventArgs e)
        {
            ButtonAutomationPeer peer = new ButtonAutomationPeer(update_btn);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    public class DynamicBindingListView
    {

        public static bool GetGenerateColumnsGridView(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            return (bool)element.GetValue(GenerateColumnsGridViewProperty);
        }

        public static void SetGenerateColumnsGridView(DependencyObject element, bool value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            element.SetValue(GenerateColumnsGridViewProperty, value);
        }


        public static readonly DependencyProperty GenerateColumnsGridViewProperty = DependencyProperty.RegisterAttached("GenerateColumnsGridView", typeof(bool?), typeof(DynamicBindingListView), new FrameworkPropertyMetadata(null, thePropChanged));


        public static string GetDateFormatString(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            return (string)element.GetValue(DateFormatStringProperty);
        }

        public static void SetDateFormatString(DependencyObject element, string value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            element.SetValue(DateFormatStringProperty, value);
        }


        public static readonly DependencyProperty DateFormatStringProperty = DependencyProperty.RegisterAttached("DateFormatString", typeof(string), typeof(DynamicBindingListView), new FrameworkPropertyMetadata(null));
        public static void thePropChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ListView lv = (ListView)obj;
            DependencyPropertyDescriptor descriptor = DependencyPropertyDescriptor.FromProperty(ListView.ItemsSourceProperty, typeof(ListView));
            descriptor.AddValueChanged(lv, new EventHandler(ItemsSourceChanged));
        }

        private static void ItemsSourceChanged(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            IEnumerable its = lv.ItemsSource;
            IEnumerator itsEnumerator = its.GetEnumerator();
            bool hasItems = itsEnumerator.MoveNext();
            if (hasItems)
            {
                SetUpTheColumns(lv, itsEnumerator.Current);
            }
        }

        private static void SetUpTheColumns(ListView theListView, object firstObject)
        {
            PropertyInfo[] theClassProperties = firstObject.GetType().GetProperties();
            GridView gv = (GridView)theListView.View;
            foreach (PropertyInfo pi in theClassProperties)
            {
                string columnName = pi.Name;
                GridViewColumn grv = new GridViewColumn { Header = columnName };

                if (object.ReferenceEquals(pi.PropertyType, typeof(DateTime)))
                {
                    Binding bnd = new Binding(columnName);
                    string formatString = (string)theListView.GetValue(DateFormatStringProperty);
                    if (formatString != string.Empty)
                    {
                        bnd.StringFormat = formatString;
                    }
                    BindingOperations.SetBinding(grv, TextBlock.TextProperty, bnd);
                    grv.DisplayMemberBinding = bnd;
                }
                else
                {
                    Binding bnd = new Binding(columnName);
                    BindingOperations.SetBinding(grv, TextBlock.TextProperty, bnd);
                    grv.DisplayMemberBinding = bnd;
                }
                gv.Columns.Add(grv);
            }
        }

    }
}

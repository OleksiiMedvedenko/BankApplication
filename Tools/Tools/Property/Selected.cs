using Prism.Interactivity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace PrehPL.Tools.Property
{
    public static class Selected
    {
        private static readonly DependencyProperty SelectedCommandBehaviorProperty = DependencyProperty.RegisterAttached(
            "SelectedCommandBehavior",
            typeof(SelectorSelectedCommandBehavior),
            typeof(Selected),
            null);

        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
            "Command",
            typeof(ICommand),
            typeof(Selected),
            new PropertyMetadata(OnSetCommandCallback));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only works for selector")]
        public static void SetCommand(Selector selector, ICommand command)
        {
            selector.SetValue(CommandProperty, command);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only works for selector")]
        public static ICommand GetCommand(Selector selector)
        {
            return selector.GetValue(CommandProperty) as ICommand;
        }

        private static void OnSetCommandCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            Selector selector = dependencyObject as Selector;
            if (selector != null)
            {
                GetOrCreateBehavior(selector).Command = e.NewValue as ICommand;
            }
        }

        private static SelectorSelectedCommandBehavior GetOrCreateBehavior(Selector selector)
        {
            SelectorSelectedCommandBehavior behavior = selector.GetValue(SelectedCommandBehaviorProperty) as SelectorSelectedCommandBehavior;
            if (behavior == null)
            {
                behavior = new SelectorSelectedCommandBehavior(selector);
                selector.SetValue(SelectedCommandBehaviorProperty, behavior);
            }
            return behavior;
        }
    }

    public class SelectorSelectedCommandBehavior : CommandBehaviorBase<Selector>
    {
        public SelectorSelectedCommandBehavior(Selector selectableObject)
            : base(selectableObject)
        {
            selectableObject.SelectionChanged += OnSelectionChanged;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommandParameter = TargetObject.SelectedItem;
            ExecuteCommand(TargetObject.SelectedItem);
        }
    }
}

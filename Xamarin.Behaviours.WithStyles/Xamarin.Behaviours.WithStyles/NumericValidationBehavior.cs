using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Xamarin.Behaviours.WithStyles
{
    public class NumericValidationBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty AttachedBehaviorProperty = BindableProperty.CreateAttached("AttachedBehavior", typeof(bool), typeof(NumericValidationBehavior), false, propertyChanged: OnAttachBehaviorChanged);

        public static bool  GetAttachedBehavior(BindableObject view)
        {
            return (bool)view.GetValue(AttachedBehaviorProperty);
        }
        public static void SetAttachedBehavior(BindableObject view,object value)
        {
            view.SetValue(AttachedBehaviorProperty, value);
        }

        static void OnAttachBehaviorChanged(BindableObject view,object oldValue,object newValue)
        {
            var entry = view as Entry;
            if (entry == null)
            {
                return;
            }

            bool attachBehavior = (bool)newValue;
            if (attachBehavior)
            {
                entry.Behaviors.Add(new NumericValidationBehavior());
            }
            else
            {
                var toRemove = entry.Behaviors.FirstOrDefault(b => b is NumericValidationBehavior);
                if (toRemove != null)
                {
                    entry.Behaviors.Remove(toRemove);
                }
            }
        }
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }
        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            double result;
            bool isValid = double.TryParse(args.NewTextValue, out result);
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}

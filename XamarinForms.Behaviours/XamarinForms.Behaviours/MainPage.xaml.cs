﻿using System.ComponentModel;
using Xamarin.Forms;

namespace XamarinForms.Behaviours
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Entry entry = FindByName("entVal") as Entry;
            entry.Behaviors.Add(new NumericValidationBehavior());
        }
    }
}

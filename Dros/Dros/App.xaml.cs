﻿using System;
using Dros.Models;
using Dros.Views;
using Xamarin.Forms;
using System.Linq;

namespace Dros
{
	public partial class App : Application
	{

		public App ()
		{
			InitializeComponent();
            Console.WriteLine(Database.Instance.All<Author>().FirstOrDefault().Name);

            MainPage = new MainPage();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

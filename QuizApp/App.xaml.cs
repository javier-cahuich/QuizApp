﻿using QuizApp;
namespace QuizApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.NewPage1();
        }
    }
}
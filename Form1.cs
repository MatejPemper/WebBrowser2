﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp;
using EasyTabs;


namespace WebBrowserCef
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitChromium();
        }

        public ChromiumWebBrowser c;

        public void InitChromium()
        {
            Cef.Initialize(new CefSettings());
            c = new ChromiumWebBrowser("https://www.google.com");
            c.AddressChanged += C_AddressChanged;
            c.TitleChanged += C_TitleChanged;
            this.panel1.Controls.Add(c);
            CheckForIllegalCrossThreadCalls = false;

        }

        private void C_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            this.Text = e.Title;
        }

        private void C_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            textBox1.Text = e.Address.ToString();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            c.Back();
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            c.Forward();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            c.Load(textBox1.Text);
        }

        protected TitleBarTabs ParentTabs
        {
            get
            {
                return (ParentForm as TitleBarTabs);
            }
        }

    }
}

using Autofac;
using Medialink.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medialink.WinFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            labelResult.Text = "";
            Refresh();
        }

        private enum Operation
        {
            Add,
            Multiply,
            Divide
        };





        // Butttons 

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int? sum = GetResult(Operation.Add);

                labelResult.Text = sum.ToString();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor.Current = Cursors.Default;
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int? product = GetResult(Operation.Multiply);

                labelResult.Text = product.ToString();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor.Current = Cursors.Default;
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int? quotient = GetResult(Operation.Divide);

                labelResult.Text = quotient.ToString();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor.Current = Cursors.Default;
        }





        // Helpers

        private (int, int) GetIntegers()
        {
            try
            {
                int a = Convert.ToInt32(textBoxIntA.Text);
                int b = Convert.ToInt32(textBoxIntB.Text);

                return (a, b);
            }
            catch(Exception)
            {
                throw new Exception("Invalid Inputs!");
            }
        }

        private int? GetResult(Operation operation)
        {
            try
            {
                var container = ContainerConfig.Configure();

                using (var scope = container.BeginLifetimeScope())
                {
                    var client = scope.Resolve<IMathWebClient>();


                    int a = GetIntegers().Item1;
                    int b = GetIntegers().Item2;

                    switch (operation)
                    {
                        case Operation.Add:
                            return client.Add(a, b);

                        case Operation.Multiply:
                            return client.Multiply(a, b);

                        case Operation.Divide:
                            return client.Divide(a, b);

                        default:
                            return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

       
    }
}

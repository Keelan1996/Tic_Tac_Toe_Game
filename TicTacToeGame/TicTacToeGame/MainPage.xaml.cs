using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TicTacToeGame
{
    public partial class MainPage : ContentPage
    {
        // global variables
        bool _IsXTurn;
        public MainPage()
        {
            InitializeComponent();

            InitialiseBoard();
            _IsXTurn = true;
            LblStatus.Text = "X to move!";
        }



        private void InitialiseBoard()
        {
            // add the labels set all to " ", get the board ready to go for the user
            Label label;
            int iRow, iCol;
            TapGestureRecognizer tapGestureRecognizer; // null place holder


            #region setting up the tap gesture 

            // instantitate the object
            //< TapGestureRecognizer Tapped = "TapGestureRecognizer_Tapped" NumberOfTapsRequired = "1" />
            tapGestureRecognizer = new TapGestureRecognizer();
            //tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped1;
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
            tapGestureRecognizer.NumberOfTapsRequired = 1;
            #endregion

            // loop this part to get all labels on grid- two embeded


            for(iRow=0;iRow < 3; iRow++ )
            {
                for(iCol = 0; iCol < 3; iCol++)
                {

                    #region setting up one label on grid
                    // instantitate label
                    label = new Label();

                    //< Label x: Name = "LblR0C2" BackgroundColor = "blue"
                    //   Text = "X" FontSize = "Large"
                    //  Grid.Row = "0" Grid.Column = "2"
                    //  HorizontalTextAlignment = "Center"  VerticalTextAlignment = "Center" >
                    label.BackgroundColor = Color.Blue;
                    label.Text = iRow.ToString() + "," + iCol.ToString();
                    //label.Text = "";
                    label.FontSize = Device.GetNamedSize(NamedSize.Large, label);
                    label.SetValue(Grid.RowProperty, iRow);
                    label.SetValue(Grid.ColumnProperty, iCol);
                    label.HorizontalTextAlignment = TextAlignment.Center;
                    label.VerticalTextAlignment = TextAlignment.Center;
                    label.GestureRecognizers.Add(tapGestureRecognizer);



                    label.StyleId = "Lb1R" + iRow.ToString() +
                        "C" + iCol.ToString(); // use this to find the label in tapped event handler
                                               // have a label in space
                                               // need to put label on the grid

                    GrdGame.Children.Add(label);
                    #endregion
                
                }// end for iCol = 0
            }// end for iRow=0





        }
            private void TapGestureRecognizer_Tapped1(object sender, EventArgs e)
          {
            // use the stylied  to find the label just added
            foreach (var item in GrdGame.Children)
            {
                if (item.StyleId == "LblR2C0")
                {
                    ((Label)item).Text = "X";
                }

            }
          }

            private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
            {
            // using x:name
            // object type is a base class for all objects - label has base clase of object
            // always need to cast the sender to the type i need
            //LblR0C2.BackgroundColor = Color.Yellow;

            Label l = (Label)sender;
           // current.BackgroundColor = Color.Yellow;
           if(l.Text == "X" || l.Text == "O")
            {
                LblStatus.Text = "illegal move";
                return;
            }

            // decide whose turn it is
            // create a boolean value which shows whos turn global
            switch (_IsXTurn) // two values true and false
            {
                case true:
                    {
                        l.Text = "X";
                        l.BackgroundColor = Color.Yellow;
                        _IsXTurn = false;
                        LblStatus.Text = "O to move";
                        break;
                    }
                case false:
                    {
                        l.Text = "O";
                        l.BackgroundColor = Color.Green;
                        _IsXTurn = true;
                        LblStatus.Text = "X to move";
                        break;
                    }
                
            }

            }

        private void BtnReset_Clicked(object sender, EventArgs e)
        {
            // reset the text on each label to ""
            foreach (var item in GrdGame.Children)
            {
                ((Label)item).Text = "";
                ((Label)item).BackgroundColor = Color.Blue;
            }

            // set bool to say it is x turn
            _IsXTurn = true;

            // update status
            LblStatus.Text = "X to move!";
        }
    }
}

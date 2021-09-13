using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DealOrNoDeal.View.Dialogs
{
    /// <summary>
    /// Asks the user to play again
    ///
    /// Author: Alex DeCesare
    /// Version: 10-September-2021
    /// </summary>
    public sealed partial class AskUserToPlayAgain
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AskUserToPlayAgain" /> class.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        public AskUserToPlayAgain()
        {
            this.InitializeComponent();
        }

        private async void ContentDialog_YesButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            await CoreApplication.RequestRestartAsync("");
        }

        private void ContentDialog_NoButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            CoreApplication.Exit();
        }

    }
}
